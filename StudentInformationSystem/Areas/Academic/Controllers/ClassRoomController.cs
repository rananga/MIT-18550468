using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Areas.Academic.Models;
using StudentInformationSystem.Areas.Base;
using StudentInformationSystem.Common;
using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentInformationSystem.Areas.Academic
{
    [ExtendedAuthorize(Roles = RoleConstants.AdminUser)]
    public class ClassRoomController : BaseController
    {
        public ActionResult Index(BaseViewModel<PhysicalClassRoomVM> vm)
        {
            vm.SetList(db.PhysicalClassRooms.AsQueryable(), "GradeClassDesc");
            return View(vm);
        }

        [AllowAnonymous]
        public ActionResult TeacherIndex(int? id, bool isToEdit = false)
        {
            PhysicalClassRoomVM obj;

            if (isToEdit && Session[sskCrtdObj] is PhysicalClassRoomVM)
            { obj = (PhysicalClassRoomVM)Session[sskCrtdObj]; }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var entity = db.PhysicalClassRooms.Where(x => x.Id == id).FirstOrDefault();
                if (entity == null)
                {
                    return HttpNotFound();
                }
                obj = new PhysicalClassRoomVM(entity);
            }

            ViewBag.IsToEdit = isToEdit;
            ViewBag.CR_Id = obj.Id;
            return PartialView("_TeacherIndex", obj.Teachers);
        }

        [AllowAnonymous]
        public ActionResult SubjectIndex(int? id, bool isToEdit = false)
        {
            PhysicalClassRoomVM obj;

            if (isToEdit && Session[sskCrtdObj] is PhysicalClassRoomVM)
            { obj = (PhysicalClassRoomVM)Session[sskCrtdObj]; }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var entity = db.PhysicalClassRooms.Where(x => x.Id == id).FirstOrDefault();
                if (entity == null)
                {
                    return HttpNotFound();
                }
                obj = new PhysicalClassRoomVM(entity);
            }

            ViewBag.IsToEdit = isToEdit;
            ViewBag.CR_Id = obj.Id;
            return PartialView("_SubjectIndex", obj.Subjects);
        }

        [AllowAnonymous]
        public ActionResult MonitorIndex(int? id, bool isToEdit = false)
        {
            PhysicalClassRoomVM obj;

            if (isToEdit && Session[sskCrtdObj] is PhysicalClassRoomVM)
            { obj = (PhysicalClassRoomVM)Session[sskCrtdObj]; }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var entity = db.PhysicalClassRooms.Where(x => x.Id == id).FirstOrDefault();
                if (entity == null)
                {
                    return HttpNotFound();
                }
                obj = new PhysicalClassRoomVM(entity);
            }

            ViewBag.IsToEdit = isToEdit;
            ViewBag.CR_Id = obj.Id;
            return PartialView("_MonitorIndex", obj.Monitors);
        }

        [AllowAnonymous]
        public ActionResult StudentIndex(int? id, bool isToEdit = false)
        {
            PhysicalClassRoomVM obj;

            if (isToEdit && Session[sskCrtdObj] is PhysicalClassRoomVM)
            { obj = (PhysicalClassRoomVM)Session[sskCrtdObj]; }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var entity = db.PhysicalClassRooms.Where(x => x.Id == id).FirstOrDefault();
                if (entity == null)
                {
                    return HttpNotFound();
                }
                obj = new PhysicalClassRoomVM(entity);
            }

            ViewBag.IsToEdit = isToEdit;
            ViewBag.CR_Id = obj.Id;
            return PartialView("_StudentIndex", obj.Students);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var entity = db.PhysicalClassRooms.Find(id);
            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(new PhysicalClassRoomVM(entity));
        }

        public ActionResult Create()
        {
            var cls = new PhysicalClassRoomVM() { Year = DateTime.Now.Year };

            Session[sskCrtdObj] = cls;
            return View(cls);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PhysicalClassRoomVM vm)
        {
            try
            {
                var svm = (PhysicalClassRoomVM)Session[sskCrtdObj];
                var existingObj = db.PhysicalClassRooms.Where(e => e.Year == vm.Year && e.GradeClassId == vm.GradeClassId).FirstOrDefault();

                if (existingObj != null)
                { ModelState.AddModelError("", "Classroom already exists for the selected Year and Grade-Class."); }

                if (ModelState.IsValid)
                {
                    vm.CreatedBy = this.GetCurrUser();
                    vm.CreatedDate = DateTime.Now;
                    var entry = db.PhysicalClassRooms.Add(vm.GetEntity());
                    var objclass = entry.Entity;

                    foreach (var det in svm.Teachers)
                    {
                        det.CR_Id = objclass.Id;
                        det.CreatedBy = objclass.CreatedBy;
                        det.CreatedDate = DateTime.Now;
                        objclass.ClassTeachers.Add(det.GetEntity());
                    }

                    entry.Reference(x => x.GradeClass).Load();
                    var subjects = db.GradeSubjects.Where(x => x.GradeId == objclass.GradeClass.GradeId).Select(x => x.SubjectId)
                        .Concat(db.GradeClassSubjects.Where(x => x.GradeClassId == objclass.GradeClassId).Select(x => x.SubjectId));

                    foreach (var subId in subjects)
                    {
                        objclass.ClassSubjects.Add(new PCR_Subject() { SubjectId = subId, CreatedBy = objclass.CreatedBy, CreatedDate = DateTime.Now });
                    }

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Classroom Created Successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(vm);
        }

        [AllowAnonymous]
        public ActionResult TeacherCreate(int? id)
        {
            if (id != 0)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var entity = db.PhysicalClassRooms.Find(id);

                if (entity == null)
                {
                    return HttpNotFound();
                }
            }

            var vm = new PCR_TeacherVM() { CR_Id = id.Value, FromDate = new DateTime(DateTime.Now.Year, 1,1), ToDate = new DateTime(DateTime.Now.Year, 12, 31) };
            return PartialView("_TeacherCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult TeacherCreate(PCR_TeacherVM vm)
        {
            PhysicalClassRoomVM obj;
            try
            {
                if (ModelState.IsValid)
                {
                    obj = (PhysicalClassRoomVM)Session[sskCrtdObj];
                    vm.Id = Math.Min(obj.Teachers.Select(x => x.Id).MinOrDefault(), 0) - 1;
                    var sm = db.StaffMembers.Find(vm.StaffId);
                    vm.TeacherName = $"{sm.Title.ToEnumChar(null)} {sm.FullName}";
                    obj.Teachers.Add(vm);

                    AddAlert(AlertStyles.success, "Class Teacher Added Successfully.");
                    string url = Url.Action("TeacherIndex", new { id = vm.Id, isToEdit = true });
                    return Json(new { success = true, url });
                }

            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            obj = (PhysicalClassRoomVM)Session[sskCrtdObj];

            return PartialView("_TeacherCreate", vm);
        }

        [AllowAnonymous]
        public ActionResult SubjectCreate(int? id)
        {
            if (id != 0)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var entity = db.PhysicalClassRooms.Find(id);

                if (entity == null)
                {
                    return HttpNotFound();
                }
            }

            var vm = new PCR_SubjectVM() { CR_Id = id.Value };
            return PartialView("_SubjectCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult SubjectCreate(PCR_SubjectVM vm)
        {
            PhysicalClassRoomVM obj;
            try
            {
                if (vm.StaffId == null)
                { ModelState.AddModelError("StaffId", "Subject teacher is required."); }

                if (ModelState.IsValid)
                {
                    obj = (PhysicalClassRoomVM)Session[sskCrtdObj];
                    vm.Id = Math.Min(obj.Subjects.Select(x => x.Id).MinOrDefault(), 0) - 1;
                    vm.SubjectName = db.Subjects.Find(vm.SubjectId).Code;
                    var sm = db.StaffMembers.Find(vm.StaffId);
                    vm.TeacherName = $"{sm.Title.ToEnumChar(null)} {sm.FullName}";
                    obj.Subjects.Add(vm);

                    AddAlert(AlertStyles.success, "Class Subject Added Successfully.");
                    string url = Url.Action("SubjectIndex", new { id = vm.Id, isToEdit = true });
                    return Json(new { success = true, url });
                }

            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            obj = (PhysicalClassRoomVM)Session[sskCrtdObj];

            return PartialView("_SubjectCreate", vm);
        }

        [AllowAnonymous]
        public ActionResult MonitorCreate(int? id)
        {
            if (id != 0)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var entity = db.PhysicalClassRooms.Find(id);

                if (entity == null)
                {
                    return HttpNotFound();
                }
            }

            var vm = new PCR_MonitorVM() { CR_Id = id.Value, FromDate = new DateTime(DateTime.Now.Year, 1, 1), ToDate = new DateTime(DateTime.Now.Year, 12, 31) };
            return PartialView("_MonitorCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult MonitorCreate(PCR_MonitorVM vm)
        {
            PhysicalClassRoomVM obj;
            try
            {
                if (ModelState.IsValid)
                {
                    obj = (PhysicalClassRoomVM)Session[sskCrtdObj];
                    vm.Id = Math.Min(obj.Monitors.Select(x => x.Id).MinOrDefault(), 0) - 1;
                    var stud = db.Students.Find(vm.StudentId);
                    vm.StudentIndex = stud.AdmissionNo;
                    vm.StudentName = stud.FullName;
                    obj.Monitors.Add(vm);

                    AddAlert(AlertStyles.success, "Class Monitor Added Successfully.");
                    string url = Url.Action("MonitorIndex", new { id = vm.Id, isToEdit = true });
                    return Json(new { success = true, url });
                }

            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            obj = (PhysicalClassRoomVM)Session[sskCrtdObj];

            return PartialView("_MonitorCreate", vm);
        }

        [AllowAnonymous]
        public ActionResult StudentCreate(int? id)
        {
            if (id != 0)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var entity = db.PhysicalClassRooms.Find(id);

                if (entity == null)
                {
                    return HttpNotFound();
                }
            }

            var vm = new PCR_StudentVM() { CR_Id = id.Value };
            return PartialView("_StudentCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult StudentCreate(PCR_StudentVM vm)
        {
            PhysicalClassRoomVM obj;
            try
            {
                if (ModelState.IsValid)
                {
                    obj = (PhysicalClassRoomVM)Session[sskCrtdObj];
                    vm.Id = Math.Min(obj.Students.Select(x => x.Id).MinOrDefault(), 0) - 1;
                    var cr = db.PhysicalClassRooms.Find(vm.CR_Id);
                    var stud = db.Students.Find(vm.StudentId);
                    vm.StudentIndex = stud.AdmissionNo;
                    vm.StudentName = stud.FullName;
                    vm.BasketSubjects = stud.StudentBasketSubjects.Where(y => y.Subject.SectionId == cr.GradeClass.Grade.SectionId).Select(y => y.Subject.Code).Aggregate((y, z) => y + "," + z);
                    obj.Students.Add(vm);

                    AddAlert(AlertStyles.success, "Class Student Added Successfully.");
                    string url = Url.Action("StudentIndex", new { id = vm.Id, isToEdit = true });
                    return Json(new { success = true, url });
                }

            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            obj = (PhysicalClassRoomVM)Session[sskCrtdObj];

            return PartialView("_StudentCreate", vm);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var entity = db.PhysicalClassRooms.Find(id);
            if (entity == null)
            {
                return HttpNotFound();
            }

            var obj = new PhysicalClassRoomVM(entity);
            Session[sskCrtdObj] = obj;
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PhysicalClassRoomVM vm)
        {
            byte[] curRowVersion = null;
            try
            {
                var svm = (PhysicalClassRoomVM)Session[sskCrtdObj];

                if (ModelState.IsValid)
                {
                    var obj = db.PhysicalClassRooms.Find(vm.Id);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = vm.GetEntity();
                    modObj.CopyContent(obj, "Medium");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.Entry(obj).OriginalValues["RowVersion"] = vm.RowVersion;

                    db.PCR_Teachers.RemoveRange(obj.ClassTeachers.Where(x =>
                        !svm.Teachers.Select(y => y.Id).ToList().Contains(x.Id)));

                    foreach (var det in svm.Teachers)
                    {
                        var objDet = db.PCR_Teachers.Find(det.Id);
                        if (objDet == null)
                        {
                            det.CreatedBy = this.GetCurrUser();
                            det.CreatedDate = DateTime.Now;
                            obj.ClassTeachers.Add(det.GetEntity());
                        }
                        else
                        {
                            var modObjDet = det.GetEntity();
                            modObjDet.CopyContent(objDet, "StaffId,FromDate,ToDate");

                            objDet.ModifiedBy = this.GetCurrUser();
                            objDet.ModifiedDate = DateTime.Now;
                        }
                    }

                    db.PCR_Subjects.RemoveRange(obj.ClassSubjects.Where(x =>
                        !svm.Subjects.Select(y => y.Id).ToList().Contains(x.Id)));

                    foreach (var det in svm.Subjects)
                    {
                        var objDet = db.PCR_Subjects.Find(det.Id);
                        if (objDet == null)
                        {
                            det.CreatedBy = this.GetCurrUser();
                            det.CreatedDate = DateTime.Now;
                            obj.ClassSubjects.Add(det.GetEntity());
                        }
                    }

                    db.PCR_Monitors.RemoveRange(obj.ClassMonitors.Where(x =>
                        !svm.Monitors.Select(y => y.Id).ToList().Contains(x.Id)));

                    foreach (var det in svm.Monitors)
                    {
                        var objDet = db.PCR_Monitors.Find(det.Id);
                        if (objDet == null)
                        {
                            det.CreatedBy = this.GetCurrUser();
                            det.CreatedDate = DateTime.Now;
                            obj.ClassMonitors.Add(det.GetEntity());
                        }
                        else
                        {
                            var modObjDet = det.GetEntity();
                            modObjDet.CopyContent(objDet, "StudentId,FromDate,ToDate");

                            objDet.ModifiedBy = this.GetCurrUser();
                            objDet.ModifiedDate = DateTime.Now;
                        }
                    }

                    db.PCR_Students.RemoveRange(obj.ClassStudents.Where(x =>
                        !svm.Students.Select(y => y.Id).ToList().Contains(x.Id)));

                    foreach (var det in svm.Students)
                    {
                        var objDet = db.PCR_Students.Find(det.Id);
                        if (objDet == null)
                        {
                            det.CreatedBy = this.GetCurrUser();
                            det.CreatedDate = DateTime.Now;
                            obj.ClassStudents.Add(det.GetEntity());
                        }
                    }

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Classroom Modified Successfully.");
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

        public ActionResult SubjectEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = ((PhysicalClassRoomVM)Session[sskCrtdObj]).Subjects.FirstOrDefault(x => x.Id == id);
            if (vm == null)
            {
                return HttpNotFound();
            }
            return PartialView("_SubjectEdit", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubjectEdit(PCR_SubjectVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = ((PhysicalClassRoomVM)Session[sskCrtdObj]).Subjects.FirstOrDefault(x => x.Id == vm.Id);
                    vm.CopyContent(obj, "SubjectId,StaffId");
                    obj.SubjectName = db.Subjects.Find(vm.SubjectId).Code;
                    var sm = db.StaffMembers.Find(vm.StaffId);
                    obj.TeacherName = $"{sm.Title.ToEnumChar(null)} {sm.FullName}";
                    AddAlert(AlertStyles.success, "Class Subject Modified Successfully.");
                    string url = Url.Action("SubjectIndex", new { id = vm.Id, isToEdit = true });
                    return Json(new { success = true, url });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return PartialView("_SubjectEdit", vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(PhysicalClassRoomVM vm)
        {
            try
            {
                var obj = db.PhysicalClassRooms.Find(vm.Id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }

                var entry = db.Entry(obj);
                entry.State = EntityState.Unchanged;

                entry.Collection(x => x.ClassTeachers).Load();
                db.PCR_Teachers.RemoveRange(entry.Entity.ClassTeachers);

                entry.Collection(x => x.ClassSubjects).Load();
                db.PCR_Subjects.RemoveRange(entry.Entity.ClassSubjects);

                entry.Collection(x => x.ClassStudents).Load();
                db.PCR_Monitors.RemoveRange(entry.Entity.ClassMonitors);

                entry.Collection(x => x.ClassStudents).Load();
                db.PCR_Students.RemoveRange(entry.Entity.ClassStudents);

                entry.State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Classroom Deleted Successfully.");
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

        [HttpPost, ActionName("TeacherDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult TeacherDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            try
            {
                var lst = ((PhysicalClassRoomVM)Session[sskCrtdObj]).Teachers;
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

        [HttpPost, ActionName("SubjectDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult SubjectDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            try
            {
                var lst = ((PhysicalClassRoomVM)Session[sskCrtdObj]).Subjects;
                var obj = lst.FirstOrDefault(x => x.Id == id);
                lst.Remove(obj);

                AddAlert(AlertStyles.success, "Subject Removed Successfully.");
            }
            catch (Exception ex)
            {
                msg = ex.GetInnerException().Message;
                AddAlert(AlertStyles.danger, msg);
            }
            string url = "";
            if (msg.IsBlank())
            { url = Url.Action("SubjectIndex", new { isToEdit = true }); }
            return Json(new { success = true, url, msg });
        }

        [HttpPost, ActionName("MonitorDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult MonitorDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            try
            {
                var lst = ((PhysicalClassRoomVM)Session[sskCrtdObj]).Monitors;
                var obj = lst.FirstOrDefault(x => x.Id == id);
                lst.Remove(obj);

                AddAlert(AlertStyles.success, "Monitor Removed Successfully.");
            }
            catch (Exception ex)
            {
                msg = ex.GetInnerException().Message;
                AddAlert(AlertStyles.danger, msg);
            }
            string url = "";
            if (msg.IsBlank())
            { url = Url.Action("MonitorIndex", new { isToEdit = true }); }
            return Json(new { success = true, url, msg });
        }

        [HttpPost, ActionName("StudentDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult StudentDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            try
            {
                var lst = ((PhysicalClassRoomVM)Session[sskCrtdObj]).Students;
                var obj = lst.FirstOrDefault(x => x.Id == id);
                lst.Remove(obj);

                AddAlert(AlertStyles.success, "Student Removed Successfully.");
            }
            catch (Exception ex)
            {
                msg = ex.GetInnerException().Message;
                AddAlert(AlertStyles.danger, msg);
            }
            string url = "";
            if (msg.IsBlank())
            { url = Url.Action("StudentIndex", new { isToEdit = true }); }
            return Json(new { success = true, url, msg });
        }
    }
}