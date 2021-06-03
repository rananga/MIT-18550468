using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nalanda.SMS.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;

namespace Nalanda.SMS.Controllers
{
    public class UserRolesController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public UserRolesController(dbNalandaContext dbContext, ILogger<HomeController> logger) : base(dbContext)
        {
            _logger = logger;
        }

        public IActionResult Index(BaseViewModel<RoleVM> vm)
        {
            vm.SetList(db.Roles.AsQueryable(), "Name");
            return View(vm);
        }

        public IActionResult Details(int? id)
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
                    var obj = db.Roles.Add(role.GetEntity());

                    var mnuLst = role.MenusJson.DeserializeJson<List<int>>();

                    foreach (var det in mnuLst)
                    {
                        obj.Menus.Add(db.Menus.Find(det));
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

                    var obj = db.Roles.Find(role.RoleID);
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

                    obj.Menus.Clear();
                    foreach (var det in mnuLst)
                    {
                        obj.Menus.Add(db.Menus.Find(det));
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
                var obj = db.Roles.Find(role.RoleID);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }
                db.Detach(obj);
                
                var entry = db.Entry(role.GetEntity());
                entry.State = EntityState.Unchanged;

                entry.Entity.Menus.Clear();
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
            return RedirectToAction("Details", new { id = role.RoleID });
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
                Role role = db.Roles.Where(x => x.RoleID == id).FirstOrDefault();
                if (role == null)
                {
                    return HttpNotFound();
                }
                obj = new RoleVM(role);
            }

            ViewBag.IsToEdit = isToEdit;
            ViewBag.RoleID = obj.RoleID;
            return PartialView("_ChildIndex", obj.MenusList);
        }
    }
}