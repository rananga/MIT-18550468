using Microsoft.Reporting.WebForms;
using StudentInformationSystem.Areas.Base;
using StudentInformationSystem.Areas.Report.Models;
using StudentInformationSystem.Reporting.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace StudentInformationSystem.Areas.Report.Controllers
{
    public class StudentCharacterController : BaseController
    {
        public ActionResult Process()
        {
            var para = new ReportParameterVM();
            return View(para);
        }

        [HttpPost]
        public ActionResult Process(ReportParameterVM para)
        {
            if (!ModelState.IsValid)
                return View(para);

            return Json(new { formValid = true });
        }

        public ActionResult Pdf(ReportParameterVM para)
        {
            return GetPdfStream(para);
        }

        public ActionResult Excel(ReportParameterVM para)
        {
            return GetExcelStream(para);
        }

        private List<WeeklySummary> GetWeeklySummary()
        {
            var lst = db.OnlineClasses
                .Where(x => x.OnlineClassRoom.Year == 2021 && x.OnlineClassRoom.GradeId == 1).ToList()
                .Select(x => new WeeklySummary()
                {
                    Date = x.Date,
                    Duration = $"{DateTime.Today.Add(x.FromTime).ToString("tt hh:mm")} - {DateTime.Today.Add(x.ToTime).ToString("tt hh:mm")}".Replace("AM", "පෙ.ව.").Replace("PM", "ප.ව."),
                    Subject = x.Subject,
                    Class = x.OnlineClassRoom.PhysicalClassRooms.Select(y => y.ClassRoom.GradeClass.Code).Aggregate((y, z) => y + "," + z),
                    Lesson = x.Lesson,
                    StudentCount = $"{x.OC_Meetings.SelectMany(y => y.OC_MeetingAttendees).Count()} / " +
                    $"{(x.OnlineClassRoom.Subject.SubjectCategory.IsBasket ? x.OnlineClassRoom.PhysicalClassRooms.SelectMany(y => y.ClassRoom.ClassStudents).Where(y => y.Student.StudentBasketSubjects.Any(z => z.SubjectId == x.OnlineClassRoom.SubjectId)).Count() : x.OnlineClassRoom.PhysicalClassRooms.SelectMany(y => y.ClassRoom.ClassStudents).Count())}",
                    Teacher = x.OCR_Teacher.StaffMember.FullName
                }).ToList();

            return lst;
        }

        private FileStreamResult GetPdfStream(ReportParameterVM para)
        {
            LocalReport report = new LocalReport();
            report.LoadReportDefinition(Shared.GetReportStream("WeeklySummary"));

            report.SetParameters(new ReportParameter("Year", "2021"));
            report.SetParameters(new ReportParameter("Grade", "1"));
            report.SetParameters(new ReportParameter("FromDate", new DateTime(2021, 6, 1).ToString("yyyy-MM-dd")));
            report.SetParameters(new ReportParameter("ToDate", new DateTime(2021, 6, 30).ToString("yyyy-MM-dd")));

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "WeeklySummary";
            rds.Value = GetWeeklySummary();
            report.DataSources.Add(rds);

            byte[] mybytes = report.Render("PDF");

            Response.AppendHeader("content-disposition", "inline; filename=file.pdf");
            return new FileStreamResult(new MemoryStream(mybytes), "application/pdf");
        }

        private FileStreamResult GetExcelStream(ReportParameterVM para)
        {
            var ms = new MemoryStream();
            Response.AppendHeader("content-disposition", "inline; filename=file.xls");
            return new FileStreamResult(ms, "application/ms-excel");
        }
    }
}