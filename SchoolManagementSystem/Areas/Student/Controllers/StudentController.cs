using Microsoft.Reporting.WebForms;
using SMS.Areas.Base.Controllers;
using SMS.Areas.Student.Models;
using SMS.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace SMS.Areas.Student.Controllers
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
                Common.DB.Student student = db.Students.Where(x => x.StudID == id).FirstOrDefault();
                if (student == null)
                {
                    return HttpNotFound();
                }
                obj = new StudentVM(student);
            }

            ViewBag.IsToEdit = isToEdit;
            ViewBag.StudID = obj.StudID;
            return PartialView("_ChildIndex", obj.StudSublings);
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
                Common.DB.Student student = db.Students.Where(x => x.StudID == id).FirstOrDefault();
                if (student == null)
                {
                    return HttpNotFound();
                }
                obj = new StudentVM(student);
            }

            ViewBag.IsToEdit = isToEdit;
            ViewBag.StudID = obj.StudID;
            return PartialView("_FamilyIndex", obj.StudFamilies);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Common.DB.Student student = db.Students.Find(id);
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

            var student = new StudentVM();            
            
            Session[sskCrtdObj] = student;
            Session.Remove(sskTempPic);
            Session.Remove(sskTempPicName);
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudID,IndexNo,Title,Gender,FullName,Initials,LName,Address,DOB,School,SchoolAddress,LastDhammaSchool,LDhammaSchoolAdd,LastDhammaGrade,EngSpeaking,EngWriting,EngReading,EmergencyConName,EmergencyContactTel,SpecialAttention,NameWithInt,ImagePath,Status,IsLeavingIssued,InactiveReason")] StudentVM student)
        {
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
                    student.IndexNo = lastStudIndex++;

                    var objStudent = db.Students.Add(student.GetEntity());
                    db.SaveChanges();

                    var imgPath = SaveImage(objStudent.StudID, student.ImagePath);
                    if (!imgPath.IsBlank())
                    {
                        objStudent.ImagePath = imgPath;
                        db.SaveChanges();
                    }

                    foreach (var det in obj.StudSublings)
                    {
                        det.SudID = objStudent.StudID;
                        det.CreatedBy = objStudent.CreatedBy;
                        det.CreatedDate = DateTime.Now;
                        db.StudSublings.Add(det.GetEntity());
                    }

                    foreach (var det in obj.StudFamilies)
                    {
                        det.StudID = objStudent.StudID;
                        det.CreatedBy = objStudent.CreatedBy;
                        det.CreatedDate = DateTime.Now;
                        db.StudFamilies.Add(det.GetEntity());
                    }

                    db.SaveChanges();

                    AddAlert(SMS.Common.AlertStyles.success, "Student Admission Created Successfully.");
                    return RedirectToAction("Details", new { id = objStudent.StudID });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

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
            StudSublingsVM studSublings = obj.StudSublings.Where(x => x.SubID == id.Value).FirstOrDefault();
            if (studSublings == null)
            {
                return HttpNotFound();
            }
            return PartialView("_ChildDetails", studSublings);
        }

        [AllowAnonymous]
        public ActionResult FamilyDetails(int? id)
        {
            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentVM obj = (StudentVM)Session[sskCrtdObj];
            StudFamilyVM studFamilyVM = obj.StudFamilies.Where(x => x.StudFID == id.Value).FirstOrDefault();
            if (studFamilyVM == null)
            {
                return HttpNotFound();
            }
            return PartialView("_FamilyDetails", studFamilyVM);
        }


        [AllowAnonymous]
        public ActionResult ChildCreate(int? studID)
        {
            StudentVM obj = null;

            if (studID != 0)
            {
                if (studID == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Common.DB.Student student = db.Students.Find(studID);

                obj = new StudentVM(student);
                if (student == null)
                {
                    return HttpNotFound();
                }
            }

            obj = (StudentVM)Session[sskCrtdObj];

            var StudSublingsVM = new StudSublingsVM() { SudID = studID.Value };
            return PartialView("_ChildCreate", StudSublingsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult ChildCreate([Bind(Include = "SubID,SudID,SublingStudID,Relationship,StudWithInit,IndexNo,Title,FullName,Initials,LName,Title")] StudSublingsVM studentSibling)
        {
            StudentVM obj;
            try
            {
                if (ModelState.IsValid)
                {
                    obj = (StudentVM)Session[sskCrtdObj];
                    studentSibling.SubID = Math.Min(obj.StudSublings.Select(x => x.SubID).MinOrDefault(), 0) - 1;
                    obj.StudSublings.Add(studentSibling);

                    AddAlert(SMS.Common.AlertStyles.success, "Student Siblings Added Successfully.");
                    string url = Url.Action("ChildIndex", new { id = studentSibling.SubID, isToEdit = true });
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
            var InitName = obj.Initials + " " + obj.LName;
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
                Common.DB.Student enrollment = db.Students.Find(studID);
                if (enrollment == null)
                {
                    return HttpNotFound();
                }
            }
            var obj = (StudentVM)Session[sskCrtdObj];

            var studFamilyVM = new StudFamilyVM() { StudID = studID.Value };
            return PartialView("_FamilyCreate", studFamilyVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult FamilyCreate([Bind(Include = "StudFID,StudID,Name,Relationship,Occupation,WorkingAdd,OfficeTel,ContactMob,ContactHome,Email,NICNo,Title")] StudFamilyVM studFamilyVM)
        {
            StudentVM obj;
            try
            {
                if (ModelState.IsValid)
                {
                    obj = (StudentVM)Session[sskCrtdObj];
                    studFamilyVM.StudFID = Math.Min(obj.StudFamilies.Select(x => x.StudFID).MinOrDefault(), 0) - 1;
                    obj.StudFamilies.Add(studFamilyVM);

                    AddAlert(SMS.Common.AlertStyles.success, "Family Member Added Successfully.");
                    string url = Url.Action("FamilyIndex", new { id = studFamilyVM.StudFID, isToEdit = true });
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
            Common.DB.Student student = db.Students.Find(id);
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
        public ActionResult Edit([Bind(Include = "StudID,IndexNo,Title,Gender,FullName,Initials,LName,Address,DOB,School,SchoolAddress,LastDhammaSchool,LDhammaSchoolAdd,LastDhammaGrade,EngSpeaking,EngWriting,EngReading,EmergencyConName,EmergencyContactTel,SpecialAttention,NameWithInt,RowVersion,ImagePath,Status,IsLeavingIssued,InactiveReason")] StudentVM student)
        {
            byte[] curRowVersion = null;
            try
            {
                var studvm = (StudentVM)Session[sskCrtdObj];

                if (student.Status == StudStatus.Inactive && student.InactiveReason == null)
                { ModelState.AddModelError("InactiveReason", "InactiveReason is required"); }

                if (ModelState.IsValid)
                {
                    var obj = db.Students.Find(student.StudID);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = student.GetEntity();
                    modObj.CopyContent(obj, "StudID,IndexNo,Title,Gender,FullName,Initials,LName,Address,DOB,School,SchoolAddress,LastDhammaSchool,LDhammaSchoolAdd,LastDhammaGrade,EngSpeaking,EngWriting,EngReading,EmergencyConName,EmergencyContactTel,SpecialAttention,NameWithInt,ImagePath,Status,IsLeavingIssued,InactiveReason");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;
                    obj.ImagePath = SaveImage(obj.StudID, obj.ImagePath);

                    db.Entry(obj).OriginalValues["RowVersion"] = student.RowVersion;

                    db.StudSublings.RemoveRange(obj.StudSublings.Where(x =>
                        !studvm.StudSublings.Select(y => y.SubID).ToList().Contains(x.SubID)));

                    foreach (var det in studvm.StudSublings)
                    {
                        var objDet = db.StudSublings.Find(det.SubID);
                        if (objDet == null)
                        {
                            det.CreatedBy = this.GetCurrUser();
                            det.CreatedDate = DateTime.Now;
                            db.StudSublings.Add(det.GetEntity());
                        }
                        else
                        {
                            var modObjDet = det.GetEntity();
                            modObjDet.CopyContent(objDet, "SudID,SublingStudID,Relationship,StudWithInit,IndexNo,Title,FullName,Initials,LName");

                            objDet.ModifiedBy = this.GetCurrUser();
                            objDet.ModifiedDate = DateTime.Now;
                        }
                    }


                    db.StudFamilies.RemoveRange(obj.StudFamilies.Where(x =>
                       !studvm.StudFamilies.Select(y => y.StudFID).ToList().Contains(x.StudFID)));

                    foreach (var exper in studvm.StudFamilies)
                    {
                        var objexpe = db.StudFamilies.Find(exper.StudFID);
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
                    return RedirectToAction("Details", new { id = obj.StudID });
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
            StudSublingsVM studSublingsVM = ((StudentVM)Session[sskCrtdObj]).StudSublings.FirstOrDefault(x => x.SubID == id);
            if (studSublingsVM == null)
            {
                return HttpNotFound();
            }
            return PartialView("_ChildEdit", studSublingsVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChildEdit([Bind(Include = "SubID,SudID,SublingStudID,Relationship,StudWithInit,IndexNo,Title,FullName,Initials,LName")] StudSublingsVM studSublingsVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = ((StudentVM)Session[sskCrtdObj]).StudSublings.FirstOrDefault(x => x.SubID == studSublingsVM.SubID);
                    studSublingsVM.CopyContent(obj, "SudID,SublingStudID,Relationship,StudWithInit,IndexNo,Title,FullName,Initials,LName");
                    AddAlert(SMS.Common.AlertStyles.success, "Siblings Modified Successfully.");
                    string url = Url.Action("ChildIndex", new { id = studSublingsVM.SubID, isToEdit = true });
                    return Json(new { success = true, url = url });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            return PartialView("_ChildEdit", studSublingsVM);
        }

        public ActionResult FamilyEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudFamilyVM studFamilyvm = ((StudentVM)Session[sskCrtdObj]).StudFamilies.FirstOrDefault(x => x.StudFID == id);
            if (studFamilyvm == null)
            {
                return HttpNotFound();
            }
            return PartialView("_FamilyEdit", studFamilyvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FamilyEdit([Bind(Include = "StudFID,StudID,Name,Relationship,Occupation,WorkingAdd,OfficeTel,ContactMob,ContactHome,Email,NICNo,Title")] StudFamilyVM studFamilyvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = ((StudentVM)Session[sskCrtdObj]).StudFamilies.FirstOrDefault(x => x.StudFID == studFamilyvm.StudFID);
                    studFamilyvm.CopyContent(obj, "Name,Relationship,Occupation,WorkingAdd,OfficeTel,ContactMob,ContactHome,Email,NICNo,Title");
                    AddAlert(SMS.Common.AlertStyles.success, "Family Member Modified Successfully.");
                    string url = Url.Action("FamilyIndex", new { id = studFamilyvm.StudFID, isToEdit = true });
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
                var obj = db.Students.Find(student.StudID);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }
                db.Detach(obj);

                db.Entry(student.GetEntity()).State = System.Data.Entity.EntityState.Deleted;
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
            return RedirectToAction("Details", new { id = student.StudID });
        }

        [HttpPost, ActionName("ChildDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ChildDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            try
            {
                var lst = ((StudentVM)Session[sskCrtdObj]).StudSublings;
                var obj = lst.FirstOrDefault(x => x.SubID == id);
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
                var lst = ((StudentVM)Session[sskCrtdObj]).StudFamilies;
                var obj = lst.FirstOrDefault(x => x.StudFID == id);
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
        public ActionResult UploadPic([Bind(Include = "StudID,IndexNo,Title,Gender,FullName,Initials,LName,Address,School,SchoolAddress,LastDhammaSchool,LDhammaSchoolAdd,EngSpeaking,EngWriting,EngReading,EmergencyConName,EmergencyContactTel,SpecialAttention,NameWithInt,RowVersion,ProfilePic,IsLeavingIssued,InactiveReason")] StudentVM student, string FromAction)
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

            Common.DB.Student student = db.Students.Find(id);

            var basePath = ConfigurationManager.AppSettings["EnrollmentsImagePath"];
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
                var basePath = ConfigurationManager.AppSettings["EnrollmentsImagePath"];
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
            var lstHdr = db.Students.Where(x => x.StudID == id).Select(x => new
            {
                x.StudID,
                Title = x.Title == TitleStud.Mr ? "Mr. " : "Ms.",
                AdmissionNo = x.IndexNo,
                FullName = x.FullName,
                Initials = x.Initials,
                LastName = x.LName,
                Address = x.Address,
                DOB = x.DOB,
                Gender = x.Gender == Gender.Female ? "Female" : "Male",
                SchoolName = x.School,
                SchoolAddress = x.SchoolAddress,
                DhammaSchoolName = x.LastDhammaSchool,
                DhammaSchoolAddress = x.LDhammaSchoolAdd,
                GradehammaSchoolLeave = x.LastDhammaGrade,
                EngSpeacking = x.EngSpeaking == Fluency.VeryGood ? "Very Good" : (x.EngSpeaking == Fluency.Good ? "Good" : (x.EngSpeaking == Fluency.Average ? "Average" : (x.EngSpeaking == Fluency.Weak ? "Weak" : "None"))),
                EngWriting = x.EngWriting == Fluency.VeryGood ? "Very Good" : (x.EngWriting == Fluency.Good ? "Good" : (x.EngWriting == Fluency.Average ? "Average" : (x.EngWriting == Fluency.Weak ? "Weak" : "None"))),
                EngReading = x.EngReading == Fluency.VeryGood ? "Very Good" : (x.EngReading == Fluency.Good ? "Good" : (x.EngReading == Fluency.Average ? "Average" : (x.EngReading == Fluency.Weak ? "Weak" : "None"))),
                EmmergencyContactName = x.EmergencyConName,
                EmmergencyContactTelno = x.EmergencyContactTel,
                SpecialAttention = x.SpecialAttention,
                DateRegistered = x.CreatedDate
            }).ToList();

            var lstSibDet = db.Students.Where(x => x.StudID == id).SelectMany(x => x.StudSublings).Select(x => new
            {
                Name = x.StudentRelation.Title + ". "+ x.StudentRelation.Initials + " " + x.StudentRelation.LName,
                Relationship = x.Relationship == SibRelationship.Brother ? "Brother" : "Sister",
                Class = x.StudentRelation.ClassStudents.Select(y => y.PromotionClass.Class.Grade).FirstOrDefault() +" - " + x.StudentRelation.ClassStudents.Select(y => y.PromotionClass.Class.ClassDesc).FirstOrDefault()
            }).ToList();

            var lstFamDet = db.Students.Where(x => x.StudID == id).SelectMany(x => x.StudFamilies).Select(x => new
            {
                Name = x.Name,
                Relationship = x.Relationship == Relationship.Father ? "Father" : (x.Relationship == Relationship.Mother ? "Mother" : "Guardian"),
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
    }
}