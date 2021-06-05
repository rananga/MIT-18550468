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

namespace Nalanda.SMS.Areas.Admin.Controllers
{
    public class TeacherController : BaseController
    {
        public ActionResult Index(BaseViewModel<TeacherVM> vm)
        {
            vm.SetList(db.Teachers.AsQueryable(), "LName");
            return View(vm);
        }

        [AllowAnonymous]
        public ActionResult ChildIndex(int? id, bool isToEdit = false)
        {
            TeacherVM obj;

            if (isToEdit && Session[sskCrtdObj] is TeacherVM)
            { obj = (TeacherVM)Session[sskCrtdObj]; }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var teacher = db.Teachers.Where(x => x.Id == id).FirstOrDefault();
                if (teacher == null)
                {
                    return HttpNotFound();
                }
                obj = new TeacherVM(teacher);
            }

            ViewBag.IsToEdit = isToEdit;
            ViewBag.TeacherId = obj.Id;
            return PartialView("_ChildIndex", obj.Subjects);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(new TeacherVM(teacher));
        }

        public ActionResult Create()
        {
            var teacher = new TeacherVM() { Status = TeacherStatus.Active };
            Session[sskCrtdObj] = teacher;

            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeacherVM teacher)
        {
            try
            {
                var svm = (TeacherVM)Session[sskCrtdObj];
                var existingTeacher = db.Teachers.Where(e => e.Nicno == teacher.Nicno).FirstOrDefault();

                if (existingTeacher != null)
                { ModelState.AddModelError("NICNo", "Teacher Name Already Exist"); }

                if (ModelState.IsValid)
                {
                    teacher.CreatedBy = this.GetCurrUser();
                    teacher.CreatedDate = DateTime.Now;
                    var objTeacher = db.Teachers.Add(teacher.GetEntity()).Entity;

                    foreach (var det in svm.Subjects)
                    {
                        det.TeacherId = objTeacher.Id;
                        det.CreatedBy = objTeacher.CreatedBy;
                        det.CreatedDate = DateTime.Now;
                        objTeacher.TeacherSubjects.Add(det.GetEntity());
                    }
                    db.SaveChanges();

                    AddAlert(SMS.Common.AlertStyles.success, "Teacher Information Created Successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            return View(teacher);
        }

        [AllowAnonymous]
        public ActionResult ChildCreate(int? teacherId)
        {
            if (teacherId != 0)
            {
                if (teacherId == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var cls = db.Teachers.Find(teacherId);

                if (cls == null)
                {
                    return HttpNotFound();
                }
            }

            var vm = new TeacherSubjectVM() { TeacherId = teacherId.Value };
            return PartialView("_ChildCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult ChildCreate(TeacherSubjectVM vm)
        {
            TeacherVM obj;
            try
            {
                if (ModelState.IsValid)
                {
                    obj = (TeacherVM)Session[sskCrtdObj];
                    vm.Id = Math.Min(obj.Subjects.Select(x => x.Id).MinOrDefault(), 0) - 1;
                    vm.SubjectName = db.Subjects.Find(vm.SubjectId).Name;
                    vm.GradeDesc = "Grade " + db.Grades.Find(vm.GradeId).GradeId;
                    obj.Subjects.Add(vm);

                    AddAlert(SMS.Common.AlertStyles.success, "Teacher Subject Added Successfully.");
                    string url = Url.Action("ChildIndex", new { id = vm.Id, isToEdit = true });
                    return Json(new { success = true, url });
                }

            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            obj = (TeacherVM)Session[sskCrtdObj];

            return PartialView("_ChildCreate", vm);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }

            var obj = new TeacherVM(teacher);
            Session[sskCrtdObj] = obj;

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TeacherVM teacher)
        {
            byte[] curRowVersion = null;
            try
            {
                var svm = (TeacherVM)Session[sskCrtdObj];
                var existingTeacher = db.Teachers.Where(e => e.Nicno == teacher.Nicno && e.Id != teacher.Id).FirstOrDefault();

                if (existingTeacher != null)
                { ModelState.AddModelError("NICNo", "Teacher Name Already Exist"); }

                if (ModelState.IsValid)
                {
                    var obj = db.Teachers.Find(teacher.Id);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = teacher.GetEntity();
                    modObj.CopyContent(obj, "Title,Gender,FullName,Initials,LName,Address,ContactNo,Email,NICNo,Status,InactiveReason,TelHome,ImmeContactNo,ImmeContactName,SchoolEmail");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.Entry(obj).OriginalValues["RowVersion"] = teacher.RowVersion;

                    db.TeacherSubjects.RemoveRange(obj.TeacherSubjects.Where(x =>
                        !svm.Subjects.Select(y => y.Id).ToList().Contains(x.Id)));

                    foreach (var det in svm.Subjects)
                    {
                        var objDet = db.TeacherSubjects.Find(det.Id);
                        if (objDet == null)
                        {
                            det.CreatedBy = this.GetCurrUser();
                            det.CreatedDate = DateTime.Now;
                            obj.TeacherSubjects.Add(det.GetEntity());
                        }
                        else
                        {
                            var modObjDet = det.GetEntity();
                            modObjDet.CopyContent(objDet, "GradeId,SubjectId,Medium");

                            objDet.ModifiedBy = this.GetCurrUser();
                            objDet.ModifiedDate = DateTime.Now;
                        }
                    }

                    db.SaveChanges();

                    AddAlert(SMS.Common.AlertStyles.success, "Teacher Modified Successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.ShowConcurrencyErrors(ex);
                teacher.RowVersion = curRowVersion;
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            return View(teacher);
        }

        public ActionResult ChildEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var vm = ((TeacherVM)Session[sskCrtdObj]).Subjects.FirstOrDefault(x => x.Id == id);
            if (vm == null)
            {
                return HttpNotFound();
            }
            return PartialView("_ChildEdit", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChildEdit(TeacherSubjectVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = ((TeacherVM)Session[sskCrtdObj]).Subjects.FirstOrDefault(x => x.Id == vm.Id);
                    vm.CopyContent(obj, "GradeId,SubjectId,Medium");
                    vm.SubjectName = db.Subjects.Find(vm.SubjectId).Name;
                    vm.GradeDesc = "Grade " + db.Grades.Find(vm.GradeId).GradeId;

                    AddAlert(SMS.Common.AlertStyles.success, "Teacher Subject Modified Successfully.");
                    string url = Url.Action("ChildIndex", new { id = vm.Id, isToEdit = true });
                    return Json(new { success = true, url = url });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            return PartialView("_ChildEdit", vm);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(TeacherVM teacher)
        {
            try
            {
                var obj = db.Teachers.Find(teacher.Id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }
                db.Detach(obj);

                var entry = db.Entry(teacher.GetEntity());
                entry.State = EntityState.Unchanged;
                entry.Collection(x => x.TeacherSubjects).Load();
                db.TeacherSubjects.RemoveRange(entry.Entity.TeacherSubjects);
                entry.State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(SMS.Common.AlertStyles.success, "Teacher Deleted Successfully.");
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

        [HttpPost, ActionName("ChildDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ChildDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            try
            {
                var lst = ((TeacherVM)Session[sskCrtdObj]).Subjects;
                var obj = lst.FirstOrDefault(x => x.Id == id);
                lst.Remove(obj);

                AddAlert(SMS.Common.AlertStyles.success, "Subject Removed Successfully.");
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
    }
}