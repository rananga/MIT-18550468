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
    public class TeacherController : BaseController
    {
        public ActionResult Index()
        {
            return View(new TeacherVM());
        }

        public ActionResult PrefSubjectIndex(int? id)
        {
            ViewBag.IsToEdit = id > 0;

            if ((id ?? 0) == 0)
                return PartialView("_PrefSubjectIndex", new List<TeacherPreferedSubjectVM>());

            var teacher = db.Teachers.Where(x => x.Id == id).FirstOrDefault();
            if (teacher == null)
                return HttpNotFound();
            var obj = new TeacherVM(teacher);

            ViewBag.TeacherId = obj.Id;
            return PartialView("_PrefSubjectIndex", obj.PreferedSubjects);
        }

        public ActionResult PrefSubjectCreate(int? teacherId)
        {
            if ((teacherId ?? 0) == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var ent = db.Teachers.Find(teacherId);

            if (ent == null)
                return HttpNotFound();

            var vm = new TeacherPreferedSubjectVM() { TeacherId = ent.Id };
            return PartialView("_PrefSubjectCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PrefSubjectCreate(TeacherPreferedSubjectVM vm)
        {
            try
            {
                var exObj = db.TeacherPreferedSubjects.Where(e => e.TeacherId == vm.TeacherId && e.SubjectId == vm.SubjectId).FirstOrDefault();

                if (exObj != null)
                { ModelState.AddModelError("SubjectId", "Subject Already Exists."); }

                if (ModelState.IsValid)
                {
                    var obj = db.Teachers.Find(vm.TeacherId);

                    vm.CreatedBy = this.GetCurrUser();
                    vm.CreatedDate = DateTime.Now;
                    obj.TeacherPreferredSubjects.Add(vm.GetEntity());

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Teacher Prefered Subject Added Successfully.");
                    string url = Url.Action("PrefSubjectIndex", new { id = vm.TeacherId });
                    return Json(new { success = true, url });
                }

            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return PartialView("_PrefSubjectCreate", vm);
        }

        [HttpPost, ActionName("PrefSubjectDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult PrefSubjectDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            var teacherId = 0;

            try
            {
                var obj = db.TeacherPreferedSubjects.Find(id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }

                teacherId = obj.TeacherId;
                var entry = db.Entry(obj);
                entry.State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Teacher Prefered Subject Deleted Successfully.");
            }
            catch (Exception ex)
            {
                msg = ex.GetInnerException().Message;
                AddAlert(AlertStyles.danger, msg);
            }

            string url = "";
            if (msg.IsBlank())
            { url = Url.Action("PrefSubjectIndex", new { id = teacherId }); }
            return Json(new { success = true, url, msg });
        }
    }
}