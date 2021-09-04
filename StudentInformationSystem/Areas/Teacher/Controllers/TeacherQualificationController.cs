using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Areas.Base;
using StudentInformationSystem.Areas.Teacher.Models;
using StudentInformationSystem.Common;
using StudentInformationSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentInformationSystem.Areas.Teacher.Controllers
{
    public class TeacherQualificationController : BaseController
    {
        public ActionResult Index()
        {
            return View(new TeacherVM());
        }

        public ActionResult QualificationIndex(int? id)
        {
            ViewBag.IsToEdit = id > 0;

            if ((id ?? 0) == 0)
                return PartialView("_QualificationIndex", new List<TeacherQualificationVM>());

            var teacher = db.Teachers.Where(x => x.Id == id).FirstOrDefault();
            if (teacher == null)
                return HttpNotFound();
            var obj = new TeacherVM(teacher);

            ViewBag.TeacherId = obj.Id;
            return PartialView("_QualificationIndex", obj.Qualifications);
        }

        public ActionResult QualificationCreate(int? teacherId)
        {
            if ((teacherId ?? 0) == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var ent = db.Teachers.Find(teacherId);

            if (ent == null)
                return HttpNotFound();

            var vm = new TeacherQualificationVM() { TeacherId = ent.Id, AwardedYear = DateTime.Now.Year };
            return PartialView("_QualificationCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult QualificationCreate(TeacherQualificationVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = db.Teachers.Find(vm.TeacherId);

                    vm.CreatedBy = this.GetCurrUser();
                    vm.CreatedDate = DateTime.Now;
                    obj.TeacherQualifications.Add(vm.GetEntity());

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Teacher Qualification Added Successfully.");
                    string url = Url.Action("QualificationIndex", new { id = vm.TeacherId });
                    return Json(new { success = true, url });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return PartialView("_QualificationCreate", vm);
        }

        public ActionResult QualificationEdit(int? id)
        {
            if ((id ?? 0) == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var ent = db.TeacherQualifications.Find(id);

            if (ent == null)
                return HttpNotFound();

            var vm = new TeacherQualificationVM(ent);
            return PartialView("_QualificationEdit", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult QualificationEdit(TeacherQualificationVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = db.TeacherQualifications.Find(vm.Id);
                    vm.CopyContent(obj, "QualificationType,Institute,AwardedYear,Remarks");
                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Teacher Qualification Modified Successfully.");
                    string url = Url.Action("QualificationIndex", new { id = obj.TeacherId });
                    return Json(new { success = true, url });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return PartialView("_QualificationEdit", vm);
        }

        [HttpPost, ActionName("QualificationDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult QualificationDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            var teacherId = 0;

            try
            {
                var obj = db.TeacherQualifications.Find(id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }

                teacherId = obj.TeacherId;
                var entry = db.Entry(obj);
                entry.State = EntityState.Unchanged;
                entry.Collection(x => x.TeacherQualificationSubjects).Load();
                db.TeacherQualificationSubjects.RemoveRange(entry.Entity.TeacherQualificationSubjects);
                entry.State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Teacher Qualification Deleted Successfully.");
            }
            catch (Exception ex)
            {
                msg = ex.GetInnerException().Message;
                AddAlert(AlertStyles.danger, msg);
            }

            string url = "";
            if (msg.IsBlank())
            { url = Url.Action("QualificationIndex", new { id = teacherId }); }
            return Json(new { success = true, url, hdrData = "", msg });
        }

        public ActionResult SubjectIndex(int? id)
        {
            ViewBag.IsToEdit = id > 0;

            if ((id ?? 0) == 0)
                return PartialView("_SubjectIndex", new List<TeacherQualificationSubjectVM>());

            var qlf = db.TeacherQualifications.Where(x => x.Id == id).FirstOrDefault();
            if (qlf == null)
                return HttpNotFound();
            var obj = new TeacherQualificationVM(qlf);

            ViewBag.TeacherQualificationId = obj.Id;
            return PartialView("_SubjectIndex", obj.QualificationSubjects);
        }

        public ActionResult SubjectCreate(int? TeacherQualificationId)
        {
            if ((TeacherQualificationId ?? 0) == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var ent = db.TeacherQualifications.Find(TeacherQualificationId);

            if (ent == null)
                return HttpNotFound();

            var vm = new TeacherQualificationSubjectVM() { TeacherQualificationId = ent.Id };
            return PartialView("_SubjectCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubjectCreate(TeacherQualificationSubjectVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = db.TeacherQualifications.Find(vm.TeacherQualificationId);

                    vm.CreatedBy = this.GetCurrUser();
                    vm.CreatedDate = DateTime.Now;
                    obj.TeacherQualificationSubjects.Add(vm.GetEntity());

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Teacher Qualification Subject Added Successfully.");
                    string url = Url.Action("SubjectIndex", new { id = vm.TeacherQualificationId });
                    return Json(new { success = true, url, hdrData = "" });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return PartialView("_SubjectCreate", vm);
        }

        [HttpPost, ActionName("SubjectDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult SubjectDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            var teacherQualificationId = 0;

            try
            {
                var obj = db.TeacherQualificationSubjects.Find(id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }

                teacherQualificationId = obj.TeacherQualificationId;
                var entry = db.Entry(obj);
                entry.State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Teacher Qualification Subject Deleted Successfully.");
            }
            catch (Exception ex)
            {
                msg = ex.GetInnerException().Message;
                AddAlert(AlertStyles.danger, msg);
            }

            string url = "";
            if (msg.IsBlank())
            { url = Url.Action("SubjectIndex", new { id = teacherQualificationId }); }
            return Json(new { success = true, url, hdrData = "", msg });
        }
    }
}