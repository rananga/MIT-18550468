using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Areas.Academic.Models;
using StudentInformationSystem.Areas.Base;
using StudentInformationSystem.Common;
using StudentInformationSystem.Data;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentInformationSystem.Areas.Academic.Controllers
{
    public class GradeSubjectController : BaseController
    {
        public ActionResult Index(BaseViewModel<GradeSubjectVM> vm)
        {
            vm.SetList(db.GradeSubjects.AsQueryable(), "GradeId");
            return View(vm);
        }
        public ActionResult Create()
        {
            var grade = new GradeSubjectVM();

            return View(grade);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GradeSubjectVM grade)
        {
            try
            {
                var exClass = db.GradeSubjects.Where(e => e.GradeId == grade.GradeId && e.SubjectId == grade.SubjectId).FirstOrDefault();
                if (exClass != null)
                { ModelState.AddModelError("", "Subject already exists for the grade."); }

                if (ModelState.IsValid)
                {
                    grade.CreatedBy = this.GetCurrUser();
                    grade.CreatedDate = DateTime.Now;
                    db.GradeSubjects.Add(grade.GetEntity());
                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Grade subject created successfully.");
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
            var obj = db.GradeSubjects.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(new GradeSubjectVM(obj));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(GradeSubjectVM grade)
        {
            try
            {
                var obj = db.GradeSubjects.Find(grade.Id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }
                db.Detach(obj);

                db.Entry(grade.GetEntity()).State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Grade subject deleted successfully.");
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
    }
}