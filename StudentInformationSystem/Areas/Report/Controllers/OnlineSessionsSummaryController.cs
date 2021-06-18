using Microsoft.Reporting.WebForms;
using StudentInformationSystem.Areas.Base;
using StudentInformationSystem.Areas.Report.Models;
using StudentInformationSystem.Reporting.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace StudentInformationSystem.Areas.Report.Controllers
{
    public class OnlineSessionsSummaryController : BaseController
    {
        public ActionResult Process(bool? viewIt)
        {
            if (viewIt != true)
            {
                return View();
            }

            return GetPdfStream();
        }

        [HttpPost]
        public ActionResult Process(ReportParameterVM para)
        {
            return Json(new { viewIt = true });
        }
        [HttpPost]
        public ActionResult Excel(ReportParameterVM para)
        {
            return Json(new { viewIt = true });
        }

        private List<OnlineSessionsSummary> GetOnlineSessionsSummary()
        {
            var lst = new List<OnlineSessionsSummary>()
            {
                new OnlineSessionsSummary(){ TeacherName = "Apsara Erandi Vithan", ClassSubject = "ICT - 8C, 8E", TotalStudents = 92, SessionHeld = 1, SessionUnheld = 0, AverageAttendance = 59 },
                new OnlineSessionsSummary(){ TeacherName = "B.M.K. Venus", ClassSubject = "සිංහල - 8B, 8F", TotalStudents = 88, SessionHeld = 1, SessionUnheld = 0, AverageAttendance = 32 },
                new OnlineSessionsSummary(){ TeacherName = "Chandana Senadeera", ClassSubject = "English - 8G", TotalStudents = 48, SessionHeld = 2, SessionUnheld = 0, AverageAttendance = 39.5M },
                new OnlineSessionsSummary(){ TeacherName = "Diana Sladen", ClassSubject = "English - 8H", TotalStudents = 49, SessionHeld = 2, SessionUnheld = 0, AverageAttendance = 29 },
                new OnlineSessionsSummary(){ TeacherName = "Dilupa Senevirathna", ClassSubject = "සිංහල - 8G", TotalStudents = 48, SessionHeld = 2, SessionUnheld = 0, AverageAttendance = 40.5M },
                new OnlineSessionsSummary(){ TeacherName = "Erangi Munasinghe", ClassSubject = "චිත්‍ර කලාව - 8C, 8D, 8E, 8F", TotalStudents = 41, SessionHeld = 1, SessionUnheld = 0, AverageAttendance = 32 },
                new OnlineSessionsSummary(){ TeacherName = "Gayathri Srinammuni", ClassSubject = "ICT - 8B, 8G", TotalStudents = 90, SessionHeld = 1, SessionUnheld = 0, AverageAttendance = 68 },
                new OnlineSessionsSummary(){ TeacherName = "Geetha Premachandra", ClassSubject = "සෞඛ්‍ය විද්‍යාව - 8G, 8H", TotalStudents = 96, SessionHeld = 2, SessionUnheld = 0, AverageAttendance = 76 },
                new OnlineSessionsSummary(){ TeacherName = "Geetha Premachandra", ClassSubject = "සෞඛ්‍ය විද්‍යාව - 8C, 8D", TotalStudents = 97, SessionHeld = 2, SessionUnheld = 0, AverageAttendance = 104 },
                new OnlineSessionsSummary(){ TeacherName = "Geetha Premachandra", ClassSubject = "සෞඛ්‍ය විද්‍යාව - 8E, 8F", TotalStudents = 97, SessionHeld = 2, SessionUnheld = 0, AverageAttendance = 84 },
                new OnlineSessionsSummary(){ TeacherName = "H.D Nanayakkara", ClassSubject = "P.T.S - 8A", TotalStudents = 44, SessionHeld = 1, SessionUnheld = 0, AverageAttendance = 37 },
                new OnlineSessionsSummary(){ TeacherName = "H.D Nanayakkara", ClassSubject = "බුද්ධ ධර්මය - 8D, 8F", TotalStudents = 98, SessionHeld = 1, SessionUnheld = 0, AverageAttendance = 67 },
                new OnlineSessionsSummary(){ TeacherName = "H.D Nanayakkara", ClassSubject = "බුද්ධ ධර්මය - 8H", TotalStudents = 50, SessionHeld = 1, SessionUnheld = 0, AverageAttendance = 30 },
                new OnlineSessionsSummary(){ TeacherName = "Harsha Widanage", ClassSubject = "- Grade 8A", TotalStudents = 44, SessionHeld = 3, SessionUnheld = 0, AverageAttendance = 24 },
                new OnlineSessionsSummary(){ TeacherName = "Harsha Widanage", ClassSubject = "English - 8A, 8B", TotalStudents = 87, SessionHeld = 2, SessionUnheld = 0, AverageAttendance = 70.5M },
                new OnlineSessionsSummary(){ TeacherName = "Indrani Jayasundara", ClassSubject = "தமிழ் - 8A, 8B", TotalStudents = 86, SessionHeld = 2, SessionUnheld = 0, AverageAttendance = 67M },
                new OnlineSessionsSummary(){ TeacherName = "Indrani Jayasundara", ClassSubject = "தமிழ் - 8C, 8D", TotalStudents = 93, SessionHeld = 2, SessionUnheld = 0, AverageAttendance = 61.5M },
                new OnlineSessionsSummary(){ TeacherName = "Indrani Jayasundara", ClassSubject = "தமிழ் - 8E, 8F", TotalStudents = 95, SessionHeld = 2, SessionUnheld = 0, AverageAttendance = 77.5M },
                new OnlineSessionsSummary(){ TeacherName = "Indrani Jayasundara", ClassSubject = "தமிழ் - 8G, 8H", TotalStudents = 92, SessionHeld = 2, SessionUnheld = 0, AverageAttendance = 63 },
                new OnlineSessionsSummary(){ TeacherName = "Jayantha Warusavithana", ClassSubject = "- Grade 8G", TotalStudents = 48, SessionHeld = 3, SessionUnheld = 0, AverageAttendance = 23.67M },
                new OnlineSessionsSummary(){ TeacherName = "Jayantha Warusavithana", ClassSubject = "ගණිතය - 8G", TotalStudents = 48, SessionHeld = 4, SessionUnheld = 0, AverageAttendance = 36 },
                new OnlineSessionsSummary(){ TeacherName = "Jayantha Warusavithana", ClassSubject = "ගණිතය - 8E, 8F", TotalStudents = 96, SessionHeld = 3, SessionUnheld = 0, AverageAttendance = 83.67M },
                new OnlineSessionsSummary(){ TeacherName = "K. V. S. Priyadarshani", ClassSubject = "විද්‍යාව - 8D, 8E", TotalStudents = 101, SessionHeld = 3, SessionUnheld = 0, AverageAttendance = 82.33M },
                new OnlineSessionsSummary(){ TeacherName = "M K Chandralatha", ClassSubject = "සිංහල - 8E", TotalStudents = 52, SessionHeld = 2, SessionUnheld = 0, AverageAttendance = 45 },
                new OnlineSessionsSummary(){ TeacherName = "M K Chandralatha", ClassSubject = "පුරවැසි අධ්‍යාපනය - 8C, 8H", TotalStudents = 91, SessionHeld = 1, SessionUnheld = 0, AverageAttendance = 67 },
                new OnlineSessionsSummary(){ TeacherName = "Manel Senarathne", ClassSubject = "පෙරදිග සංගීතය - Grade 8", TotalStudents = 99, SessionHeld = 1, SessionUnheld = 0, AverageAttendance = 77 },
                new OnlineSessionsSummary(){ TeacherName = "Manori Thilakawardhana", ClassSubject = "- Grade 8F", TotalStudents = 48, SessionHeld = 3, SessionUnheld = 0, AverageAttendance = 23 },
                new OnlineSessionsSummary(){ TeacherName = "Manori Thilakawardhana", ClassSubject = "භූගෝලය - 8F, 8H", TotalStudents = 96, SessionHeld = 1, SessionUnheld = 0, AverageAttendance = 65 },
                new OnlineSessionsSummary(){ TeacherName = "Manori Thilakawardhana", ClassSubject = "පුරවැසි අධ්‍යාපනය - 8D, 8E", TotalStudents = 100, SessionHeld = 1, SessionUnheld = 0, AverageAttendance = 76 },
                new OnlineSessionsSummary(){ TeacherName = "Manori Thilakawardhana", ClassSubject = "පුරවැසි අධ්‍යාපනය - 8F, 8G", TotalStudents = 91, SessionHeld = 1, SessionUnheld = 0, AverageAttendance = 71 },
                new OnlineSessionsSummary(){ TeacherName = "N.G. Koshila", ClassSubject = "Mathematics - 8A, 8B", TotalStudents = 86, SessionHeld = 2, SessionUnheld = 0, AverageAttendance = 73 },
                new OnlineSessionsSummary(){ TeacherName = "Nadeeka Weerasinghe", ClassSubject = "ICT - 8A, 8H", TotalStudents = 91, SessionHeld = 1, SessionUnheld = 0, AverageAttendance = 57 },
                new OnlineSessionsSummary(){ TeacherName = "Nawamal Jayaweera", ClassSubject = "නර්තනය -", TotalStudents = 26, SessionHeld = 1, SessionUnheld = 0, AverageAttendance = 16 },
                new OnlineSessionsSummary(){ TeacherName = "Nayana Ashoka", ClassSubject = "ගණිතය - 8H", TotalStudents = 51, SessionHeld = 3, SessionUnheld = 0, AverageAttendance = 33.33M },
                new OnlineSessionsSummary(){ TeacherName = "Nilanthi Jayalath", ClassSubject = "P.T.S - 8B, 8D", TotalStudents = 93, SessionHeld = 1, SessionUnheld = 0, AverageAttendance = 74 },
                new OnlineSessionsSummary(){ TeacherName = "Nilanthi Jayalath", ClassSubject = "P.T.S - 8C, 8G", TotalStudents = 89, SessionHeld = 1, SessionUnheld = 0, AverageAttendance = 71 },
                new OnlineSessionsSummary(){ TeacherName = "Nimali Wijesundara", ClassSubject = "- Grade 8C", TotalStudents = 47, SessionHeld = 3, SessionUnheld = 0, AverageAttendance = 24 },
                new OnlineSessionsSummary(){ TeacherName = "Nimali Wijesundara", ClassSubject = "සිංහල - 8C, 8H", TotalStudents = 96, SessionHeld = 2, SessionUnheld = 0, AverageAttendance = 74 },
                new OnlineSessionsSummary(){ TeacherName = "Nipuni Dulanjali", ClassSubject = "ගණිතය - 8C, 8D", TotalStudents = 98, SessionHeld = 3, SessionUnheld = 0, AverageAttendance = 64.33M },
                new OnlineSessionsSummary(){ TeacherName = "Nisansala Galappaththi", ClassSubject = "- Grade 8E", TotalStudents = 49, SessionHeld = 3, SessionUnheld = 0, AverageAttendance = 24.67M },
                new OnlineSessionsSummary(){ TeacherName = "Nisansala Galappaththi", ClassSubject = "භූගෝලය - 8C, 8D", TotalStudents = 95, SessionHeld = 1, SessionUnheld = 0, AverageAttendance = 74 },
                new OnlineSessionsSummary(){ TeacherName = "Nisansala Galappaththi", ClassSubject = "P.T.S - 8E", TotalStudents = 51, SessionHeld = 1, SessionUnheld = 0, AverageAttendance = 47 },
                new OnlineSessionsSummary(){ TeacherName = "Nisansala Galappaththi", ClassSubject = "භූගෝලය - 8E, 8G", TotalStudents = 96, SessionHeld = 1, SessionUnheld = 0, AverageAttendance = 74 },
                new OnlineSessionsSummary(){ TeacherName = "P. V. de Alwis", ClassSubject = "ICT - 8D, 8F", TotalStudents = 93, SessionHeld = 1, SessionUnheld = 0, AverageAttendance = 68 },
                new OnlineSessionsSummary(){ TeacherName = "Pavithra Wijerathna", ClassSubject = "විද්‍යාව - 8F, 8G", TotalStudents = 93, SessionHeld = 3, SessionUnheld = 0, AverageAttendance = 78 },
                new OnlineSessionsSummary(){ TeacherName = "Pavithra Wijerathna", ClassSubject = "Health Science - 8A, 8B", TotalStudents = 86, SessionHeld = 2, SessionUnheld = 0, AverageAttendance = 76.5M },
                new OnlineSessionsSummary(){ TeacherName = "Piyumika Alensu", ClassSubject = "ඉතිහාසය - 8A, 8B", TotalStudents = 87, SessionHeld = 2, SessionUnheld = 0, AverageAttendance = 70 },
                new OnlineSessionsSummary(){ TeacherName = "Piyumika Alensu", ClassSubject = "ඉතිහාසය - 8C", TotalStudents = 47, SessionHeld = 2, SessionUnheld = 0, AverageAttendance = 30.5M },
                new OnlineSessionsSummary(){ TeacherName = "Ranga Bandaranayaka", ClassSubject = "English - 8C, 8F", TotalStudents = 94, SessionHeld = 2, SessionUnheld = 0, AverageAttendance = 74 },
                new OnlineSessionsSummary(){ TeacherName = "Ruchira Pushpadari", ClassSubject = "බුද්ධ ධර්මය - 8A, 8B", TotalStudents = 86, SessionHeld = 1, SessionUnheld = 0, AverageAttendance = 71 },
                new OnlineSessionsSummary(){ TeacherName = "Ruchira Pushpadari", ClassSubject = "බුද්ධ ධර්මය - 8C", TotalStudents = 46, SessionHeld = 1, SessionUnheld = 0, AverageAttendance = 33 },
                new OnlineSessionsSummary(){ TeacherName = "Ruchira Pushpadari", ClassSubject = "බුද්ධ ධර්මය - 8E, 8G", TotalStudents = 97, SessionHeld = 1, SessionUnheld = 0, AverageAttendance = 77 },
                new OnlineSessionsSummary(){ TeacherName = "Ruwani Ramawikrama", ClassSubject = "- Grade 8D", TotalStudents = 51, SessionHeld = 3, SessionUnheld = 0, AverageAttendance = 19 },
                new OnlineSessionsSummary(){ TeacherName = "Ruwani Ramawikrama", ClassSubject = "සිංහල - 8A, 8D", TotalStudents = 93, SessionHeld = 2, SessionUnheld = 0, AverageAttendance = 79.5M },
                new OnlineSessionsSummary(){ TeacherName = "Sakunthala Sandamali", ClassSubject = "Geography - 8A, 8B", TotalStudents = 86, SessionHeld = 1, SessionUnheld = 0, AverageAttendance = 73 },
                new OnlineSessionsSummary(){ TeacherName = "Sakunthala Sandamali", ClassSubject = "Civic Education - 8A, 8B", TotalStudents = 85, SessionHeld = 1, SessionUnheld = 0, AverageAttendance = 68 },
                new OnlineSessionsSummary(){ TeacherName = "Thamara Wijesinghe", ClassSubject = "- Grade 8H", TotalStudents = 52, SessionHeld = 3, SessionUnheld = 0, AverageAttendance = 22.67M },
                new OnlineSessionsSummary(){ TeacherName = "Thamara Wijesinghe", ClassSubject = "ඉතිහාසය - 8D, 8E", TotalStudents = 99, SessionHeld = 2, SessionUnheld = 0, AverageAttendance = 80 },
                new OnlineSessionsSummary(){ TeacherName = "Thamara Wijesinghe", ClassSubject = "ඉතිහාසය - 8F, 8G", TotalStudents = 94, SessionHeld = 2, SessionUnheld = 0, AverageAttendance = 71.5M },
                new OnlineSessionsSummary(){ TeacherName = "Thamara Wijesinghe", ClassSubject = "ඉතිහාසය - 8H", TotalStudents = 49, SessionHeld = 2, SessionUnheld = 0, AverageAttendance = 36 },
                new OnlineSessionsSummary(){ TeacherName = "Thamara Wijesinghe", ClassSubject = "P.T.S - 8F, 8H", TotalStudents = 94, SessionHeld = 1, SessionUnheld = 0, AverageAttendance = 69 },
                new OnlineSessionsSummary(){ TeacherName = "Thanuja Hadapangoda", ClassSubject = "විද්‍යාව - 8C, 8H", TotalStudents = 95, SessionHeld = 3, SessionUnheld = 0, AverageAttendance = 74 },
                new OnlineSessionsSummary(){ TeacherName = "Upeksha Hewapathage", ClassSubject = "English - 8D, 8E", TotalStudents = 99, SessionHeld = 2, SessionUnheld = 0, AverageAttendance = 81 },
                new OnlineSessionsSummary(){ TeacherName = "Vijini Herath", ClassSubject = "- Grade 8B", TotalStudents = 45, SessionHeld = 3, SessionUnheld = 0, AverageAttendance = 24.33M },
                new OnlineSessionsSummary(){ TeacherName = "Vijini Herath", ClassSubject = "Science - 8A, 8B", TotalStudents = 86, SessionHeld = 3, SessionUnheld = 0, AverageAttendance = 74 },
            };

            return lst;
        }

        private FileStreamResult GetPdfStream()
        {
            LocalReport report = new LocalReport();
            report.LoadReportDefinition(Shared.GetReportStream("OnlineSessionsSummary"));

            report.SetParameters(new ReportParameter("Year", "2021"));
            report.SetParameters(new ReportParameter("Grade", "6"));
            report.SetParameters(new ReportParameter("FromDate", DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd")));
            report.SetParameters(new ReportParameter("ToDate", DateTime.Now.ToString("yyyy-MM-dd")));

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "OnlineSessionsSummary";
            rds.Value = GetOnlineSessionsSummary();
            report.DataSources.Add(rds);

            byte[] mybytes = report.Render("PDF");

            Response.AppendHeader("content-disposition", "inline; filename=file.pdf");
            return new FileStreamResult(new MemoryStream(mybytes), "application/pdf");
        }
    }
}