using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;

namespace StudentInformationSystem.Sync
{
    public static class SyncAttendance
    {
        public static DateTime? TriggeredTime = null;

        [FunctionName("SyncAttendance")]
        public static void Run([TimerTrigger("0 */5 * * * *", RunOnStartup = true)] TimerInfo myTimer, ILogger log)
        {
            if (TriggeredTime == null || TriggeredTime < DateTime.Now.AddMinutes(-5))
                RunIt(log, new dbNalandaContext());
        }

        public static void RunIt(ILogger log, dbNalandaContext db)
        {
            try
            {
                TriggeredTime = DateTime.Now;
                Common.LogIt(log, db, LogSevierity.Info, $"Courses sync started at: {DateTime.Now}");
                ProcessAttendanceSync(log, db);
                Common.LogIt(log, db, LogSevierity.Info, $"Courses sync successfully completed at: {DateTime.Now}");
            }
            catch (Exception ex)
            {
                var lst = new List<string>() { ex.Message };
                var lstST = new List<string>() { ex.StackTrace };

                Exception inner = ex.InnerException;
                while (inner != null)
                {
                    lst.Add(inner.Message);
                    lstST.Add(inner.StackTrace);
                    inner = inner.InnerException;
                }

                lst.ForEach((x) => Common.LogIt(log, db, LogSevierity.Error, x));
                lstST.ForEach((x) => Common.LogIt(log, db, LogSevierity.Error, x));
                Common.LogIt(log, db, LogSevierity.Error, $"Courses sync ended in error at : {DateTime.Now}");
            }
            finally
            {
                TriggeredTime = null;
            }
        }

        public static void ProcessAttendanceSync(ILogger log, dbNalandaContext db, bool specifiedDaysOnly = true, int numberOfDaysBack = 5)
        {
            var ft = db.AuditTemp.OrderByDescending(x => x.MeetingDate).Select(x => x.MeetingDate).FirstOrDefault();
            SyncLog(log, db, ft);

            var classes = db.OnlineClasses.Where(x => x.OC_Meetings.Count == 0).ToList();

            var now = DateTime.UtcNow.AddHours(5.5);
            var clsQry = classes.Where(x => x.Date.Add(x.ToTime) < now.AddHours(-2));
            if (specifiedDaysOnly)
                clsQry = clsQry.Where(x => x.Date.Add(x.ToTime) > now.AddDays(numberOfDaysBack * -1));

            classes = clsQry.ToList();

            foreach (var cls in classes)
            {
                SyncClass(log, db, cls);
            }
        }

        public static void SyncLog(ILogger log, dbNalandaContext db, DateTime fromDate)
        {
            var edgeTime = DateTime.Now.AddHours(-1);

            if (fromDate > edgeTime)
                return;

            var ft = fromDate;
            var tt = fromDate;

            do
            {
                ft = tt.AddMinutes(-1);
                tt = tt.AddMinutes(30);

                if (ft >= edgeTime)
                    ft = edgeTime.AddMinutes(-1);
                if (tt > edgeTime)
                    tt = edgeTime;

                var activities = GoogleApiHelper.Instance.GetAuditActivities(ft, tt).OrderBy(x => x.Id.Time.Value).ToList();
                var count = 0;
                var dbTransaction = db.Database.BeginTransaction();

                var meetingCodes = activities.Select(x => x.Events[0].Parameters.Where(y => y.Name == "meeting_code").FirstOrDefault()?.Value).Distinct().ToList();
                var syncedClasses = db.OnlineClasses.Include(x => x.OC_Meetings).ThenInclude(x => x.OC_MeetingAttendees).Where(x => x.OC_Meetings.Any(y => meetingCodes.Contains(y.MeetingCode))).ToList();

                foreach (var cls in syncedClasses)
                {
                    foreach (var clsMeet in cls.OC_Meetings)
                    {
                        db.OC_MeetingAttendees.RemoveRange(clsMeet.OC_MeetingAttendees);
                    }
                    db.OC_Meetings.RemoveRange(cls.OC_Meetings);
                    Common.LogIt(log, db, LogSevierity.Info, $"Online class meeting data cleared for {cls.Id}.");
                }

                try
                {
                    foreach (var activity in activities)
                    {
                        var para = activity.Events[0].Parameters;
                        var tmp = new AuditTemp()
                        {
                            MeetingDate = activity.Id.Time.Value.ToUniversalTime().AddHours(5.5),
                            CustomerId = activity.Id.CustomerId,
                            UniqueQualifier = activity.Id.UniqueQualifier ?? 0,
                            ParticipantEmail = para.Where(x => x.Name == "identifier").FirstOrDefault()?.Value ?? para.Where(x => x.Name == "display_name").FirstOrDefault()?.Value,
                            MeetingCode = para.Where(x => x.Name == "meeting_code").FirstOrDefault()?.Value,
                            OrganizerEmail = para.Where(x => x.Name == "organizer_email").FirstOrDefault()?.Value,
                            Duration = para.Where(x => x.Name == "duration_seconds").FirstOrDefault()?.IntValue,
                            CalendarEventId = para.Where(x => x.Name == "calendar_event_id").FirstOrDefault()?.Value,
                            ConferenceId = para.Where(x => x.Name == "conference_id").FirstOrDefault()?.Value,
                            IsOutSide = para.Where(x => x.Name == "is_external").FirstOrDefault()?.BoolValue ?? true,
                        };

                        if (db.AuditTemp.Where(x => x.MeetingDate == tmp.MeetingDate && x.CustomerId == tmp.CustomerId &&
                            x.ParticipantEmail == tmp.ParticipantEmail && x.UniqueQualifier == tmp.UniqueQualifier).Any())
                            continue;

                        db.AuditTemp.Add(tmp);
                        count++;
                        if (count >= 100)
                        {
                            TriggeredTime = DateTime.Now;
                            Common.LogIt(log, db, LogSevierity.Info, $"{count} activities synced.");
                            db.SaveChanges();
                            dbTransaction.Commit();
                            dbTransaction = db.Database.BeginTransaction();
                            count = 0;
                        }
                    }
                    TriggeredTime = DateTime.Now;
                    Common.LogIt(log, db, LogSevierity.Info, $"{count} activities synced.");
                    db.SaveChanges();
                    dbTransaction.Commit();
                }
                catch (Exception)
                {
                    dbTransaction.Rollback();
                    throw;
                }

            } while (tt < edgeTime);
        }

        public static void SyncClass(ILogger log, dbNalandaContext db, OnlineClass cls)
        {
            var fromTime = cls.Date.Add(cls.FromTime).AddMinutes(-120);
            var toTime = cls.Date.Add(cls.ToTime).AddMinutes(120);

            var filteredAudit = db.AuditTemp.Where(x => x.MeetingDate >= fromTime && x.MeetingDate <= toTime && x.ParticipantEmail == cls.OCR_Teacher.StaffMember.SchoolEmail_Google);
            var meetings = filteredAudit.Select(x => x.MeetingCode).Distinct().ToList();

            if (meetings.Count == 0)
            {
                var teacherEmails = cls.OnlineClassRoom.ClassTeachers.Select(x => x.StaffMember.SchoolEmail_Google).ToList();
                filteredAudit = db.AuditTemp.Where(x => x.MeetingDate >= fromTime && x.MeetingDate <= toTime && teacherEmails.Contains(x.ParticipantEmail));
                meetings = filteredAudit.Select(x => x.MeetingCode).Distinct().ToList();
            }

            foreach (var meet in meetings)
            {
                if (cls.OC_Meetings.Any(x => x.MeetingCode == meet))
                    continue;

                var filteredAuditMeet = db.AuditTemp.Where(x => x.MeetingDate >= fromTime && x.MeetingDate <= toTime && x.MeetingCode == meet);

                var studs = cls.OnlineClassRoom.PhysicalClassRooms.SelectMany(x => x.PhysicalClassRoom.ClassStudents).ToList();
                if (cls.OnlineClassRoom.Subject.SubjectCategory.IsBasket)
                    studs = studs.Where(x => x.Student.StudentBasketSubjects.Any(y => y.SubjectId == cls.OnlineClassRoom.Subject.Id)).ToList();

                var newMeetAttendees = studs
                    .Join(filteredAuditMeet, x => x.Student.SchoolEmail_Google, x => x.ParticipantEmail, (x, y) => new { x.StudentId, y.MeetingCode, y.Duration })
                    .GroupBy(x => new { x.MeetingCode, x.StudentId })
                    .Select(x => new OC_MeetingAttendee()
                    {
                        StudentId = x.Key.StudentId,
                        Duration = x.Sum(y => y.Duration ?? 0),
                        TimesVisited = x.Count()
                    }).ToList();

                if (newMeetAttendees.Count / (double)studs.Count < 0.1)
                    continue;

                var newMeet = db.OC_Meetings.Where(x => x.OC_Id == cls.Id && x.MeetingCode == meet).FirstOrDefault();
                var isNew = false;
                if (newMeet == null || db.Entry(newMeet).State == EntityState.Deleted)
                {
                    newMeet = new OC_Meeting() { OC_Id = cls.Id, MeetingCode = meet };
                    isNew = true;
                }

                foreach (var attendee in newMeetAttendees)
                {
                    newMeet.OC_MeetingAttendees.Add(attendee);
                }

                if (isNew)
                    cls.OC_Meetings.Add(newMeet);

                Common.LogIt(log, db, LogSevierity.Info, $"Online class meeting synced \"{newMeet.MeetingCode}\".");
                db.SaveChanges();
            }
        }
    }
}