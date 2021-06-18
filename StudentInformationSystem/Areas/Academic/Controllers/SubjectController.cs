using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Areas.Academic.Models;
using StudentInformationSystem.Areas.Base;
using StudentInformationSystem.Common;
using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Linq;

namespace StudentInformationSystem.Areas.Academic.Controllers
{
    public class SubjectController : BaseController
    {
        public ActionResult Index(BaseViewModel<SubjectVM> vm)
        {
            vm.SetList(db.Subjects.AsQueryable(), "Code");
            return View(vm);
        }
        public ActionResult Create()
        {
            var subject = new SubjectVM();

            return View(subject);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubjectVM subject)
        {
            try
            {
                var exName = db.Subjects.Where(e => e.SectionId == subject.SectionId && e.SubjectCategoryId == subject.SubjectCategoryId && e.Medium == subject.Medium && e.Code.ToLower().Trim() == subject.Code.ToLower().Trim()).FirstOrDefault();
                if (exName != null)
                { ModelState.AddModelError("", "Subject Code Already Exists for the selected Section, Category & Medium."); }

                exName = db.Subjects.Where(e => e.SectionId == subject.SectionId && e.SubjectCategoryId == subject.SubjectCategoryId && e.Medium == subject.Medium && e.Number == subject.Number).FirstOrDefault();
                if (exName != null)
                { ModelState.AddModelError("", "Subject Number Already Exists for the selected Section, Category & Medium."); }

                if (ModelState.IsValid)
                {
                    subject.CreatedBy = this.GetCurrUser();
                    subject.CreatedDate = DateTime.Now;
                    db.Subjects.Add(subject.GetEntity());
                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Subject Information created successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(subject);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject clibs = db.Subjects.Find(id);
            if (clibs == null)
            {
                return HttpNotFound();
            }
            return View(new SubjectVM(clibs));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(new SubjectVM(subject));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubjectVM subject)
        {
            byte[] curRowVersion = null;
            try
            {
                var exName = db.Subjects.Where(e => e.Id != subject.Id && e.SectionId == subject.SectionId && e.SubjectCategoryId == subject.SubjectCategoryId && e.Medium == subject.Medium && e.Code.ToLower().Trim() == subject.Code.ToLower().Trim()).FirstOrDefault();
                if (exName != null)
                { ModelState.AddModelError("", "Subject Code Already Exists for the selected Section, Category & Medium."); }

                exName = db.Subjects.Where(e => e.Id != subject.Id && e.SectionId == subject.SectionId && e.SubjectCategoryId == subject.SubjectCategoryId && e.Medium == subject.Medium && e.Number == subject.Number).FirstOrDefault();
                if (exName != null)
                { ModelState.AddModelError("", "Subject Number Already Exists for the selected Section, Category & Medium."); }

                if (ModelState.IsValid)
                {
                    var obj = db.Subjects.Find(subject.Id);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = subject.GetEntity();
                    modObj.CopyContent(obj, "SectionId,SubjectCategoryId,Code,Number,Medium,Description");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.Entry(obj).OriginalValues["RowVersion"] = subject.RowVersion;
                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Subject Information modified successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.ShowConcurrencyErrors(ex);
                subject.RowVersion = curRowVersion;
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(subject);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(SubjectVM subject)
        {
            try
            {
                var obj = db.Subjects.Find(subject.Id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }
                db.Detach(obj);

                db.Entry(subject.GetEntity()).State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Subject Information deleted successfully.");
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
            return RedirectToAction("Details", new { id = subject.Id });
        }
    }
}