using Microsoft.Reporting.WebForms;
using SMS.Areas.Base.Controllers;
using SMS.Areas.Base.Models;
using SMS.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Areas.Student.Controllers
{
    public class ReportsController : BaseController
    {
        // GET: Student/Reports
        public ActionResult StudExCurricularSumReport(bool? viewIt)
        {
            if (viewIt != true || !(Session[sskCrtdObj] is ReportParameterVM))
            { return View(new ReportParameterVM()); }

            ReportParameterVM rptObj = (ReportParameterVM)Session[sskCrtdObj];
            var Headerlst = db.Students.Where(x => x.StudID == rptObj.StudentID).ToList().Select(x => new
            {
                IndexNo = x.IndexNo.ToString(),
                StudentName = x.Title + ". " + x.Initials + " " + x.LName,
                StudentAddress = x.Address.ToString()
            }).ToList();


            var lstClub = db.ClubMembers.Where(x => x.StudentID == rptObj.StudentID).ToList().Select(x => new
            {
                ClubName = x.Club.Name.ToString(),
                MemberDate = x.MemberDate.ToString("yyyy-MM-dd"),
                MemberType = x.MembershipType.ToEnumChar(),
                CommiteeMemberType = x.CommiteeMemberType == Common.CommitteeMemberType.None ? "-" : x.CommiteeMemberType.ToEnumChar(),
            }).ToList().OrderBy(x => x.ClubName);

            var lstEvent = db.EventParticipations.Where(x => (x.StudID == rptObj.StudentID)).ToList().Select(x => new
            {
                x.EventDesc,
                IsWinner = x.IsWinner == true ? "Yes" : "No",
                x.WinningDetails,
                TeacherInCharge = x.Teacher.Title + ". " + x.Teacher.Initials + " " + x.Teacher.LName

            }).ToList();


            LocalReport report = new LocalReport();
            report.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/StudExCurricularSummaryReport.rdlc");

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "dsCurricularActivity";
            rds.Value = lstClub;
            report.DataSources.Add(rds);

            rds = new ReportDataSource();
            rds.Name = "dsEventParticipation";
            rds.Value = lstEvent;
            report.DataSources.Add(rds);

            rds = new ReportDataSource();
            rds.Name = "dsCurricularHead";
            rds.Value = Headerlst;
            report.DataSources.Add(rds);

            Byte[] mybytes = report.Render("PDF");
            Response.AppendHeader("content-disposition", "inline; filename=file.pdf");
            return new FileStreamResult(new MemoryStream(mybytes), "application/pdf");
        }

        [HttpPost]
        public ActionResult StudExCurricularSumReport(ReportParameterVM para)
        {
            Session.Remove(sskCrtdObj);

            if (para.StudentID == 0)
            { ModelState.AddModelError("StudentID", "Student must be selected"); }

            if (!ModelState.IsValid)
            { return View(para); }

            Session[sskCrtdObj] = para;
            return Json(new { viewIt = true });
        }

        public ActionResult StudentWiseIDCard(bool? viewIt)
        {
            if (viewIt != true || !(Session[sskCrtdObj] is ReportParameterVM))
            { return View(new ReportParameterVM()); }

            ReportParameterVM rptObj = (ReportParameterVM)Session[sskCrtdObj];
            var basePath = ConfigurationManager.AppSettings["EnrollmentsImagePath"];
            if (basePath.StartsWith("\\") && !basePath.StartsWith("\\\\"))
            { basePath = Server.MapPath("~" + basePath); }
            var objStudent = db.ClassStudents.Find(rptObj.StudentID);
            var lstHdr = db.Students.Where(e => e.StudID == objStudent.StudID).ToList()
                 .Select(x => new
                 {
                     StudentName = x.LName + " " + (x.Initials).ToUpper(),
                     IndexNO = x.IndexNo,
                     Address = x.Address.Trim(),
                     ImagePath = @"file:\" + basePath + "\\" + (x.ImagePath != null ? x.ImagePath : "NoImage.png"),
                     ImergencyContact = x.EmergencyContactTel
                 }).OrderBy(x => x.IndexNO).ToList();

            if (lstHdr.Count == 0)
            { return HttpNotFound(); }

            LocalReport report = new LocalReport();
            report.EnableExternalImages = true;
            report.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/StudentIDCard.rdlc");

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "dsStudentIDCardDetails";
            rds.Value = lstHdr;
            report.DataSources.Add(rds);

            Byte[] mybytes = report.Render("PDF");
            Response.AppendHeader("content-disposition", "inline; filename=file.pdf");
            return new FileStreamResult(new MemoryStream(mybytes), "application/pdf");
        }

        [HttpPost]
        public ActionResult StudentWiseIDCard(ReportParameterVM para)
        {
            Session.Remove(sskCrtdObj);

            if (para.StudentID == 0)
            { ModelState.AddModelError("StudentID", "Student must be selected"); }
            if (para.ClassID == 0)
            { ModelState.AddModelError("ClassID", "Class must be selected"); }

            if (!ModelState.IsValid)
            { return View(para); }

            Session[sskCrtdObj] = para;
            return Json(new { viewIt = true });
        }

        public ActionResult ClassWiseStudentIDCard(bool? viewIt)
        {
            if (viewIt != true || !(Session[sskCrtdObj] is ReportParameterVM))
            { return View(new ReportParameterVM()); }

            ReportParameterVM rptObj = (ReportParameterVM)Session[sskCrtdObj];
            var basePath = ConfigurationManager.AppSettings["EnrollmentsImagePath"];
            if (basePath.StartsWith("\\") && !basePath.StartsWith("\\\\"))
            { basePath = Server.MapPath("~" + basePath); }

            var lst = db.ClassStudents.Where(x => x.PrClID == rptObj.ClassID).ToList()
                 .Select(x => new
                 {
                     StudentName = x.Student.LName + " " + (x.Student.Initials).ToUpper(),
                     IndexNO = x.Student.IndexNo,
                     Address = x.Student.Address.Trim(),
                     ImagePath = @"file:\" + basePath + "\\" + (x.Student.ImagePath != null ? x.Student.ImagePath : "NoImage.png"),
                     ImergencyContact = x.Student.EmergencyContactTel
                 }).OrderBy(x => x.IndexNO).ToList();

            if (lst.Count == 0)
            { return HttpNotFound(); }

            LocalReport report = new LocalReport();
            report.EnableExternalImages = true;
            report.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/StudentIDCard.rdlc");

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "dsStudentIDCardDetails";
            rds.Value = lst;
            report.DataSources.Add(rds);

            Byte[] mybytes = report.Render("PDF");
            Response.AppendHeader("content-disposition", "inline; filename=file.pdf");
            return new FileStreamResult(new MemoryStream(mybytes), "application/pdf");
        }

        [HttpPost]
        public ActionResult ClassWiseStudentIDCard(ReportParameterVM para)
        {
            Session.Remove(sskCrtdObj);

            if (para.PeriodID == 0)
            { ModelState.AddModelError("PeriodID", "Period must be selected"); }
            if (para.ClassID == 0)
            { ModelState.AddModelError("ClassID", "Class must be selected"); }

            if (!ModelState.IsValid)
            { return View(para); }

            Session[sskCrtdObj] = para;
            return Json(new { viewIt = true });
        }

        public ActionResult PrefectGuild(bool? viewIt)
        {
            if (viewIt != true || !(Session[sskCrtdObj] is ReportParameterVM))
            { return View(new ReportParameterVM()); }

            ReportParameterVM rptObj = (ReportParameterVM)Session[sskCrtdObj];
            var period = db.PeriodSetups.Find(rptObj.PeriodID);

            var lst = db.Prefects.Where(x => x.EffectiveDate >= period.PeriodStartDate && x.InactiveDate <= period.PeriodEndDate || x.InactiveDate == null).ToList().Select(x => new
            {
                CoveredPeriod = period.PeriodStartDate.ToString("yyyy-MM-dd") + " - " + period.PeriodEndDate.ToString("yyyy-MM-dd"),
                YearPeriod = x.InactiveDate == null? x.EffectiveDate.ToString("yyyy-MM-dd") : x.EffectiveDate.ToString("yyyy-MM-dd") +" - " + x.InactiveDate.Value.ToString("yyyy-MM-dd"),
                PrefectType = x.Type == Common.PrefectType.Junior ? "Junior" : x.Type == Common.PrefectType.Senior ? "Senior" : "PendingPrefect",
                Name = x.Student.Title + ". " + x.Student.Initials + " " + x.Student.LName,
                Class = x.PromotionClass.Class.Grade.ToEnumChar() + " - " + x.PromotionClass.Class.ClassDesc,
                IsHP = x.IsHP == true ? "Yes" : "",
                IsDHP = x.IsDHP == true ? "Yes" : ""
            }).ToList();


            //var Headerlst = db.Prefects.Where(x => x.EffectiveDate >= period.PeriodStartDate && x.InactiveDate <= period.PeriodEndDate || x.InactiveDate == null && (x.IsDHP == true || x.IsHP == true)).ToList().Select(x => new
            //{
            //    HP1 = x.PromotionClass.Prefects.Where(y => y.IsHP == true).Select(y => y.Student.Title + ". " + y.Student.Initials + " " + y.Student.LName).FirstOrDefault(),
            //    HP2 = x.PromotionClass.Prefects.Where(y => y.IsHP == true && y.PreID != x.PromotionClass.Prefects.Where(z => z.IsHP == true).Select(z => z.PreID).FirstOrDefault()).Select(y => y.Student.Title + ". " + y.Student.Initials + " " + y.Student.LName).FirstOrDefault(),
            //    DHP1 = x.PromotionClass.Prefects.Where(y => y.IsDHP == true).Select(y => y.Student.Title + ". " + y.Student.Initials + " " + y.Student.LName).FirstOrDefault(),
            //    DHP2 = x.PromotionClass.Prefects.Where(y => y.IsDHP == true).Select(y => y.Student.Title + ". " + y.Student.Initials + " " + y.Student.LName).LastOrDefault(),

            //}).ToList();

            var Headerlst = db.Prefects.Where(x => x.IsDHP == true || x.IsHP == true).ToList().Select(x => new
            {
                HP1 = x.IsHP == true ?  x.Student.Title + ". " + x.Student.Initials + " " + x.Student.LName :"",
                HP2 = x.PromotionClass.Prefects.Where(y => y.IsHP == true && y.PreID != x.PromotionClass.Prefects.Where(z => z.IsHP == true).Select(z => z.PreID).FirstOrDefault()).Select(y => y.Student.Title + ". " + y.Student.Initials + " " + y.Student.LName).FirstOrDefault(),
                DHP1 = x.IsDHP == true ? x.Student.Title + ". " + x.Student.Initials + " " + x.Student.LName : "",
                DHP2 = x.PromotionClass.Prefects.Where(y => y.IsDHP == true && y.PreID != x.PromotionClass.Prefects.Where(z => z.IsDHP == true).Select(z => z.PreID).FirstOrDefault()).Select(y => y.Student.Title + ". " + y.Student.Initials + " " + y.Student.LName).FirstOrDefault(),
            }).ToList();

            LocalReport report = new LocalReport();
            report.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/PrefectGuildSummaryReport.rdlc");

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "dsPrefectDetails";
            rds.Value = lst;
            report.DataSources.Add(rds);

            rds = new ReportDataSource();
            rds.Name = "dsPrefectDetailsHeader";
            rds.Value = Headerlst;
            report.DataSources.Add(rds);

            Byte[] mybytes = report.Render("PDF");
            Response.AppendHeader("content-disposition", "inline; filename=file.pdf");
            return new FileStreamResult(new MemoryStream(mybytes), "application/pdf");
        }

        [HttpPost]
        public ActionResult PrefectGuild(ReportParameterVM para)
        {
            Session.Remove(sskCrtdObj);

            if (para.PeriodID == 0)
            { ModelState.AddModelError("PeriodID", "Period must be selected"); }

            if (!ModelState.IsValid)
            { return View(para); }

            Session[sskCrtdObj] = para;
            return Json(new { viewIt = true });
        }

        public ActionResult ClassRegistry(bool? viewIt)
        {
            if (viewIt != true || !(Session[sskCrtdObj] is ReportParameterVM))
            { return View(new ReportParameterVM()); }

            ReportParameterVM rptObj = (ReportParameterVM)Session[sskCrtdObj];
            var period = db.PeriodSetups.Find(rptObj.PeriodID);
            var lst = db.ClassStudents.Where(x => (x.PrClID == rptObj.ClassID)).ToList().Select(x => new
            {
                Grade = x.PromotionClass.Class.Grade.ToEnumChar(),
                Class = x.PromotionClass.Class.ClassDesc,
                TeacherInCharge = x.PromotionClass.Teacher.Title + ". " + x.PromotionClass.Teacher.Initials + " " + x.PromotionClass.Teacher.LName,
                ClassMonitor = x.IsCurrentMonitor == true ? x.Student.Title + ". " + x.Student.Initials + " " + x.Student.LName : "",
                AdmissionNo = x.Student.IndexNo,
                Name = x.Student.Title + " ." + x.Student.Initials + " " + x.Student.LName,
                IsMonitor = x.IsMonitor == true ? "Yes" : "",
                YearPeriod = x.IsMonitor == true && x.PeriodEndDate != null ? x.PeriodStartDate.Value.ToString("yyyy-MM-dd") + " - " + x.PeriodEndDate.Value.ToString("yyyy-MM-dd") :"",
                PeriodCovers = period.PeriodStartDate.ToString("yyyy-MM-dd") + " - " + period.PeriodEndDate.ToString("yyyy-MM-dd")
            }).ToList().OrderBy(x => x.AdmissionNo);

            LocalReport report = new LocalReport();
            report.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/ClassRegistry - Copy.rdlc");

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "dsStudPromotion";
            rds.Value = lst;
            report.DataSources.Add(rds);

            Byte[] mybytes = report.Render("PDF");
            Response.AppendHeader("content-disposition", "inline; filename=file.pdf");
            return new FileStreamResult(new MemoryStream(mybytes), "application/pdf");
        }

        [HttpPost]
        public ActionResult ClassRegistry(ReportParameterVM para)
        {
            Session.Remove(sskCrtdObj);

            if (para.PeriodID == 0)
            { ModelState.AddModelError("PeriodID", "Period must be selected"); }
            if (para.ClassID == 0)
            { ModelState.AddModelError("ClassID", "Class must be selected"); }

            if (!ModelState.IsValid)
            { return View(para); }

            Session[sskCrtdObj] = para;
            return Json(new { viewIt = true });
        }

        public ActionResult StudentRecordBook(bool? viewIt)
        {
            if (viewIt != true || !(Session[sskCrtdObj] is ReportParameterVM))
            { return View(new ReportParameterVM()); }

            ReportParameterVM rptObj = (ReportParameterVM)Session[sskCrtdObj];

            var StudentPromotionsList = db.ClassStudents.Where(x => x.StudID == rptObj.StudentID).ToList().Select(x => new
            {
                YearPeriod = x.PromotionClass.PeriodSetup.PeriodStartDate.ToString("yyyy-MM-dd") + " - " + x.PromotionClass.PeriodSetup.PeriodEndDate.ToString("yyyy-MM-dd"),
                Grade = x.PromotionClass.Class.Grade.ToEnumChar(),
                Class = x.PromotionClass.Class.ClassDesc,
                TeacherInCharge = x.PromotionClass.Teacher.Title + ". " + x.PromotionClass.Teacher.Initials + " " + x.PromotionClass.Teacher.LName,
                ClassMonitor = x.IsMonitor == true ? x.Student.Title + ". " + x.Student.Initials + " " + x.Student.LName : "",
                AdmissionNo = x.Student.IndexNo,
                Name = x.Student.Title + ". " + x.Student.Initials + " " + x.Student.LName,
                IsMonitor = x.IsMonitor == true ? "Yes" : "",
                Period = x.PromotionClass.PeriodSetup.PeriodStartDate.ToString("yyyy-MM-dd") + " - " + x.PromotionClass.PeriodSetup.PeriodEndDate.ToString("yyyy-MM-dd"),
                x.Student.Address,
                GuardianName = x.Student.EmergencyConName,
                DateofAdmission = x.Student.CreatedDate.ToString("yyyy-MM-dd")
            }).ToList().OrderBy(x => x.AdmissionNo);

            var ExtraCurriculerActivityList = db.EventParticipations.Where(x => x.StudID == rptObj.StudentID).ToList().Select(x => new
            {
                EventName = x.EventDesc,
                EventDate = x.Date.ToString("yyyy-MM-dd"),
                IsWinner = x.IsWinner == true ? "Yes" : "",
                x.WinningDetails
            }).ToList().OrderBy(x => x.EventName);

            var ClubMemberShipList = db.ClubMembers.Where(x => x.StudentID == rptObj.StudentID).ToList().Select(x => new
            {
                ClubName = x.Club.Name,
                MemberDate = x.MemberDate.ToString("yyyy-MM-dd"),
                CommiteeMemberType = x.CommiteeMemberType == Common.CommitteeMemberType.None ? "-" : x.CommiteeMemberType.ToEnumChar(),
                MemberType = x.MembershipType.ToEnumChar()
            }).ToList().OrderBy(x => x.ClubName);

            var PrefectList = db.Prefects.Where(x => x.StudID == rptObj.StudentID).ToList().Select(x => new
            {
                YearPeriod = x.InactiveDate == null ? x.EffectiveDate.ToString("yyyy-MM-dd") : x.EffectiveDate.ToString("yyyy-MM-dd") + " - " + x.InactiveDate.Value.ToString("yyyy-MM-dd"),
                Grade = x.PromotionClass.Class.Grade.ToEnumChar(),
                Class = x.PromotionClass.Class.ClassDesc,
                PrefectType = x.Type.ToEnumChar(),
                IsDHP = x.IsDHP == true ? "Yes" : "-",
                IsHP = x.IsHP == true ? "Yes" : "-"
            }).ToList().OrderBy(x => x.YearPeriod);

            LocalReport report = new LocalReport();
            report.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/StudentRecordBook.rdlc");

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "dsStudPromotion";
            rds.Value = StudentPromotionsList;
            report.DataSources.Add(rds);

            rds = new ReportDataSource();
            rds.Name = "dsExtraCurriculerActivity";
            rds.Value = ExtraCurriculerActivityList;
            report.DataSources.Add(rds);

            rds = new ReportDataSource();
            rds.Name = "dsClubMemberShip";
            rds.Value = ClubMemberShipList;
            report.DataSources.Add(rds);

            rds = new ReportDataSource();
            rds.Name = "dsPrefectDetails";
            rds.Value = PrefectList;
            report.DataSources.Add(rds);

            Byte[] mybytes = report.Render("PDF");
            Response.AppendHeader("content-disposition", "inline; filename=file.pdf");
            return new FileStreamResult(new MemoryStream(mybytes), "application/pdf");
        }

        [HttpPost]
        public ActionResult StudentRecordBook(ReportParameterVM para)
        {
            Session.Remove(sskCrtdObj);

            if (para.StudentID == 0)
            { ModelState.AddModelError("StudentID", "Student must be selected"); }

            if (!ModelState.IsValid)
            { return View(para); }

            Session[sskCrtdObj] = para;
            return Json(new { viewIt = true });
        }

        [HttpPost]
        public ActionResult StaffMeeting(ReportParameterVM para)
        {
            Session.Remove(sskCrtdObj);

            if (para.MeetingDate == null)
            { ModelState.AddModelError("MeetingDate", "Meeting Date must be selected"); }

            if (!ModelState.IsValid)
            { return View(para); }

            Session[sskCrtdObj] = para;
            return Json(new { viewIt = true });
        }

        public ActionResult AdmissionSheet(bool? viewIt)
        {
            if (viewIt != true || !(Session[sskCrtdObj] is ReportParameterVM))
            { return View(new ReportParameterVM() { MeetingDate = DateTime.Now }); }

            ReportParameterVM rptObj = (ReportParameterVM)Session[sskCrtdObj];

            var lstHdr = db.Students.Where(x => x.StudID == rptObj.StudentID).Select(x => new
            {
                x.StudID,
                Title = x.Title == Common.TitleStud.Mr ? "Mr. " : "Ms.",
                AdmissionNo = x.IndexNo,
                FullName = x.FullName,
                Initials = x.Initials,
                LastName = x.LName,
                Address = x.Address,
                DOB = x.DOB,
                Gender = x.Gender == Common.Gender.Female ? "Female" : "Male",
                SchoolName = x.School,
                SchoolAddress = x.SchoolAddress,
                DhammaSchoolName = x.LastDhammaSchool,
                DhammaSchoolAddress = x.LDhammaSchoolAdd,
                GradehammaSchoolLeave = x.LastDhammaGrade,
                EngSpeacking = x.EngSpeaking == Common.Fluency.VeryGood ? "Very Good" : (x.EngSpeaking == Common.Fluency.Good ? "Good" : (x.EngSpeaking == Common.Fluency.Average ? "Average" : (x.EngSpeaking == Common.Fluency.Weak ? "Weak" : "None"))),
                EngWriting = x.EngWriting == Common.Fluency.VeryGood ? "Very Good" : (x.EngWriting == Common.Fluency.Good ? "Good" : (x.EngWriting == Common.Fluency.Average ? "Average" : (x.EngWriting == Common.Fluency.Weak ? "Weak" : "None"))),
                EngReading = x.EngReading == Common.Fluency.VeryGood ? "Very Good" : (x.EngReading == Common.Fluency.Good ? "Good" : (x.EngReading == Common.Fluency.Average ? "Average" : (x.EngReading == Common.Fluency.Weak ? "Weak" : "None"))),
                EmmergencyContactName = x.EmergencyConName,
                EmmergencyContactTelno = x.EmergencyContactTel,
                SpecialAttention = x.SpecialAttention,
                DateRegistered = x.CreatedDate,
                Grade = x.ClassStudents.Select(y => y.PromotionClass.Class.Grade == StudGrade.Grade1 ? "Grade 1" : y.PromotionClass.Class.Grade == StudGrade.Grade2 ? "Grade 2" : y.PromotionClass.Class.Grade == StudGrade.Grade3 ? "Grade 3" : y.PromotionClass.Class.Grade == StudGrade.Grade4 ? "Grade 4" :
                y.PromotionClass.Class.Grade == StudGrade.JuniorPart1 ? "Junior Part 1" : y.PromotionClass.Class.Grade == StudGrade.JuniorPart2 ? "Junior Part 2" : y.PromotionClass.Class.Grade == StudGrade.SeniorPart1 ? "Senior Part 1" : y.PromotionClass.Class.Grade == StudGrade.SeniorPart2 ? "Senior Part 2" : y.PromotionClass.Class.Grade.ToString()).FirstOrDefault()
            }).ToList();

            var lstSibDet = db.Students.Where(x => x.StudID == rptObj.StudentID).SelectMany(x => x.StudSublings).Select(x => new
            {
                Name = x.StudentRelation.Title + ". " + x.StudentRelation.FullName,
                Relationship = x.Relationship == Common.SibRelationship.Brother ? "Brother" : "Sister",
                Class = x.StudentRelation.ClassStudents.Select(y => y.PromotionClass.Class.Grade == StudGrade.Grade1 ? "Grade 1" : y.PromotionClass.Class.Grade == StudGrade.Grade2 ? "Grade 2" : y.PromotionClass.Class.Grade == StudGrade.Grade3 ? "Grade 3" : y.PromotionClass.Class.Grade == StudGrade.Grade4 ? "Grade 4" :
                y.PromotionClass.Class.Grade == StudGrade.JuniorPart1 ? "Junior Part 1" : y.PromotionClass.Class.Grade == StudGrade.JuniorPart2 ? "Junior Part 2" : y.PromotionClass.Class.Grade == StudGrade.SeniorPart1 ? "Senior Part 1" : y.PromotionClass.Class.Grade == StudGrade.SeniorPart2 ? "Senior Part 2" : y.PromotionClass.Class.Grade.ToString()).FirstOrDefault() + " - " + x.StudentRelation.ClassStudents.Select(y => y.PromotionClass.Class.ClassDesc).FirstOrDefault()
            }).ToList();

            var lstFamDet = db.Students.Where(x => x.StudID == rptObj.StudentID).SelectMany(x => x.StudFamilies).Select(x => new
            {
                Name = x.Title + " " + x.Name,
                Relationship = x.Relationship == Common.Relationship.Father ? "Father" : (x.Relationship == Common.Relationship.Mother ? "Mother" : "Guardian"),
                Occupation = x.Occupation,
                WorkingAdd = x.WorkingAdd,
                OfficeContact = x.OfficeTel,
                HomeContact = x.ContactHome,
                MobileContact = x.ContactMob,
                EmailAdd = x.Email,
                NICno = x.NICNo
            }).ToList();

            if (lstHdr.Count == 0)
            { return HttpNotFound(); }

            LocalReport report = new LocalReport();
            report.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/ApplicationForm.rdlc");

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "dsStudent";
            rds.Value = lstHdr;
            report.DataSources.Add(rds);

            rds = new ReportDataSource();
            rds.Name = "dbSiblings";
            rds.Value = lstSibDet;
            report.DataSources.Add(rds);

            rds = new ReportDataSource();
            rds.Name = "dsFamily";
            rds.Value = lstFamDet;
            report.DataSources.Add(rds);

            Byte[] mybytes = report.Render("PDF");

            Response.AppendHeader("content-disposition", "inline; filename=file.pdf");
            return new FileStreamResult(new MemoryStream(mybytes), "application/pdf");
        }

        [HttpPost]
        public ActionResult AdmissionSheet(ReportParameterVM para)
        {
            Session.Remove(sskCrtdObj);

            if (para.StudentID == 0)
            { ModelState.AddModelError("StudentID", "Student must be selected"); }

            if (!ModelState.IsValid)
            { return View(para); }

            Session[sskCrtdObj] = para;
            return Json(new { viewIt = true });
        }

        public ActionResult PrintEnvelope(bool? viewIt)
        {
            if (viewIt != true || !(Session[sskCrtdObj] is ReportParameterVM))
            { return View(new ReportParameterVM()); }

            ReportParameterVM rptObj = (ReportParameterVM)Session[sskCrtdObj];

            LocalReport report = new LocalReport();
            report.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/Envelope.rdlc");
            ReportDataSource rds = new ReportDataSource();
            if (rptObj.EnvelopType == EnvelopType.StudentWise)
            {
                var lst1 = db.Students.Where(x => x.StudID == rptObj.StudentID).ToList().Select(x => new
                {
                    Name = x.Title + ". " + x.Initials + " " + x.LName,
                    AdmissionNo = "[ " + x.IndexNo + " ]",
                    x.Address,
                }).ToList();

                rds = new ReportDataSource();
                rds.Name = "dsEnvelope";
                rds.Value = lst1;
                report.DataSources.Add(rds);
            }
            else
            {
                var lst2 = db.ClassStudents.Where(x => x.PrClID == rptObj.ClassID).ToList().Select(x => new
                {
                    Name = x.Student.Title + ". " + x.Student.Initials + " " + x.Student.LName,
                    AdmissionNo = "[ " + x.Student.IndexNo + " ]",
                    x.Student.Address,
                }).ToList();

                rds = new ReportDataSource();
                rds.Name = "dsEnvelope";
                rds.Value = lst2;
                report.DataSources.Add(rds);
            }
            Byte[] mybytes = report.Render("PDF");
            Response.AppendHeader("content-disposition", "inline; filename=file.pdf");
            return new FileStreamResult(new MemoryStream(mybytes), "application/pdf");
        }
        [HttpPost]
        public ActionResult PrintEnvelope(ReportParameterVM para)
        {
            Session.Remove(sskCrtdObj);

            if (para.EnvelopType == EnvelopType.ClassWise)
            {
                if (para.PeriodID == 0)
                { ModelState.AddModelError("PeriodID", "Period must be selected"); }
                if (para.ClassID == 0)
                { ModelState.AddModelError("ClassID", "Class must be selected"); }
                ModelState["StudentID"].Errors.Clear();
            }
            else
            {
                if (para.StudentID == 0)
                { ModelState.AddModelError("StudentID", "Student must be selected"); }
                ModelState["PeriodID"].Errors.Clear();
                ModelState["ClassID"].Errors.Clear();
            }

            if (!ModelState.IsValid)
            { return View(para); }

            Session[sskCrtdObj] = para;
            return Json(new { viewIt = true });
        }
    }
}