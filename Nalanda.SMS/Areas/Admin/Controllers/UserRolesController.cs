using Microsoft.EntityFrameworkCore;
using Nalanda.SMS.Data;
using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Areas.Admin.Models;
using Nalanda.SMS.Areas.Base;
using Nalanda.SMS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Nalanda.SMS.Areas.Admin.Controllers
{
    [ExtendedAuthorize(Roles = RoleConstants.AdminUser)]
    public class UserRolesController : BaseController
    {
        public ActionResult Index(BaseViewModel<RoleVM> vm)
        {
            vm.SetList(db.Roles.AsQueryable(), "Name");
            return View(vm);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(new RoleVM(role));
        }

        public ActionResult Create()
        {
            var role = new RoleVM();
            Session[sskCrtdObj] = role;
            return View(role);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoleID,Code,Name,MenusJson")] RoleVM role)
        {
            try
            {
                if (role.Name == null )
                { ModelState.AddModelError("Name", "Name field is required"); }
                if (role.Code == null)
                { ModelState.AddModelError("Code", "Code field is required"); }

                if (ModelState.IsValid)
                {
                    role.CreatedBy = this.GetCurrUser();
                    role.CreatedDate = DateTime.Now;
                    var obj = db.Roles.Add(role.GetEntity()).Entity;

                    var mnuLst = role.MenusJson.DeserializeJson<List<int>>();

                    foreach (var det in mnuLst)
                    {
                        obj.RoleMenuAccesses.Add(new RoleMenuAccess() { RoleId = obj.RoleId, MenuId = det });
                    }
                    db.SaveChanges();

                    AddAlert(SMS.Common.AlertStyles.success, "User role created successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            return View(role);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = db.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            var obj = new RoleVM(role);
            Session[sskCrtdObj] = obj;
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoleID,Code,Name,MenusJson,RowVersion")] RoleVM role)
        {
            byte[] curRowVersion = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var sRole = (RoleVM)Session[sskCrtdObj];

                    var obj = db.Roles.Find(role.RoleId);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = role.GetEntity();
                    var props = "Name";
                    modObj.CopyContent(obj, props);

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.Entry(obj).OriginalValues["RowVersion"] = role.RowVersion;

                    var mnuLst = role.MenusJson.DeserializeJson<List<int>>();

                    db.RoleMenuAccesses.RemoveRange(obj.RoleMenuAccesses.Where(x => !mnuLst.Contains(x.MenuId)));
                    mnuLst = mnuLst.Except(obj.RoleMenuAccesses.Select(x => x.MenuId)).ToList();
                    foreach (var det in mnuLst)
                    {
                        obj.RoleMenuAccesses.Add(new RoleMenuAccess() { RoleId = obj.RoleId, MenuId = det });
                    }

                    db.SaveChanges();

                    AddAlert(SMS.Common.AlertStyles.success, "User Role modified successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.ShowConcurrencyErrors(ex);
                role.RowVersion = curRowVersion;
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            return View(role);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(RoleVM role)
        {
            try
            {
                var obj = db.Roles.Find(role.RoleId);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }
                db.Detach(obj);
                
                var entry = db.Entry(role.GetEntity());
                entry.State = EntityState.Unchanged;
                entry.Collection(x => x.RoleMenuAccesses).Load();
                db.RoleMenuAccesses.RemoveRange(entry.Entity.RoleMenuAccesses);
                entry.State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(SMS.Common.AlertStyles.success, "User Role deleted successfully.");
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
            return RedirectToAction("Details", new { id = role.RoleId });
        }

        public ActionResult ChildIndex(int? id, bool isToEdit = false)
        {
            RoleVM obj;

            if (isToEdit && Session[sskCrtdObj] is RoleVM)
            { obj = (RoleVM)Session[sskCrtdObj]; }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Role role = db.Roles.Where(x => x.RoleId == id).FirstOrDefault();
                if (role == null)
                {
                    return HttpNotFound();
                }
                obj = new RoleVM(role);
            }

            ViewBag.IsToEdit = isToEdit;
            ViewBag.RoleID = obj.RoleId;
            return PartialView("_ChildIndex", obj.MenusList);
        }
    }
}