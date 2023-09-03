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
    public class VisitorController : BaseController
    {
        public ActionResult Index(BaseViewModel<VisitorVM> vm)
        {
            vm.SetList(db.Visitors.AsQueryable(), "LastName");
            return View(vm);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var obj = db.Visitors.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            Session.Remove(sskTempPic);
            Session.Remove(sskTempPicName);
            return View(new VisitorVM(obj));
        }

        public ActionResult Create()
        {
            var vm = new VisitorVM();
            Session[sskCrtdObj] = vm;
            Session.Remove(sskTempPic);
            Session.Remove(sskTempPicName);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VisitorVM vm)
        {
            var dbTrans = db.Database.BeginTransaction();
            try
            {
                var existObj = db.Visitors.Where(e => e.NicNo == vm.NicNo).FirstOrDefault();
                if (existObj != null)
                { ModelState.AddModelError("Nicno", "NIC already assigned."); }

                var exSchoolEmail_MS = db.Visitors.Where(e => e.SchoolEmail_MS == vm.SchoolEmail_MS).FirstOrDefault();
                if (exSchoolEmail_MS != null)
                { ModelState.AddModelError("SchoolEmail_MS", $"Email Already Assinged to - {exSchoolEmail_MS.FullName}."); }

                var svm = (VisitorVM)Session[sskCrtdObj];

                if (ModelState.IsValid)
                {
                    vm.CreatedBy = this.GetCurrUser();
                    vm.CreatedDate = DateTime.Now;
                    var objEntity = db.Visitors.Add(vm.GetEntity()).Entity;
                    db.SaveChanges();

                    var imgPath = SaveImage(objEntity.Id, vm.ImagePath);
                    if (!imgPath.IsBlank())
                    {
                        objEntity.ImagePath = imgPath;
                    }

                    db.SaveChanges();
                    dbTrans.Commit();

                    AddAlert(AlertStyles.success, "Visitor Created Successfully.");
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

            return View(vm);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var obj = db.Visitors.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }

            var vm = new VisitorVM(obj);
            Session[sskCrtdObj] = vm;
            Session.Remove(sskTempPic);
            Session.Remove(sskTempPicName);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VisitorVM vm)
        {
            byte[] curRowVersion = null;
            try
            {
                var existObj = db.Visitors.Where(e => e.Id != vm.Id && e.NicNo == vm.NicNo).FirstOrDefault();
                if (existObj != null)
                { ModelState.AddModelError("Nicno", "NIC already assigned."); }

                var exSchoolEmail_MS = db.Visitors.Where(e => e.Id != vm.Id && !string.IsNullOrEmpty(e.SchoolEmail_MS) && e.SchoolEmail_MS == vm.SchoolEmail_MS).FirstOrDefault();
                if (exSchoolEmail_MS != null)
                { ModelState.AddModelError("SchoolEmail_MS", $"Email Already Assinged to - {exSchoolEmail_MS.FullName}."); }

                var svm = (VisitorVM)Session[sskCrtdObj];

                if (ModelState.IsValid)
                {
                    var obj = db.Visitors.Find(vm.Id);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = vm.GetEntity();
                    modObj.CopyContent(obj, "Gender,Title,FullName,Initials,LastName,Address1,Address2,City,MobileNo,SchoolEmail_MS,Nicno,ImagePath");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;
                    obj.ImagePath = SaveImage(obj.Id, obj.ImagePath);

                    db.Entry(obj).OriginalValues["RowVersion"] = vm.RowVersion;

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Visitor Modified Successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.ShowConcurrencyErrors(ex);
                vm.RowVersion = curRowVersion;
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(VisitorVM vm)
        {
            try
            {
                var obj = db.Visitors.Find(vm.Id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }

                var entry = db.Entry(obj);
                entry.State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Visitor Deleted Successfully.");
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
            return RedirectToAction("Details", new { id = vm.Id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadPic(VisitorVM vm, string FromAction)
        {
            if (vm.ProfilePic != null && vm.ProfilePic.ContentLength > 0)
            {
                BinaryReader br = new BinaryReader(vm.ProfilePic.InputStream);
                byte[] binData = br.ReadBytes((int)vm.ProfilePic.InputStream.Length);
                Session[sskTempPic] = Convert.ToBase64String(binData);
                Session[sskTempPicName] = vm.ProfilePic.FileName;
            }

            TempData["TempEnrol"] = vm;
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

            var visitor = db.Visitors.Find(id);

            var basePath = ConfigurationManager.AppSettings["VisitorImagePath"];
            if (basePath.StartsWith("\\") && !basePath.StartsWith("\\\\"))
            { basePath = Server.MapPath("~" + basePath); }
            var defFilePath = Path.Combine(basePath, "Default.png");
            var filePath = defFilePath;

            if (visitor != null && !visitor.ImagePath.IsBlank())
            {
                var tempPath = Path.Combine(basePath, visitor.ImagePath);
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
                var basePath = ConfigurationManager.AppSettings["VisitorImagePath"];
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