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
    [ExtendedAuthorize(Roles = RoleConstants.AdminUser)]
    public class RoleController : BaseController
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
            var vm = new RoleVM();
            Session[sskCrtdObj] = vm;
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoleVM role)
        {
            try
            {
                if (role.Name == null)
                { ModelState.AddModelError("Name", "Name field is required"); }
                if (role.Code == null)
                { ModelState.AddModelError("Code", "Code field is required"); }

                if (ModelState.IsValid)
                {
                    role.CreatedBy = this.GetCurrUser();
                    role.CreatedDate = DateTime.Now;
                    var obj = db.Roles.Add(role.GetEntity()).Entity;

                    var mnuLst = role.MenusJson.DeserializeJson<List<MenusJsonItem>>();

                    foreach (var itm in mnuLst)
                    {
                        obj.RoleMenuAccesses.Add(new RoleMenuAccess() { RoleId = obj.RoleId, MenuId = itm.MenuId, ActionId = itm.ActionId });
                    }

                    var grdLst = role.GradesJson.DeserializeJson<List<int>>();

                    foreach (var det in grdLst)
                    {
                        obj.RoleGradeAccesses.Add(new RoleGradeAccess() { RoleId = obj.RoleId, GradeId = det });
                    }

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "User role created successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

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
        public ActionResult Edit(RoleVM role)
        {
            byte[] curRowVersion = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var svm = (RoleVM)Session[sskCrtdObj];

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

                    var mnuLst = role.MenusJson.DeserializeJson<List<MenusJsonItem>>();

                    db.RoleMenuAccesses.RemoveRange(obj.RoleMenuAccesses.Where(x => !mnuLst.Any(y => y.MenuId == x.MenuId && y.ActionId == x.ActionId)));
                    mnuLst = mnuLst.Where(x=> !obj.RoleMenuAccesses.Any(y=> y.MenuId == x.MenuId && y.ActionId == x.ActionId)).ToList();
                    foreach (var itm in mnuLst)
                    {
                        obj.RoleMenuAccesses.Add(new RoleMenuAccess() { RoleId = obj.RoleId, MenuId = itm.MenuId, ActionId = itm.ActionId });
                    }

                    var grdLst = role.GradesJson.DeserializeJson<List<int>>();

                    db.RoleGradeAccesses.RemoveRange(obj.RoleGradeAccesses.Where(x => !grdLst.Contains(x.GradeId)));
                    grdLst = grdLst.Except(obj.RoleGradeAccesses.Select(x => x.GradeId)).ToList();
                    foreach (var det in grdLst)
                    {
                        obj.RoleGradeAccesses.Add(new RoleGradeAccess() { RoleId = obj.RoleId, GradeId = det });
                    }

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "User role modified successfully.");
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
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

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
                entry.Collection(x => x.RoleGradeAccesses).Load();
                db.RoleGradeAccesses.RemoveRange(entry.Entity.RoleGradeAccesses);
                entry.State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "User role deleted successfully.");
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

        public ActionResult GradeIndex(int? id, bool isToEdit = false)
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
            var gradesList = db.Grades.ToList();

            ViewBag.IsToEdit = isToEdit;
            ViewBag.RoleID = obj.RoleId;
            return PartialView("_GradeIndex", gradesList);
        }
    }
}