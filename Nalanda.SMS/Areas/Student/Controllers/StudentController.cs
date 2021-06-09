﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Reporting.WebForms;
using Nalanda.SMS.Data;
using Nalanda.SMS.Areas.Base;
using Nalanda.SMS.Areas.Student.Models;
using Nalanda.SMS.Common;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Nalanda.SMS.Areas.Student.Controllers
{
    public class StudentController : BaseController
    {
        // GET: Student/Student
        public static readonly string tdkTempEnrol = "TempEnrol";
        public ActionResult Index(BaseViewModel<StudentVM> vm)
        {
            vm.SetList(db.Students.AsQueryable(), "IndexNo", SortDirection.Descending);
            return View(vm);
        }

        [AllowAnonymous]
        public ActionResult ChildIndex(int? id, bool isToEdit = false)
        {
            StudentVM obj;

            if (isToEdit && Session[sskCrtdObj] is StudentVM)
            { obj = (StudentVM)Session[sskCrtdObj]; }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Nalanda.SMS.Data.Models.Student student = db.Students.Where(x => x.Id == id).FirstOrDefault();
                if (student == null)
                {
                    return HttpNotFound();
                }
                obj = new StudentVM(student);
            }

            ViewBag.IsToEdit = isToEdit;
            ViewBag.StudID = obj.Id;
            return PartialView("_ChildIndex", obj.Siblings);
        }

        [AllowAnonymous]
        public ActionResult FamilyIndex(int? id, bool isToEdit = false)
        {
            StudentVM obj;

            if (isToEdit && Session[sskCrtdObj] is StudentVM)
            { obj = (StudentVM)Session[sskCrtdObj]; }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Nalanda.SMS.Data.Models.Student student = db.Students.Where(x => x.Id == id).FirstOrDefault();
                if (student == null)
                {
                    return HttpNotFound();
                }
                obj = new StudentVM(student);
            }

            ViewBag.IsToEdit = isToEdit;
            ViewBag.StudID = obj.Id;
            return PartialView("_FamilyIndex", obj.FamilyMembers);
        }

        [AllowAnonymous]
        public ActionResult AcheivementIndex(int? id, bool isToEdit = false)
        {
            StudentVM obj;

            if (isToEdit && Session[sskCrtdObj] is StudentVM)
            { obj = (StudentVM)Session[sskCrtdObj]; }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var cls = db.Students.Where(x => x.Id == id).FirstOrDefault();
                if (cls == null)
                {
                    return HttpNotFound();
                }
                obj = new StudentVM(cls);
            }

            ViewBag.IsToEdit = isToEdit;
            ViewBag.ActivityId = obj.Id;
            return PartialView("_AcheivementIndex", obj.Acheivements);
        }

        [AllowAnonymous]
        public ActionResult PositionIndex(int? id, bool isToEdit = false)
        {
            StudentVM obj;

            if (isToEdit && Session[sskCrtdObj] is StudentVM)
            { obj = (StudentVM)Session[sskCrtdObj]; }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var cls = db.Students.Where(x => x.Id == id).FirstOrDefault();
                if (cls == null)
                {
                    return HttpNotFound();
                }
                obj = new StudentVM(cls);
            }

            ViewBag.IsToEdit = isToEdit;
            ViewBag.ActivityId = obj.Id;
            return PartialView("_PositionIndex", obj.Positions);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nalanda.SMS.Data.Models.Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            Session.Remove(sskTempPic);
            Session.Remove(sskTempPicName);
            return View(new StudentVM(student));
        }

        public ActionResult Create()
        {
            if (TempData.ContainsKey(tdkTempEnrol))
            {
                var stud = (StudentVM)TempData[tdkTempEnrol];
                TempData.Remove(tdkTempEnrol);
                return View(stud);
            }

            var student = new StudentVM() { AdmissionDate = new DateTime(DateTime.Now.Year, 1, 1) };

            Session[sskCrtdObj] = student;
            Session.Remove(sskTempPic);
            Session.Remove(sskTempPicName);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentVM student)
        {
            var dbTrans = db.Database.BeginTransaction();
            try
            {
                var obj = (StudentVM)Session[sskCrtdObj];

                var existingStudent = db.Students.Where(e => e.FullName == student.FullName).FirstOrDefault();

                if (existingStudent != null)
                { ModelState.AddModelError("FullName", "Student Already Exist"); }

                if (ModelState.IsValid)
                {
                    student.CreatedBy = this.GetCurrUser();
                    student.CreatedDate = DateTime.Now;

                    var lastStudIndex = db.Students.MaxOrDefault(x => x.IndexNo);
                    student.IndexNo = Math.Max(lastStudIndex, 10000) + 1;

                    var objStudent = db.Students.Add(student.GetEntity()).Entity;
                    db.SaveChanges();

                    objStudent.SchoolEmail = $"{objStudent.IndexNo}@nalandacollege.info";

                    var imgPath = SaveImage(objStudent.Id, student.ImagePath);
                    if (!imgPath.IsBlank())
                    {
                        objStudent.ImagePath = imgPath;
                        db.SaveChanges();
                    }

                    foreach (var det in obj.Siblings)
                    {
                        det.StudentId = objStudent.Id;
                        det.CreatedBy = objStudent.CreatedBy;
                        det.CreatedDate = DateTime.Now;
                        db.StudSiblings.Add(det.GetEntity());
                    }

                    foreach (var det in obj.FamilyMembers)
                    {
                        det.StudentId = objStudent.Id;
                        det.CreatedBy = objStudent.CreatedBy;
                        det.CreatedDate = DateTime.Now;
                        db.StudFamilies.Add(det.GetEntity());
                    }

                    db.SaveChanges();
                    dbTrans.Commit();

                    AddAlert(SMS.Common.AlertStyles.success, "Student Admission Created Successfully.");
                    return RedirectToAction("Details", new { id = objStudent.Id });
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                dbTrans.Rollback();
                this.ShowEntityErrors(dbEx);
            }
            catch (Exception ex)
            {
                dbTrans.Rollback();
                AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message);
            }

            return View(student);
        }

        [AllowAnonymous]
        public ActionResult ChildDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentVM obj = (StudentVM)Session[sskCrtdObj];
            StudSiblingsVM studSiblings = obj.Siblings.Where(x => x.Id == id.Value).FirstOrDefault();
            if (studSiblings == null)
            {
                return HttpNotFound();
            }
            return PartialView("_ChildDetails", studSiblings);
        }

        [AllowAnonymous]
        public ActionResult FamilyDetails(int? id)
        {
            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentVM obj = (StudentVM)Session[sskCrtdObj];
            StudFamilyVM studFamilyVM = obj.FamilyMembers.Where(x => x.Id == id.Value).FirstOrDefault();
            if (studFamilyVM == null)
            {
                return HttpNotFound();
            }
            return PartialView("_FamilyDetails", studFamilyVM);
        }


        [AllowAnonymous]
        public ActionResult ChildCreate(int? studID)
        {
            if (studID != 0)
            {
                if (studID == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var student = db.Students.Find(studID);

                if (student == null)
                {
                    return HttpNotFound();
                }
            }

            var StudSiblingsVM = new StudSiblingsVM() { StudentId = studID.Value };
            return PartialView("_ChildCreate", StudSiblingsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult ChildCreate(StudSiblingsVM studentSibling)
        {
            StudentVM obj;
            try
            {
                if (ModelState.IsValid)
                {
                    obj = (StudentVM)Session[sskCrtdObj];
                    studentSibling.Id = Math.Min(obj.Siblings.Select(x => x.Id).MinOrDefault(), 0) - 1;
                    obj.Siblings.Add(studentSibling);

                    AddAlert(SMS.Common.AlertStyles.success, "Student Siblings Added Successfully.");
                    string url = Url.Action("ChildIndex", new { id = studentSibling.Id, isToEdit = true });
                    return Json(new { success = true, url });
                }

            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            obj = (StudentVM)Session[sskCrtdObj];

            return PartialView("_ChildCreate", studentSibling);
        }

        public ActionResult GetFeeInfo(int studID)
        {
            var obj = db.Students.Find(studID);

            var IndexNo = obj.IndexNo;
            var Title = obj.Title.ToEnumChar();
            var InitName = obj.Initials + " " + obj.Lname;
            var Fullname = obj.FullName;

            return Json(new { IndexNo, Title, InitName, Fullname }, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult FamilyCreate(int? studID)
        {
            if (studID != 0)
            {
                if (studID == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Nalanda.SMS.Data.Models.Student enrollment = db.Students.Find(studID);
                if (enrollment == null)
                {
                    return HttpNotFound();
                }
            }
            var obj = (StudentVM)Session[sskCrtdObj];

            var studFamilyVM = new StudFamilyVM() { StudentId = studID.Value };
            return PartialView("_FamilyCreate", studFamilyVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult FamilyCreate(StudFamilyVM studFamilyVM)
        {
            StudentVM obj;
            try
            {
                if (ModelState.IsValid)
                {
                    obj = (StudentVM)Session[sskCrtdObj];
                    studFamilyVM.Id = Math.Min(obj.FamilyMembers.Select(x => x.Id).MinOrDefault(), 0) - 1;
                    obj.FamilyMembers.Add(studFamilyVM);

                    AddAlert(SMS.Common.AlertStyles.success, "Family Member Added Successfully.");
                    string url = Url.Action("FamilyIndex", new { id = studFamilyVM.Id, isToEdit = true });
                    return Json(new { success = true, url });
                }

            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            obj = (StudentVM)Session[sskCrtdObj];

            return PartialView("_FamilyCreate", studFamilyVM);
        }

        public ActionResult Edit(int? id)
        {
            if (TempData.ContainsKey(tdkTempEnrol))
            {
                var std = (StudentVM)TempData[tdkTempEnrol];
                TempData.Remove(tdkTempEnrol);
                return View(std);
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nalanda.SMS.Data.Models.Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            var obj = new StudentVM(student);
            Session[sskCrtdObj] = obj;
            Session.Remove(sskTempPic);
            Session.Remove(sskTempPicName);
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentVM student)
        {
            byte[] curRowVersion = null;
            try
            {
                var studvm = (StudentVM)Session[sskCrtdObj];

                if (student.Status == StudStatus.Inactive && student.InactiveReason == null)
                { ModelState.AddModelError("InactiveReason", "InactiveReason is required"); }

                if (ModelState.IsValid)
                {
                    var obj = db.Students.Find(student.Id);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = student.GetEntity();
                    modObj.CopyContent(obj, "StudID,IndexNo,Title,Gender,FullName,Initials,Lname,Address,DOB,School,SchoolAddress,LastDhammaSchool,LDhammaSchoolAdd,LastDhammaGrade,EngSpeaking,EngWriting,EngReading,EmergencyConName,EmergencyContactTel,SpecialAttention,NameWithInt,ImagePath,Status,IsLeavingIssued,InactiveReason");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;
                    obj.ImagePath = SaveImage(obj.Id, obj.ImagePath);

                    db.Entry(obj).OriginalValues["RowVersion"] = student.RowVersion;

                    db.StudSiblings.RemoveRange(obj.StudSiblings.Where(x =>
                        !studvm.Siblings.Select(y => y.Id).ToList().Contains(x.Id)));

                    foreach (var det in studvm.Siblings)
                    {
                        var objDet = db.StudSiblings.Find(det.Id);
                        if (objDet == null)
                        {
                            det.CreatedBy = this.GetCurrUser();
                            det.CreatedDate = DateTime.Now;
                            db.StudSiblings.Add(det.GetEntity());
                        }
                        else
                        {
                            var modObjDet = det.GetEntity();
                            modObjDet.CopyContent(objDet, "SudID,SiblingStudID,Relationship,StudWithInit,IndexNo,Title,FullName,Initials,LName");

                            objDet.ModifiedBy = this.GetCurrUser();
                            objDet.ModifiedDate = DateTime.Now;
                        }
                    }


                    db.StudFamilies.RemoveRange(obj.StudFamilies.Where(x =>
                       !studvm.FamilyMembers.Select(y => y.Id).ToList().Contains(x.Id)));

                    foreach (var exper in studvm.FamilyMembers)
                    {
                        var objexpe = db.StudFamilies.Find(exper.Id);
                        if (objexpe == null)
                        {
                            exper.CreatedBy = this.GetCurrUser();
                            exper.CreatedDate = DateTime.Now;
                            db.StudFamilies.Add(exper.GetEntity());
                        }
                        else
                        {
                            var modObjDet = exper.GetEntity();
                            modObjDet.CopyContent(objexpe, "StudID,Name,Relationship,Occupation,WorkingAdd,OfficeTel,ContactMob,ContactHome,Email,NICNo");

                            objexpe.ModifiedBy = this.GetCurrUser();
                            objexpe.ModifiedDate = DateTime.Now;
                        }
                    }

                    db.SaveChanges();

                    AddAlert(SMS.Common.AlertStyles.success, "Admission Modified Successfully.");
                    return RedirectToAction("Details", new { id = obj.Id });
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.ShowConcurrencyErrors(ex);
                student.RowVersion = curRowVersion;
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            return View(student);
        }


        public ActionResult ChildEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudSiblingsVM studSiblingsVM = ((StudentVM)Session[sskCrtdObj]).Siblings.FirstOrDefault(x => x.Id == id);
            if (studSiblingsVM == null)
            {
                return HttpNotFound();
            }
            return PartialView("_ChildEdit", studSiblingsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChildEdit(StudSiblingsVM studSiblingsVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = ((StudentVM)Session[sskCrtdObj]).Siblings.FirstOrDefault(x => x.Id == studSiblingsVM.Id);
                    studSiblingsVM.CopyContent(obj, "SudID,SiblingStudID,Relationship,StudWithInit,IndexNo,Title,FullName,Initials,LName");
                    AddAlert(SMS.Common.AlertStyles.success, "Siblings Modified Successfully.");
                    string url = Url.Action("ChildIndex", new { id = studSiblingsVM.Id, isToEdit = true });
                    return Json(new { success = true, url = url });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            return PartialView("_ChildEdit", studSiblingsVM);
        }

        public ActionResult FamilyEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudFamilyVM studFamilyvm = ((StudentVM)Session[sskCrtdObj]).FamilyMembers.FirstOrDefault(x => x.Id == id);
            if (studFamilyvm == null)
            {
                return HttpNotFound();
            }
            return PartialView("_FamilyEdit", studFamilyvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FamilyEdit(StudFamilyVM studFamilyvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = ((StudentVM)Session[sskCrtdObj]).FamilyMembers.FirstOrDefault(x => x.Id == studFamilyvm.Id);
                    studFamilyvm.CopyContent(obj, "Name,Relationship,Occupation,WorkingAdd,OfficeTel,ContactMob,ContactHome,Email,NICNo,Title");
                    AddAlert(SMS.Common.AlertStyles.success, "Family Member Modified Successfully.");
                    string url = Url.Action("FamilyIndex", new { id = studFamilyvm.Id, isToEdit = true });
                    return Json(new { success = true, url });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            return PartialView("_FamilyEdit", studFamilyvm);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(StudentVM student)
        {
            try
            {
                var obj = db.Students.Find(student.Id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }
                db.Detach(obj);

                var entry = db.Entry(student.GetEntity());
                entry.State = EntityState.Unchanged;
                entry.Collection(x => x.StudFamilies).Load();
                db.StudFamilies.RemoveRange(entry.Entity.StudFamilies);
                entry.Collection(x => x.StudSiblings).Load();
                db.StudSiblings.RemoveRange(entry.Entity.StudSiblings);
                entry.State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(SMS.Common.AlertStyles.success, "Student Admission Deleted Successfully.");
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.ShowConcurrencyErrors(ex, true);
                if (ex.Message == "")
                { return RedirectToAction("Index"); }
            }
            catch (Exception ex)
            {
                AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message);
            }
            return RedirectToAction("Details", new { id = student.Id });
        }

        [HttpPost, ActionName("ChildDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ChildDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            try
            {
                var lst = ((StudentVM)Session[sskCrtdObj]).Siblings;
                var obj = lst.FirstOrDefault(x => x.Id == id);
                lst.Remove(obj);

                AddAlert(SMS.Common.AlertStyles.success, "Sibling Removed Successfully.");
            }
            catch (Exception ex)
            {
                msg = ex.GetInnerException().Message;
                AddAlert(SMS.Common.AlertStyles.danger, msg);
            }
            string url = "";
            if (msg.IsBlank())
            { url = Url.Action("ChildIndex", new { isToEdit = true }); }
            return Json(new { success = true, url, msg });
        }

        [HttpPost, ActionName("FamilyDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult FamilyDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            try
            {
                var lst = ((StudentVM)Session[sskCrtdObj]).FamilyMembers;
                var obj = lst.FirstOrDefault(x => x.Id == id);
                lst.Remove(obj);

                AddAlert(SMS.Common.AlertStyles.success, "Family Member Removed Successfully.");
            }
            catch (Exception ex)
            {
                msg = ex.GetInnerException().Message;
                AddAlert(SMS.Common.AlertStyles.danger, msg);
            }
            string url = "";
            if (msg.IsBlank())
            { url = Url.Action("FamilyIndex", new { isToEdit = true }); }
            return Json(new { success = true, url, msg });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult UploadPic(StudentVM student, string FromAction)
        {
            if (student.ProfilePic != null && student.ProfilePic.ContentLength > 0)
            {
                BinaryReader br = new BinaryReader(student.ProfilePic.InputStream);
                byte[] binData = br.ReadBytes((int)student.ProfilePic.InputStream.Length);
                Session[sskTempPic] = Convert.ToBase64String(binData);
                Session[sskTempPicName] = student.ProfilePic.FileName;
            }

            TempData["TempEnrol"] = student;
            return RedirectToAction(FromAction);
        }

        [HttpPost]
        [AllowAnonymous]
        public JsonResult UploadPicStr(string imgString)
        {
            Session[sskTempPic] = imgString.Replace("data:image/png;base64,", "").Replace("data:image/jpeg;base64,", "");
            Session[sskTempPicName] = imgString.StartsWith("data:image/png") ? "temp.png" : "temp.jpeg";

            return Json("Success", JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult GetPic(int? id)
        {
            if (Session[sskTempPic] is string)
            {
                byte[] binData = Convert.FromBase64String((string)Session[sskTempPic]);
                return base.File(binData, MimeMapping.GetMimeMapping((string)Session[sskTempPicName]));
            }

            if (id == null)
            { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }

            Nalanda.SMS.Data.Models.Student student = db.Students.Find(id);

            var basePath = ConfigurationManager.AppSettings["StudentImagePath"];
            if (basePath.StartsWith("\\") && !basePath.StartsWith("\\\\"))
            { basePath = Server.MapPath("~" + basePath); }
            var defFilePath = Path.Combine(basePath, "Default.png");
            var filePath = defFilePath;

            if (student != null && !student.ImagePath.IsBlank())
            {
                var tempPath = Path.Combine(basePath, student.ImagePath);
                if (System.IO.File.Exists(tempPath))
                { filePath = tempPath; }
            }

            MemoryStream ms = new MemoryStream();
            using (FileStream fs = System.IO.File.OpenRead(filePath))
            { fs.CopyTo(ms); }

            return base.File(ms.ToArray(), MimeMapping.GetMimeMapping(filePath));
        }

        private string SaveImage(int EnrolId, string curPath)
        {
            if (!(Session[sskTempPic] is string))
            { return curPath; }

            try
            {
                var basePath = ConfigurationManager.AppSettings["StudentImagePath"];
                if (basePath.StartsWith("\\") && !basePath.StartsWith("\\\\"))
                { basePath = Server.MapPath("~" + basePath); }

                var fnam = EnrolId + Path.GetExtension(Session[sskTempPicName].ToString());
                var path = Path.Combine(basePath, fnam);

                if (!Directory.Exists(basePath))
                { Directory.CreateDirectory(basePath); }

                if (System.IO.File.Exists(path))
                { System.IO.File.Delete(path); }

                byte[] binData = Convert.FromBase64String((string)Session[sskTempPic]);
                System.IO.File.WriteAllBytes(path, binData);

                return fnam;
            }
            catch (Exception)
            { return null; }
        }

        public ActionResult PrintAdmissionSheet(int id)
        {
            var lstHdr = db.Students.Where(x => x.Id == id).Select(x => new
            {
                x.Id,
                Title = x.Title == TitleStud.Mr ? "Mr. " : "Ms.",
                AdmissionNo = x.IndexNo,
                FullName = x.FullName,
                Initials = x.Initials,
                LastName = x.Lname,
                Address = x.Address,
                DOB = x.Dob,
                GradehammaSchoolLeave = x.LastGrade,
                EmmergencyContactName = x.EmergencyConName,
                EmmergencyContactTelno = x.EmergencyContactTel,
                SpecialAttention = x.Medium,
                DateRegistered = x.AdmissionDate
            }).ToList();

            var lstSibDet = db.Students.Where(x => x.Id == id).SelectMany(x => x.StudSiblings).Select(x => new
            {
                Name = x.SiblingStudent.Title + ". " + x.SiblingStudent.Initials + " " + x.SiblingStudent.Lname,
                Relationship = x.Relationship == SibRelationship.YoungerBrother ? "Younger Brother" : "Elder Brother",
                Class = "" //x.SiblingStudent.ClassStudents.Select(y => y.PromotionClass.Class.Grade).FirstOrDefault() + " - " + x.SiblingStudent.ClassStudents.Select(y => y.PromotionClass.Class.ClassDesc).FirstOrDefault()
            }).ToList();

            var lstFamDet = db.Students.Where(x => x.Id == id).SelectMany(x => x.StudFamilies).Select(x => new
            {
                Name = x.Name,
                Relationship = x.Relationship == Relationship.Father ? "Father" : (x.Relationship == Relationship.Mother ? "Mother" : "Guardian"),
                Occupation = x.Occupation,
                WorkingAdd = x.WorkingAdd,
                OfficeContact = x.OfficeTel,
                HomeContact = x.ContactHome,
                MobileContact = x.ContactMob,
                EmailAdd = x.Email,
                NICno = x.Nicno
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
    }
}