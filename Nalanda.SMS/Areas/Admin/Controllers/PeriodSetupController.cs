using Microsoft.EntityFrameworkCore;
using Nalanda.SMS.Data;
using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Areas.Admin.Models;
using Nalanda.SMS.Areas.Base;
using Nalanda.SMS.Common;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Nalanda.SMS.Areas.Admin.Controllers
{
    public class PeriodSetupController : BaseController
    {
        // GET: Admin/PeriodSetup
        public ActionResult Index(BaseViewModel<PeriodSetupVM> vm)
        {
            vm.SetList(db.PeriodSetups, "PeriodStartDate", SortDirection.Descending);
            return View(vm);
        }
        public ActionResult Create()
        {
            var periodSetupVM = new PeriodSetupVM();
            periodSetupVM.PeriodStartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            periodSetupVM.PeriodEndDate = DateTime.Now;
            Session[sskCrtdObj] = periodSetupVM;
            return View(periodSetupVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PeriodID,PeriodStartDate,PeriodEndDate")]PeriodSetupVM periodSetupVM)
        {
            try
            {
                if (periodSetupVM.PeriodStartDate == null)
                { ModelState.AddModelError("PeriodStartDate", "Period Start Date should be selected."); }

                if (periodSetupVM.PeriodEndDate == null)
                { ModelState.AddModelError("PeriodEndDate", "Period End Date should be selected."); }

                int existPeriodSetup = db.PeriodSetups.Where(x => x.PeriodStartDate <= periodSetupVM.PeriodStartDate && x.PeriodEndDate >= periodSetupVM.PeriodEndDate).Count();
                if (existPeriodSetup > 0)
                { ModelState.AddModelError("", "Can't create new period setup in between already exist period setup."); }

                if (ModelState.IsValid)
                {
                    periodSetupVM.CreatedBy = this.GetCurrUser();
                    periodSetupVM.CreatedDate = DateTime.Now;
                    var newObj = db.PeriodSetups.Add(periodSetupVM.GetEntity()).Entity;
                    db.SaveChanges();

                    AddAlert(SMS.Common.AlertStyles.success, "Academic Period Setup Created Successfully.");
                    return RedirectToAction("Details", new { id = newObj.PeriodId });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            return View(periodSetupVM);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeriodSetup period = db.PeriodSetups.Find(id);
            if (period == null)
            {
                return HttpNotFound();
            }

            PeriodSetupVM PeriodSetupVM = new PeriodSetupVM(period);

            return View(PeriodSetupVM);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PeriodSetup periodSetup = db.PeriodSetups.Find(id);
            if (periodSetup == null)
            {
                return HttpNotFound();
            }

            var obj = new PeriodSetupVM(periodSetup);
            Session[sskCrtdObj] = obj;
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PeriodID,PeriodStartDate,PeriodEndDate")]PeriodSetupVM periodSetupVM)
        {
            byte[] curRowVersion = null;
            try
            {
                if (periodSetupVM.PeriodStartDate == null)
                { ModelState.AddModelError("PeriodStartDate", "Period Start Date should be selected."); }

                if (periodSetupVM.PeriodEndDate == null)
                { ModelState.AddModelError("PeriodEndDate", "Period End Date should be selected"); }

                int existPeriodSetup = db.PeriodSetups.Where(x => x.PeriodStartDate <= periodSetupVM.PeriodStartDate && x.PeriodEndDate >= periodSetupVM.PeriodEndDate).Count();
                if (existPeriodSetup > 0)
                { ModelState.AddModelError("", "Can't create new period setup in between already exist period setup."); }

                if (ModelState.IsValid)
                {
                    var obj = db.PeriodSetups.Find(periodSetupVM.PeriodID);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = periodSetupVM.GetEntity();
                    modObj.CopyContent(obj, "PeriodStartDate,PeriodEndDate");
                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;
                    db.SaveChanges();

                    AddAlert(SMS.Common.AlertStyles.success, "Academic Period Setup Modified Successfully.");
                    return RedirectToAction("Details", new { id = modObj.PeriodId });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            return View(periodSetupVM);
        }

        public ActionResult Confirm(PeriodSetupVM periodSetupVM)
        {
            try
            {
                var obj = db.PeriodSetups.Find(periodSetupVM.PeriodID);
                if (obj.PeriodEndDate >= DateTime.Now)
                {
                    AddAlert(SMS.Common.AlertStyles.danger, "Period setup can not be complete until the period end date.");
                    return RedirectToAction("Details", new { id = periodSetupVM.PeriodID });
                }
               
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }

                obj.IsPeriodComplete = true;
                obj.ModifiedBy = this.GetCurrUser();
                obj.ModifiedDate = DateTime.Now;
                db.SaveChanges();

                AddAlert(SMS.Common.AlertStyles.success, "Academic Date Setup successfully Completed");
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
            return RedirectToAction("Details", new { id = periodSetupVM.PeriodID });
        }
    }
}