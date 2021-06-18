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
    public class SubjectCategoryController : BaseController
    {
        public ActionResult Index(BaseViewModel<SubjectCategoryVM> vm)
        {
            vm.SetList(db.SubjectCategories.AsQueryable(), "Code");
            return View(vm);
        }
        public ActionResult Create()
        {
            var category = new SubjectCategoryVM();

            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubjectCategoryVM category)
        {
            try
            {
                var exName = db.SubjectCategories.Where(e => e.Code.ToLower().Trim() == category.Code.ToLower().Trim()).FirstOrDefault();

                if (exName != null)
                { ModelState.AddModelError("Code", "Category Code Already Exists."); }

                if (ModelState.IsValid)
                {
                    category.CreatedBy = this.GetCurrUser();
                    category.CreatedDate = DateTime.Now;
                    db.SubjectCategories.Add(category.GetEntity());
                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Subject category created successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(category);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var obj = db.SubjectCategories.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(new SubjectCategoryVM(obj));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var obj = db.SubjectCategories.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(new SubjectCategoryVM(obj));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubjectCategoryVM category)
        {
            byte[] curRowVersion = null;
            try
            {
                var exName = db.SubjectCategories.Where(e => e.Id != category.Id && e.Code.ToLower().Trim() == category.Code.ToLower().Trim()).FirstOrDefault();

                if (exName != null)
                { ModelState.AddModelError("Code", "Category Code Already Exists."); }

                if (ModelState.IsValid)
                {
                    var obj = db.SubjectCategories.Find(category.Id);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = category.GetEntity();
                    modObj.CopyContent(obj, "Code,Description,IsBasket");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.Entry(obj).OriginalValues["RowVersion"] = category.RowVersion;
                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Subject category modified successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.ShowConcurrencyErrors(ex);
                category.RowVersion = curRowVersion;
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(SubjectCategoryVM category)
        {
            try
            {
                var obj = db.SubjectCategories.Find(category.Id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }
                db.Detach(obj);

                db.Entry(category.GetEntity()).State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Subject category deleted successfully.");
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
            return RedirectToAction("Details", new { id = category.Id });
        }
    }
}