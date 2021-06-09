using Microsoft.EntityFrameworkCore;
using Nalanda.SMS.Data;
using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Areas.Admin.Models;
using Nalanda.SMS.Areas.Base;
using Nalanda.SMS.Common;
using System;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Nalanda.SMS.Areas.Admin.Controllers
{
    public class GradeController : BaseController
    {
        public ActionResult Index(BaseViewModel<GradeVM> vm)
        {
            vm.SetList(db.Grades.AsQueryable(), "GradeId");
            return View(vm);
        }
        public ActionResult Create()
        {
            var grade = new GradeVM() { GradeId =  Grades.Grade1 };

            return View(grade);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GradeVM grade)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    grade.CreatedBy = this.GetCurrUser();
                    grade.CreatedDate = DateTime.Now;
                    db.Grades.Add(grade.GetEntity());
                    db.SaveChanges();

                    AddAlert(SMS.Common.AlertStyles.success, "Grade Information created successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            return View(grade);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grade grade = db.Grades.Find(id);
            if (grade == null)
            {
                return HttpNotFound();
            }
            return View(new GradeVM(grade));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grade grade = db.Grades.Find(id);
            if (grade == null)
            {
                return HttpNotFound();
            }
            return View(new GradeVM(grade));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GradeVM grade)
        {
            byte[] curRowVersion = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = db.Grades.Find(grade.Id);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = grade.GetEntity();
                    modObj.CopyContent(obj, "GradeId,HeadTeacherId");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.Entry(obj).OriginalValues["RowVersion"] = grade.RowVersion;
                    db.SaveChanges();

                    AddAlert(SMS.Common.AlertStyles.success, "Grade Information modified successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.ShowConcurrencyErrors(ex);
                grade.RowVersion = curRowVersion;
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            return View(grade);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(GradeVM grade)
        {
            try
            {
                var obj = db.Grades.Find(grade.Id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }
                db.Detach(obj);

                db.Entry(grade.GetEntity()).State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(SMS.Common.AlertStyles.success, "Grade Information deleted successfully.");
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
                AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message);
            }
            return RedirectToAction("Details", new { id = grade.Id });
        }
    }
}