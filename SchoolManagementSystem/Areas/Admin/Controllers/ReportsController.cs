using Microsoft.Reporting.WebForms;
using SMS.Areas.Base.Controllers;
using SMS.Areas.Base.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Areas.Admin.Controllers
{
    public class ReportsController : BaseController
    {
        // GET: Admin/Reports
        public ActionResult IntakeSummary(bool? viewIt)
        {
            if (viewIt != true || !(Session[sskCrtdObj] is ReportParameterVM))
            { return View(new ReportParameterVM()); }

            ReportParameterVM rptObj = (ReportParameterVM)Session[sskCrtdObj];
            var Headerlst = db.PeriodSetups.Where(x => x.PeriodID == rptObj.PeriodID).ToList().Select(x => new
            {
                StartDate = x.PeriodStartDate.ToString("yyyy-MM-dd"),
                EndDate = x.PeriodEndDate.ToString("yyyy-MM-dd"),
                ReportDate = DateTime.Now.ToString("yyyy-MM-dd")
            }).ToList();
            
            var lst = db.PromotionClasses.Where(x => x.PeriodID == rptObj.PeriodID).ToList().Select(x => new
            {
                Grade = x.Class.Grade.ToEnumChar(),
                NoOfStudents = x.ClassStudents.Count(),
            }).ToList();

            LocalReport report = new LocalReport();
            report.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/IntakeSummary.rdlc");
   
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "dsIntakeSummary";
            rds.Value = lst;
            report.DataSources.Add(rds);

            rds = new ReportDataSource();
            rds.Name = "dsIntakeHeader";
            rds.Value = Headerlst;
            report.DataSources.Add(rds);

            Byte[] mybytes = report.Render("PDF");
            Response.AppendHeader("content-disposition", "inline; filename=file.pdf");
            return new FileStreamResult(new MemoryStream(mybytes), "application/pdf");
        }

        [HttpPost]
        public ActionResult IntakeSummary(ReportParameterVM para)
        {
            Session.Remove(sskCrtdObj);

            if (para.PeriodID == 0)
            { ModelState.AddModelError("PeriodID", "Period must be selected"); }

            if (!ModelState.IsValid)
            { return View(para); }

            Session[sskCrtdObj] = para;
            return Json(new { viewIt = true });
        }

        public ActionResult IntakeComparison(bool? viewIt)
        {
            if (viewIt != true || !(Session[sskCrtdObj] is ReportParameterVM))
            { return View(new ReportParameterVM()); }

            ReportParameterVM rptObj = (ReportParameterVM)Session[sskCrtdObj];
            var Period2 = db.PeriodSetups.Find(rptObj.PeriodID2);
            var Headerlst = db.PeriodSetups.Where(x => x.PeriodID == rptObj.PeriodID).ToList().Select(x => new
            {
                StartDate = x.PeriodStartDate.ToString("yyyy-MM-dd"),
                EndDate = x.PeriodEndDate.ToString("yyyy-MM-dd"),
                StartDate2 = Period2.PeriodStartDate.ToString("yyyy-MM-dd"),
                EndDate2 = Period2.PeriodEndDate.ToString("yyyy-MM-dd"),
                ReportDate = DateTime.Now.ToString("yyyy-MM-dd")
            }).ToList();

            var lst = db.PromotionClasses.ToList().Select(x => new
            {
                Grade = x.Class.Grade.ToEnumChar(),
                NoOfStudents = x.ClassStudents.Where(y => y.PromotionClass.PeriodID == rptObj.PeriodID).Count(),
                NoOfStudents2 = x.ClassStudents.Where(y => y.PromotionClass.PeriodID == rptObj.PeriodID2).Count(),
            }).ToList();

            LocalReport report = new LocalReport();
            report.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/IntakeComparissonReport.rdlc");

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "dsIntakeSummary";
            rds.Value = lst;
            report.DataSources.Add(rds);

            rds = new ReportDataSource();
            rds.Name = "dsIntakeHeader";
            rds.Value = Headerlst;
            report.DataSources.Add(rds);

            Byte[] mybytes = report.Render("PDF");
            Response.AppendHeader("content-disposition", "inline; filename=file.pdf");
            return new FileStreamResult(new MemoryStream(mybytes), "application/pdf");
        }

        [HttpPost]
        public ActionResult IntakeComparison(ReportParameterVM para)
        {
            Session.Remove(sskCrtdObj);

            if (para.PeriodID == 0)
            { ModelState.AddModelError("PeriodID", "Period 1 must be selected"); }
            if (para.PeriodID2 == 0)
            { ModelState.AddModelError("PeriodID2", "Period 2 must be selected"); }

            if (!ModelState.IsValid)
            { return View(para); }

            Session[sskCrtdObj] = para;
            return Json(new { viewIt = true });
        }

        [HttpPost]
        public ActionResult DailyIncome(ReportParameterVM para)
        {
            Session.Remove(sskCrtdObj);

            if (para.FromDate == null)
            { ModelState.AddModelError("FromDate", "Date must be selected"); }

            if (!ModelState.IsValid)
            { return View(para); }

            Session[sskCrtdObj] = para;
            return Json(new { viewIt = true });
        }

    }
}