﻿using Microsoft.Reporting.WebForms;
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
    public class StudentAttendanceController : BaseController
    {
        public ActionResult Process(bool? byDuration)
        {
            if (byDuration == null)
            {
                return View();
            }

            return GetPdfStream(byDuration.Value);
        }

        [HttpPost]
        public ActionResult Process(ReportParameterVM para)
        {
            return Json(new { byDuration = para.ByDuration });
        }

        [HttpPost]
        public ActionResult Excel(ReportParameterVM para)
        {
            return Json(new { viewIt = true });
        }

        public ActionResult ByDuration(bool? viewIt)
        {
            if (viewIt != true)
            {
                return View();
            }

            return GetPdfStream(true);
        }

        [HttpPost]
        public ActionResult ByDuration(ReportParameterVM para)
        {
            return Json(new { viewIt = true });
        }

        private List<StudentAttendance> GetStudentAttendance(bool WithDuration)
        {
            var fdate = new DateTime(2021, 6, 1);
            var tdate = DateTime.Now;

            var ocqry = db.OnlineClasses.Where(x => x.Date >= fdate && x.Date <= tdate);

            var qry1 = from ocr in db.OnlineClassRooms
                       from oc in ocqry.Where(x => x.OCR_Id == ocr.Id)
                       from pcr in db.OCR_ClassRooms.Where(x => x.OCR_Id == ocr.Id)
                       from cr in db.ClassRooms.Where(x => x.Id == pcr.CR_Id)
                       from crs in db.CR_Students.Where(x => x.CR_Id == pcr.CR_Id)
                       from s in db.Students.Where(x => x.Id == crs.StudentId)
                       select new
                       {
                           oc.Id,
                           oc.Date,
                           StudentId = s.Id,
                           s.IndexNo,
                           s.FullName,
                           oc.Subject,
                           StudentClass = cr.GradeClass.Code
                       };

            var qry2 = from c in ocqry
                       from cm in db.OC_Meetings.Where(x => x.OC_Id == c.Id).DefaultIfEmpty()
                       from cma in db.OC_MeetingAttendees.Where(x => x.OC_MeetingId == cm.Id).DefaultIfEmpty()
                       group new { c, cma } by new { c.Id, cma.StudentId } into g
                       select new
                       {
                           g.Key.Id,
                           g.Key.StudentId,
                           Duration = g.Sum(x => x.cma.Duration)
                       };

            var qry3 = from c in ocqry
                       from cm in db.OC_Meetings.Where(x => x.OC_Id == c.Id).DefaultIfEmpty()
                       group new { c, cm } by new { c.Id } into g
                       select new
                       {
                           g.Key.Id,
                           cmid = g.Max(x => x.cm.Id)
                       };

            Func<long, string> getDuration = (duration) => 
            {
                if (duration == 0)
                    return "X";

                var hrs = Math.Floor(duration / 3600M);
                var bal = duration - hrs * 3600;
                var min = Math.Floor(bal / 60M);
                var sec = bal - min * 60;

                var lst = new List<string>();

                if (hrs > 0)
                    lst.Add($"{hrs}h");
                if (min > 0)
                    lst.Add($"{min}m");
                if (sec > 0)
                    lst.Add($"{sec}s");

                return string.Join(",", lst);
            };

            var qry = from q1 in qry1
                      from q2 in qry2.Where(x => x.Id == q1.Id && x.StudentId == q1.StudentId).DefaultIfEmpty()
                      from q3 in qry3.Where(x => x.Id == q1.Id)
                      select new 
                      {
                          q1.Id,
                          q1.Date,
                          q1.IndexNo,
                          q1.FullName,
                          q2.Duration,
                          q1.Subject,
                          q3.cmid,
                          q1.StudentClass
                      };

            return qry.ToList().Select(x=> new StudentAttendance()
            {
                OC_Id = x.Id,
                MeetingDate = x.Date,
                AdmissionNo = x.IndexNo,
                StudentName = x.FullName,
                Duration = x.cmid == 0 ? "" : WithDuration ? getDuration(x.Duration) : x.Duration == 0 ? "X" : "C",
                Subject = x.Subject,
                StudentClass = x.StudentClass
            }).ToList();
        }

        private FileStreamResult GetPdfStream(bool WithDuration)
        {
            LocalReport report = new LocalReport();
            report.LoadReportDefinition(Shared.GetReportStream("StudentAttendance"));

            report.SetParameters(new ReportParameter("Year", "2021"));
            report.SetParameters(new ReportParameter("Grade", "1"));
            report.SetParameters(new ReportParameter("FromDate", DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd")));
            report.SetParameters(new ReportParameter("ToDate", DateTime.Now.ToString("yyyy-MM-dd")));
            report.SetParameters(new ReportParameter("Class", "Grade 1A"));
            report.SetParameters(new ReportParameter("Teacher", "Subeda Nawarathna"));

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "StudentAttendance";
            rds.Value = GetStudentAttendance(WithDuration);
            report.DataSources.Add(rds);

            byte[] mybytes = report.Render("PDF");

            Response.AppendHeader("content-disposition", "inline; filename=file.pdf");
            return new FileStreamResult(new MemoryStream(mybytes), "application/pdf");
        }
    }
}