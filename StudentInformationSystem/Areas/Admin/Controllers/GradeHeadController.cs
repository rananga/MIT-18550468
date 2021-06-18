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
    public class GradeHeadController : BaseController
    {
        public ActionResult Index(BaseViewModel<GradeHeadVM> vm)
        {
            vm.SetList(db.GradeHeads.AsQueryable(), "Grade");
            return View(vm);
        }
        public ActionResult Create()
        {
            var vm = new GradeHeadVM() { Year = DateTime.Now.Year, FromDate = new DateTime(DateTime.Now.Year, 1, 1), ToDate = new DateTime(DateTime.Now.Year, 12, 31) };

            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GradeHeadVM vm)
        {
            try
            {
                var exName = db.GradeHeads.Where(e => e.Year == vm.Year && e.GradeId == vm.GradeId && e.StaffId == vm.StaffId).FirstOrDefault();
                if (exName != null)
                { ModelState.AddModelError("StaffId", "A grade head already assigned for the grade."); }

                exName = db.GradeHeads.Where(e => e.GradeId == vm.GradeId &&
                ((e.FromDate <= vm.FromDate && e.ToDate >= vm.FromDate) || (vm.FromDate <= e.FromDate && vm.ToDate >= e.FromDate)))
                    .FirstOrDefault();
                if (exName != null)
                { ModelState.AddModelError("", "A grade head already exists for the given period."); }

                if (vm.FromDate.Year != vm.Year)
                { ModelState.AddModelError("FromDate", "From date should fall within the selected year."); }

                if (vm.ToDate.Year != vm.Year)
                { ModelState.AddModelError("ToDate", "To date should fall within the selected year."); }

                if (ModelState.IsValid)
                {
                    vm.CreatedBy = this.GetCurrUser();
                    vm.CreatedDate = DateTime.Now;
                    db.GradeHeads.Add(vm.GetEntity());
                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Grade head created successfully.");
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
            var obj = db.GradeHeads.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(new GradeHeadVM(obj));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var obj = db.GradeHeads.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(new GradeHeadVM(obj));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GradeHeadVM vm)
        {
            byte[] curRowVersion = null;
            try
            {
                var exName = db.GradeHeads.Where(e => e.Id != vm.Id && e.Year == vm.Year && e.GradeId == vm.GradeId && e.StaffId == vm.StaffId).FirstOrDefault();
                if (exName != null)
                { ModelState.AddModelError("StaffId", "A grade head already assigned for the grade."); }

                exName = db.GradeHeads.Where(e => e.Id != vm.Id && e.GradeId == vm.GradeId &&
                ((e.FromDate <= vm.FromDate && e.ToDate >= vm.FromDate) || (vm.FromDate <= e.FromDate && vm.ToDate >= e.FromDate)))
                    .FirstOrDefault();
                if (exName != null)
                { ModelState.AddModelError("", "A grade head already exists for the given period."); }

                if (vm.FromDate.Year != vm.Year)
                { ModelState.AddModelError("FromDate", "From date should fall within the selected year."); }

                if (vm.ToDate.Year != vm.Year)
                { ModelState.AddModelError("ToDate", "To date should fall within the selected year."); }

                if (ModelState.IsValid)
                {
                    var obj = db.GradeHeads.Find(vm.Id);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = vm.GetEntity();
                    modObj.CopyContent(obj, "Year,GradeId,StaffId,FromDate,ToDate");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.Entry(obj).OriginalValues["RowVersion"] = vm.RowVersion;
                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Grade head modified successfully.");
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
        public ActionResult DeleteConfirmed(GradeHeadVM vm)
        {
            try
            {
                var obj = db.GradeHeads.Find(vm.Id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }
                db.Detach(obj);

                db.Entry(vm.GetEntity()).State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Grade head deleted successfully.");
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