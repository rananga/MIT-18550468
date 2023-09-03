using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Areas.Base;
using StudentInformationSystem.Areas.Student.Models;
using StudentInformationSystem.Common;
using StudentInformationSystem.Data;
using System;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentInformationSystem.Areas.Student.Controllers
{
    public class TransferStudentController : BaseController
    {
        public ActionResult Index(BaseViewModel<StudentTransferVM> vm)
        {
            vm.SetList(db.StudentTransfers.AsQueryable(), "AdmissionNo");
            return View(vm);
        }

        public ActionResult Create()
        {
            var grade = new StudentTransferVM() { Year = DateTime.Now.Year };

            return View(grade);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentTransferVM grade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    grade.CreatedBy = this.GetCurrUser();
                    grade.CreatedDate = DateTime.Now;
                    db.StudentTransfers.Add(grade.GetEntity());
                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Student transfered successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(grade);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ent = db.StudentTransfers.Find(id);
            if (ent == null)
            {
                return HttpNotFound();
            }
            return View(new StudentTransferVM(ent));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ent = db.StudentTransfers.Find(id);
            if (ent == null)
            {
                return HttpNotFound();
            }
            return View(new StudentTransferVM(ent));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentTransferVM vm)
        {
            byte[] curRowVersion = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = db.StudentTransfers.Find(vm.Id);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = vm.GetEntity();
                    modObj.CopyContent(obj, "Reason");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.Entry(obj).OriginalValues["RowVersion"] = vm.RowVersion;
                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Student transfer modified successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.ShowConcurrencyErrors(ex);
                vm.RowVersion = curRowVersion;
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(StudentTransferVM grade)
        {
            try
            {
                var obj = db.StudentTransfers.Find(grade.Id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }
                db.Detach(obj);

                db.Entry(grade.GetEntity()).State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Student transfer reverted successfully.");
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.ShowConcurrencyErrors(ex, true);
                if (ex.Message == "")
                { return RedirectToAction("Index"); }
            }
            catch (Exception ex)
            {
                AddAlert(AlertStyles.danger, ex.GetInnerException().Message);
            }
            return RedirectToAction("Details", new { id = grade.Id });
        }

        public ActionResult GetStudentLastClassInfo(int year, int studentId)
        {
            var lastclass = db.Students.Find(studentId).LastClass;

            string errmsg;

            if (lastclass == null)
                errmsg = "Student not yet admitted to a class.";
            else if (lastclass.Year != year)
                errmsg = "Student not assigned to a class in the selected year.";
            else
            {
                return Json(new { lastclass.Id, lastclass.GradeClass.Code }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { errmsg }, JsonRequestBehavior.AllowGet);
        }
    }
}