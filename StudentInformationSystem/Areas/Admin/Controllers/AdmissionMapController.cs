using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Areas.Admin.Models;
using StudentInformationSystem.Areas.Base;
using StudentInformationSystem.Common;
using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentInformationSystem.Areas.Admin.Controllers
{
    [ExtendedAuthorize(Roles = "AdminUser,AdmissionMap")]
    public class AdmissionMapController : BaseController
    {
        public ActionResult Index()
        {
            var vm = new AdmissionMapVM
            {
                SchoolLocationLatitude = decimal.Parse(db.SystemParameters.Where(x => x.Key == ParameterConstants.SchoolLocationLatitude).Select(x => x.Value).FirstOrDefault()),
                SchoolLocationLongitude = decimal.Parse(db.SystemParameters.Where(x => x.Key == ParameterConstants.SchoolLocationLongitude).Select(x => x.Value).FirstOrDefault())
            };
            return View(vm);
        }

        public ActionResult ChildDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var obj = (AdmissionMapVM)Session[sskCrtdObj];
            NearbySchoolVM nearbySchool = obj.NearbySchools.Where(x => x.Id == id.Value).FirstOrDefault();
            if (nearbySchool == null)
            {
                return HttpNotFound();
            }
            return PartialView("_ChildDetails", nearbySchool);
        }

        public ActionResult ChildCreate()
        {
            var vm = new NearbySchoolVM { IsActive = true };
            return PartialView("_ChildCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChildCreate(NearbySchoolVM vm)
        {
            AdmissionMapVM obj;
            try
            {
                if (ModelState.IsValid)
                {
                    obj = (AdmissionMapVM)Session[sskCrtdObj];
                    vm.Id = Math.Min(obj.NearbySchools.Select(x => x.Id).MinOrDefault(), 0) - 1;
                    obj.NearbySchools.Add(vm);

                    AddAlert(AlertStyles.success, "Nearby school added successfully.");
                    string url = Url.Action("ChildIndex", new { isToEdit = true });
                    return Json(new { success = true, url });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return PartialView("_ChildCreate", vm);
        }

        public ActionResult Edit()
        {
            var obj = new AdmissionMapVM
            {
                SchoolLocationLatitude = decimal.Parse(db.SystemParameters.Where(x => x.Key == ParameterConstants.SchoolLocationLatitude).Select(x => x.Value).FirstOrDefault()),
                SchoolLocationLongitude = decimal.Parse(db.SystemParameters.Where(x => x.Key == ParameterConstants.SchoolLocationLongitude).Select(x => x.Value).FirstOrDefault()),
                NearbySchools = db.NearbySchools.Select(x => new NearbySchoolVM(x)).ToList()
            };
            Session[sskCrtdObj] = obj;
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AdmissionMapVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var svm = (AdmissionMapVM)Session[sskCrtdObj];

                    var sysParaLat = db.SystemParameters.Where(x => x.Key == ParameterConstants.SchoolLocationLatitude).First();
                    var sysParaLng = db.SystemParameters.Where(x => x.Key == ParameterConstants.SchoolLocationLongitude).First();

                    sysParaLat.Value = vm.SchoolLocationLatitude.ToString();
                    sysParaLng.Value = vm.SchoolLocationLongitude.ToString();

                    db.NearbySchools.RemoveRange(db.NearbySchools.Where(x =>
                        !svm.NearbySchools.Select(y => y.Id).ToList().Contains(x.Id)));

                    foreach (var det in svm.NearbySchools)
                    {
                        var objDet = db.NearbySchools.Find(det.Id);
                        if (objDet == null)
                        {
                            det.CreatedBy = this.GetCurrUser();
                            det.CreatedDate = DateTime.Now;
                            db.NearbySchools.Add(det.GetEntity());
                        }
                    }

                    var activityChanges = vm.ActivityChangesJson.DeserializeJson<List<NearbySchool>>();
                    foreach (var changeObj in activityChanges)
                    {
                        var objDet = db.NearbySchools.Find(changeObj.Id);
                        if (objDet != null)
                        {
                            objDet.IsActive = changeObj.IsActive;
                        }
                    }

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Admission map details saved successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.ShowConcurrencyErrors(ex);
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(vm);
        }

        [HttpPost, ActionName("ChildDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ChildDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            try
            {
                var lst = ((AdmissionMapVM)Session[sskCrtdObj]).NearbySchools;
                var obj = lst.FirstOrDefault(x => x.Id == id);
                lst.Remove(obj);

                AddAlert(AlertStyles.success, "Nearby school removed successfully.");
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

        public ActionResult ChildIndex(bool isToEdit = false)
        {
            AdmissionMapVM obj;

            if (isToEdit && Session[sskCrtdObj] is AdmissionMapVM)
            { obj = (AdmissionMapVM)Session[sskCrtdObj]; }
            else
            {
                obj = new AdmissionMapVM
                {
                    SchoolLocationLatitude = decimal.Parse(db.SystemParameters.Where(x => x.Key == ParameterConstants.SchoolLocationLatitude).Select(x => x.Value).FirstOrDefault()),
                    SchoolLocationLongitude = decimal.Parse(db.SystemParameters.Where(x => x.Key == ParameterConstants.SchoolLocationLongitude).Select(x => x.Value).FirstOrDefault()),
                    NearbySchools = db.NearbySchools.Select(x => new NearbySchoolVM(x)).ToList()
                };
            }

            ViewBag.IsToEdit = isToEdit;
            return PartialView("_ChildIndex", obj.NearbySchools.OrderBy(x => x.DisplayName));
        }

        public ActionResult Circle()
        {
            var schoolPos = new
            {
                lat = decimal.Parse(db.SystemParameters.Where(x => x.Key == ParameterConstants.SchoolLocationLatitude).Select(x => x.Value).FirstOrDefault()),
                lng = decimal.Parse(db.SystemParameters.Where(x => x.Key == ParameterConstants.SchoolLocationLongitude).Select(x => x.Value).FirstOrDefault())
            };

            var schools = db.NearbySchools.Where(x=> x.IsActive).Select(x => new { text = x.DisplayName, lat = x.Latitude, lng = x.Longitude }).ToList();

            ViewBag.SchoolLocationJson = schoolPos.SerializeToJson();
            ViewBag.NearbySchoolsJson = schools.SerializeToJson();

            return View();
        }
    }
}
