using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Areas.Admin.Models;
using StudentInformationSystem.Areas.Base;
using StudentInformationSystem.Common;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Configuration;

namespace StudentInformationSystem.Areas.Admin.Controllers
{
    public class StaffMemberController : BaseController
    {
        public ActionResult Index(BaseViewModel<StaffMemberVM> vm)
        {
            vm.SetList(db.StaffMembers.AsQueryable(), "LastName");
            return View(vm);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var staff = db.StaffMembers.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            Session.Remove(sskTempPic);
            Session.Remove(sskTempPicName);
            return View(new StaffMemberVM(staff));
        }

        public ActionResult Create()
        {
            var teacher = new StaffMemberVM() { Status = ActiveStatus.Active };
            Session[sskCrtdObj] = teacher;
            Session.Remove(sskTempPic);
            Session.Remove(sskTempPicName);

            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StaffMemberVM staff)
        {
            var dbTrans = db.Database.BeginTransaction();
            try
            {
                var exStaffNo = db.StaffMembers.Where(e => e.StaffNumber == staff.StaffNumber).FirstOrDefault();
                if (exStaffNo != null)
                { ModelState.AddModelError("StaffNumber", "Staff Number Already Exists."); }

                var exSchoolEmail_MS = db.StaffMembers.Where(e => e.SchoolEmail_MS == staff.SchoolEmail_MS).FirstOrDefault();
                if (exSchoolEmail_MS != null)
                { ModelState.AddModelError("SchoolEmail_MS", $"Email Already Assinged to - {exSchoolEmail_MS.StaffNumber}."); }

                if (staff.IsTeacher && staff.TeacherSectionId == null)
                    ModelState.AddModelError("TeacherSectionId", "Teacher section is required.");

                var svm = (StaffMemberVM)Session[sskCrtdObj];

                if (ModelState.IsValid)
                {
                    staff.CreatedBy = this.GetCurrUser();
                    staff.CreatedDate = DateTime.Now;
                    var objStaff = db.StaffMembers.Add(staff.GetEntity()).Entity;
                    db.SaveChanges();

                    var imgPath = SaveImage(objStaff.Id, staff.ImagePath);
                    if (!imgPath.IsBlank())
                    {
                        objStaff.ImagePath = imgPath;
                    }

                    if (staff.IsTeacher)
                        objStaff.Teacher = new Data.Models.Teacher() { StaffId = objStaff.Id, SectionId = staff.TeacherSectionId.Value, CreatedBy = objStaff.CreatedBy, CreatedDate = DateTime.Now };

                    db.SaveChanges();
                    dbTrans.Commit();

                    AddAlert(AlertStyles.success, "Staff Member Created Successfully.");
                    return RedirectToAction("Index");
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
                AddAlert(AlertStyles.danger, ex.GetInnerException().Message);
            }

            return View(staff);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var staff = db.StaffMembers.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }

            var obj = new StaffMemberVM(staff);
            Session[sskCrtdObj] = obj;
            Session.Remove(sskTempPic);
            Session.Remove(sskTempPicName);

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StaffMemberVM staff)
        {
            byte[] curRowVersion = null;
            try
            {
                var exStaffNo = db.StaffMembers.Where(e => e.Id != staff.Id && e.StaffNumber == staff.StaffNumber).FirstOrDefault();
                if (exStaffNo != null)
                { ModelState.AddModelError("StaffNumber", "Staff Number Already Exists."); }

                var exSchoolEmail_MS = db.StaffMembers.Where(e => e.Id != staff.Id && !string.IsNullOrEmpty(e.SchoolEmail_MS) && e.SchoolEmail_MS == staff.SchoolEmail_MS).FirstOrDefault();
                if (exSchoolEmail_MS != null)
                { ModelState.AddModelError("SchoolEmail", $"Email Already Assinged to - {exSchoolEmail_MS.StaffNumber}."); }

                if (staff.IsTeacher && staff.TeacherSectionId == null)
                    ModelState.AddModelError("TeacherSectionId", "Teacher section is required.");

                var svm = (StaffMemberVM)Session[sskCrtdObj];

                if (ModelState.IsValid)
                {
                    var obj = db.StaffMembers.Find(staff.Id);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = staff.GetEntity();
                    modObj.CopyContent(obj, "StaffNumber,Gender,Title,FullName,Initials,LastName,Address1,Address2,City,MobileNo,SchoolEmail_MS,Nicno,TelHome,ImmeContactName,ImmeContactNo,Status,ImagePath,JoinedDate,RetiredDate,IsTeacher,TeacherSectionId");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;
                    obj.ImagePath = SaveImage(obj.Id, obj.ImagePath);

                    db.Entry(obj).OriginalValues["RowVersion"] = staff.RowVersion;

                    if (!staff.IsTeacher)
                    {
                        if (obj.Teacher != null)
                            db.Teachers.Remove(obj.Teacher);
                    }
                    else if (obj.Teacher == null)
                        obj.Teacher = new Data.Models.Teacher() { StaffId = obj.Id, SectionId = staff.TeacherSectionId.Value, CreatedBy = obj.CreatedBy, CreatedDate = DateTime.Now };
                    else
                    {
                        obj.Teacher.StaffId = obj.Id;
                        obj.Teacher.SectionId = staff.TeacherSectionId.Value;
                        obj.Teacher.ModifiedBy = this.GetCurrUser();
                        obj.Teacher.ModifiedDate = DateTime.Now;
                    }

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Staff Member Modified Successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.ShowConcurrencyErrors(ex);
                staff.RowVersion = curRowVersion;
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(staff);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(StaffMemberVM teacher)
        {
            try
            {
                var obj = db.StaffMembers.Find(teacher.Id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }

                var entry = db.Entry(obj);
                entry.State = EntityState.Unchanged;
                entry.Reference(x => x.Teacher).Load();
                if (entry.Entity.Teacher != null)
                    db.Teachers.Remove(entry.Entity.Teacher);
                entry.State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Staff Member Deleted Successfully.");
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
                AddAlert(AlertStyles.danger, ex.GetInnerException().Message);
            }
            return RedirectToAction("Details", new { id = teacher.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadPic(StaffMemberVM staff, string FromAction)
        {
            if (staff.ProfilePic != null && staff.ProfilePic.ContentLength > 0)
            {
                BinaryReader br = new BinaryReader(staff.ProfilePic.InputStream);
                byte[] binData = br.ReadBytes((int)staff.ProfilePic.InputStream.Length);
                Session[sskTempPic] = Convert.ToBase64String(binData);
                Session[sskTempPicName] = staff.ProfilePic.FileName;
            }

            TempData["TempEnrol"] = staff;
            return RedirectToAction(FromAction);
        }

        [HttpPost]
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

            var staff = db.StaffMembers.Find(id);

            var basePath = ConfigurationManager.AppSettings["StaffImagePath"];
            if (basePath.StartsWith("\\") && !basePath.StartsWith("\\\\"))
            { basePath = Server.MapPath("~" + basePath); }
            var defFilePath = Path.Combine(basePath, "Default.png");
            var filePath = defFilePath;

            if (staff != null && !staff.ImagePath.IsBlank())
            {
                var tempPath = Path.Combine(basePath, staff.ImagePath);
                if (System.IO.File.Exists(tempPath))
                { filePath = tempPath; }
            }

            MemoryStream ms = new MemoryStream();
            using (FileStream fs = System.IO.File.OpenRead(filePath))
            { fs.CopyTo(ms); }

            return base.File(ms.ToArray(), MimeMapping.GetMimeMapping(filePath));
        }

        private string SaveImage(int Id, string curPath)
        {
            if (!(Session[sskTempPic] is string))
            { return curPath; }

            try
            {
                var basePath = ConfigurationManager.AppSettings["StaffImagePath"];
                if (basePath.StartsWith("\\") && !basePath.StartsWith("\\\\"))
                { basePath = Server.MapPath("~" + basePath); }

                var fnam = Id + Path.GetExtension(Session[sskTempPicName].ToString());
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
    }
}