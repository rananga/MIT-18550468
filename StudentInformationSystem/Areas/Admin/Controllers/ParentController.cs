using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Areas.Admin.Models;
using StudentInformationSystem.Areas.Base;
using StudentInformationSystem.Common;
using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudentInformationSystem.Areas.Admin.Controllers
{
    public class ParentController : BaseController
    {
        public ActionResult Index(BaseViewModel<ParentVM> vm)
        {
            vm.SetList(db.ParentsQuery().AsQueryable(), "FullName");
            return View(vm);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var obj = db.Parents.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            Session.Remove(sskTempPic);
            Session.Remove(sskTempPicName);
            return View(new ParentVM(obj));
        }

        public ActionResult Create()
        {
            var vm = new ParentVM();
            Session[sskCrtdObj] = vm;
            Session.Remove(sskTempPic);
            Session.Remove(sskTempPicName);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ParentVM vm)
        {
            var dbTrans = db.Database.BeginTransaction();
            try
            {
                var existObj = db.Parents.Where(e => e.NicNo == vm.NicNo).FirstOrDefault();
                if (existObj != null)
                { ModelState.AddModelError("NicNo", "NIC already assigned."); }

                var exParent = db.Parents.Where(e => e.Email == vm.Email).FirstOrDefault();
                if (exParent != null)
                { ModelState.AddModelError("Email", $"A parent already exists with the same Email address - {exParent.FullName}."); }

                var svm = (ParentVM)Session[sskCrtdObj];

                if (ModelState.IsValid)
                {
                    vm.CreatedBy = this.GetCurrUser();
                    vm.CreatedDate = DateTime.Now;
                    var objEntity = db.Parents.Add(vm.GetEntity()).Entity;
                    db.SaveChanges();

                    var imgPath = SaveImage(objEntity.Id, vm.ImagePath);
                    if (!imgPath.IsBlank())
                    {
                        objEntity.ImagePath = imgPath;
                    }

                    var objUser = db.Users.Add(new Data.Models.User()
                    {
                        ParentId = objEntity.Id,
                        UserName = objEntity.Email,
                        Password = Membership.GeneratePassword(6, 0),
                        Status = ActiveState.Active,
                        CreatedBy = this.GetCurrUser(),
                        CreatedDate = DateTime.Now
                    }).Entity;

                    db.SaveChanges();

                    db.UserRoles.Add(new UserRole()
                    {
                        UserId = objUser.Id,
                        RoleId = 3
                    });

                    db.SaveChanges();
                    //TODO Send password email
                    dbTrans.Commit();

                    AddAlert(AlertStyles.success, "Parent Created Successfully.");
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
            var obj = db.Parents.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }

            var vm = new ParentVM(obj);
            Session[sskCrtdObj] = vm;
            Session.Remove(sskTempPic);
            Session.Remove(sskTempPicName);

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ParentVM vm)
        {
            byte[] curRowVersion = null;
            try
            {
                var existObj = db.Parents.Where(e => e.Id != vm.Id && e.NicNo == vm.NicNo).FirstOrDefault();
                if (existObj != null)
                { ModelState.AddModelError("NicNo", "NIC already assigned."); }

                var exParent = db.Parents.Where(e => e.Id != vm.Id && !string.IsNullOrEmpty(e.Email) && e.Email == vm.Email).FirstOrDefault();
                if (exParent != null)
                { ModelState.AddModelError("Email", $"A parent already exists with the same Email address - {exParent.FullName}."); }

                var svm = (ParentVM)Session[sskCrtdObj];

                if (ModelState.IsValid)
                {
                    var obj = db.Parents.Find(vm.Id);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = vm.GetEntity();
                    modObj.CopyContent(obj, null, "CreatedBy,CreatedDate,ImagePath");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;
                    obj.ImagePath = SaveImage(obj.Id, obj.ImagePath);

                    db.Entry(obj).OriginalValues["RowVersion"] = vm.RowVersion;

                    var objUser = db.Users.Where(e => e.ParentId == obj.Id).FirstOrDefault();
                    if (objUser.UserName != obj.Email)
                    {
                        objUser.UserName = obj.Email;
                        objUser.Password = Membership.GeneratePassword(6, 0);
                        objUser.Status = ActiveState.Active;
                        objUser.ModifiedBy = this.GetCurrUser();
                        objUser.ModifiedDate = DateTime.Now;
                        //TODO Send password email
                    }

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Parent Modified Successfully.");
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
        public ActionResult DeleteConfirmed(ParentVM vm)
        {
            try
            {
                var obj = db.Parents.Find(vm.Id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }

                var objUser = db.Users.Find(obj.User.Id);
                var entryUser = db.Entry(objUser);
                entryUser.State = EntityState.Unchanged;
                entryUser.Collection(x => x.UserRoles).Load();
                db.UserRoles.RemoveRange(entryUser.Entity.UserRoles);
                entryUser.State = EntityState.Deleted;

                var entry = db.Entry(obj);
                entry.State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Parent Deleted Successfully.");
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
        public ActionResult UploadPic(ParentVM vm, string FromAction)
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

            var parent = db.Parents.Find(id);

            var basePath = ConfigurationManager.AppSettings["ParentImagePath"];
            if (basePath.StartsWith("\\") && !basePath.StartsWith("\\\\"))
            { basePath = Server.MapPath("~" + basePath); }
            var defFilePath = Path.Combine(basePath, "Default.png");
            var filePath = defFilePath;

            if (parent != null && !parent.ImagePath.IsBlank())
            {
                var tempPath = Path.Combine(basePath, parent.ImagePath);
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
                var basePath = ConfigurationManager.AppSettings["ParentImagePath"];
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