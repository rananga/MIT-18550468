using Microsoft.EntityFrameworkCore;
using Nalanda.SMS.Data;
using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Areas.Admin.Models;
using Nalanda.SMS.Areas.Base;
using Nalanda.SMS.Common;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Configuration;

namespace Nalanda.SMS.Areas.Admin.Controllers
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
            return View(new StaffMemberVM(staff));
        }

        public ActionResult Create()
        {
            var teacher = new StaffMemberVM() { Status = ActiveStatus.Active };
            Session[sskCrtdObj] = teacher;

            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StaffMemberVM staff)
        {
            try
            {
                var svm = (StaffMemberVM)Session[sskCrtdObj];
                var existingTeacher = db.Teachers.Where(e => e.Nicno == staff.Nicno).FirstOrDefault();

                if (existingTeacher != null)
                { ModelState.AddModelError("NICNo", "Staff NIC Already Exists"); }

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
                        db.SaveChanges();
                    }

                    AddAlert(SMS.Common.AlertStyles.success, "Staff Member Created Successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

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

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StaffMemberVM staff)
        {
            byte[] curRowVersion = null;
            try
            {
                var svm = (StaffMemberVM)Session[sskCrtdObj];
                var existingTeacher = db.Teachers.Where(e => e.Nicno == staff.Nicno && e.Id != staff.Id).FirstOrDefault();

                if (existingTeacher != null)
                { ModelState.AddModelError("NICNo", "Staff NIC Already Exist"); }

                if (ModelState.IsValid)
                {
                    var obj = db.StaffMembers.Find(staff.Id);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = staff.GetEntity();
                    modObj.CopyContent(obj, "StaffNumber,Gender,Title,FullName,Initials,LastName,Address1,Address2,City,MobileNo,SchoolEmail,Nicno,TelHome,ImmeContactName,ImmeContactNo,Status,TeacherId,ImagePath,JoinedDate,RetiredDate");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;
                    obj.ImagePath = SaveImage(obj.Id, obj.ImagePath);

                    db.Entry(obj).OriginalValues["RowVersion"] = staff.RowVersion;
                    db.SaveChanges();

                    AddAlert(SMS.Common.AlertStyles.success, "Staff Member Modified Successfully.");
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
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            return View(staff);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(StaffMemberVM teacher)
        {
            try
            {
                var obj = db.Teachers.Find(teacher.Id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }
                db.Detach(obj);

                var entry = db.Entry(teacher.GetEntity());
                entry.State = EntityState.Unchanged;
                entry.State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(SMS.Common.AlertStyles.success, "Staff Member Deleted Successfully.");
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

            Nalanda.SMS.Data.Models.Student student = db.Students.Find(id);

            var basePath = ConfigurationManager.AppSettings["StaffImagePath"];
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
                var basePath = ConfigurationManager.AppSettings["StaffImagePath"];
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
    }
}