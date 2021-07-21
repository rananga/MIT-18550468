using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Areas.Base;
using StudentInformationSystem.Areas.Online.Models;
using StudentInformationSystem.Common;
using StudentInformationSystem.Data;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentInformationSystem.Areas.Online.Controllers
{
    public class OnlineTimeTableController : BaseController
    {
        public ActionResult Index(DateTime? fromDate, DateTime? toDate, int? gradeId, int? staffId)
        {
            OnlineTimeTableVM vm;
            if (Session[sskCrtdObj] is OnlineTimeTableVM)
                vm= (OnlineTimeTableVM)Session[sskCrtdObj];
            else
                vm = new OnlineTimeTableVM() { FromDate = fromDate ?? DateTime.Today.AddDays(-21), ToDate = toDate ?? DateTime.Today.AddDays(7), GradeId = gradeId ?? 1, StaffId = staffId };
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
                if (ModelState.IsValid)
                {
                    vm.CreatedBy = this.GetCurrUser();
                    vm.CreatedDate = DateTime.Now;
                    db.OnlineClasses.Add(vm.GetEntity());

                    db.SaveChanges();

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
    }
}