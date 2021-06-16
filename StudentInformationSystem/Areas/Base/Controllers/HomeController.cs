using Microsoft.EntityFrameworkCore;
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
                DataURL = Url.Action("GetStudentAdmissions", "Home", new { area = "Base" }),
                ColorClass = "tile4",
                IconURL = Url.Content("~/Content/Images/interview.png")
            });
            lst.Add(new TileData()
            {
                Text = "Teacher Management",
                LandingURL = Url.Action("Index", "Teacher", new { area = "Admin" }),
                DataURL = Url.Action("GetTeachers", "Home", new { area = "Base" }),
                ColorClass = "tile2",
                IconURL = Url.Content("~/Content/Images/LecHrs.png")
            });
            lst.Add(new TileData()
            {
                Text = "Class Management",
                LandingURL = Url.Action("Index", "Class", new { area = "Admin" }),
                //DataURL = Url.Action("GetUserLeaveApprovals", "Home", new { area = "Base" }),
                ColorClass = "tile5",
                IconURL = Url.Content("~/Content/Images/studentProgress.png")
            });
            //lst.Add(new TileData()
            //{
            //    Text = "Student Attendance Management",
            //    LandingURL = Url.Action("Index", "StudAttendance", new { area = "Student" }),
            //    //DataURL = Url.Action("GetUserLieuLeaveApprovals", "Home", new { area = "Base" }),
            //    ColorClass = "tile5",
            //    IconURL = Url.Content("~/Content/Images/check-list.png")
            //});

            //lst.Add(new TileData()
            //{
            //    Text = "Student Promotion",
            //    LandingURL = Url.Action("Index", "StudentPromotion", new { area = "Student" }),
            //    //DataURL = Url.Action("GetDailyPerformanceDG", "Home", new { area = "Base" }),
            //    ColorClass = "tile3",
            //    IconURL = Url.Content("~/Content/Images/success.png")
            //});
            //lst.Add(new TileData()
            //{
            //    Text = "Student Club Membership",
            //    LandingURL = Url.Action("Index", "StudentClubMembership", new { area = "Student" }),
            //    //DataURL = Url.Action("GetDailyPerformanceDG", "Home", new { area = "Base" }),
            //    ColorClass = "tile1",
            //    IconURL = Url.Content("~/Content/Images/restaurant-membership-card-tool.png")
            //});

            //lst.Add(new TileData()
            //{
            //    Text = "Intake Summary Report",
            //    LandingURL = Url.Action("IntakeSummary", "Reports", new { area = "Admin" }),
            //   // DataURL = Url.Action("GetStudentAdmissions", "Home", new { area = "Base" }),
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
            if (!ModelState.IsValid)
            { return View(signInVM); }

            var lst = db.Users.Where(x => x.UserName.ToLower() == signInVM.UserName.ToLower()).ToList();
            var obj = lst.Where(x => x.Password.Decrypt() == signInVM.Password).FirstOrDefault();

            if (obj == null)
            {
                AddAlert(AlertStyles.danger, "The user name or password provided is incorrect.");
                return View(signInVM);
            }
            if (obj.Status == ActiveState.Inactive)
            {
                AddAlert(AlertStyles.warning, "The user \"" + obj.UserName + "\" is inactive. Please contact IT Administrator.");
                return View(signInVM);
            }

            var jser = new JavaScriptSerializer();
            var lstRoles = db.UserRoles.Include(x => x.Role).Where(x => x.UserId == obj.Id).Select(x => x.Role.Code).ToList();

            var authTicket = new FormsAuthenticationTicket(
                1,
                obj.UserName,
                DateTime.Now,
                DateTime.Now.AddMinutes(20),
                signInVM.RememberMe,
                jser.Serialize(new { userName = obj.UserName, roles = lstRoles }));

            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(authCookie);
            Session[sskCurUsrID] = obj.Id;

            if (Url.IsLocalUrl(ReturnUrl) && ReturnUrl.Length > 1 && ReturnUrl.StartsWith("/")
                && !ReturnUrl.StartsWith("//") && !ReturnUrl.StartsWith("/\\"))
            { return Redirect(ReturnUrl); }
            else
            { return RedirectToAction("Index", "Home"); }
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
        public ActionResult ChangePassword([Bind(Include = "UserID,PassWord,NewPassword,ConfirmPassword")] SignInVM signInVM)
        {
            var objUser = db.Users.Find(signInVM.Id);

            if (objUser.Password.Decrypt() != signInVM.Password)
            { ModelState.AddModelError("Password", "Incorrect password."); }
            else if (signInVM.Password == signInVM.NewPassword)
            { ModelState.AddModelError("NewPassword", "New password is same as the current password."); }
            else if (signInVM.ConfirmPassword != signInVM.NewPassword)
            { ModelState.AddModelError("ConfirmPassword", "Confirm password should be equal to new password."); }

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
            var path = Server.MapPath("~/Content/Images/school_logo.png");
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