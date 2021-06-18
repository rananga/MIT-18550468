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
    public class SectionHeadController : BaseController
    {
        public ActionResult Index(BaseViewModel<SectionHeadVM> vm)
        {
            vm.SetList(db.SectionHeads.AsQueryable(), "Section");
            return View(vm);
        }
        public ActionResult Create()
        {
            var vm = new SectionHeadVM() { Year = DateTime.Now.Year, FromDate = new DateTime(DateTime.Now.Year, 1, 1), ToDate = new DateTime(DateTime.Now.Year, 12, 31) };

            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SectionHeadVM vm)
        {
            try
            {
                var exName = db.SectionHeads.Where(e => e.Year == vm.Year && e.SectionId == vm.SectionId && e.StaffId == vm.StaffId).FirstOrDefault();
                if (exName != null)
                { ModelState.AddModelError("StaffId", "A section head already assigned for the section."); }

                exName = db.SectionHeads.Where(e => e.SectionId == vm.SectionId &&
                ((e.FromDate <= vm.FromDate && e.ToDate >= vm.FromDate) || (vm.FromDate <= e.FromDate && vm.ToDate >= e.FromDate)))
                    .FirstOrDefault();
                if (exName != null)
                { ModelState.AddModelError("", "A section head already exists for the given period."); }

                if (vm.FromDate.Year != vm.Year)
                { ModelState.AddModelError("FromDate", "From date should fall within the selected year."); }

                if (vm.ToDate.Year != vm.Year)
                { ModelState.AddModelError("ToDate", "To date should fall within the selected year."); }

                if (ModelState.IsValid)
                {
                    vm.CreatedBy = this.GetCurrUser();
                    vm.CreatedDate = DateTime.Now;
                    db.SectionHeads.Add(vm.GetEntity());
                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Section head created successfully.");
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
            var obj = db.SectionHeads.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(new SectionHeadVM(obj));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var obj = db.SectionHeads.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(new SectionHeadVM(obj));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SectionHeadVM vm)
        {
            byte[] curRowVersion = null;
            try
            {
                var exName = db.SectionHeads.Where(e => e.Id != vm.Id && e.Year == vm.Year && e.SectionId == vm.SectionId && e.StaffId == vm.StaffId).FirstOrDefault();
                if (exName != null)
                { ModelState.AddModelError("StaffId", "A section head already assigned for the section."); }

                exName = db.SectionHeads.Where(e => e.Id != vm.Id && e.SectionId == vm.SectionId &&
                ((e.FromDate <= vm.FromDate && e.ToDate >= vm.FromDate) || (vm.FromDate <= e.FromDate && vm.ToDate >= e.FromDate)))
                    .FirstOrDefault();
                if (exName != null)
                { ModelState.AddModelError("", "A section head already exists for the given period."); }

                if (vm.FromDate.Year != vm.Year)
                { ModelState.AddModelError("FromDate", "From date should fall within the selected year."); }

                if (vm.ToDate.Year != vm.Year)
                { ModelState.AddModelError("ToDate", "To date should fall within the selected year."); }

                if (ModelState.IsValid)
                {
                    var obj = db.SectionHeads.Find(vm.Id);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = vm.GetEntity();
                    modObj.CopyContent(obj, "Year,SectionId,StaffId,FromDate,ToDate");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.Entry(obj).OriginalValues["RowVersion"] = vm.RowVersion;
                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Section head modified successfully.");
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
        public ActionResult DeleteConfirmed(SectionHeadVM vm)
        {
            try
            {
                var obj = db.SectionHeads.Find(vm.Id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }
                db.Detach(obj);

                db.Entry(vm.GetEntity()).State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Section head deleted successfully.");
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
            return RedirectToAction("Details", new { id = vm.Id });
        }
    }
}