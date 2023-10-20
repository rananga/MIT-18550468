using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WebForms;
using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Areas.Base;
using StudentInformationSystem.Areas.Student.Models;
using StudentInformationSystem.Common;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace StudentInformationSystem.Areas.Student.Controllers
{
    public class LeavingCertificateController : BaseController
    {
        // GET: Student/LeavingCertificate
        public ActionResult Index(BaseViewModel<LeavingCertificatesVM> vm)
        {
            vm.SetList(db.LeavingCertificates.AsQueryable(), "StudID", SortDirection.Descending);
            return View(vm);
        }

        public ActionResult Create()
        {
            var leavingCertificateVm = new LeavingCertificatesVM() { DateLeaving = DateTime.Now };
            Session[sskCrtdObj] = leavingCertificateVm;

            return View(leavingCertificateVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LeavCertID,StudID,DateLeaving,Reason,Conduct")] LeavingCertificatesVM leavingCertificate)
        {
            try
            {
                if (leavingCertificate.StudID == 0)
                { ModelState.AddModelError("StudID", "Student should be selected."); }

                if (leavingCertificate.DateLeaving == null)
                { ModelState.AddModelError("DateLeaving", "Leaving Date should be selected."); }


                int ExistLeavingCet = db.LeavingCertificates.Where(x => x.StudId == leavingCertificate.StudID).Count();
                if (ExistLeavingCet != 0)
                { ModelState.AddModelError("", "Leaving Certificate already issued for this student."); }

                if (ModelState.IsValid)
                {
                    leavingCertificate.CreatedBy = this.GetCurrUser();
                    leavingCertificate.CreatedDate = DateTime.Now;
                    var newObj = db.LeavingCertificates.Add(leavingCertificate.GetEntity()).Entity;

                    var student = db.Students.Find(leavingCertificate.StudID);
                    student.IsLeavingIssued = true;
                    student.Status = StudStatus.Inactive;
                    student.ModifiedBy = this.GetCurrUser();
                    student.ModifiedDate = DateTime.Now;
                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Leaving certificate issued successfully.");
                    return RedirectToAction("Details", new { id = newObj.LeavCertId });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(leavingCertificate);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeavingCertificate leavingCert = db.LeavingCertificates.Find(id);
            if (leavingCert == null)
            {
                return HttpNotFound();
            }

            LeavingCertificatesVM VM = new LeavingCertificatesVM(leavingCert);
            return View(VM);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LeavingCertificate LeavingCert = db.LeavingCertificates.Find(id);
            if (LeavingCert == null)
            {
                return HttpNotFound();
            }
            var obj = new LeavingCertificatesVM(LeavingCert);
            Session[sskCrtdObj] = obj;
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LeavCertID,StudID,DateLeaving,Reason,Conduct,RowVersion,StudentName")] LeavingCertificatesVM leavingCertificate)
        {
            byte[] curRowVersion = null;
            try
            {
                if (leavingCertificate.StudID == 0)
                { ModelState.AddModelError("StudID", "Student should be selected."); }

                if (leavingCertificate.DateLeaving == null)
                { ModelState.AddModelError("DateLeaving", "Leaving Date should be selected."); }

                if (ModelState.IsValid)
                {
                    var obj = db.LeavingCertificates.Find(leavingCertificate.LeavCertID);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = leavingCertificate.GetEntity();
                    modObj.CopyContent(obj, "DateLeaving,Reason,Conduct");
                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;
                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Leaving certificate Modified Successfully.");
                    return RedirectToAction("Details", new { id = modObj.LeavCertId });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(leavingCertificate);
        }
        public ActionResult PrintLeaveCertificate(int id)
        {
            var lst = db.LeavingCertificates.Where(x => x.LeavCertId == id).ToList()
                .Select(x => new
                {
                    StudentName = x.Student.FullName,
                    DOB = x.Student.DOB.Value.ToString("dd-MM-yyyy"),
                    Address = x.Student.Address1 + " " + x.Student.Address2 + " " + x.Student.City,
                    EmergencyConName = x.Student.StudentFamilies.Select(y => y.Parent.FullName + " " + "(" + y.Relationship.ToEnumChar() + ")").FirstOrDefault(),
                    DateOfAdmission = x.Student.CreatedDate.ToString("dd-MM-yyyy"),
                    AdmissionNo = x.Student.AdmissionNo,
                    DateLeaving = x.DateLeaving.ToString("dd-MM-yyyy"),
                    x.Reason,
                    Conduct = x.Conduct.ToEnumChar(),
                    //LastClassAttend = x.Student.ClassStudents.Select(y => y.PromotionClass.Class.Grade.ToEnumChar()).LastOrDefault()
                }).ToList();


            LocalReport report = new LocalReport();
            report.ReportPath = System.Web.HttpContext.Current.Server.MapPath("~/Reports/StudentLeavingCertificate.rdlc");

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "dsLeavingCertificateDetails";
            rds.Value = lst;
            report.DataSources.Add(rds);

            Byte[] mybytes = report.Render("PDF");

            Response.AppendHeader("content-disposition", "inline; filename=file.pdf");
            return new FileStreamResult(new MemoryStream(mybytes), "application/pdf");
        }

        public ActionResult GetStudInfo(int studID)
        {
            var obj = db.Students.Find(studID);

            var AdmissionNo = obj.AdmissionNo;
            var InitName = obj.Initials + " " + obj.LastName;
            var Fullname = obj.FullName;

            return Json(new { AdmissionNo, InitName, Fullname, }, JsonRequestBehavior.AllowGet);
        }
    }
}