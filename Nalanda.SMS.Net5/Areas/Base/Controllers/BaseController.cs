using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Nalanda.SMS.Common;
using Nalanda.SMS.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Claims;

namespace Nalanda.SMS.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected dbNalandaContext db;

        public BaseController(dbNalandaContext dbContext)
        {
            db = dbContext;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public void AddAlert(AlertStyles alertStyle, string message, bool dismissable = true, bool renderOnTop = true)
        {
            var alerts = TempData.ContainsKey(Alert.TempDataKey)
                ? (List<Alert>)TempData[Alert.TempDataKey]
                : new List<Alert>();

            alerts.Add(new Alert
            {
                AlertStyle = alertStyle.ToString(),
                Message = message,
                Dismissable = dismissable,
                RenderOnTop = renderOnTop
            });

            TempData[Alert.TempDataKey] = alerts;
        }

        public ActionResult GetPopUpSelector(string dataUrl, string dlgID)
        {
            ViewBag.DataUrl = dataUrl;
            ViewBag.DialogID = dlgID + "_content";
            return PartialView("~/Areas/Base/Views/Shared/_PartialPopupSelector.cshtml");
        }

        public void ShowEntityErrors(DbEntityValidationException EntValEx)
        {
            foreach (var validationErrors in EntValEx.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    AddAlert(SMS.Common.AlertStyles.warning,
                        string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage));
                }
            }
        }

        public void ShowConcurrencyErrors(DbUpdateConcurrencyException UpdConcEx, bool forDelete = false)
        {
            if (UpdConcEx.Message.In("", "Data Exception."))
            {
                if (forDelete)
                { AddAlert(SMS.Common.AlertStyles.danger, "The record you attempted to delete was deleted by another user."); }
                else
                { ModelState.AddModelError(string.Empty, "Unable to save changes. The record was deleted by another user."); }
                return;
            }

            if (forDelete)
            {
                AddAlert(SMS.Common.AlertStyles.danger, "The record you attempted to delete "
                    + "was modified by another user after you got the original values. "
                    + "The delete operation was canceled and the current values in the "
                    + "database have been displayed. If you still want to delete this "
                    + "record, click the Delete button again. Otherwise "
                    + "click the Back to List hyperlink.");
                return;
            }

            foreach (var entry in UpdConcEx.Entries)
            {
                var clientValues = entry.Entity;
                var databaseEntry = entry.GetDatabaseValues();
                if (databaseEntry == null)
                {
                    ModelState.AddModelError(string.Empty, "Unable to save changes. The record was deleted by another user.");
                }
                else
                {
                    foreach (var pn in databaseEntry.Properties)
                    {
                        var pi = clientValues.GetType().GetProperty(pn.Name);

                        if (pi != null && databaseEntry[pn] != null && !databaseEntry[pn].Equals(pi.GetValue(clientValues)))
                        {
                            ModelState.AddModelError(pn.Name, "Current value: " + databaseEntry[pn]);
                        }
                    }

                    ModelState.AddModelError(string.Empty, "The record you attempted to edit "
                           + "was modified by another user after you got the original value. The "
                           + "edit operation was canceled and the current values in the database "
                           + "have been displayed. If you still want to edit this record, click "
                           + "the Save button again. Otherwise click the Back to List hyperlink.");
                }
            }
        }

        public string GetCurrUser()
        {
            var usr = User.Identity.Name.IsBlank() ? "Anonymous" : User.Identity.Name;
            try
            {
                IPAddress myIP = Request.HttpContext.Connection.RemoteIpAddress;
                IPHostEntry GetIPHost = Dns.GetHostEntry(myIP);
                List<string> compName = GetIPHost.HostName.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                return (compName.FirstOrDefault() ?? "Unknown") + "\\" + usr;
            }
            catch (Exception)
            {
                return Request.HttpContext.Connection.RemoteIpAddress + "\\" + usr;
            }
        }

        public int CurUserID
        {
            get
            {
                if (!User.Identity.IsAuthenticated)
                    return 0;
                else
                {
                    var claims = ClaimsPrincipal.Current.Identities.First().Claims.ToList();

                    var id = claims?.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Sid, StringComparison.OrdinalIgnoreCase))?.Value;
                    int.TryParse(id, out int retId);
                    return retId;
                }
            }
        }
    }
}