using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nalanda.SMS.Data;
using Nalanda.SMS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Nalanda.SMS.Common;

namespace Nalanda.SMS.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(dbNalandaContext dbContext, ILogger<HomeController> logger) : base(dbContext)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        public IActionResult SignIn()
        {
            if (User != null && User.Identity != null && User.Identity.IsAuthenticated && CurUserID != 0)
            { return RedirectToAction("Index", "Home"); }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInVM signInVM, string ReturnUrl)
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

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, obj.UserName),
                new Claim(ClaimTypes.Sid, obj.UserId.ToString())
            };

            var roleClaims = db.UserRoles.Include(x => x.Role).Where(x => x.UserId == obj.UserId).Select(x => new Claim(ClaimTypes.Role, x.Role.Code)).ToList();
            claims.AddRange(roleClaims);

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            if (Url.IsLocalUrl(ReturnUrl) && ReturnUrl.Length > 1 && ReturnUrl.StartsWith("/")
                && !ReturnUrl.StartsWith("//") && !ReturnUrl.StartsWith("/\\"))
            { return Redirect(ReturnUrl); }
            else
            { return RedirectToAction("Index", "Home"); }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("SignIn", "Home");
        }
    }
}
