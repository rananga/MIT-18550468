using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Areas.Base;
using StudentInformationSystem.Areas.Student.Models;
using StudentInformationSystem.Common;
using StudentInformationSystem.Data;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentInformationSystem.Areas.Student.Controllers
{
    public class BasketSubjectController : BaseController
    {
        public ActionResult Index(BaseViewModel<StudentVM> vm)
        {
            vm.SetList(db.Students.AsQueryable(), "IndexNo");
            return View(vm);
        }

        [AllowAnonymous]
        public ActionResult SubjectIndex(int? id, bool isToEdit = false)
        {
            StudentVM obj;

            if (isToEdit && Session[sskCrtdObj] is StudentVM)
            { obj = (StudentVM)Session[sskCrtdObj]; }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var entity = db.Students.Where(x => x.Id == id).FirstOrDefault();
                if (entity == null)
                {
                    return HttpNotFound();
                }
                obj = new StudentVM(entity);
            }

            ViewBag.IsToEdit = isToEdit;
            ViewBag.StudentId = obj.Id;
            return PartialView("_SubjectIndex", obj.BasketSubjects);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var obj = db.Students.Find(id);
            if (obj == null)
            {
                return HttpNotFound();
            }
            return View(new StudentVM(obj));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Data.Models.Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            var obj = new StudentVM(student);

            Session[sskCrtdObj] = obj;
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentVM student)
        {
            byte[] curRowVersion = null;
            try
            {
                var svm = (StudentVM)Session[sskCrtdObj];

                var obj = db.Students.Find(student.Id);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(); }

                db.StudentBasketSubjects.RemoveRange(obj.StudentBasketSubjects.Where(x =>
                    !svm.BasketSubjects.Select(y => y.Id).ToList().Contains(x.Id)));

                foreach (var det in svm.BasketSubjects)
                {
                    var objDet = db.StudentBasketSubjects.Find(det.Id);
                    if (objDet == null)
                    {
                        det.CreatedBy = this.GetCurrUser();
                        det.CreatedDate = DateTime.Now;
                        db.StudentBasketSubjects.Add(det.GetEntity());
                    }
                }

                db.SaveChanges();

                AddAlert(AlertStyles.success, "Student Basket Subjects Successfully.");
                return RedirectToAction("Details", new { id = obj.Id });
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.ShowConcurrencyErrors(ex);
                student.RowVersion = curRowVersion;
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(student);
        }

        [AllowAnonymous]
        public ActionResult SubjectCreate(int? id)
        {
            if (id != 0)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var entity = db.Students.Find(id);

                if (entity == null)
                {
                    return HttpNotFound();
                }
            }

            var vm = new StudentBasketSubjectVM() { StudentId = id.Value };
            return PartialView("_SubjectCreate", vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult SubjectCreate(StudentBasketSubjectVM vm)
        {
            StudentVM obj;
            try
            {
                if (ModelState.IsValid)
                {
                    obj = (StudentVM)Session[sskCrtdObj];
                    vm.Id = Math.Min(obj.BasketSubjects.Select(x => x.Id).MinOrDefault(), 0) - 1;
                    vm.SubjectName = db.Subjects.Find(vm.SubjectId).Code;
                    obj.BasketSubjects.Add(vm);

                    AddAlert(AlertStyles.success, "Student Basket Subject Added Successfully.");
                    string url = Url.Action("SubjectIndex", new { id = vm.Id, isToEdit = true });
                    return Json(new { success = true, url });
                }

            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            obj = (StudentVM)Session[sskCrtdObj];

            return PartialView("_SubjectCreate", vm);
        }

        [HttpPost, ActionName("SubjectDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult SubjectDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            try
            {
                var lst = ((StudentVM)Session[sskCrtdObj]).BasketSubjects;
                var obj = lst.FirstOrDefault(x => x.Id == id);
                lst.Remove(obj);

                AddAlert(AlertStyles.success, "Student Basket Subject Removed Successfully.");
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