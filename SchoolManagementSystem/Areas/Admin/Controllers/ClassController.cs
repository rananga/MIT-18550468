using SMS.Areas.Admin.Models;
using SMS.Areas.Base.Controllers;
using SMS.Common;
using SMS.Common.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SMS.Areas.Admin.Controllers
{
    public class ClassController : BaseController
    {
        // GET: Admin/Class
        public ActionResult Index(BaseViewModel<ClassVM> vm)
        {
            vm.SetList(db.Classes.AsQueryable(), "Grade", "ClassDesc");
            return View(vm);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class classes = db.Classes.Find(id);
            if (classes == null)
            {
                return HttpNotFound();
            }
            return View(new ClassVM(classes));
        }

        public ActionResult Create()
        {
            var classes = new ClassVM() { Status = ActiveState.Active };
            return View(classes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassID,Grade,ClassDesc,Status")] ClassVM classes)
        {
            try
            {
                var existingClass = db.Classes.Where(e => e.Grade == classes.Grade && e.ClassDesc == classes.ClassDesc).FirstOrDefault();

                if (existingClass != null)
                { ModelState.AddModelError("", "Grade & Class Already Exist"); }

                if (ModelState.IsValid)
                {
                    classes.CreatedBy = this.GetCurrUser();
                    classes.CreatedDate = DateTime.Now;
                    db.Classes.Add(classes.GetEntity());
                    db.SaveChanges();

                    AddAlert(SMS.Common.AlertStyles.success, "Class Information Created Successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            return View(classes);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class classes = db.Classes.Find(id);
            if (classes == null)
            {
                return HttpNotFound();
            }
            return View(new ClassVM(classes));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassID,Grade,ClassDesc,Status,RowVersion")] ClassVM classes)
        {
            byte[] curRowVersion = null;
            try
            {
                var existingClass = db.Classes.Where(e => e.Grade == classes.Grade && e.ClassDesc == classes.ClassDesc && e.Status == classes.Status).FirstOrDefault();

                if (existingClass != null)
                { ModelState.AddModelError("", "Grade & Class Already Exist"); }

                if (ModelState.IsValid)
                {
                    var obj = db.Classes.Find(classes.ClassID);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = classes.GetEntity();
                    modObj.CopyContent(obj, "Grade,ClassDesc,Status");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.Entry(obj).OriginalValues["RowVersion"] = classes.RowVersion;
                    db.SaveChanges();

                    AddAlert(SMS.Common.AlertStyles.success, "Class Modified Successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.ShowConcurrencyErrors(ex);
                classes.RowVersion = curRowVersion;
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            return View(classes);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(ClassVM classes)
        {
            try
            {
                var obj = db.Classes.Find(classes.ClassID);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }
                db.Detach(obj);

                db.Entry(classes.GetEntity()).State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(SMS.Common.AlertStyles.success, "Class Deleted Successfully.");
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
            return RedirectToAction("Details", new { id = classes.ClassID });
        }
    }
}