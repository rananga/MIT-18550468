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
    public class TeacherOffTimeController : BaseController
    {
        public ActionResult Index()
        {
            return View(new TeacherVM());
        }

        public ActionResult OffTimeIndex(int? id)
        {
            ViewBag.IsToEdit = id > 0;

            if ((id ?? 0) == 0)
                return PartialView("_OffTimeIndex", new List<TeacherOffTimeVM>());

            var teacher = db.Teachers.Where(x => x.Id == id).FirstOrDefault();
            if (teacher == null)
                return HttpNotFound();
            var obj = new TeacherVM(teacher);

            ViewBag.TeacherId = obj.Id;
            return PartialView("_OffTimeIndex", obj.OffTimes);
        }

        public ActionResult OffTimeCreate(int? teacherId)
        {
            if ((teacherId ?? 0) == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var ent = db.Teachers.Find(teacherId);

            if (ent == null)
                return HttpNotFound();

            var vm = new TeacherOffTimeVM() { TeacherId = ent.Id, FromTime = DateTime.Now, ToTime = DateTime.Now };
            return PartialView("_OffTimeCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OffTimeCreate(TeacherOffTimeVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = db.Teachers.Find(vm.TeacherId);

                    vm.CreatedBy = this.GetCurrUser();
                    vm.CreatedDate = DateTime.Now;
                    obj.TeacherOffTimes.Add(vm.GetEntity());

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Teacher Off Time Added Successfully.");
                    string url = Url.Action("OffTimeIndex", new { id = vm.TeacherId });
                    return Json(new { success = true, url });
                }

            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return PartialView("_OffTimeCreate", vm);
        }

        public ActionResult OffTimeEdit(int? id)
        {
            if ((id ?? 0) == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var ent = db.TeacherOffTimes.Find(id);

            if (ent == null)
                return HttpNotFound();

            var vm = new TeacherOffTimeVM(ent);
            return PartialView("_OffTimeEdit", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OffTimeEdit(TeacherOffTimeVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = db.TeacherOffTimes.Find(vm.Id);
                    vm.CopyContent(obj, "FromTime,ToTime,Reason");
                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Teacher Off Time Modified Successfully.");
                    string url = Url.Action("OffTimeIndex", new { id = obj.TeacherId });
                    return Json(new { success = true, url });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return PartialView("_OffTimeEdit", vm);
        }

        [HttpPost, ActionName("OffTimeDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult OffTimeDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            var teacherId = 0;

            try
            {
                var obj = db.TeacherOffTimes.Find(id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }

                teacherId = obj.TeacherId;
                var entry = db.Entry(obj);
                entry.State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Teacher Off Time Deleted Successfully.");
            }
            catch (Exception ex)
            {
                msg = ex.GetInnerException().Message;
                AddAlert(AlertStyles.danger, msg);
            }

            string url = "";
            if (msg.IsBlank())
            { url = Url.Action("OffTimeIndex", new { id = teacherId }); }
            return Json(new { success = true, url, msg });
        }
    }
}