using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Areas.Base;
using StudentInformationSystem.Areas.Student.Models;
using StudentInformationSystem.Common;
using StudentInformationSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentInformationSystem.Areas.Student.Controllers
{
    public class BasketSubjectController : BaseController
    {
        public ActionResult Index()
        {
            return View(new StudentVM());
        }

        [AllowAnonymous]
        public ActionResult SubjectIndex(int? id)
        {
            ViewBag.IsToEdit = id > 0;

            if ((id ?? 0) == 0)
                return PartialView("_SubjectIndex", new List<StudentBasketSubjectVM>());

            var ent = db.Students.Where(x => x.Id == id).FirstOrDefault();
            if (ent == null)
                return HttpNotFound();
            var obj = new StudentVM(ent);

            ViewBag.StudentId = obj.Id;
            return PartialView("_SubjectIndex", obj.BasketSubjects);
        }

        [AllowAnonymous]
        public ActionResult SubjectCreate(int? studentId)
        {
            if ((studentId ?? 0) == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var ent = db.Students.Find(studentId);

            if (ent == null)
                return HttpNotFound();

            var vm = new StudentBasketSubjectVM() { StudentId = ent.Id };
            return PartialView("_SubjectCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult SubjectCreate(StudentBasketSubjectVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = db.Students.Find(vm.StudentId);

                    vm.CreatedBy = this.GetCurrUser();
                    vm.CreatedDate = DateTime.Now;
                    obj.StudentBasketSubjects.Add(vm.GetEntity());

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Student Basket Subject Added Successfully.");
                    string url = Url.Action("SubjectIndex", new { id = vm.StudentId });
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
                var obj = db.StudentBasketSubjects.Find(id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }

                studentId = obj.StudentId;
                var entry = db.Entry(obj);
                entry.State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Student Basket Subject Deleted Successfully.");
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