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
    public class StudentExtraActivitiesController : BaseController
    {
        public ActionResult Index()
        {
            return View(new StudentVM());
        }

        public ActionResult AcheivementIndex(int? id)
        {
            ViewBag.IsToEdit = id > 0;

            if ((id ?? 0) == 0)
                return PartialView("_AcheivementIndex", new List<StudentExtraActivityAcheivementVM>());

            var ent = db.Students.Where(x => x.Id == id).FirstOrDefault();
            if (ent == null)
                return HttpNotFound();
            var obj = new StudentVM(ent);

            ViewBag.StudentId = obj.Id;
            return PartialView("_AcheivementIndex", obj.Acheivements);
        }

        public ActionResult PositionIndex(int? id)
        {
            ViewBag.IsToEdit = id > 0;

            if ((id ?? 0) == 0)
                return PartialView("_PositionIndex", new List<StudentExtraActivityPositionVM>());

            var ent = db.Students.Where(x => x.Id == id).FirstOrDefault();
            if (ent == null)
                return HttpNotFound();
            var obj = new StudentVM(ent);

            ViewBag.StudentId = obj.Id;
            return PartialView("_PositionIndex", obj.Positions);
        }

        public ActionResult AcheivementCreate(int? studentId)
        {
            if ((studentId ?? 0) == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var ent = db.Students.Find(studentId);

            if (ent == null)
                return HttpNotFound();

            var vm = new StudentExtraActivityAcheivementVM() { StudentId = ent.Id, AwardedDate = DateTime.Now };
            return PartialView("_AcheivementCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AcheivementCreate(StudentExtraActivityAcheivementVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = db.Students.Find(vm.StudentId);

                    vm.CreatedBy = this.GetCurrUser();
                    vm.CreatedDate = DateTime.Now;
                    obj.ActivityAcheivements.Add(vm.GetEntity());

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Student Acheivement Added Successfully.");
                    string url = Url.Action("AcheivementIndex", new { id = vm.StudentId });
                    return Json(new { success = true, url });
                }

            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return PartialView("_AcheivementCreate", vm);
        }

        public ActionResult PositionCreate(int? studentId)
        {
            if ((studentId ?? 0) == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var ent = db.Students.Find(studentId);

            if (ent == null)
                return HttpNotFound();

            var vm = new StudentExtraActivityPositionVM() { StudentId = ent.Id, FromDate = DateTime.Now, ToDate = DateTime.Now };
            return PartialView("_PositionCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PositionCreate(StudentExtraActivityPositionVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = db.Students.Find(vm.StudentId);

                    vm.CreatedBy = this.GetCurrUser();
                    vm.CreatedDate = DateTime.Now;
                    obj.ActivityPositions.Add(vm.GetEntity());

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Student Position Added Successfully.");
                    string url = Url.Action("PositionIndex", new { id = vm.StudentId });
                    return Json(new { success = true, url });
                }

            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return PartialView("_PositionCreate", vm);
        }

        public ActionResult AcheivementEdit(int? id)
        {
            if ((id ?? 0) == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var ent = db.StudentExtraActivityAcheivements.Find(id);

            if (ent == null)
                return HttpNotFound();

            var vm = new StudentExtraActivityAcheivementVM(ent);
            return PartialView("_AcheivementEdit", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AcheivementEdit(StudentExtraActivityAcheivementVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = db.StudentExtraActivityAcheivements.Find(vm.Id);
                    vm.CopyContent(obj, "AcheivementId,AwardedDate,Remarks");
                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Student Acheivement Modified Successfully.");
                    string url = Url.Action("AcheivementIndex", new { id = obj.StudentId });
                    return Json(new { success = true, url });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return PartialView("_AcheivementEdit", vm);
        }

        public ActionResult PositionEdit(int? id)
        {
            if ((id ?? 0) == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var ent = db.StudentExtraActivityPositions.Find(id);

            if (ent == null)
                return HttpNotFound();

            var vm = new StudentExtraActivityPositionVM(ent);
            return PartialView("_PositionEdit", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PositionEdit(StudentExtraActivityPositionVM vm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = db.StudentExtraActivityPositions.Find(vm.Id);
                    vm.CopyContent(obj, "PositionId,FromDate,ToDate,Remarks");
                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Student Position Modified Successfully.");
                    string url = Url.Action("PositionIndex", new { id = obj.StudentId });
                    return Json(new { success = true, url });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return PartialView("_PositionEdit", vm);
        }

        [HttpPost, ActionName("AcheivementDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult AcheivementDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            var studentId = 0;

            try
            {
                var obj = db.StudentExtraActivityAcheivements.Find(id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }

                studentId = obj.StudentId;
                var entry = db.Entry(obj);
                entry.State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Student Acheivement Deleted Successfully.");
            }
            catch (Exception ex)
            {
                msg = ex.GetInnerException().Message;
                AddAlert(AlertStyles.danger, msg);
            }

            string url = "";
            if (msg.IsBlank())
            { url = Url.Action("AcheivementIndex", new { id = studentId }); }
            return Json(new { success = true, url, msg });
        }

        [HttpPost, ActionName("PositionDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult PositionDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            var studentId = 0;

            try
            {
                var obj = db.StudentExtraActivityPositions.Find(id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }

                studentId = obj.StudentId;
                var entry = db.Entry(obj);
                entry.State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Student Position Deleted Successfully.");
            }
            catch (Exception ex)
            {
                msg = ex.GetInnerException().Message;
                AddAlert(AlertStyles.danger, msg);
            }

            string url = "";
            if (msg.IsBlank())
            { url = Url.Action("PositionIndex", new { id = studentId }); }
            return Json(new { success = true, url, msg });
        }
    }
}