using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Areas.Admin.Models;
using StudentInformationSystem.Areas.Base;
using StudentInformationSystem.Common;
using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Linq;

namespace StudentInformationSystem.Areas.Admin.Controllers
{
    public class SectionController : BaseController
    {
        public ActionResult Index(BaseViewModel<SectionVM> vm)
        {
            vm.SetList(db.Sections.AsQueryable(), "Code");
            return View(vm);
        }
        public ActionResult Create()
        {
            var section = new SectionVM();

            return View(section);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SectionVM section)
        {
            try
            {
                var exName = db.Sections.Where(e => e.Code.ToLower().Trim() == section.Code.ToLower().Trim()).FirstOrDefault();

                if (exName != null)
                { ModelState.AddModelError("Code", "Name Already Exists."); }

                if (ModelState.IsValid)
                {
                    section.CreatedBy = this.GetCurrUser();
                    section.CreatedDate = DateTime.Now;
                    db.Sections.Add(section.GetEntity());
                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Section created successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(section);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section clibs = db.Sections.Find(id);
            if (clibs == null)
            {
                return HttpNotFound();
            }
            return View(new SectionVM(clibs));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Section section = db.Sections.Find(id);
            if (section == null)
            {
                return HttpNotFound();
            }
            return View(new SectionVM(section));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SectionVM section)
        {
            byte[] curRowVersion = null;
            try
            {
                var exName = db.Sections.Where(e => e.Id != section.Id && e.Code.ToLower().Trim() == section.Code.ToLower().Trim()).FirstOrDefault();

                if (exName != null)
                { ModelState.AddModelError("Name", "Name Already Exists."); }

                if (ModelState.IsValid)
                {
                    var obj = db.Sections.Find(section.Id);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = section.GetEntity();
                    modObj.CopyContent(obj, "Name,Description");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.Entry(obj).OriginalValues["RowVersion"] = section.RowVersion;
                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Section modified successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.ShowConcurrencyErrors(ex);
                section.RowVersion = curRowVersion;
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(section);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(SectionVM section)
        {
            try
            {
                var obj = db.Sections.Find(section.Id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }
                db.Detach(obj);

                db.Entry(section.GetEntity()).State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Section deleted successfully.");
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
            return RedirectToAction("Details", new { id = section.Id });
        }
    }
}