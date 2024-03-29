﻿using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Data;
using StudentInformationSystem.Areas.Base.Models;
using StudentInformationSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Security.Claims;

namespace StudentInformationSystem.Areas.Base
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Tiles = GetTilesList();
            return View();
        }

        private List<TileData> GetTilesList()
        {
            var lst = new List<TileData>();
            // tile1 - tile7

            lst.Add(new TileData()
            {
                Text = "Student Admission",
                LandingURL = Url.Action("Index", "Student", new { area = "Student" }),
                //DataURL = Url.Action("GetStudentAdmissions", "Home", new { area = "Base" }),
                ColorClass = "tile4",
                IconURL = "fas fa-user-graduate"
            });

            lst.Add(new TileData()
            {
                Text = "Staff Members",
                LandingURL = Url.Action("Index", "StaffMember", new { area = "Admin" }),
                //DataURL = Url.Action("GetTeachers", "Home", new { area = "Base" }),
                ColorClass = "tile2",
                IconURL = "fas fa-user-friends"
            });

            lst.Add(new TileData()
            {
                Text = "Physical Classrooms",
                LandingURL = Url.Action("Index", "ClassRoom", new { area = "Academic" }),
                //DataURL = Url.Action("GetUserLeaveApprovals", "Home", new { area = "Base" }),
                ColorClass = "tile5",
                IconURL = "fas fa-school"
            });

            lst.Add(new TileData()
            {
                Text = "Online Classrooms",
                LandingURL = Url.Action("Index", "OnlineClassRoom", new { area = "Online" }),
                //DataURL = Url.Action("GetUserLieuLeaveApprovals", "Home", new { area = "Base" }),
                ColorClass = "tile5",
                IconURL = "fas fa-chalkboard-teacher"
            });

            lst.Add(new TileData()
            {
                Text = "Online Time Table",
                LandingURL = Url.Action("Index", "OnlineTimeTable", new { area = "Online" }),
                //DataURL = Url.Action("GetDailyPerformanceDG", "Home", new { area = "Base" }),
                ColorClass = "tile3",
                IconURL = "fas fa-calendar-alt"
            });

            lst.Add(new TileData()
            {
                Text = "Weekly Summary By Grade",
                LandingURL = Url.Action("Process", "WeeklySummary", new { area = "Report" }),
                //DataURL = Url.Action("GetDailyPerformanceDG", "Home", new { area = "Base" }),
                ColorClass = "tile1",
                IconURL = "fas fa-chart-bar"
            });

            //lst.Add(new TileData()
            //{
            //    Text = "Intake Summary Report",
            //    LandingURL = Url.Action("IntakeSummary", "Reports", new { area = "Admin" }),
            //    // DataURL = Url.Action("GetStudentAdmissions", "Home", new { area = "Base" }),
            //    ColorClass = "tile4",
            //    IconURL = Url.Content("~/Content/Images/interview.png")
            //});

            //lst.Add(new TileData()
            //{
            //    Text = "Intake Comparison Report",
            //    LandingURL = Url.Action("IntakeComparison", "Reports", new { area = "Admin" }),
            //    // DataURL = Url.Action("GetStudentAdmissions", "Home", new { area = "Base" }),
            //    ColorClass = "tile1",
            //    IconURL = Url.Content("~/Content/Images/success.png")
            //});

            return lst;
        }

        [AllowAnonymous]
        public ActionResult AccessDenied()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult SignIn()
        {
            if (User != null && User.Identity != null && User.Identity.IsAuthenticated && Session[BaseController.sskCurUsrID] != null)
            { return RedirectToAction("Index", "Home"); }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(SignInVM signInVM, string ReturnUrl)
        {
            Data.Models.User user = null;

            if (!string.IsNullOrEmpty(signInVM.AccessToken))
            {
                Data.Models.Visitor visitor = null;
                Data.Models.Student student = null;
                var staff = db.StaffMembers.Where(x => x.SchoolEmail_MS.Trim().ToLower() == signInVM.UserEmail.Trim().ToLower()).FirstOrDefault();
                if (staff == null)
                {
                    visitor = db.Visitors.Where(x => x.SchoolEmail_MS.Trim().ToLower() == signInVM.UserEmail.Trim().ToLower()).FirstOrDefault();

                    if (visitor == null)
                        student = db.Students.Where(x => x.SchoolEmail_MS.Trim().ToLower() == signInVM.UserEmail.Trim().ToLower()).FirstOrDefault();
                }


                user = staff?.User ?? visitor?.User ?? student?.User;

                if (user == null)
                {
                    AddAlert(AlertStyles.warning, $"Access denied for user '{signInVM.UserEmail}'. Please contact support team to obtain the required access.");
                    return View(signInVM);
                }
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    var msg = ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).Aggregate((x, y) => x + "," + y);
                    AddAlert(AlertStyles.danger, msg);
                    return View(signInVM);
                }

                var lst = db.Users.Where(x => signInVM.UserName != null && x.UserName.ToLower() == signInVM.UserName.ToLower()).ToList();
                user = lst.Where(x => x.Password.Decrypt() == signInVM.Password).FirstOrDefault();

                if (user == null)
                {
                    AddAlert(AlertStyles.danger, "The user name or password provided is incorrect.");
                    return View(signInVM);
                }
                if (user.Status == ActiveState.Inactive)
                {
                    AddAlert(AlertStyles.warning, "The user \"" + user.UserName + "\" is inactive. Please contact IT Administrator.");
                    return View(signInVM);
                }
            }

            var jser = new JavaScriptSerializer();
            var lstRoles = db.UserRoles.Include(x => x.Role).Where(x => x.UserId == user.Id).Select(x => x.Role.Code).ToList();

            var authTicket = new FormsAuthenticationTicket(
                1,
                user.UserName,
                DateTime.Now,
                DateTime.Now.AddMinutes(20),
                signInVM.RememberMe,
                jser.Serialize(new { userName = user.UserName, roles = lstRoles }));

            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(authCookie);
            Session[sskCurUsrID] = user.Id;

            if (user.MustResetPassword == true)
                return RedirectToAction("ForcePasswordChange");

            if (Url.IsLocalUrl(ReturnUrl) && ReturnUrl.Length > 1 && ReturnUrl.StartsWith("/")
                && !ReturnUrl.StartsWith("//") && !ReturnUrl.StartsWith("/\\"))
            { return Redirect(ReturnUrl); }
            else
            { return RedirectToAction("Index", "Home"); }
        }

        public ActionResult ForcePasswordChange()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ForcePasswordChange([Bind(Include = "NewPassword,ConfirmPassword")] SignInVM signInVM)
        {
            var objUser = db.Users.Find(Session[sskCurUsrID]);
            var curPassword = objUser.Password.Decrypt();

            if (string.IsNullOrEmpty(signInVM.NewPassword))
            { AddAlert(AlertStyles.danger, "New password is required."); }
            else if (curPassword == signInVM.NewPassword)
            { AddAlert(AlertStyles.danger, "New password is same as the current password."); }
            else if (signInVM.ConfirmPassword != signInVM.NewPassword)
            { AddAlert(AlertStyles.danger, "Confirm password should be equal to new password."); }
            else
            {
                objUser.Password = signInVM.NewPassword.Encrypt();
                objUser.ModifiedBy = this.GetCurrUser();
                objUser.ModifiedDate = DateTime.Now;
                objUser.MustResetPassword = false;

                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("SignIn", "Home");
        }

        [AllowAnonymous]
        public ActionResult Error(int? id)
        {
            return View(id);
        }

        public ActionResult ChangePassword()
        {
            var user = db.Users.Find(CurUserID);
            if (user == null)
            {
                return HttpNotFound();
            }

            return PartialView("_ChangePassword", new SignInVM(user));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword([Bind(Include = "Id,PassWord,NewPassword,ConfirmPassword")] SignInVM signInVM)
        {
            var objUser = db.Users.Find(signInVM.Id);

            if (objUser.Password.Decrypt() != signInVM.Password)
            { ModelState.AddModelError("Password", "Incorrect password."); }
            else if (signInVM.Password == signInVM.NewPassword)
            { ModelState.AddModelError("NewPassword", "New password is same as the current password."); }
            else if (signInVM.ConfirmPassword != signInVM.NewPassword)
            { ModelState.AddModelError("ConfirmPassword", "Confirm password should be equal to new password."); }

            ModelState.Where(m => m.Key == "UserName").FirstOrDefault().Value.Errors.Clear();

            if (ModelState.IsValid)
            {
                objUser.Password = signInVM.NewPassword.Encrypt();
                objUser.ModifiedBy = this.GetCurrUser();
                objUser.ModifiedDate = DateTime.Now;

                db.SaveChanges();
                return Json(new { success = true });
            }

            return PartialView("_ChangePassword");
        }

        public ActionResult GetMyProfilePicture()
        {
            var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();
            var email = claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Email, StringComparison.OrdinalIgnoreCase))?.Value;

            return GetProfilePicture(email);
        }

        public ActionResult GetProfilePicture(string email)
        {
            var path = Server.MapPath("~/Content/Images/nalanda_logo.png");
            //if (string.IsNullOrEmpty(email))
            return File(path, "image/jpeg");

            //byte[] bytes;
            //using (var ms = GraphApiAccess.GetProfilePicture(email))
            //{
            //    if (ms == null)
            //        return File(path, "image/jpeg");
            //    bytes = ms.ToArray();
            //}

            //return File(bytes, "image/jpeg");
        }

        public ActionResult GetStudentAdmissions()
        {
            var studentAdmissions = db.Students.Select(e => new
            {
                StudentID = e.Id
            }).ToList();

            return Json(new { studentAdmissions, count = studentAdmissions.Count }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetTeachers()
        {
            var teachers = db.Teachers.Select(e => new
            {
                TeacherID = e.Id
            }).ToList();

            return Json(new { teachers, count = teachers.Count }, JsonRequestBehavior.AllowGet);
        }
        public class TileData
        {
            public string Text { get; set; }
            public string LandingURL { get; set; }
            public string DataURL { get; set; }
            public string ColorClass { get; set; }
            public string IconURL { get; set; }
            public bool OpenInNewTab { get; set; }
        }
    }
}