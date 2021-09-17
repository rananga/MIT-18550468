using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Areas.Academic.Models;
using StudentInformationSystem.Areas.Admin.Models;
using StudentInformationSystem.Areas.Base;
using StudentInformationSystem.Common;
using StudentInformationSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentInformationSystem.Areas.Academic.Controllers
{
    public class GradeSubjectController : BaseController
    {
        public ActionResult Index()
        {
            return View(new GradeVM());
        }

        [AllowAnonymous]
        public ActionResult SubjectIndex(int? id)
        {
            ViewBag.IsToEdit = id > 0;

            if ((id ?? 0) == 0)
                return PartialView("_SubjectIndex", new List<GradeSubjectVM>());

            var ent = db.Grades.Where(x => x.Id == id).FirstOrDefault();
            if (ent == null)
                return HttpNotFound();
            var obj = new GradeVM(ent);

            ViewBag.GradeId = obj.Id;
            return PartialView("_SubjectIndex", obj.Subjects);
        }

        [AllowAnonymous]
        public ActionResult SubjectCreate(int? gradeId)
        {
            if ((gradeId ?? 0) == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var ent = db.Students.Find(gradeId);

            if (ent == null)
                return HttpNotFound();

            var vm = new GradeSubjectVM() { GradeId = ent.Id };
            return PartialView("_SubjectCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult SubjectCreate(GradeSubjectVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = db.Grades.Find(vm.GradeId);

                    vm.CreatedBy = this.GetCurrUser();
                    vm.CreatedDate = DateTime.Now;
                    obj.GradeSubjects.Add(vm.GetEntity());

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Grade Subject Added Successfully.");
                    string url = Url.Action("SubjectIndex", new { id = vm.GradeId });
                    return Json(new { success = true, url });
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
            var studentId = 0;

            try
            {
                var obj = db.GradeSubjects.Find(id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }

                studentId = obj.GradeId;
                var entry = db.Entry(obj);
                entry.State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Grade Subject Deleted Successfully.");
            }
            catch (Exception ex)
            {
                msg = ex.GetInnerException().Message;
                AddAlert(AlertStyles.danger, msg);
            }

            string url = "";
            if (msg.IsBlank())
            { url = Url.Action("SubjectIndex", new { id = studentId }); }
            return Json(new { success = true, url, msg });
        }
    }
}