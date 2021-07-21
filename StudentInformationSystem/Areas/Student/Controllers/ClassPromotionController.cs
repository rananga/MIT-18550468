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
    public class ClassPromotionController : BaseController
    {
        public ActionResult Index(BaseViewModel<ClassPromotionVM> vm)
        {
            vm.SetList(db.ClassPromotions.AsQueryable(), "Year");
            return View(vm);
        }

        public ActionResult Create()
        {
            var grade = new ClassPromotionVM() { Year = DateTime.Now.Year + 1 };

            return View(grade);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClassPromotionVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    vm.CreatedBy = this.GetCurrUser();
                    vm.CreatedDate = DateTime.Now;
                    db.ClassPromotions.Add(vm.GetEntity());
                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Class promotion successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(vm);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ent = db.ClassPromotions.Find(id);
            if (ent == null)
            {
                return HttpNotFound();
            }
            return View(new ClassPromotionVM(ent));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ent = db.ClassPromotions.Find(id);
            if (ent == null)
            {
                return HttpNotFound();
            }
            return View(new ClassPromotionVM(ent));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClassPromotionVM vm)
        {
            byte[] curRowVersion = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = db.ClassPromotions.Find(vm.Id);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = vm.GetEntity();
                    modObj.CopyContent(obj, "Reason");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.Entry(obj).OriginalValues["RowVersion"] = vm.RowVersion;
                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Class promotion modified successfully.");
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
        public ActionResult DeleteConfirmed(ClassPromotionVM grade)
        {
            try
            {
                var obj = db.ClassPromotions.Find(grade.Id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }
                db.Detach(obj);

                db.Entry(grade.GetEntity()).State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Class promotion deleted successfully.");
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