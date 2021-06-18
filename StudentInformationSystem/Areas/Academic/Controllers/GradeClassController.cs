using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Areas.Academic.Models;
using StudentInformationSystem.Areas.Base;
using StudentInformationSystem.Common;
using StudentInformationSystem.Data;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentInformationSystem.Areas.Academic.Controllers
{
    public class GradeClassController : BaseController
    {
        public ActionResult Index(BaseViewModel<GradeClassVM> vm)
        {
            vm.SetList(db.GradeClasses.AsQueryable(), "GradeId");
            return View(vm);
        }

        [AllowAnonymous]
        public ActionResult SubjectIndex(int? id, bool isToEdit = false)
        {
            GradeClassVM obj;

            if (isToEdit && Session[sskCrtdObj] is GradeClassVM)
            { obj = (GradeClassVM)Session[sskCrtdObj]; }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var gradCls = db.GradeClasses.Where(x => x.Id == id).FirstOrDefault();
                if (gradCls == null)
                {
                    return HttpNotFound();
                }
                obj = new GradeClassVM(gradCls);
            }

            ViewBag.IsToEdit = isToEdit;
            ViewBag.GradeClassId = obj.Id;
            return PartialView("_SubjectIndex", obj.ClassSubjects);
        }
        public ActionResult Create()
        {
            var grade = new GradeClassVM();
            Session[sskCrtdObj] = grade;
            return View(grade);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GradeClassVM grade)
        {
            try
            {
                var exClass = db.GradeClasses.Where(e => e.GradeId == grade.GradeId && e.Name == grade.Name).FirstOrDefault();
                if (exClass != null)
                { ModelState.AddModelError("", "Class already exists for the grade."); }

                var svm = (GradeClassVM)Session[sskCrtdObj];

                if (ModelState.IsValid)
                {
                    grade.CreatedBy = this.GetCurrUser();
                    grade.CreatedDate = DateTime.Now;
                    var obj = db.GradeClasses.Add(grade.GetEntity()).Entity;

                    foreach (var det in svm.ClassSubjects)
                    {
                        det.CreatedBy = obj.CreatedBy;
                        det.CreatedDate = DateTime.Now;
                        obj.GradeClassSubjects.Add(det.GetEntity());
                    }

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Grade class created successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(grade);
        }

        [AllowAnonymous]
        public ActionResult SubjectCreate(int? gradeClassId)
        {
            if (gradeClassId != 0)
            {
                if (gradeClassId == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var cls = db.GradeClasses.Find(gradeClassId);

                if (cls == null)
                {
                    return HttpNotFound();
                }
            }

            var vm = new GradeClassSubjectVM() { GradeClassId = gradeClassId.Value };
            return PartialView("_SubjectCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult SubjectCreate(GradeClassSubjectVM vm)
        {
            GradeClassVM obj;
            try
            {
                if (ModelState.IsValid)
                {
                    obj = (GradeClassVM)Session[sskCrtdObj];
                    vm.Id = Math.Min(obj.ClassSubjects.Select(x => x.Id).MinOrDefault(), 0) - 1;
                    var objSubject = db.Subjects.Find(vm.SubjectId);
                    vm.SubjectName = objSubject.Code;
                    vm.SectionName = objSubject.Section.Code;
                    vm.SubjectMedium = objSubject.Medium.ToEnumChar();
                    obj.ClassSubjects.Add(vm);

                    AddAlert(AlertStyles.success, "Grade Class Subject Added Successfully.");
                    string url = Url.Action("SubjectIndex", new { id = vm.Id, isToEdit = true });
                    return Json(new { success = true, url });
                }

            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            obj = (GradeClassVM)Session[sskCrtdObj];

            return PartialView("_SubjectCreate", vm);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var obj = db.GradeClasses.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(new GradeClassVM(obj));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var obj = db.GradeClasses.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }

            var vm = new GradeClassVM(obj);
            Session[sskCrtdObj] = vm;

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GradeClassVM grade)
        {
            byte[] curRowVersion = null;
            try
            {
                var svm = (GradeClassVM)Session[sskCrtdObj];

                if (ModelState.IsValid)
                {
                    var obj = db.GradeClasses.Find(grade.Id);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = grade.GetEntity();
                    modObj.CopyContent(obj, "Code,Medium,MaxStudentCount");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.Entry(obj).OriginalValues["RowVersion"] = grade.RowVersion;

                    db.GradeClassSubjects.RemoveRange(obj.GradeClassSubjects.Where(x =>
                        !svm.ClassSubjects.Select(y => y.Id).ToList().Contains(x.Id)));

                    foreach (var det in svm.ClassSubjects)
                    {
                        var objDet = db.GradeClassSubjects.Find(det.Id);
                        if (objDet == null)
                        {
                            det.CreatedBy = this.GetCurrUser();
                            det.CreatedDate = DateTime.Now;
                            obj.GradeClassSubjects.Add(det.GetEntity());
                        }
                    }

                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Grade class modified successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.ShowConcurrencyErrors(ex);
                grade.RowVersion = curRowVersion;
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(grade);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(GradeClassVM grade)
        {
            try
            {
                var obj = db.GradeClasses.Find(grade.Id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }

                var entry = db.Entry(obj);
                entry.State = EntityState.Unchanged;
                entry.Collection(x => x.GradeClassSubjects).Load();
                db.GradeClassSubjects.RemoveRange(entry.Entity.GradeClassSubjects);
                entry.State = EntityState.Deleted;
                db.SaveChanges();

                AddAlert(AlertStyles.success, "Grade class deleted successfully.");
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
            return RedirectToAction("Details", new { id = grade.Id });
        }

        [HttpPost, ActionName("SubjectDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult SubjectDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            try
            {
                var lst = ((GradeClassVM)Session[sskCrtdObj]).ClassSubjects;
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
            { url = Url.Action("SubjectIndex", new { isToEdit = true }); }
            return Json(new { success = true, url, msg });
        }
    }
}