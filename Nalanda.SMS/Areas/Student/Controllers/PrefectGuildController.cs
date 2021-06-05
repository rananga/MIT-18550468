using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WebForms;
using Nalanda.SMS.Data;
using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Areas.Base;
using Nalanda.SMS.Areas.Student.Models;
using Nalanda.SMS.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Nalanda.SMS.Areas.Student.Controllers
{
    public class PrefectGuildController : BaseController
    {
        // GET: Student/PrefectGuild
        public ActionResult Index(BaseViewModel<PrefectVM> vm)
        {
            vm.SetList(db.Prefects.AsQueryable(), "PreID", SortDirection.Descending);
            return View(vm);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prefect prefGuild = db.Prefects.Find(id);
            if (prefGuild == null)
            {
                return HttpNotFound();
            }

            var prefectGuildVM = new PrefectVM(prefGuild);
            Session[sskCrtdObj] = prefectGuildVM;
            return View(prefectGuildVM);
        }

        public ActionResult Create()
        {
            PrefectVM prefectVm = prefectVm = new PrefectVM();
            prefectVm.EffectiveDate = DateTime.Now.Date;
            prefectVm.PromotedDate = DateTime.Now.Date;
            Session[sskCrtdObj] = prefectVm;
            return View(prefectVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PreID,StudID,PrefClassID,Type,EffectiveDate,IsHP,IsDHP,Responsibilty,IsPromoted,PromotedDate,Status,InactiveDate,InactiveReason,ClassGrade,PrefGuildJson")] PrefectVM prefGuildVM)
        {
            try
            {
                var objSession = (PrefectVM)Session[sskCrtdObj];
                objSession.StudID = prefGuildVM.StudID;
                UpdatePrefects(prefGuildVM.PrefGuildJson);

                prefGuildVM.InactiveReason = objSession.InactiveReason;
                prefGuildVM.InactiveDate = objSession.InactiveDate;

                if (prefGuildVM.StudID == 0 || prefGuildVM.PrefClassID == 0)
                { ModelState.AddModelError("StudID", "Student should be selected"); }

                if (prefGuildVM.IsPromoted && prefGuildVM.PromotedDate == null)
                { ModelState.AddModelError("PromotedDate", "Promoted Date should be selected"); }

                if (prefGuildVM.Status == ActiveState.Inactive && prefGuildVM.InactiveReason == null)
                { ModelState.AddModelError("InactiveReason", "Inactive Reason should be filled"); }

                if (prefGuildVM.Status == ActiveState.Inactive && prefGuildVM.InactiveDate == null)
                { ModelState.AddModelError("InactiveDate", "Inactive Date should be selected"); }

                var existPrefGuild = db.Prefects.Where(x => x.StudId == prefGuildVM.StudID && x.PrefClassId == prefGuildVM.PrefClassID && x.Type == prefGuildVM.Type
                         && x.EffectiveDate == prefGuildVM.EffectiveDate && x.IsHp == prefGuildVM.IsHP && x.IsDhp == prefGuildVM.IsDHP && x.Responsibilty == prefGuildVM.Responsibilty
                         && x.IsPromoted == prefGuildVM.IsPromoted && x.PromotedDate == prefGuildVM.PromotedDate && x.Status == prefGuildVM.Status
                         && x.InactiveDate == prefGuildVM.InactiveDate && x.InactiveReason == prefGuildVM.InactiveReason).FirstOrDefault();

                if (existPrefGuild != null)
                { ModelState.AddModelError("", "Existing Prefect"); }

                var existActivePref = db.Prefects.Where(x => x.StudId == prefGuildVM.StudID && x.Status == prefGuildVM.Status).FirstOrDefault();
                if (existActivePref != null)
                { ModelState.AddModelError("", "Existing Active Prefect"); }

                var existTypePref = db.Prefects.Where(x => x.StudId == prefGuildVM.StudID && x.Status != prefGuildVM.Status && x.Type == prefGuildVM.Type).FirstOrDefault();
                if (existTypePref != null)
                { ModelState.AddModelError("", "Existing Student with same Prefect Type"); }


                Session[sskCrtdObj] = objSession;

                if (ModelState.IsValid)
                {
                    prefGuildVM.CreatedBy = this.GetCurrUser();
                    prefGuildVM.CreatedDate = DateTime.Now;
                    prefGuildVM.InactiveDate = null;
                    var dbPrefGdID = db.Prefects.Add(prefGuildVM.GetEntity()).Entity;
                    db.SaveChanges();

                    AddAlert(SMS.Common.AlertStyles.success, "Prefect created successfully.");
                    return RedirectToAction("Details", new { id = dbPrefGdID.PreId });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            return View(prefGuildVM);
        }

        public JsonResult UpdatePrefects(string dataJson)
        {
            try
            {
                if (!(Session[sskCrtdObj] is PrefectVM))
                { throw new Exception("Session expired."); }

                var objVM = (PrefectVM)Session[sskCrtdObj];
                var lst = new JavaScriptSerializer().Deserialize<List<Dictionary<string, object>>>(dataJson);

                var dct = lst.Where(x => x["id"].ToString() == objVM.StudID.ToString()).FirstOrDefault();

                objVM.InactiveReason = dct["InactiveReason"].ConvertTo<string>();
                objVM.InactiveDate = dct["InactiveDate"].ConvertTo<DateTime>();
            }
            catch (Exception ex)
            { return Json("Error : " + ex.Message, JsonRequestBehavior.AllowGet); }

            return Json("Success", JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetStudClass(int studID)
        {
            var obj = db.ClassStudents.Where(x => x.StudentId == studID).ToList().OrderByDescending(x => x.Id).FirstOrDefault();

            //var ClassID = obj.PromotionClass.PrClId;
            var IndexNo = obj.Student.IndexNo;
            var InitName = obj.Student.Title.ToEnumChar() + ". " + obj.Student.Initials + " " + obj.Student.Lname;
            //var ClassGrade = obj.PromotionClass.Class.Grade.ToEnumChar() + " - " + obj.PromotionClass.Class.ClassDesc;

            return Json(new { IndexNo, InitName, ClassGrade = "", ClassID = "" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prefect prefGuild = db.Prefects.Find(id);
            if (prefGuild == null)
            {
                return HttpNotFound();
            }
            var obj = new PrefectVM(prefGuild);
            Session[sskCrtdObj] = obj;

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PreID,StudID,PrefClassID,Type,EffectiveDate,IsHP,IsDHP,Responsibilty,IsPromoted,PromotedDate,Status,InactiveDate,InactiveReason,ClassGrade,RowVersion,PrefGuildJson")] PrefectVM prefGuild)
        {
            byte[] curRowVersion = null;
            try
            {
                var objSession = (PrefectVM)Session[sskCrtdObj];
                objSession.StudID = prefGuild.StudID;
                UpdatePrefects(prefGuild.PrefGuildJson);

                prefGuild.InactiveReason = objSession.InactiveReason;
                prefGuild.InactiveDate = objSession.InactiveDate;

                if (prefGuild.StudID == 0 || prefGuild.PrefClassID == 0)
                { ModelState.AddModelError("StudID", "Student should be selected"); }

                if (prefGuild.IsPromoted && prefGuild.PromotedDate == null)
                { ModelState.AddModelError("PromotedDate", "Promoted Date should be selected"); }

                if (prefGuild.Status == ActiveState.Inactive && prefGuild.InactiveReason == null)
                { ModelState.AddModelError("InactiveReason", "Inactive Reason should be filled"); }

                if (prefGuild.Status == ActiveState.Inactive && prefGuild.InactiveDate == null)
                { ModelState.AddModelError("InactiveDate", "Inactive Date should be selected"); }

                var existPrefGuild = db.Prefects.Where(x => x.StudId == prefGuild.StudID && x.PrefClassId == prefGuild.PrefClassID && x.Type == prefGuild.Type
                        && x.EffectiveDate == prefGuild.EffectiveDate && x.IsHp == prefGuild.IsHP && x.IsDhp == prefGuild.IsDHP && x.Responsibilty == prefGuild.Responsibilty
                        && x.IsPromoted == prefGuild.IsPromoted && x.PromotedDate == prefGuild.PromotedDate && x.Status == prefGuild.Status
                        && x.InactiveDate == prefGuild.InactiveDate && x.InactiveReason == prefGuild.InactiveReason).FirstOrDefault();


                if (ModelState.IsValid)
                {
                    var obj = db.Prefects.Find(prefGuild.PreID);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;

                    var modObjDet = prefGuild.GetEntity();
                    modObjDet.CopyContent(obj, "PrefClassID,Type,EffectiveDate,IsHP,IsDHP,Responsibilty,IsPromoted,PromotedDate,Status,InactiveDate,InactiveReason");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;
                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Prefect modified successfully.");
                    return RedirectToAction("Details", new { id = prefGuild.PreID });
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.ShowConcurrencyErrors(ex);
                prefGuild.RowVersion = curRowVersion;
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(prefGuild);
        }

        public ActionResult PrefectDetails()
        {
            List<Prefect> prefGuildList = db.Prefects.Where(x => x.Status == ActiveState.Active).ToList();
            if (prefGuildList == null)
            {
                return HttpNotFound();
            }

            var prefectVM = new PrefectVM();
            prefectVM.SeniorCount = prefGuildList.Where(x => x.Type == PrefectType.Senior).Count();
            prefectVM.JuniorCount = prefGuildList.Where(x => x.Type == PrefectType.Junior).Count();
            prefectVM.PendingCount = prefGuildList.Where(x => x.Type == PrefectType.PendingPrefect).Count();

            Session[sskCrtdObj] = prefectVM;
            return View(prefectVM);
        }

        public ActionResult ChildIndex(int? id, bool isSenior = false, bool isJunior = false, bool isPending = false)
        {
            var obj = new List<PrefectVM>();

            var prefectList = new List<Prefect>();
            if (isSenior)
            {
                prefectList = db.Prefects.Where(x => x.Status == ActiveState.Active && x.Type == PrefectType.Senior).ToList();
            }
            if (isJunior)
            {
                prefectList = db.Prefects.Where(x => x.Status == ActiveState.Active && x.Type == PrefectType.Junior).ToList();
            }
            if (isPending)
            {
                prefectList = db.Prefects.Where(x => x.Status == ActiveState.Active && x.Type == PrefectType.PendingPrefect).ToList();
            }
            foreach (var det in prefectList)
            {
                //var TempPrefect = new PrefectVM(det);
                //var objTemp = db.ClassStudents.Where(x => x.StudentId == det.StudId).ToList().OrderByDescending(x => x.Id).FirstOrDefault();

                //TempPrefect.PrefClassID = objTemp.PromotionClass.PrClId;
                //TempPrefect.ClassGrade = objTemp.PromotionClass.Class.Grade.ToEnumChar() + " - " + objTemp.PromotionClass.Class.ClassDesc;

                //obj.Add(TempPrefect);
            }

            ViewBag.IsSenior = isSenior;
            ViewBag.isJunior = isJunior;
            ViewBag.isPending = isPending;

            return PartialView("_ChildIndex", obj);
        }

        public ActionResult PrintCurPrefGuild()
        {

            var lstSenDet = db.Prefects.Where(x => x.Status == ActiveState.Active && x.Type == PrefectType.Senior).Select(x => new
            {
                AdmissionNo = x.Student.IndexNo,
                Student = x.Student.Title + ". " + x.Student.Initials + " " + x.Student.Lname,
                Class = "Grade " + x.PromotionClass.Class.Grade + " - " + x.PromotionClass.Class.Name,
                x.Responsibilty,
                HP = x.IsHp == true ? "Yes" : "-",
                DHP = x.IsDhp == true ? "Yes" : "-"
            }).ToList();

            var lstJunDet = db.Prefects.Where(x => x.Status == ActiveState.Active && x.Type == PrefectType.Junior).Select(x => new
            {
                AdmissionNo = x.Student.IndexNo,
                Student = x.Student.Title + ". " + x.Student.Initials + " " + x.Student.Lname,
                Class = "Grade " + x.PromotionClass.Class.Grade + " - " + x.PromotionClass.Class.Name,
                x.Responsibilty
            }).ToList();

            var lstPenDet = db.Prefects.Where(x => x.Status == ActiveState.Active && x.Type == PrefectType.PendingPrefect).Select(x => new
            {
                AdmissionNo = x.Student.IndexNo,
                Student = x.Student.Title + ". " + x.Student.Initials + " " + x.Student.Lname,
                Class = "Grade " + x.PromotionClass.Class.Grade + " - " + x.PromotionClass.Class.Name,
                x.Responsibilty
            }).ToList();

            if (lstSenDet.Count == 0)
            { return HttpNotFound(); }

            LocalReport report = new LocalReport();
            report.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/CurPrefectGuildReport.rdlc");

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "dsSeniorDetail";
            rds.Value = lstSenDet;
            report.DataSources.Add(rds);

            rds = new ReportDataSource();
            rds.Name = "dsJuniorDetail";
            rds.Value = lstJunDet;
            report.DataSources.Add(rds);

            rds = new ReportDataSource();
            rds.Name = "dsPendingDetail";
            rds.Value = lstPenDet;
            report.DataSources.Add(rds);

            Byte[] mybytes = report.Render("PDF");

            Response.AppendHeader("content-disposition", "inline; filename=file.pdf");
            return new FileStreamResult(new MemoryStream(mybytes), "application/pdf");
        }
    }
}