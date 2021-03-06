using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Areas.Admin.Models;
using StudentInformationSystem.Areas.Base;
using StudentInformationSystem.Common;
using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentInformationSystem.Areas.Admin.Controllers
{
    [ExtendedAuthorize(Roles = PermissionConstants.AdminUser)]
    public class UsersController : BaseController
    {
        public ActionResult Index(BaseViewModel<UserVM> vm)
        {
            vm.SetList(db.Users.AsQueryable(), "UserName");
            return View(vm);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(new UserVM(user));
        }

        public ActionResult ChildDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserVM obj = (UserVM)Session[sskCrtdObj];
            UserPermissionVM userPermission = obj.DetailsList.Where(x => x.UserPermissionId == id.Value).FirstOrDefault();
            if (userPermission == null)
            {
                return HttpNotFound();
            }
            return PartialView("_ChildDetails", userPermission);
        }

        public ActionResult Create()
        {
            var user = new UserVM() { Status = ActiveState.Active };
            Session[sskCrtdObj] = user;
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserVM user)
        {
            try
            {
                var obj = (UserVM)Session[sskCrtdObj];
                var exUserName = db.Users.Where(e => e.UserName == user.UserName).FirstOrDefault();

                if (exUserName != null)
                { ModelState.AddModelError("UserName", "User Name Already Exists."); }
                if (user.Password == null)
                { ModelState.AddModelError("Password", "Enter Password."); }
                if (user.StaffId != null && user.VisitorId != null)
                { ModelState.AddModelError("", "Cannot assign both staff member and visitor to the same user."); }

                if (ModelState.IsValid)
                {
                    user.CreatedBy = this.GetCurrUser();
                    user.CreatedDate = DateTime.Now;
                    user.DetailsList = obj.DetailsList;
                    var newObj = db.Users.Add(user.GetEntity()).Entity;

                    foreach (var det in user.DetailsList)
                    {
                        newObj.UserPermissions.Add(det.GetEntity());
                    }
                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "User created successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(user);
        }

        public ActionResult ChildCreate(int? userID)
        {
            if (userID != 0)
            {
                if (userID == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(userID);
                if (user == null)
                {
                    return HttpNotFound();
                }
            }

            var obj = (UserVM)Session[sskCrtdObj];
            ViewBag.UserPermissions = obj.DetailsList.Select(x => x.PermissionId).ToList();

            var vm = new UserPermissionVM() { UserId = userID.Value };
            return PartialView("_ChildCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChildCreate(UserPermissionVM vm)
        {
            UserVM obj;
            try
            {
                if (ModelState.IsValid)
                {
                    obj = (UserVM)Session[sskCrtdObj];
                    var permission = db.Permissions.Find(vm.PermissionId);
                    vm.PermissionName = permission.Name;
                    vm.UserPermissionId = Math.Min(obj.DetailsList.Select(x => x.UserPermissionId).MinOrDefault(), 0) - 1;
                    obj.DetailsList.Add(vm);

                    AddAlert(AlertStyles.success, "User Permission added successfully.");
                    string url = Url.Action("ChildIndex", new { id = vm.UserId, isToEdit = true });
                    return Json(new { success = true, url = url });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            obj = (UserVM)Session[sskCrtdObj];
            ViewBag.UserPermissions = obj.DetailsList.Select(x => x.PermissionId).ToList();

            return PartialView("_ChildCreate", vm);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            var obj = new UserVM(user);
            Session[sskCrtdObj] = obj;
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UserVM user)
        {
            byte[] curRowVersion = null;
            try
            {
                if (user.StaffId != null && user.VisitorId != null)
                { ModelState.AddModelError("", "Cannot assign both staff member and visitor to the same user."); }

                if (ModelState.IsValid)
                {
                    var sUser = (UserVM)Session[sskCrtdObj];

                    var obj = db.Users.Find(user.Id);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = user.GetEntity();
                    var props = "UserName,Status,StaffId,VisitorId";
                    if (!user.Password.IsBlank())
                    { props += ",Password"; }
                    modObj.CopyContent(obj, props);

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.Entry(obj).OriginalValues["RowVersion"] = user.RowVersion;

                    db.UserPermissions.RemoveRange(obj.UserPermissions.Where(x =>
                        !sUser.DetailsList.Select(y => y.UserPermissionId).ToList().Contains(x.UserPermissionId)));

                    foreach (var det in sUser.DetailsList)
                    {
                        var objDet = db.UserPermissions.Find(det.UserPermissionId);
                        if (objDet == null)
                        {
                            db.UserPermissions.Add(det.GetEntity());
                        }
                    }
                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "User modified successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.ShowConcurrencyErrors(ex);
                user.RowVersion = curRowVersion;
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(UserVM user)
        {
            try
            {
                var obj = db.Users.Find(user.Id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }
                db.Detach(obj);

                var entry = db.Entry(user.GetEntity());
                entry.State = EntityState.Unchanged;
                entry.Collection(x => x.UserPermissions).Load();
                db.UserPermissions.RemoveRange(entry.Entity.UserPermissions);
                entry.State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "User deleted successfully.");
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
            return RedirectToAction("Details", new { id = user.Id });
        }

        [HttpPost, ActionName("ChildDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ChildDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            try
            {
                var lst = ((UserVM)Session[sskCrtdObj]).DetailsList;
                var obj = lst.FirstOrDefault(x => x.UserPermissionId == id);
                lst.Remove(obj);

                AddAlert(AlertStyles.success, "User Permission removed successfully.");
            }
            catch (Exception ex)
            {
                msg = ex.GetInnerException().Message;
                AddAlert(AlertStyles.danger, msg);
            }
            string url = "";
            if (msg.IsBlank())
            { url = Url.Action("ChildIndex", new { isToEdit = true }); }
            return Json(new { success = true, url = url, msg });
        }

        public ActionResult ChildIndex(int? id, bool isToEdit = false)
        {
            UserVM obj;

            if (isToEdit && Session[sskCrtdObj] is UserVM)
            { obj = (UserVM)Session[sskCrtdObj]; }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Where(x => x.Id == id).FirstOrDefault();
                if (user == null)
                {
                    return HttpNotFound();
                }
                obj = new UserVM(user);
            }

            ViewBag.IsToEdit = isToEdit;
            ViewBag.UserID = obj.Id;
            return PartialView("_ChildIndex", obj.DetailsList.OrderBy(x => x.PermissionName));
        }
    }
}
