using Microsoft.Reporting.WebForms;
using StudentInformationSystem.Areas.Base;
using StudentInformationSystem.Areas.Report.Models;
using StudentInformationSystem.Data;
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
            var res = GetPdfStream(para);
            if (res == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            else
                return res;
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
                    Class = x.OnlineClassRoom.PhysicalClassRooms.Select(y => y.PhysicalClassRoom.GradeClass.Code).Aggregate((y, z) => y + "," + z),
                    Lesson = x.Lesson,
                    StudentCount = $"{x.OC_Meetings.SelectMany(y => y.OC_MeetingAttendees).Count()} / " +
                    $"{(x.OnlineClassRoom.Subject.SubjectCategory.IsBasket ? x.OnlineClassRoom.PhysicalClassRooms.SelectMany(y => y.PhysicalClassRoom.ClassStudents).Where(y => y.Student.StudentBasketSubjects.Any(z => z.SubjectId == x.OnlineClassRoom.SubjectId)).Count() : x.OnlineClassRoom.PhysicalClassRooms.SelectMany(y => y.PhysicalClassRoom.ClassStudents).Count())}",
                    Teacher = x.OCR_Teacher.StaffMember.FullName
                }).ToList();

            return lst;
        }

        private FileStreamResult GetPdfStream(ReportParameterVM para)
        {
            var lstHdr = db.Students.Where(x => x.Id == para.StudentId).Select(x => new StudentInfo
            {
                AdmissionNo = x.AdmissionNo,
                AddmittedDate = x.AdmissionDate,
                NameWithInitials = $"{x.Initials} {x.LastName}",
                FullName = x.FullName,
                Address = x.Address1 + " " + x.Address2 + " " + x.City,
                DOB = x.DOB,
                EmmergencyContactName = x.EmergContactName,
                EmmergencyContactTelno = x.EmergContactNo
            }).ToList();

            var lstSibDet = db.Students.Where(x => x.Id == para.StudentId).SelectMany(x => x.StudentSiblings).ToList().Select(x => new StudentSibling
            {
                Name = x.SiblingStudent.Initials + " " + x.SiblingStudent.LastName,
                Relationship = x.Relationship == SibRelationship.YoungerBrother ? "Younger Brother" : "Elder Brother",
                Class = x.SiblingStudent.ClassStudents.MaxOrDefault(y => y.PhysicalClassRoom.GradeClass.Code)
            }).ToList();

            var lstFamDet = db.Students.Where(x => x.Id == para.StudentId).SelectMany(x => x.StudentFamilies).ToList().Select(x => new StudentFamily
            {
                Name = x.Parent.FullName,
                Relationship = x.Relationship == Relationship.Father ? "Father" : (x.Relationship == Relationship.Mother ? "Mother" : "Guardian"),
                Occupation = x.Parent.Occupation,
                WorkingAdd = x.Parent.WorkingAddress,
                OfficeTel = x.Parent.OfficePhoneNo,
                ContactHome = x.Parent.HomePhoneNo,
                ContactMob = x.Parent.MobileNo
            }).ToList();

            var lstStudAcheive = db.Students.Where(x => x.Id == para.StudentId).SelectMany(x => x.ClassMonitors).ToList().Select(x => new StudentAcheivements
            {
                Description = $"Is the class monitor in grade {x.PhysicalClassRoom.GradeClass.Code} from {x.FromDate.ToString("yyyy-MMM-dd")} to {x.ToDate.ToString("yyyy-MMM-dd")}",
                FromDate = x.FromDate,
                ToDate = x.ToDate
            })
                .Concat(db.Students.Where(x => x.Id == para.StudentId).SelectMany(x => x.ActivityPositions).ToList().Select(x => new StudentAcheivements
                {
                    Description = $"Held the \"{x.Position.Name}\" position in the \"{x.Position.Activity.Name}\" from {x.FromDate.ToString("yyyy-MMM-dd")} to {x.ToDate.ToString("yyyy-MMM-dd")}",
                    FromDate = x.FromDate,
                    ToDate = x.ToDate
                }))
                .Concat(db.Students.Where(x => x.Id == para.StudentId).SelectMany(x => x.ActivityAcheivements).ToList().Select(x => new StudentAcheivements
                {
                    Description = $"Awarded the \"{x.Acheivement.Name}\" award on {x.AwardedDate.ToString("yyyy-MMM-dd")} from the \"{x.Acheivement.Activity.Name}\"",
                    FromDate = x.AwardedDate,
                    ToDate = x.AwardedDate
                })).ToList();

            if (lstHdr.Count == 0)
            { return null; }

            LocalReport report = new LocalReport();
            report.LoadReportDefinition(Shared.GetReportStream("StudentCharacter"));

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "StudentInfo";
            rds.Value = lstHdr;
            report.DataSources.Add(rds);

            rds = new ReportDataSource();
            rds.Name = "StudentSibling";
            rds.Value = lstSibDet;
            report.DataSources.Add(rds);

            rds = new ReportDataSource();
            rds.Name = "StudentFamily";
            rds.Value = lstFamDet;
            report.DataSources.Add(rds);

            rds = new ReportDataSource();
            rds.Name = "StudentAcheivements";
            rds.Value = lstStudAcheive;
            report.DataSources.Add(rds);

            Byte[] mybytes = report.Render("PDF");

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