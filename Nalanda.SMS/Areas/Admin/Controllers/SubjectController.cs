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
    public class SubjectController : BaseController
    {
        // GET: Admin/Subject
        public ActionResult Index(BaseViewModel<SubjectVM> vm)
        {
            vm.SetList(db.Subjects.AsQueryable(), "Name");
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
                if (subject.Name == null)
                { ModelState.AddModelError("Name", "Name Field is Required"); }
                if (ModelState.IsValid)
                {
                    subject.CreatedBy = this.GetCurrUser();
                    subject.CreatedDate = DateTime.Now;
                    db.Subjects.Add(subject.GetEntity());
                    db.SaveChanges();

                    AddAlert(SMS.Common.AlertStyles.success, "Subject Information created successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

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
                if (ModelState.IsValid)
                {
                    var obj = db.Subjects.Find(subject.Id);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = subject.GetEntity();
                    modObj.CopyContent(obj, "Name,IsBasket");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.Entry(obj).OriginalValues["RowVersion"] = subject.RowVersion;
                    db.SaveChanges();

                    AddAlert(SMS.Common.AlertStyles.success, "Subject Information modified successfully.");
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
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

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

                AddAlert(SMS.Common.AlertStyles.success, "Subject Information deleted successfully.");
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
            return RedirectToAction("Details", new { id = subject.Id });
        }
    }
}