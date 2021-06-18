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
    public class ClassController : BaseController
    {
        public ActionResult Index(BaseViewModel<ClassVM> vm)
        {
            vm.SetList(db.Classes.AsQueryable(), "GradeClassDesc");
            return View(vm);
        }

        [AllowAnonymous]
        public ActionResult ChildIndex(int? id, bool isToEdit = false)
        {
            ClassVM obj;

            if (isToEdit && Session[sskCrtdObj] is ClassVM)
            { obj = (ClassVM)Session[sskCrtdObj]; }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Class cls = db.Classes.Where(x => x.Id == id).FirstOrDefault();
                if (cls == null)
                {
                    return HttpNotFound();
                }
                obj = new ClassVM(cls);
            }

            ViewBag.IsToEdit = isToEdit;
            ViewBag.ClassId = obj.Id;
            return PartialView("_ChildIndex", obj.Subjects);
        }

        [AllowAnonymous]
        public ActionResult StudentIndex(int? id, bool isToEdit = false)
        {
            ClassVM obj;

            if (isToEdit && Session[sskCrtdObj] is ClassVM)
            { obj = (ClassVM)Session[sskCrtdObj]; }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Class cls = db.Classes.Where(x => x.Id == id).FirstOrDefault();
                if (cls == null)
                {
                    return HttpNotFound();
                }
                obj = new ClassVM(cls);
            }

            ViewBag.IsToEdit = isToEdit;
            ViewBag.ClassId = obj.Id;
            return PartialView("_StudentIndex", obj.Students);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class classes = db.Classes.Find(id);
            if (classes == null)
            {
                return HttpNotFound();
            }
            return View(new ClassVM(classes));
        }

        [AllowAnonymous]
        public ActionResult ChildDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClassVM obj = (ClassVM)Session[sskCrtdObj];
            ClassSubjectVM clsSubject = obj.Subjects.Where(x => x.Id == id.Value).FirstOrDefault();
            if (clsSubject == null)
            {
                return HttpNotFound();
            }
            return PartialView("_ChildDetails", clsSubject);
        }

        public ActionResult Create()
        {
            var cls = new ClassVM() { Year = DateTime.Now.Year };

            Session[sskCrtdObj] = cls;
            return View(cls);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClassVM classes)
        {
            try
            {
                var svm = (ClassVM)Session[sskCrtdObj];
                //var existingClass = db.Classes.Where(e => e.Grade == classes.Grade && e.Name == classes.Name).FirstOrDefault();

                //if (existingClass != null)
                //{ ModelState.AddModelError("", "Grade & Class Already Exist"); }

                if (ModelState.IsValid)
                {
                    classes.CreatedBy = this.GetCurrUser();
                    classes.CreatedDate = DateTime.Now;
                    var objclass = db.Classes.Add(classes.GetEntity()).Entity;

                    foreach (var det in svm.Subjects)
                    {
                        det.ClassId = objclass.Id;
                        det.CreatedBy = objclass.CreatedBy;
                        det.CreatedDate = DateTime.Now;
                        //objclass.ClassSubjects.Add(det.GetEntity());
                    }

                    foreach (var det in svm.Students)
                    {
                        det.ClassId = objclass.Id;
                        det.CreatedBy = objclass.CreatedBy;
                        det.CreatedDate = DateTime.Now;
                        //objclass.ClassStudents.Add(det.GetEntity());
                    }
                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Class Information Created Successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(classes);
        }

        [AllowAnonymous]
        public ActionResult ChildCreate(int? classId)
        {
            if (classId != 0)
            {
                if (classId == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var cls = db.Classes.Find(classId);

                if (cls == null)
                {
                    return HttpNotFound();
                }
            }

            var vm = new ClassSubjectVM() { ClassId = classId.Value };
            return PartialView("_ChildCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult ChildCreate(ClassSubjectVM vm)
        {
            ClassVM obj;
            try
            {
                if (ModelState.IsValid)
                {
                    obj = (ClassVM)Session[sskCrtdObj];
                    vm.Id = Math.Min(obj.Subjects.Select(x => x.Id).MinOrDefault(), 0) - 1;
                    vm.SubjectName = db.Subjects.Find(vm.SubjectId).Code;
                    //vm.TeacherName = db.TeacherSubjects.Where(x=> x.Id == vm.TeacherSubjectId).Select(x=> x.Teacher.Title + " " + x.Teacher.FullName).FirstOrDefault();
                    obj.Subjects.Add(vm);

                    AddAlert(AlertStyles.success, "Class Subject Teacher Added Successfully.");
                    string url = Url.Action("ChildIndex", new { id = vm.Id, isToEdit = true });
                    return Json(new { success = true, url });
                }

            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            obj = (ClassVM)Session[sskCrtdObj];

            return PartialView("_ChildCreate", vm);
        }

        [AllowAnonymous]
        public ActionResult StudentCreate(int? classId)
        {
            if (classId != 0)
            {
                if (classId == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var cls = db.Classes.Find(classId);

                if (cls == null)
                {
                    return HttpNotFound();
                }
            }

            var vm = new ClassStudentVM() { ClassId = classId.Value };
            return PartialView("_StudentCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult StudentCreate(ClassStudentVM vm)
        {
            ClassVM obj;
            try
            {
                if (ModelState.IsValid)
                {
                    obj = (ClassVM)Session[sskCrtdObj];
                    vm.Id = Math.Min(obj.Students.Select(x => x.Id).MinOrDefault(), 0) - 1;
                    var stud = db.Students.Find(vm.StudentId);
                    vm.StudentName = stud.FullName;
                    vm.StudentIndex = stud.IndexNo;
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

            obj = (ClassVM)Session[sskCrtdObj];

            return PartialView("_StudentCreate", vm);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Class classes = db.Classes.Find(id);
            if (classes == null)
            {
                return HttpNotFound();
            }

            var obj = new ClassVM(classes);
            Session[sskCrtdObj] = obj;
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClassVM classes)
        {
            byte[] curRowVersion = null;
            try
            {
                var svm = (ClassVM)Session[sskCrtdObj];
                //var existingClass = db.Classes.Where(e => e.Grade == classes.Grade && e.Name == classes.Name).FirstOrDefault();

                //if (existingClass != null)
                //{ ModelState.AddModelError("", "Grade & Class Already Exist"); }

                if (ModelState.IsValid)
                {
                    var obj = db.Classes.Find(classes.Id);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = classes.GetEntity();
                    modObj.CopyContent(obj, "Grade,Name,Status");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.Entry(obj).OriginalValues["RowVersion"] = classes.RowVersion;

                    //db.ClassSubjects.RemoveRange(obj.ClassSubjects.Where(x =>
                    //    !svm.Subjects.Select(y => y.Id).ToList().Contains(x.Id)));

                    foreach (var det in svm.Subjects)
                    {
                        var objDet = db.ClassSubjects.Find(det.Id);
                        if (objDet == null)
                        {
                            det.CreatedBy = this.GetCurrUser();
                            det.CreatedDate = DateTime.Now;
                            //obj.ClassSubjects.Add(det.GetEntity());
                        }
                        else
                        {
                            var modObjDet = det.GetEntity();
                            modObjDet.CopyContent(objDet, "TeacherSubjectId");

                            objDet.ModifiedBy = this.GetCurrUser();
                            objDet.ModifiedDate = DateTime.Now;
                        }
                    }

                    //db.ClassStudents.RemoveRange(obj.ClassStudents.Where(x =>
                    //    !svm.Students.Select(y => y.Id).ToList().Contains(x.Id)));

                    foreach (var det in svm.Students)
                    {
                        var objDet = db.ClassStudents.Find(det.Id);
                        if (objDet == null)
                        {
                            det.CreatedBy = this.GetCurrUser();
                            det.CreatedDate = DateTime.Now;
                            //obj.ClassStudents.Add(det.GetEntity());
                        }
                        else
                        {
                            var modObjDet = det.GetEntity();
                            modObjDet.CopyContent(objDet, "StudentId");

                            objDet.ModifiedBy = this.GetCurrUser();
                            objDet.ModifiedDate = DateTime.Now;
                        }
                    }

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Class Modified Successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.ShowConcurrencyErrors(ex);
                classes.RowVersion = curRowVersion;
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(classes);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(ClassVM classes)
        {
            try
            {
                var obj = db.Classes.Find(classes.Id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }
                db.Detach(obj);

                var entry = db.Entry(classes.GetEntity());
                entry.State = EntityState.Unchanged;
                //entry.Collection(x => x.ClassSubjects).Load();
                //db.ClassSubjects.RemoveRange(entry.Entity.ClassSubjects);
                //entry.Collection(x => x.ClassStudents).Load();
                //db.ClassStudents.RemoveRange(entry.Entity.ClassStudents);
                entry.State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Class Deleted Successfully.");
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
            return RedirectToAction("Details", new { id = classes.Id });
        }

        [HttpPost, ActionName("ChildDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ChildDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            try
            {
                var lst = ((ClassVM)Session[sskCrtdObj]).Subjects;
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
            { url = Url.Action("ChildIndex", new { isToEdit = true }); }
            return Json(new { success = true, url, msg });
        }

        [HttpPost, ActionName("StudentDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult StudentDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            try
            {
                var lst = ((ClassVM)Session[sskCrtdObj]).Students;
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