using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Areas.Base;
using StudentInformationSystem.Areas.Online.Models;
using StudentInformationSystem.Common;
using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Sync;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentInformationSystem.Areas.Online.Controllers
{
    [ExtendedAuthorize(Roles = RoleConstants.AdminUser)]
    public class OnlineTimeTableController : BaseController
    {
        public ActionResult Index(DateTime? fromDate, DateTime? toDate, int? gradeId, int? staffId)
        {
            OnlineTimeTableVM vm;
            if (Session[sskCrtdObj] is OnlineTimeTableVM && fromDate == null && toDate == null && gradeId == null)
                vm = (OnlineTimeTableVM)Session[sskCrtdObj];
            else
                vm = new OnlineTimeTableVM() { FromDate = fromDate ?? DateTime.Today.AddDays(-21), ToDate = toDate ?? DateTime.Today.AddDays(7), GradeId = gradeId ?? 1, StaffId = staffId };

            Session[sskCrtdObj] = vm;
            return View(vm);
        }

        [AllowAnonymous]
        public ActionResult TimeTableIndex(DateTime FromDate, DateTime ToDate, int GradeId, int? StaffId)
        {
            var qry = db.OnlineClasses.Where(x => x.Date >= FromDate && x.Date <= ToDate);
            if (StaffId == null)
                qry = qry.Where(x => x.OnlineClassRoom.GradeId == GradeId);
            else
                qry = qry.Where(x => x.OCR_TeacherId == StaffId);

            var lst = qry.ToList().Select(x => new OnlineClassVM(x)).ToList();
            return PartialView("_TimeTableIndex", lst);
        }

        public ActionResult TimeTableCreate()
        {
            var vm = new OnlineClassVM() { Year = DateTime.Now.Year, Date = DateTime.Now.AddDays(1) };
            return PartialView("_TimeTableCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TimeTableCreate(OnlineClassVM vm)
        {
            try
            {
                if (db.OnlineClasses.Where(x => x.OnlineClassRoom.GradeId == vm.GradeId && x.Date == vm.Date && x.OCR_Id == vm.OCR_Id &&
                    ((x.FromTime <= vm.FromTime && x.ToTime >= vm.FromTime) ||
                    (x.FromTime >= vm.FromTime && x.ToTime <= vm.FromTime))).Any())
                {
                    ModelState.AddModelError("", "Class already exists.");
                }

                if (db.OnlineClasses.Where(x => x.OnlineClassRoom.GradeId != vm.GradeId && x.OCR_TeacherId == vm.OCR_TeacherId && x.Date == vm.Date &&
                    ((x.FromTime <= vm.FromTime && x.ToTime >= vm.FromTime) ||
                    (x.FromTime >= vm.FromTime && x.ToTime <= vm.FromTime))).Any())
                {
                    ModelState.AddModelError("", "A class already exist for this teacher in a different grade.");
                }


                if (ModelState.IsValid)
                {
                    vm.CreatedBy = this.GetCurrUser();
                    vm.CreatedDate = DateTime.Now;
                    var ent = db.OnlineClasses.Add(vm.GetEntity()).Entity;

                    db.SaveChanges();

                    SyncClass(ent);

                    AddAlert(AlertStyles.success, "Online class created successfully.");
                    var svm = (OnlineTimeTableVM)Session[sskCrtdObj];
                    string url = Url.Action("Index", new { fromDate = svm?.FromDate, ToDate = svm?.ToDate, GradeId = svm?.GradeId, staffId = svm?.StaffId });
                    return Json(new { success = true, url = url });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return PartialView("_TimeTableCreate", vm);
        }

        public ActionResult TimeTableEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var obj = db.OnlineClasses.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            var vm = new OnlineClassVM(obj);
            return PartialView("_TimeTableEdit", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TimeTableEdit(OnlineClassVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = db.OnlineClasses.Find(vm.Id);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    var modObj = vm.GetEntity();
                    modObj.CopyContent(obj, "Date,FromTime,ToTime,OCR_Id,OCR_TeacherId,Subject,Lesson,RepeatPattern");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.Entry(obj).OriginalValues["RowVersion"] = vm.RowVersion;

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Online class modified successfully.");
                    var svm = (OnlineTimeTableVM)Session[sskCrtdObj];
                    string url = Url.Action("Index", new { fromDate = svm?.FromDate, ToDate = svm?.ToDate, GradeId = svm?.GradeId, staffId = svm?.StaffId });
                    return Json(new { success = true, url = url });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return PartialView("_TimeTableEdit", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TimeTableDelete(OnlineClassVM vm)
        {
            try
            {
                var obj = db.OnlineClasses.Find(vm.Id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }

                var entry = db.Entry(obj);
                entry.State = EntityState.Unchanged;
                entry.Collection(x => x.OC_Meetings).Load();
                foreach (var meet in entry.Entity.OC_Meetings)
                {
                    db.OC_MeetingAttendees.RemoveRange(meet.OC_MeetingAttendees);
                }
                db.OC_Meetings.RemoveRange(entry.Entity.OC_Meetings);
                entry.State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Online class deleted successfully.");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.ShowConcurrencyErrors(ex, true);
            }
            catch (Exception ex)
            {
                AddAlert(AlertStyles.danger, ex.GetInnerException().Message);
            }
            return RedirectToAction("Index");
        }

        private void SyncClass(OnlineClass cls)
        {
            cls = db.OnlineClasses.Include(x => x.OCR_Teacher).Include(x => x.OnlineClassRoom).Include(x => x.OC_Meetings).Where(x => x.Id == cls.Id).FirstOrDefault();
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
                        TimesVisited = x.Count(),
                        CreatedBy = this.GetCurrUser(),
                        CreatedDate = DateTime.Now
                    }).ToList();

                if (newMeetAttendees.Count / (double)studs.Count < 0.1)
                    continue;

                var newMeet = db.OC_Meetings.Where(x => x.OC_Id == cls.Id && x.MeetingCode == meet).FirstOrDefault();
                var isNew = false;
                if (newMeet == null || db.Entry(newMeet).State == EntityState.Deleted)
                {
                    newMeet = new OC_Meeting() { OC_Id = cls.Id, MeetingCode = meet, CreatedBy = this.GetCurrUser(), CreatedDate = DateTime.Now };
                    isNew = true;
                }

                foreach (var attendee in newMeetAttendees)
                {
                    newMeet.OC_MeetingAttendees.Add(attendee);
                }

                if (isNew)
                    cls.OC_Meetings.Add(newMeet);

                db.SaveChanges();
            }
        }
    }
}