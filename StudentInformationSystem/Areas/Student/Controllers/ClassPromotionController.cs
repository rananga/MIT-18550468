using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Areas.Base;
using StudentInformationSystem.Areas.Student.Models;
using StudentInformationSystem.Common;
using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentInformationSystem.Areas.Student.Controllers
{
    public class ClassPromotionController : BaseController
    {
        public ActionResult Index(BaseViewModel<ClassPromotionVM> vm)
        {
            vm.SetList(db.ClassPromotions.AsQueryable(), "Year");
            return View(vm);
        }

        public ActionResult Create()
        {
            var grade = new ClassPromotionVM() { Year = DateTime.Now.Year + 1 };

            return View(grade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClassPromotionVM vm)
        {
            try
            {
                var exPromo = db.ClassPromotions.Where(e => e.Year == vm.Year && e.GradeId == vm.GradeId).FirstOrDefault();

                if (exPromo != null)
                { ModelState.AddModelError("", "A class promotion already exists for the selected year and grade."); }

                if (ModelState.IsValid)
                {
                    vm.CreatedBy = this.GetCurrUser();
                    vm.CreatedDate = DateTime.Now;
                    var ent = db.ClassPromotions.Add(vm.GetEntity()).Entity;

                    ProcessPromotion(ent);

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Class promotion created successfully.");
                    return RedirectToAction("Edit", new { id = ent.Id });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(vm);
        }

        private void ProcessPromotion(ClassPromotion ent)
        {
            var lst = db.PhysicalClassRooms.Where(x => x.Year == ent.Year - 1 && x.GradeClass.GradeId == ent.GradeId).SelectMany(x => x.ClassStudents).ToList();
            var lstNew = db.PhysicalClassRooms.Where(x => x.Year == ent.Year && x.GradeClass.GradeId == ent.GradeId + 1).ToList();

            foreach (var stud in lst)
            {
                ent.ClassPromotionDetails.Add(new ClassPromotionDetail()
                {
                    StudentId = stud.StudentId,
                    FromClassId = stud.CR_Id,
                    ToClassId = lstNew.FirstOrDefault(x => x.GradeClass.Name == stud.PhysicalClassRoom.GradeClass.Name)?.Id,
                    CreatedBy = GetCurrUser(),
                    CreatedDate = DateTime.Now
                });
            }
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ent = db.ClassPromotions.Find(id);
            if (ent == null)
            {
                return HttpNotFound();
            }
            return View(new ClassPromotionVM(ent));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var ent = db.ClassPromotions.Find(id);
            if (ent == null)
            {
                return HttpNotFound();
            }
            return View(new ClassPromotionVM(ent));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClassPromotionVM vm)
        {
            byte[] curRowVersion = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = db.ClassPromotions.Find(vm.Id);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = vm.GetEntity();
                    modObj.CopyContent(obj, "Reason");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.Entry(obj).OriginalValues["RowVersion"] = vm.RowVersion;
                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Class promotion modified successfully.");
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(ClassPromotionVM grade)
        {
            try
            {
                var obj = db.ClassPromotions.Find(grade.Id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }

                var entry = db.Entry(obj);
                entry.State = EntityState.Unchanged;
                entry.Collection(x => x.ClassPromotionDetails).Load();
                db.ClassPromotionDetails.RemoveRange(entry.Entity.ClassPromotionDetails);
                entry.State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Class promotion deleted successfully.");
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
                AddAlert(AlertStyles.danger, ex.GetInnerException().Message, renderOnTop: true);
            }
            return RedirectToAction("Details", new { id = grade.Id });
        }

        [HttpPost, ActionName("Finalize")]
        [ValidateAntiForgeryToken]
        public ActionResult FinalizeConfirmed(ClassPromotionVM vm)
        {
            try
            {
                var obj = db.ClassPromotions.Find(vm.Id);
                if (obj == null || obj.IsFinalized)
                { throw new DbUpdateConcurrencyException(""); }

                obj.IsFinalized = true;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Class promotion finalized successfully.");
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

        public ActionResult StudentClassIndex(int? promotionId, bool isToEdit = false)
        {
            if (promotionId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var objPromo = db.ClassPromotions.Find(promotionId);
            if (objPromo == null)
            {
                return HttpNotFound();
            }

            ViewBag.IsToEdit = isToEdit;
            ViewBag.smClasses = db.PhysicalClassRooms.Where(x => x.Year == objPromo.Year && x.GradeClass.GradeId == objPromo.GradeId + 1 && x.Medium == Medium.Sinhala)
                .Select(x => new KeyValuePair<int, string>(x.Id, x.GradeClass.Code)).ToList();
            ViewBag.emClasses = db.PhysicalClassRooms.Where(x => x.Year == objPromo.Year && x.GradeClass.GradeId == objPromo.GradeId + 1 && x.Medium == Medium.English)
                .Select(x => new KeyValuePair<int, string>(x.Id, x.GradeClass.Code)).ToList();

            var lst = objPromo.ClassPromotionDetails.Select(x => new ClassPromotionDetailVM(x)).ToList();
            return PartialView("_StudentClassIndex", lst);
        }

        [HttpPost]
        public ActionResult StudentClassUpdate(int? id, string jsonData)
        {
            var trans = db.Database.BeginTransaction();
            try
            {
                if (id == null)
                {
                    trans.Rollback();
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                var objPromo = db.ClassPromotions.Find(id);

                if (objPromo == null || objPromo.IsFinalized)
                {
                    trans.Rollback();
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                foreach (var item in jsonData.DeserializeToDynamic())
                {
                    var studentId = (int?)item.studentId;
                    var toClassId = (int?)item.toClassId;

                    var promoDet = objPromo.ClassPromotionDetails.Where(x => x.StudentId == studentId).FirstOrDefault();
                    if (promoDet == null)
                    {
                        trans.Rollback();
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }

                    promoDet.ToClassId = toClassId;

                    db.SaveChanges();
                }
                trans.Commit();
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                trans.Rollback();
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
    }
}