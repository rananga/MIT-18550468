using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Areas.Base;
using StudentInformationSystem.Areas.Online.Models;
using StudentInformationSystem.Common;
using StudentInformationSystem.Data;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentInformationSystem.Areas.Online.Controllers
{
    public class OnlineClassRoomController : BaseController
    {
        public ActionResult Index(BaseViewModel<OnlineClassRoomVM> vm)
        {
            vm.SetList(db.OnlineClassRooms.AsQueryable(), "GradeName");
            return View(vm);
        }

        [AllowAnonymous]
        public ActionResult PhysicalClassIndex(int? id, bool isToEdit = false)
        {
            OnlineClassRoomVM obj;

            if (isToEdit && Session[sskCrtdObj] is OnlineClassRoomVM)
            { obj = (OnlineClassRoomVM)Session[sskCrtdObj]; }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var entity = db.OnlineClassRooms.Where(x => x.Id == id).FirstOrDefault();
                if (entity == null)
                {
                    return HttpNotFound();
                }
                obj = new OnlineClassRoomVM(entity);
            }

            ViewBag.IsToEdit = isToEdit;
            ViewBag.OCR_Id = obj.Id;
            return PartialView("_PhysicalClassIndex", obj.ClassRooms);
        }

        [AllowAnonymous]
        public ActionResult TeacherIndex(int? id, bool isToEdit = false)
        {
            OnlineClassRoomVM obj;

            if (isToEdit && Session[sskCrtdObj] is OnlineClassRoomVM)
            { obj = (OnlineClassRoomVM)Session[sskCrtdObj]; }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var entity = db.OnlineClassRooms.Where(x => x.Id == id).FirstOrDefault();
                if (entity == null)
                {
                    return HttpNotFound();
                }
                obj = new OnlineClassRoomVM(entity);
            }

            ViewBag.IsToEdit = isToEdit;
            ViewBag.OCR_Id = obj.Id;
            return PartialView("_TeacherIndex", obj.Teachers);
        }

        public ActionResult Create()
        {
            var grade = new OnlineClassRoomVM() { Year = DateTime.Now.Month == 12 ? DateTime.Now.Year + 1 : DateTime.Now.Year };
            Session[sskCrtdObj] = grade;
            return View(grade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OnlineClassRoomVM grade)
        {
            try
            {
                //var exClass = db.OnlineClassRooms.Where(e => e.GradeId == grade.GradeId && e.Name == grade.Name).FirstOrDefault();
                //if (exClass != null)
                //{ ModelState.AddModelError("", "Class already exists for the grade."); }

                var svm = (OnlineClassRoomVM)Session[sskCrtdObj];

                if (ModelState.IsValid)
                {
                    grade.CreatedBy = this.GetCurrUser();
                    grade.CreatedDate = DateTime.Now;
                    var obj = db.OnlineClassRooms.Add(grade.GetEntity()).Entity;

                    foreach (var det in svm.ClassRooms)
                    {
                        det.CreatedBy = obj.CreatedBy;
                        det.CreatedDate = DateTime.Now;
                        obj.PhysicalClassRooms.Add(det.GetEntity());
                    }

                    foreach (var det in svm.Teachers)
                    {
                        det.CreatedBy = obj.CreatedBy;
                        det.CreatedDate = DateTime.Now;
                        obj.ClassTeachers.Add(det.GetEntity());
                    }

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Online classroom created successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(grade);
        }

        [AllowAnonymous]
        public ActionResult PhysicalClassCreate(int? Id)
        {
            if (Id != 0)
            {
                if (Id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var cls = db.OnlineClassRooms.Find(Id);

                if (cls == null)
                {
                    return HttpNotFound();
                }
            }

            var vm = new OCR_ClassRoomVM() { OCR_Id = Id.Value };
            return PartialView("_PhysicalClassCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult PhysicalClassCreate(OCR_ClassRoomVM vm)
        {
            OnlineClassRoomVM obj;
            try
            {
                if (ModelState.IsValid)
                {
                    obj = (OnlineClassRoomVM)Session[sskCrtdObj];
                    vm.Id = Math.Min(obj.ClassRooms.Select(x => x.Id).MinOrDefault(), 0) - 1;
                    var objCR = db.ClassRooms.Find(vm.CR_Id);
                    vm.ClassCode = objCR.GradeClass.Code;
                    obj.ClassRooms.Add(vm);

                    AddAlert(AlertStyles.success, "Physical class Added Successfully.");
                    string url = Url.Action("PhysicalClassIndex", new { id = vm.Id, isToEdit = true });
                    return Json(new { success = true, url });
                }

            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            obj = (OnlineClassRoomVM)Session[sskCrtdObj];

            return PartialView("_PhysicalClassCreate", vm);
        }

        [AllowAnonymous]
        public ActionResult TeacherCreate(int? Id)
        {
            if (Id != 0)
            {
                if (Id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var cls = db.OnlineClassRooms.Find(Id);

                if (cls == null)
                {
                    return HttpNotFound();
                }
            }

            var vm = new OCR_TeacherVM() { OCR_Id = Id.Value };
            return PartialView("_TeacherCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult TeacherCreate(OCR_TeacherVM vm)
        {
            OnlineClassRoomVM obj;
            try
            {
                if (ModelState.IsValid)
                {
                    obj = (OnlineClassRoomVM)Session[sskCrtdObj];
                    vm.Id = Math.Min(obj.Teachers.Select(x => x.Id).MinOrDefault(), 0) - 1;
                    var sm = db.StaffMembers.Find(vm.StaffId);
                    vm.TeacherName = $"{sm.Title.ToEnumChar()} {sm.FullName}";
                    obj.Teachers.Add(vm);

                    AddAlert(AlertStyles.success, "Teacher Added Successfully.");
                    string url = Url.Action("TeacherIndex", new { id = vm.Id, isToEdit = true });
                    return Json(new { success = true, url });
                }

            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            obj = (OnlineClassRoomVM)Session[sskCrtdObj];

            return PartialView("_TeacherCreate", vm);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var obj = db.OnlineClassRooms.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(new OnlineClassRoomVM(obj));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var obj = db.OnlineClassRooms.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }

            var vm = new OnlineClassRoomVM(obj);
            Session[sskCrtdObj] = vm;

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OnlineClassRoomVM grade)
        {
            byte[] curRowVersion = null;
            try
            {
                var svm = (OnlineClassRoomVM)Session[sskCrtdObj];

                if (ModelState.IsValid)
                {
                    var obj = db.OnlineClassRooms.Find(grade.Id);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = grade.GetEntity();
                    modObj.CopyContent(obj, "Code,Medium,MaxStudentCount");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.Entry(obj).OriginalValues["RowVersion"] = grade.RowVersion;

                    db.OCR_ClassRooms.RemoveRange(obj.PhysicalClassRooms.Where(x =>
                        !svm.ClassRooms.Select(y => y.Id).ToList().Contains(x.Id)));

                    foreach (var det in svm.ClassRooms)
                    {
                        var objDet = db.OCR_ClassRooms.Find(det.Id);
                        if (objDet == null)
                        {
                            det.CreatedBy = this.GetCurrUser();
                            det.CreatedDate = DateTime.Now;
                            obj.PhysicalClassRooms.Add(det.GetEntity());
                        }
                    }

                    db.OCR_Teachers.RemoveRange(obj.ClassTeachers.Where(x =>
                        !svm.Teachers.Select(y => y.Id).ToList().Contains(x.Id)));

                    foreach (var det in svm.Teachers)
                    {
                        var objDet = db.OCR_Teachers.Find(det.Id);
                        if (objDet == null)
                        {
                            det.CreatedBy = this.GetCurrUser();
                            det.CreatedDate = DateTime.Now;
                            obj.ClassTeachers.Add(det.GetEntity());
                        }
                    }

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Online classroom modified successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.ShowConcurrencyErrors(ex);
                grade.RowVersion = curRowVersion;
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(grade);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(OnlineClassRoomVM grade)
        {
            try
            {
                var obj = db.OnlineClassRooms.Find(grade.Id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }

                var entry = db.Entry(obj);
                entry.State = EntityState.Unchanged;
                entry.Collection(x => x.PhysicalClassRooms).Load();
                db.OCR_ClassRooms.RemoveRange(entry.Entity.PhysicalClassRooms);
                entry.Collection(x => x.ClassTeachers).Load();
                db.OCR_Teachers.RemoveRange(entry.Entity.ClassTeachers);
                entry.State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Online classroom deleted successfully.");
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
            return RedirectToAction("Details", new { id = grade.Id });
        }

        [HttpPost, ActionName("PhysicalClassDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult PhysicalClassDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            try
            {
                var lst = ((OnlineClassRoomVM)Session[sskCrtdObj]).ClassRooms;
                var obj = lst.FirstOrDefault(x => x.Id == id);
                lst.Remove(obj);

                AddAlert(AlertStyles.success, "Physical Class Removed Successfully.");
            }
            catch (Exception ex)
            {
                msg = ex.GetInnerException().Message;
                AddAlert(AlertStyles.danger, msg);
            }
            string url = "";
            if (msg.IsBlank())
            { url = Url.Action("PhysicalClassIndex", new { isToEdit = true }); }
            return Json(new { success = true, url, msg });
        }

        [HttpPost, ActionName("TeacherDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult TeacherDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            try
            {
                var lst = ((OnlineClassRoomVM)Session[sskCrtdObj]).Teachers;
                var obj = lst.FirstOrDefault(x => x.Id == id);
                lst.Remove(obj);

                AddAlert(AlertStyles.success, "Teacher Removed Successfully.");
            }
            catch (Exception ex)
            {
                msg = ex.GetInnerException().Message;
                AddAlert(AlertStyles.danger, msg);
            }
            string url = "";
            if (msg.IsBlank())
            { url = Url.Action("TeacherIndex", new { isToEdit = true }); }
            return Json(new { success = true, url, msg });
        }
    }
}