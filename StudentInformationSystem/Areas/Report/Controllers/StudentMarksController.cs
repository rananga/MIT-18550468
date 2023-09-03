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
    public class StudentMarksController : BaseController
    {
        public ActionResult Process()
        {
            var para = new ReportParameterVM()
            {
                Year = DateTime.Now.Year,
                FromDate = DateTime.Now.Date.AddMonths(-1),
                ToDate = DateTime.Now.Date
            };

            return View(para);
        }

        [HttpPost]
        public ActionResult Process(ReportParameterVM para)
        {
            if (para.Year < DateTime.Now.Year - 25 || para.Year > DateTime.Now.Year + 1 )
            { ModelState.AddModelError("Year", "Year is invalid"); }

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

        private List<StudentMarks> GetStudentMarks(ReportParameterVM para)
        {
            var lst = db.PhysicalClassRooms.Where(x => x.Year == para.Year && x.GradeClass.GradeId == para.GradeId)
                .SelectMany(x => x.ClassStudents).Select(x => new StudentMarks()
                {
                    AdmissionNo = x.Student.AdmissionNo,
                    CurrentClass = x.PhysicalClassRoom.GradeClass.Code,
                    StudentName = x.Student.FullName,
                    MarksTerm1 = x.StudentSubjects.SelectMany(y => y.ClassStudentSubjectMarks).Where(y => y.Term == Data.Term.Term1).Sum(y => y.Marks),
                    MarksTerm2 = x.StudentSubjects.SelectMany(y => y.ClassStudentSubjectMarks).Where(y => y.Term == Data.Term.Term2).Sum(y => y.Marks),
                    MarksTerm3 = x.StudentSubjects.SelectMany(y => y.ClassStudentSubjectMarks).Where(y => y.Term == Data.Term.Term3).Sum(y => y.Marks)
                }).ToList();

            switch (para.MarksReportOrderBy)
            {
                case Data.MarksReportOrderBy.Average:
                    lst = lst.OrderBy(x => x.MarksTerm1 + x.MarksTerm2 + x.MarksTerm3).ToList();
                    break;
                case Data.MarksReportOrderBy.Term1:
                    lst = lst.OrderBy(x => x.MarksTerm1).ToList();
                    break;
                case Data.MarksReportOrderBy.Term2:
                    lst = lst.OrderBy(x => x.MarksTerm2).ToList();
                    break;
                case Data.MarksReportOrderBy.Term3:
                    lst = lst.OrderBy(x => x.MarksTerm3).ToList();
                    break;
                default:
                    break;
            }

            return lst;
        }

        private FileStreamResult GetPdfStream(ReportParameterVM para)
        {
            LocalReport report = new LocalReport();
            report.LoadReportDefinition(Shared.GetReportStream("StudentMarks"));

            var lst = GetStudentMarks(para); ;
            GetCounts(lst, out int passCount, out int failCount);

            report.SetParameters(new ReportParameter("Year", para.Year.ToString()));
            report.SetParameters(new ReportParameter("Grade", para.GradeId.ToString()));
            report.SetParameters(new ReportParameter("OrderBy", ((int)para.MarksReportOrderBy).ToString()));
            report.SetParameters(new ReportParameter("PassCount", passCount.ToString()));
            report.SetParameters(new ReportParameter("FailCount", failCount.ToString()));

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "StudentMarks";
            rds.Value = lst;
            report.DataSources.Add(rds);

            byte[] mybytes = report.Render("PDF");

            Response.AppendHeader("content-disposition", "inline; filename=file.pdf");
            return new FileStreamResult(new MemoryStream(mybytes), "application/pdf");
        }

        private void GetCounts(List<StudentMarks> lst, out int passCount, out int failCount)
        {
            passCount = lst.Where(x => (x.MarksTerm1 + x.MarksTerm2 + x.MarksTerm3) / 3 > 35).Count();
            failCount = lst.Where(x => (x.MarksTerm1 + x.MarksTerm2 + x.MarksTerm3) / 3 <= 35).Count();
        }

        private FileStreamResult GetExcelStream(ReportParameterVM para)
        {
            var ms = new MemoryStream();
            Response.AppendHeader("content-disposition", "inline; filename=file.xls");
            return new FileStreamResult(ms, "application/ms-excel");
        }
    }
}