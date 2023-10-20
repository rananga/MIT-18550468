using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Areas.Admin.Models;
using StudentInformationSystem.Areas.Base;
using StudentInformationSystem.Common;
using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentInformationSystem.Areas.Admin
{
    public class ExtraActivityController : BaseController
    {
        public ActionResult Index(BaseViewModel<ExtraActivityVM> vm)
        {
            vm.SetList(db.ExtraActivities.AsQueryable(), "Name");
            return View(vm);
        }

        [AllowAnonymous]
        public ActionResult AcheivementIndex(int? id, bool isToEdit = false)
        {
            ExtraActivityVM obj;

            if (isToEdit && Session[sskCrtdObj] is ExtraActivityVM)
            { obj = (ExtraActivityVM)Session[sskCrtdObj]; }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ExtraActivity cls = db.ExtraActivities.Where(x => x.Id == id).FirstOrDefault();
                if (cls == null)
                {
                    return HttpNotFound();
                }
                obj = new ExtraActivityVM(cls);
            }

            ViewBag.IsToEdit = isToEdit;
            ViewBag.ActivityId = obj.Id;
            return PartialView("_AcheivementIndex", obj.vmAcheivements);
        }

        [AllowAnonymous]
        public ActionResult PositionIndex(int? id, bool isToEdit = false)
        {
            ExtraActivityVM obj;

            if (isToEdit && Session[sskCrtdObj] is ExtraActivityVM)
            { obj = (ExtraActivityVM)Session[sskCrtdObj]; }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ExtraActivity cls = db.ExtraActivities.Where(x => x.Id == id).FirstOrDefault();
                if (cls == null)
                {
                    return HttpNotFound();
                }
                obj = new ExtraActivityVM(cls);
            }

            ViewBag.IsToEdit = isToEdit;
            ViewBag.ActivityId = obj.Id;
            return PartialView("_PositionIndex", obj.vmPositions);
        }

        [AllowAnonymous]
        public ActionResult InChargeIndex(int? id, bool isToEdit = false)
        {
            ExtraActivityVM obj;

            if (isToEdit && Session[sskCrtdObj] is ExtraActivityVM)
            { obj = (ExtraActivityVM)Session[sskCrtdObj]; }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                ExtraActivity cls = db.ExtraActivities.Where(x => x.Id == id).FirstOrDefault();
                if (cls == null)
                {
                    return HttpNotFound();
                }
                obj = new ExtraActivityVM(cls);
            }

            ViewBag.IsToEdit = isToEdit;
            ViewBag.ActivityId = obj.Id;
            return PartialView("_InChargeIndex", obj.vmInCharges);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ent = db.ExtraActivities.Find(id);
            if (ent == null)
            {
                return HttpNotFound();
            }
            return View(new ExtraActivityVM(ent));
        }

        [AllowAnonymous]
        public ActionResult AcheivementDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExtraActivityVM obj = (ExtraActivityVM)Session[sskCrtdObj];
            ExtraActivityAcheivementVM actAcheiv = obj.vmAcheivements.Where(x => x.Id == id.Value).FirstOrDefault();
            if (actAcheiv == null)
            {
                return HttpNotFound();
            }
            return PartialView("_AcheivementDetails", actAcheiv);
        }

        public ActionResult Create()
        {
            var cls = new ExtraActivityVM();

            Session[sskCrtdObj] = cls;
            return View(cls);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ExtraActivityVM activity)
        {
            try
            {
                var svm = (ExtraActivityVM)Session[sskCrtdObj];
                var existingEnt = db.ExtraActivities.Where(e => e.Name == activity.Name).FirstOrDefault();

                if (existingEnt != null)
                { ModelState.AddModelError("", "Extra activity already exists."); }

                if (ModelState.IsValid)
                {
                    activity.CreatedBy = this.GetCurrUser();
                    activity.CreatedDate = DateTime.Now;
                    var objActivity = db.ExtraActivities.Add(activity.GetEntity()).Entity;

                    foreach (var det in svm.vmAcheivements)
                    {
                        det.ActivityId = objActivity.Id;
                        det.CreatedBy = objActivity.CreatedBy;
                        det.CreatedDate = DateTime.Now;
                        objActivity.Acheivements.Add(det.GetEntity());
                    }

                    foreach (var det in svm.vmPositions)
                    {
                        det.ActivityId = objActivity.Id;
                        det.CreatedBy = objActivity.CreatedBy;
                        det.CreatedDate = DateTime.Now;
                        objActivity.Positions.Add(det.GetEntity());
                    }
                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Extra Activity Created Successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(activity);
        }

        [AllowAnonymous]
        public ActionResult AcheivementCreate(int? activityId)
        {
            if (activityId != 0)
            {
                if (activityId == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var cls = db.ExtraActivities.Find(activityId);

                if (cls == null)
                {
                    return HttpNotFound();
                }
            }

            var vm = new ExtraActivityAcheivementVM() { ActivityId = activityId.Value };
            return PartialView("_AcheivementCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult AcheivementCreate(ExtraActivityAcheivementVM vm)
        {
            ExtraActivityVM obj;
            try
            {
                if (ModelState.IsValid)
                {
                    obj = (ExtraActivityVM)Session[sskCrtdObj];
                    vm.Id = Math.Min(obj.vmAcheivements.Select(x => x.Id).MinOrDefault(), 0) - 1;
                    obj.vmAcheivements.Add(vm);

                    AddAlert(AlertStyles.success, "Acheivement Added Successfully.");
                    string url = Url.Action("AcheivementIndex", new { id = vm.Id, isToEdit = true });
                    return Json(new { success = true, url });
                }

            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            obj = (ExtraActivityVM)Session[sskCrtdObj];

            return PartialView("_AcheivementCreate", vm);
        }

        [AllowAnonymous]
        public ActionResult PositionCreate(int? activityId)
        {
            if (activityId != 0)
            {
                if (activityId == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var cls = db.ExtraActivities.Find(activityId);

                if (cls == null)
                {
                    return HttpNotFound();
                }
            }

            var vm = new ExtraActivityPositionVM() { ActivityId = activityId.Value };
            return PartialView("_PositionCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult PositionCreate(ExtraActivityPositionVM vm)
        {
            ExtraActivityVM obj;
            try
            {
                if (ModelState.IsValid)
                {
                    obj = (ExtraActivityVM)Session[sskCrtdObj];
                    vm.Id = Math.Min(obj.vmPositions.Select(x => x.Id).MinOrDefault(), 0) - 1;
                    obj.vmPositions.Add(vm);

                    AddAlert(AlertStyles.success, "Position Added Successfully.");
                    string url = Url.Action("PositionIndex", new { id = vm.Id, isToEdit = true });
                    return Json(new { success = true, url });
                }

            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            obj = (ExtraActivityVM)Session[sskCrtdObj];

            return PartialView("_PositionCreate", vm);
        }

        [AllowAnonymous]
        public ActionResult InChargeCreate(int? activityId)
        {
            if (activityId != 0)
            {
                if (activityId == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var cls = db.ExtraActivities.Find(activityId);

                if (cls == null)
                {
                    return HttpNotFound();
                }
            }

            var vm = new ExtraActivityInchargeVM() { ActivityId = activityId.Value, FromDate = DateTime.Now.Date, ToDate = DateTime.Now.Date };
            return PartialView("_InChargeCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult InChargeCreate(ExtraActivityInchargeVM vm)
        {
            ExtraActivityVM obj;
            try
            {
                if (ModelState.IsValid)
                {
                    obj = (ExtraActivityVM)Session[sskCrtdObj];
                    vm.Id = Math.Min(obj.vmInCharges.Select(x => x.Id).MinOrDefault(), 0) - 1;
                    var sm = db.StaffMembers.Find(vm.StaffId);
                    vm.MasterName = $"{sm.Title.ToEnumChar()} {sm.Initials} {sm.LastName}";
                    obj.vmInCharges.Add(vm);

                    AddAlert(AlertStyles.success, "Master In Charge Added Successfully.");
                    string url = Url.Action("InChargeIndex", new { id = vm.Id, isToEdit = true });
                    return Json(new { success = true, url });
                }

            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            obj = (ExtraActivityVM)Session[sskCrtdObj];

            return PartialView("_InChargeCreate", vm);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var activity = db.ExtraActivities.Find(id);
            if (activity == null)
            {
                return HttpNotFound();
            }

            var obj = new ExtraActivityVM(activity);
            Session[sskCrtdObj] = obj;
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ExtraActivityVM activity)
        {
            byte[] curRowVersion = null;
            try
            {
                var svm = (ExtraActivityVM)Session[sskCrtdObj];
                var existingEnt = db.ExtraActivities.Where(e => e.Id != activity.Id && e.Name == activity.Name).FirstOrDefault();

                if (existingEnt != null)
                { ModelState.AddModelError("", "Activity Name Already Exist"); }

                if (ModelState.IsValid)
                {
                    var obj = db.ExtraActivities.Find(activity.Id);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = activity.GetEntity();
                    modObj.CopyContent(obj, "Grade,Name,Status");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.Entry(obj).OriginalValues["RowVersion"] = activity.RowVersion;

                    db.ExtraActivityAchievements.RemoveRange(obj.Acheivements.Where(x =>
                        !svm.vmAcheivements.Select(y => y.Id).ToList().Contains(x.Id)));

                    foreach (var det in svm.vmAcheivements)
                    {
                        var objDet = db.ExtraActivityAchievements.Find(det.Id);
                        if (objDet == null)
                        {
                            det.CreatedBy = this.GetCurrUser();
                            det.CreatedDate = DateTime.Now;
                            obj.Acheivements.Add(det.GetEntity());
                        }
                        else
                        {
                            var modObjDet = det.GetEntity();
                            modObjDet.CopyContent(objDet, "Name,Description");

                            objDet.ModifiedBy = this.GetCurrUser();
                            objDet.ModifiedDate = DateTime.Now;
                        }
                    }

                    db.ExtraActivityPositions.RemoveRange(obj.Positions.Where(x =>
                        !svm.vmPositions.Select(y => y.Id).ToList().Contains(x.Id)));

                    foreach (var det in svm.vmPositions)
                    {
                        var objDet = db.ExtraActivityPositions.Find(det.Id);
                        if (objDet == null)
                        {
                            det.CreatedBy = this.GetCurrUser();
                            det.CreatedDate = DateTime.Now;
                            obj.Positions.Add(det.GetEntity());
                        }
                        else
                        {
                            var modObjDet = det.GetEntity();
                            modObjDet.CopyContent(objDet, "Name,HierarchyOrder");

                            objDet.ModifiedBy = this.GetCurrUser();
                            objDet.ModifiedDate = DateTime.Now;
                        }
                    }

                    db.ExtraActivityIncharges.RemoveRange(obj.Incharges.Where(x =>
                        !svm.vmInCharges.Select(y => y.Id).ToList().Contains(x.Id)));

                    foreach (var det in svm.vmInCharges)
                    {
                        var objDet = db.ExtraActivityIncharges.Find(det.Id);
                        if (objDet == null)
                        {
                            det.CreatedBy = this.GetCurrUser();
                            det.CreatedDate = DateTime.Now;
                            obj.Incharges.Add(det.GetEntity());
                        }
                        else
                        {
                            var modObjDet = det.GetEntity();
                            modObjDet.CopyContent(objDet, "StaffId,FromDate,ToDate");

                            objDet.ModifiedBy = this.GetCurrUser();
                            objDet.ModifiedDate = DateTime.Now;
                        }
                    }

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Extra Activity Modified Successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.ShowConcurrencyErrors(ex);
                activity.RowVersion = curRowVersion;
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(activity);
        }

        public ActionResult InChargeEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = ((ExtraActivityVM)Session[sskCrtdObj]).vmInCharges.FirstOrDefault(x => x.Id == id);
            if (vm == null)
            {
                return HttpNotFound();
            }
            return PartialView("_InChargeEdit", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult InChargeEdit(ExtraActivityInchargeVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = ((ExtraActivityVM)Session[sskCrtdObj]).vmInCharges.FirstOrDefault(x => x.Id == vm.Id);
                    vm.CopyContent(obj, "StaffId,FromDate,ToDate");
                    AddAlert(AlertStyles.success, "Master In Charge Modified Successfully.");
                    string url = Url.Action("InChargeIndex", new { id = vm.Id, isToEdit = true });
                    return Json(new { success = true, url });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return PartialView("_InChargeEdit", vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(ExtraActivityVM activity)
        {
            try
            {
                var obj = db.ExtraActivities.Find(activity.Id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }
                db.Detach(obj);

                var entry = db.Entry(activity.GetEntity());
                entry.State = EntityState.Unchanged;
                entry.Collection(x => x.Acheivements).Load();
                db.ExtraActivityAchievements.RemoveRange(entry.Entity.Acheivements);
                entry.Collection(x => x.Positions).Load();
                db.ExtraActivityPositions.RemoveRange(entry.Entity.Positions);
                entry.State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Extra Activity Deleted Successfully.");
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
            return RedirectToAction("Details", new { id = activity.Id });
        }

        [HttpPost, ActionName("AcheivementDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult AcheivementDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            try
            {
                var lst = ((ExtraActivityVM)Session[sskCrtdObj]).vmAcheivements;
                var obj = lst.FirstOrDefault(x => x.Id == id);
                lst.Remove(obj);

                AddAlert(AlertStyles.success, "Acheivement Removed Successfully.");
            }
            catch (Exception ex)
            {
                msg = ex.GetInnerException().Message;
                AddAlert(AlertStyles.danger, msg);
            }
            string url = "";
            if (msg.IsBlank())
            { url = Url.Action("AcheivementIndex", new { isToEdit = true }); }
            return Json(new { success = true, url, msg });
        }

        [HttpPost, ActionName("PositionDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult PositionDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            try
            {
                var lst = ((ExtraActivityVM)Session[sskCrtdObj]).vmPositions;
                var obj = lst.FirstOrDefault(x => x.Id == id);
                lst.Remove(obj);

                AddAlert(AlertStyles.success, "Position Removed Successfully.");
            }
            catch (Exception ex)
            {
                msg = ex.GetInnerException().Message;
                AddAlert(AlertStyles.danger, msg);
            }
            string url = "";
            if (msg.IsBlank())
            { url = Url.Action("PositionIndex", new { isToEdit = true }); }
            return Json(new { success = true, url, msg });
        }

        [HttpPost, ActionName("InChargeDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult InChargeDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            try
            {
                var lst = ((ExtraActivityVM)Session[sskCrtdObj]).vmInCharges;
                var obj = lst.FirstOrDefault(x => x.Id == id);
                lst.Remove(obj);

                AddAlert(AlertStyles.success, "Master In Charge Removed Successfully.");
            }
            catch (Exception ex)
            {
                msg = ex.GetInnerException().Message;
                AddAlert(AlertStyles.danger, msg);
            }
            string url = "";
            if (msg.IsBlank())
            { url = Url.Action("InChargeIndex", new { isToEdit = true }); }
            return Json(new { success = true, url, msg });
        }
    }
}