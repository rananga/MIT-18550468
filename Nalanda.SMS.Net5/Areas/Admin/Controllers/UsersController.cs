using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SMS.Common.DB;
using SMS.Areas.Base.Controllers;
using SMS.Common;
using SMS.Areas.Admin.Models;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using Microsoft.Extensions.Logging;
using Nalanda.SMS.Data;

namespace Nalanda.SMS.Controllers
{
    public class UsersController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public UsersController(dbNalandaContext dbContext, ILogger<HomeController> logger) : base(dbContext)
        {
            _logger = logger;
        }

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
            UserRoleVM userRole = obj.DetailsList.Where(x => x.UserRoleID == id.Value).FirstOrDefault();
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
        public ActionResult Create([Bind(Include = "UserID,UserName,Password,EmployeeID,Status,NavUserName,CallCenterUserName,DetailsList,BranchID,DepartmentID")] UserVM user)
        {
            try
            {
                var obj = (UserVM)Session[sskCrtdObj];
                var exUserName = db.Users.Where(e => e.UserName == user.UserName).FirstOrDefault();

                if (exUserName != null)
                { ModelState.AddModelError("", "User Name Already Exists."); }
                if (user.Password == null)
                { ModelState.AddModelError("", "Enter Password."); }

                if (ModelState.IsValid)
                {
                    user.CreatedBy = this.GetCurrUser();
                    user.CreatedDate = DateTime.Now;
                    user.DetailsList = obj.DetailsList;
                    db.Users.Add(user.GetEntity());

                    foreach (var det in user.DetailsList)
                    {
                        db.UserRoles.Add(det.GetEntity());
                    }
                    db.SaveChanges();

                    AddAlert(SMS.Common.AlertStyles.success, "User created successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

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
            ViewBag.UserRoles = obj.DetailsList.Select(x => x.RoleID).ToList();

            var userRole = new UserRoleVM() { UserID = userID.Value };
            return PartialView("_ChildCreate", userRole);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChildCreate([Bind(Include = "UserRoleID,UserID,RoleID,RoleName")] UserRoleVM userRole)
        {
            UserVM obj;
            try
            {
                if (ModelState.IsValid)
                {
                    obj = (UserVM)Session[sskCrtdObj];
                    var role = db.Roles.Find(userRole.RoleID);
                    userRole.RoleName = role.Name;
                    userRole.UserRoleID = Math.Min(obj.DetailsList.Select(x => x.UserRoleID).MinOrDefault(), 0) - 1;
                    obj.DetailsList.Add(userRole);

                    AddAlert(SMS.Common.AlertStyles.success, "User Role added successfully.");
                    string url = Url.Action("ChildIndex", new { id = userRole.UserID, isToEdit = true });
                    return Json(new { success = true, url = url });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            obj = (UserVM)Session[sskCrtdObj];
            ViewBag.UserRoles = obj.DetailsList.Select(x => x.RoleID).ToList();

            return PartialView("_ChildCreate", userRole);
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
        public ActionResult Edit([Bind(Include = "UserID,UserName,Password,EmployeeID,Status,RowVersion,NavUserName,CallCenterUserName,BranchID,DepartmentID")] UserVM user)
        {
            byte[] curRowVersion = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var sUser = (UserVM)Session[sskCrtdObj];

                    var obj = db.Users.Find(user.UserID);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = user.GetEntity();
                    var props = "EmployeeID,Status,CallCenterUserName,BranchID,DepartmentID";
                    if (!user.Password.IsBlank())
                    { props += ",Password"; }
                    modObj.CopyContent(obj, props);

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.Entry(obj).OriginalValues["RowVersion"] = user.RowVersion;

                    db.UserRoles.RemoveRange(obj.UserRoles.Where(x =>
                        !sUser.DetailsList.Select(y => y.UserRoleID).ToList().Contains(x.UserRoleID)));

                    foreach (var det in sUser.DetailsList)
                    {
                        var objDet = db.UserRoles.Find(det.UserRoleID);
                        if (objDet == null)
                        {
                            db.UserRoles.Add(det.GetEntity());
                        }
                    }
                    db.SaveChanges();

                    AddAlert(SMS.Common.AlertStyles.success, "User modified successfully.");
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
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(UserVM user)
        {
            try
            {
                var obj = db.Users.Find(user.UserID);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }
                db.Detach(obj);

                db.Entry(user.GetEntity()).State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(SMS.Common.AlertStyles.success, "User deleted successfully.");
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
            return RedirectToAction("Details", new { id = user.UserID });
        }

        [HttpPost, ActionName("ChildDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ChildDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            try
            {
                var lst = ((UserVM)Session[sskCrtdObj]).DetailsList;
                var obj = lst.FirstOrDefault(x => x.UserRoleID == id);
                lst.Remove(obj);

                AddAlert(SMS.Common.AlertStyles.success, "User Role removed successfully.");
            }
            catch (Exception ex)
            {
                msg = ex.GetInnerException().Message;
                AddAlert(SMS.Common.AlertStyles.danger, msg);
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
                User user = db.Users.Where(x => x.UserID == id).FirstOrDefault();
                if (user == null)
                {
                    return HttpNotFound();
                }
                obj = new UserVM(user);
            }

            ViewBag.IsToEdit = isToEdit;
            ViewBag.UserID = obj.UserID;
            return PartialView("_ChildIndex", obj.DetailsList.OrderBy(x => x.RoleName));
        }

        public ActionResult EncryptUserPasswords()
        {
            try
            {
                foreach (var usr in db.Users)
                {
                    var pw = usr.Password.Decrypt();
                    if (pw == usr.Password)
                    {
                        usr.Password = usr.Password.Encrypt();
                    }
                }
                db.SaveChanges();
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }
    }
}
