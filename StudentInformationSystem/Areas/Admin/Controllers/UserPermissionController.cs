using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Areas.Admin.Models;
using StudentInformationSystem.Areas.Base;
using StudentInformationSystem.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentInformationSystem.Areas.Admin.Controllers
{
    [ExtendedAuthorize(Roles = PermissionConstants.AdminUser)]
    public class UserPermissionController : BaseController
    {
        public ActionResult Index(BaseViewModel<PermissionVM> vm)
        {
            vm.SetList(db.Permissions.AsQueryable(), "Name");
            return View(vm);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permission permission = db.Permissions.Find(id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            return View(new PermissionVM(permission));
        }

        public ActionResult Create()
        {
            var vm = new PermissionVM();
            Session[sskCrtdObj] = vm;
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PermissionVM permission)
        {
            try
            {
                if (permission.Name == null )
                { ModelState.AddModelError("Name", "Name field is required"); }
                if (permission.Code == null)
                { ModelState.AddModelError("Code", "Code field is required"); }

                if (ModelState.IsValid)
                {
                    permission.CreatedBy = this.GetCurrUser();
                    permission.CreatedDate = DateTime.Now;
                    var obj = db.Permissions.Add(permission.GetEntity()).Entity;

                    var mnuLst = permission.MenusJson.DeserializeJson<List<int>>();

                    foreach (var det in mnuLst)
                    {
                        obj.PermissionMenuAccesses.Add(new PermissionMenuAccess() { PermissionId = obj.PermissionId, MenuId = det });
                    }

                    var grdLst = permission.GradesJson.DeserializeJson<List<int>>();

                    foreach (var det in grdLst)
                    {
                        obj.PermissionGradeAccesses.Add(new PermissionGradeAccess() { PermissionId = obj.PermissionId, GradeId = det });
                    }

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "User permission created successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(permission);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Permission permission = db.Permissions.Find(id);
            if (permission == null)
            {
                return HttpNotFound();
            }
            var obj = new PermissionVM(permission);
            Session[sskCrtdObj] = obj;
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PermissionVM permission)
        {
            byte[] curRowVersion = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var svm = (PermissionVM)Session[sskCrtdObj];

                    var obj = db.Permissions.Find(permission.PermissionId);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = permission.GetEntity();
                    var props = "Name";
                    modObj.CopyContent(obj, props);

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.Entry(obj).OriginalValues["RowVersion"] = permission.RowVersion;

                    var mnuLst = permission.MenusJson.DeserializeJson<List<int>>();

                    db.PermissionMenuAccesses.RemoveRange(obj.PermissionMenuAccesses.Where(x => !mnuLst.Contains(x.MenuId)));
                    mnuLst = mnuLst.Except(obj.PermissionMenuAccesses.Select(x => x.MenuId)).ToList();
                    foreach (var det in mnuLst)
                    {
                        obj.PermissionMenuAccesses.Add(new PermissionMenuAccess() { PermissionId = obj.PermissionId, MenuId = det });
                    }

                    var grdLst = permission.GradesJson.DeserializeJson<List<int>>();

                    db.PermissionGradeAccesses.RemoveRange(obj.PermissionGradeAccesses.Where(x => !grdLst.Contains(x.GradeId)));
                    grdLst = grdLst.Except(obj.PermissionGradeAccesses.Select(x => x.GradeId)).ToList();
                    foreach (var det in grdLst)
                    {
                        obj.PermissionGradeAccesses.Add(new PermissionGradeAccess() { PermissionId = obj.PermissionId, GradeId = det });
                    }

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "User Permission modified successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.ShowConcurrencyErrors(ex);
                permission.RowVersion = curRowVersion;
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(permission);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(PermissionVM permission)
        {
            try
            {
                var obj = db.Permissions.Find(permission.PermissionId);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }
                db.Detach(obj);
                
                var entry = db.Entry(permission.GetEntity());
                entry.State = EntityState.Unchanged;
                entry.Collection(x => x.PermissionMenuAccesses).Load();
                db.PermissionMenuAccesses.RemoveRange(entry.Entity.PermissionMenuAccesses);
                entry.Collection(x => x.PermissionGradeAccesses).Load();
                db.PermissionGradeAccesses.RemoveRange(entry.Entity.PermissionGradeAccesses);
                entry.State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "User Permission deleted successfully.");
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
            return RedirectToAction("Details", new { id = permission.PermissionId });
        }

        public ActionResult ChildIndex(int? id, bool isToEdit = false)
        {
            PermissionVM obj;

            if (isToEdit && Session[sskCrtdObj] is PermissionVM)
            { obj = (PermissionVM)Session[sskCrtdObj]; }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Permission permission = db.Permissions.Where(x => x.PermissionId == id).FirstOrDefault();
                if (permission == null)
                {
                    return HttpNotFound();
                }
                obj = new PermissionVM(permission);
            }

            ViewBag.IsToEdit = isToEdit;
            ViewBag.PermissionID = obj.PermissionId;
            return PartialView("_ChildIndex", obj.MenusList);
        }

        public ActionResult GradeIndex(int? id, bool isToEdit = false)
        {
            PermissionVM obj;

            if (isToEdit && Session[sskCrtdObj] is PermissionVM)
            { obj = (PermissionVM)Session[sskCrtdObj]; }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Permission permission = db.Permissions.Where(x => x.PermissionId == id).FirstOrDefault();
                if (permission == null)
                {
                    return HttpNotFound();
                }
                obj = new PermissionVM(permission);
            }
            var gradesList = db.Grades.ToList();

            ViewBag.IsToEdit = isToEdit;
            ViewBag.PermissionID = obj.PermissionId;
            return PartialView("_GradeIndex", gradesList);
        }
    }
}