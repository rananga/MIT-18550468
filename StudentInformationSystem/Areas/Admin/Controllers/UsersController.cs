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
    [ExtendedAuthorize(Roles = RoleConstants.AdminUser)]
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
            UserRoleVM userRole = obj.DetailsList.Where(x => x.UserRoleId == id.Value).FirstOrDefault();
            if (userRole == null)
            {
                return HttpNotFound();
            }
            return PartialView("_ChildDetails", userRole);
        }

        public ActionResult Create()
        {
            var user = new UserVM() { Status = ActiveState.Active };
            Session[sskCrtdObj] = user;
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ExtendedAuthorize(Roles = RoleConstants.AdminUser)]
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
                var accCount = (user.StaffId == null ? 0 : 1) + (user.VisitorId == null ? 0 : 1) + (user.ParentId == null ? 0 : 1) + (user.StudentId == null ? 0 : 1);
                if (accCount > 1)
                { ModelState.AddModelError("", "Only one can be selected from Staff Member, Visitor, Parent & Student."); }

                if (ModelState.IsValid)
                {
                    user.CreatedBy = this.GetCurrUser();
                    user.CreatedDate = DateTime.Now;
                    user.DetailsList = obj.DetailsList;
                    var newObj = db.Users.Add(user.GetEntity()).Entity;

                    foreach (var det in user.DetailsList)
                    {
                        newObj.UserRoles.Add(det.GetEntity());
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
            ViewBag.UserRoles = obj.DetailsList.Select(x => x.RoleId).ToList();

            var vm = new UserRoleVM() { UserId = userID.Value };
            return PartialView("_ChildCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChildCreate(UserRoleVM vm)
        {
            UserVM obj;
            try
            {
                if (ModelState.IsValid)
                {
                    obj = (UserVM)Session[sskCrtdObj];
                    var role = db.Roles.Find(vm.RoleId);
                    vm.RoleName = role.Name;
                    vm.UserRoleId = Math.Min(obj.DetailsList.Select(x => x.UserRoleId).MinOrDefault(), 0) - 1;
                    obj.DetailsList.Add(vm);

                    AddAlert(AlertStyles.success, "User role added successfully.");
                    string url = Url.Action("ChildIndex", new { id = vm.UserId, isToEdit = true });
                    return Json(new { success = true, url = url });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            obj = (UserVM)Session[sskCrtdObj];
            ViewBag.UserRoles = obj.DetailsList.Select(x => x.RoleId).ToList();

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
                var accCount = (user.StaffId == null ? 0 : 1) + (user.VisitorId == null ? 0 : 1) + (user.ParentId == null ? 0 : 1) + (user.StudentId == null ? 0 : 1);
                if (accCount > 1)
                { ModelState.AddModelError("", "Only one can be selected from Staff Member, Visitor, Parent & Student."); }

                if (ModelState.IsValid)
                {
                    var sUser = (UserVM)Session[sskCrtdObj];

                    var obj = db.Users.Find(user.Id);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = user.GetEntity();
                    var props = "UserName,Status,StaffId,VisitorId,ParentId,StudentId";
                    if (!user.Password.IsBlank())
                    { props += ",Password"; }
                    modObj.CopyContent(obj, props);

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.Entry(obj).OriginalValues["RowVersion"] = user.RowVersion;

                    db.UserRoles.RemoveRange(obj.UserRoles.Where(x =>
                        !sUser.DetailsList.Select(y => y.UserRoleId).ToList().Contains(x.UserRoleId)));

                    foreach (var det in sUser.DetailsList)
                    {
                        var objDet = db.UserRoles.Find(det.UserRoleId);
                        if (objDet == null)
                        {
                            db.UserRoles.Add(det.GetEntity());
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
                entry.Collection(x => x.UserRoles).Load();
                db.UserRoles.RemoveRange(entry.Entity.UserRoles);
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
                var obj = lst.FirstOrDefault(x => x.UserRoleId == id);
                lst.Remove(obj);

                AddAlert(AlertStyles.success, "User role removed successfully.");
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
            return PartialView("_ChildIndex", obj.DetailsList.OrderBy(x => x.RoleName));
        }
    }
}
