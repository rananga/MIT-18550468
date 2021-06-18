using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Areas.Base;
using StudentInformationSystem.Areas.Teacher.Models;
using StudentInformationSystem.Common;
using StudentInformationSystem.Data;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentInformationSystem.Areas.Teacher.Controllers
{
    public class TeacherController : BaseController
    {
        public ActionResult Index(BaseViewModel<TeacherVM> vm)
        {
            vm.SetList(db.Teachers.AsQueryable(), "TeacherName");
            return View(vm);
        }

        [AllowAnonymous]
        public ActionResult PrefSubjectIndex(int? id, bool isToEdit = false)
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
            return PartialView("_PrefSubjectIndex", obj.PreferedSubjects);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Data.Models.Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(new TeacherVM(teacher));
        }

        [AllowAnonymous]
        public ActionResult PrefSubjectCreate(int? teacherId)
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

            var vm = new TeacherPreferedSubjectVM() { TeacherId = teacherId.Value };
            return PartialView("_PrefSubjectCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult PrefSubjectCreate(TeacherPreferedSubjectVM vm)
        {
            TeacherVM obj;
            try
            {
                if (ModelState.IsValid)
                {
                    obj = (TeacherVM)Session[sskCrtdObj];
                    vm.Id = Math.Min(obj.PreferedSubjects.Select(x => x.Id).MinOrDefault(), 0) - 1;
                    var objSubject = db.Subjects.Find(vm.SubjectId);
                    vm.SubjectName = objSubject.Code;
                    vm.SectionName = objSubject.Section.Code;
                    obj.PreferedSubjects.Add(vm);

                    AddAlert(AlertStyles.success, "Teacher Prefered Subject Added Successfully.");
                    string url = Url.Action("PrefSubjectIndex", new { id = vm.Id, isToEdit = true });
                    return Json(new { success = true, url });
                }

            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            obj = (TeacherVM)Session[sskCrtdObj];

            return PartialView("_PrefSubjectCreate", vm);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Data.Models.Teacher teacher = db.Teachers.Find(id);
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

                if (ModelState.IsValid)
                {
                    var obj = db.Teachers.Find(teacher.Id);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = teacher.GetEntity();

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.Entry(obj).OriginalValues["RowVersion"] = teacher.RowVersion;

                    db.TeacherPreferedSubjects.RemoveRange(obj.TeacherPreferedSubjects.Where(x =>
                        !svm.PreferedSubjects.Select(y => y.Id).ToList().Contains(x.Id)));

                    foreach (var det in svm.PreferedSubjects)
                    {
                        var objDet = db.TeacherPreferedSubjects.Find(det.Id);
                        if (objDet == null)
                        {
                            det.CreatedBy = this.GetCurrUser();
                            det.CreatedDate = DateTime.Now;
                            obj.TeacherPreferedSubjects.Add(det.GetEntity());
                        }
                    }

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Teacher Modified Successfully.");
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
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(teacher);
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

                var entry = db.Entry(obj);
                entry.State = EntityState.Unchanged;
                entry.Collection(x => x.TeacherPreferedSubjects).Load();
                db.TeacherPreferedSubjects.RemoveRange(entry.Entity.TeacherPreferedSubjects);
                entry.State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Teacher Deleted Successfully.");
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

        [HttpPost, ActionName("PrefSubjectDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult PrefSubjectDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            try
            {
                var lst = ((TeacherVM)Session[sskCrtdObj]).PreferedSubjects;
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
            { url = Url.Action("PrefSubjectIndex", new { isToEdit = true }); }
            return Json(new { success = true, url, msg });
        }
    }
}