using Google.Apis.Classroom.v1.Data;
using Microsoft.Azure.WebJobs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentInformationSystem.Sync
{
    public static class SyncStudents
    {
        public static DateTime? TriggeredTime = null;

        [FunctionName("SyncStudents")]
        public static void Run([TimerTrigger("0 */5 * * * *", RunOnStartup = true)] TimerInfo myTimer, ILogger log)
        {
            if (TriggeredTime == null || TriggeredTime < DateTime.Now.AddMinutes(-5))
                RunIt(log, new dbNalandaContext());
        }

        public static void RunIt(ILogger log, dbNalandaContext db)
        {
            var lst = db.SyncQueue.OrderBy(x => x.QueuedDate).ToList();

            foreach (var item in lst)
            {
                var succeeded = true;
                switch (item.SyncType)
                {
                    case SyncType.CreateCourse:
                        succeeded = CreateCourse(log, db, item);
                        break;
                    case SyncType.DeleteCourse:
                        succeeded = DeleteCourse(log, db, item);
                        break;
                    case SyncType.UpdateCourse:
                        break;
                    case SyncType.CreateStudent:
                        break;
                    case SyncType.ResetPassword:
                        break;
                    case SyncType.CreateTeacher:
                        break;
                    case SyncType.UpdateTeacher:
                        break;
                    default:
                        break;
                }

                if (succeeded)
                {
                    var obj = db.SyncQueue.Find(item.Id);
                    var entry = db.Entry(obj);
                    entry.State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
        }

        public static bool CreateCourse(ILogger log, dbNalandaContext db, SyncQueue item)
        {
            try
            {
                var obj = item.JsonData.DeserializeToDynamic();
                OnlineClassRoom ocr = db.OnlineClassRooms.Find((int)obj.OCR_Id);
                if (ocr == null)
                {
                    Common.LogIt(log, db, LogSevierity.Info, $"Invaid course id or course already deleted.");
                    return true;
                }
                if (!ocr.GoogleClassRoomId.IsBlank())
                {
                    Common.LogIt(log, db, LogSevierity.Info, $"Course already created.");
                    return true;
                }

                var clsDesc = ocr.PhysicalClassRooms.Select(x => x.PhysicalClassRoom.GradeClass.Code).Aggregate((x, y) => x + ", " + y).Replace(".", "");
                var subject = ocr.Subject.Code;
                var sm = ocr.ClassTeachers.FirstOrDefault(x => x.IsOwner).StaffMember;
                var teacher = sm.Title.ToEnumChar() + " " + sm.FullName;

                var owner = db.GradeEmails.Where(x => x.Year == ocr.Year && x.Grade == ocr.GradeId).FirstOrDefault().EmailAddress;

                var crs = new Course()
                {
                    Name = $"{subject} - {clsDesc}",
                    OwnerId = owner,
                    Description = clsDesc,
                    Section = teacher,
                    Room = subject,
                    DescriptionHeading = "Test Description Heading"
                };
                crs = GoogleApiHelper.Instance.CreateCourse(crs);

                ocr.GoogleClassrommLink = crs.AlternateLink;
                ocr.GoogleClassRoomId = crs.Id;
                db.SaveChanges();

                Common.LogIt(log, db, LogSevierity.Info, $"Course {crs.Id} created successfully.");
                return true;
            }
            catch (Exception ex)
            {
                Common.LogIt(log, db, LogSevierity.Info, $"Course creation error : {ex.Message}");
                return false;
            }
        }

        public static bool DeleteCourse(ILogger log, dbNalandaContext db, SyncQueue item)
        {
            try
            {
                var obj = item.JsonData.DeserializeToDynamic();

                var courseId = (string)obj.GoogleCourseId;
                var year = (int)obj.Year;
                var gradeId = (int)obj.GradeId;

                if (courseId == null)
                {
                    Common.LogIt(log, db, LogSevierity.Info, $"Invaid course id or course already deleted.");
                    return true;
                }

                var owner = db.GradeEmails.Where(x => x.Year == year && x.Grade == gradeId).FirstOrDefault().EmailAddress;

                GoogleApiHelper.Instance.DeleteCourse(courseId, owner);

                Common.LogIt(log, db, LogSevierity.Info, $"Course {courseId} deleted successfully.");
                return true;
            }
            catch (Exception ex)
            {
                Common.LogIt(log, db, LogSevierity.Info, $"Course deletion error : {ex.Message}");
                return false;
            }
        }
    }
}