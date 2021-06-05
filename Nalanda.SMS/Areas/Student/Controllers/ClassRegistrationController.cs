using Microsoft.EntityFrameworkCore;
using Nalanda.SMS.Data;
using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Areas.Base;
using Nalanda.SMS.Areas.Student.Models;
using Nalanda.SMS.Common;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Nalanda.SMS.Areas.Student.Controllers
{
    public class ClassRegistrationController : BaseController
    {
        // GET: Student/ClassRegistration
        public ActionResult Index(BaseViewModel<ClassStudentVM> vm)
        {
            vm.SetList(db.ClassStudents.AsQueryable(), "StudentName", SortDirection.Descending);
            return View(vm);
        }

        public ActionResult Create()
        {
            var classStudentVm = new ClassStudentVM();
            Session[sskCrtdObj] = classStudentVm;

            return View(classStudentVm);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClStudID,ClassID,StudID,PeriodID,PeriodStartDate,StudentName,School,PeriodEndDate,IsMonitor,PrClID,PeriodID,PeriodFrom,PeriodTo")] ClassStudentVM classStudentVM)
        {
            try
            {
                if (classStudentVM.StudID == 0)
                { ModelState.AddModelError("StudID", "Student should be selected."); }

                if (classStudentVM.PeriodID == 0)
                { ModelState.AddModelError("PeriodID", "Period should be selected."); }

                if (classStudentVM.PrClID == 0)
                { ModelState.AddModelError("PrClID", "Class should be selected."); }

                int ExistStudent = 0; //db.ClassStudents.Where(x => x.StudentId == classStudentVM.StudID && x.PromotionClass.PeriodSetup.PeriodId == classStudentVM.PeriodID).Count();
                if (ExistStudent != 0)
                { ModelState.AddModelError("", "Student Already Registered for this Academic Period"); }


                if (ModelState.IsValid)
                {
                    classStudentVM.CreatedBy = this.GetCurrUser();
                    classStudentVM.CreatedDate = DateTime.Now;
                    var newObj = db.ClassStudents.Add(classStudentVM.GetEntity()).Entity;
                    db.SaveChanges();

                    AddAlert(SMS.Common.AlertStyles.success, "Student Registered successfully.");
                    return RedirectToAction("Details", new { id = newObj.Id });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            return View(classStudentVM);
        }


        public ActionResult GetStudentDetails(int? StudID)
        {
            string StName = null;
            string School = null;

            using (dbNalandaContext dbctx = new dbNalandaContext())
            {
                var StdDet = dbctx.Students.Find(StudID);
                if (StdDet != null)
                {
                    StName = StdDet.Title+". "+StdDet.Initials+" "+StdDet.Lname;
                    //School = StdDet.School.Trim();
                }
            }
            return Json(new { StName, School }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetPeriodDetails(int? PeriodID)
        {
            string periodTo = null;
            string periodFrom = null;

            using (dbNalandaContext dbctx = new dbNalandaContext())
            {
                var PeriodDet = dbctx.PeriodSetups.Find(PeriodID);
                if (PeriodDet != null)
                {
                    periodFrom = PeriodDet.PeriodStartDate.ToString("yyyy-MM-dd");
                    periodTo = PeriodDet.PeriodEndDate.ToString("yyyy-MM-dd");
                
                }
            }
            return Json(new { periodFrom,periodTo }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassStudent classStudent = db.ClassStudents.Find(id);
            if (classStudent == null)
            {
                return HttpNotFound();
            }
            
            ClassStudentVM VM = new ClassStudentVM(classStudent);
            return View(VM);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassStudent classStudent = db.ClassStudents.Find(id);
            if (classStudent == null)
            {
                return HttpNotFound();
            }
            var period = db.PromotionClasses.Where(x => x.PrClId == classStudent.Id).FirstOrDefault();
            var obj = new ClassStudentVM(classStudent) { PeriodID = period.PeriodId };
            Session[sskCrtdObj] = obj;
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClStudID,ClassID,StudID,PeriodID,PeriodStartDate,StudentName,School,PeriodEndDate,IsMonitor,PrClID,PeriodID,PeriodTo")] ClassStudentVM classStudentVM)
        {
            byte[] curRowVersion = null;
            try
            {
                if (classStudentVM.StudID == 0)
                { ModelState.AddModelError("StudID", "Student should be selected."); }

                if (classStudentVM.PeriodID == 0)
                { ModelState.AddModelError("PeriodID", "Period should be selected."); }

                if (classStudentVM.PrClID == 0)
                { ModelState.AddModelError("StudID", "Promotion Period should be selected."); }

                if (ModelState.IsValid)
                {
                    var obj = db.ClassStudents.Find(classStudentVM.ClStudID);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = classStudentVM.GetEntity();
                    var promotionClasses = db.PromotionClasses.Find(classStudentVM.PrClID);
                    var periodsetup = db.PeriodSetups.Find(promotionClasses.PeriodId);
                    //obj.PeriodStartDate = periodsetup.PeriodStartDate;
                    //obj.PeriodEndDate = periodsetup.PeriodEndDate;
                    modObj.CopyContent(obj, "PrClID,IsMonitor");
                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;
                    db.SaveChanges();

                    AddAlert(SMS.Common.AlertStyles.success, "Class registration modified successfully.");
                    return RedirectToAction("Details", new { id = modObj.Id });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            return View(classStudentVM);
        }
    }
}