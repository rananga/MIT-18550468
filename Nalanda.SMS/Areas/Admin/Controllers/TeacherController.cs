using Microsoft.EntityFrameworkCore;
using Nalanda.SMS.Data;
using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Areas.Admin.Models;
using Nalanda.SMS.Areas.Base;
using Nalanda.SMS.Common;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Nalanda.SMS.Areas.Admin.Controllers
{
    public class TeacherController : BaseController    
    {
        public ActionResult Index(BaseViewModel<TeacherVM> vm)
    {
        vm.SetList(db.Teachers.AsQueryable(), "LName");
        return View(vm);
    }

    public ActionResult Details(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Teacher teacher = db.Teachers.Find(id);
        if (teacher == null)
        {
            return HttpNotFound();
        }
        return View(new TeacherVM(teacher));
    }

    public ActionResult Create()
    {
        var teacher = new TeacherVM() { Status = TeacherStatus.Active };
        return View(teacher);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "TeachID,Title,Gender,FullName,Initials,LName,Address,ContactNo,Email,NICNo,Status,InactiveReason,TelHome,ImmeContactNo,ImmeContactName")] TeacherVM teacher)
    {
        try
        {
            var existingTeacher = db.Teachers.Where(e => e.Nicno == teacher.Nicno).FirstOrDefault();

            if (existingTeacher != null)
            { ModelState.AddModelError("NICNo", "Teacher Name Already Exist"); }

            if (ModelState.IsValid)
            {
                teacher.CreatedBy = this.GetCurrUser();
                    teacher.CreatedDate = DateTime.Now;
                db.Teachers.Add(teacher.GetEntity());
                db.SaveChanges();

                AddAlert(SMS.Common.AlertStyles.success, "Teacher Information Created Successfully.");
                return RedirectToAction("Index");
            }
        }
        catch (DbEntityValidationException dbEx)
        { this.ShowEntityErrors(dbEx); }
        catch (Exception ex)
        { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

        return View(teacher);
    }

    public ActionResult Edit(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Teacher teacher = db.Teachers.Find(id);
        if (teacher == null)
        {
            return HttpNotFound();
        }
        return View(new TeacherVM(teacher));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit([Bind(Include = "TeachID,Title,Gender,FullName,Initials,LName,Address,ContactNo,Email,NICNo,Status,InactiveReason,RowVersion,TelHome,ImmeContactNo,ImmeContactName")] TeacherVM teacher)
    {
        byte[] curRowVersion = null;
        try
        {
            var existingTeacher = db.Teachers.Where(e => e.Nicno == teacher.Nicno && e.TeachId != teacher.TeachId).FirstOrDefault();

            if (existingTeacher != null)
            { ModelState.AddModelError("NICNo", "Teacher Name Already Exist"); }

            if (ModelState.IsValid)
            {
                var obj = db.Teachers.Find(teacher.TeachId);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(); }

                curRowVersion = obj.RowVersion;
                var modObj = teacher.GetEntity();
                modObj.CopyContent(obj, "Title,Gender,FullName,Initials,LName,Address,ContactNo,Email,NICNo,Status,InactiveReason,TelHome,ImmeContactNo,ImmeContactName");

                obj.ModifiedBy = this.GetCurrUser();
                obj.ModifiedDate = DateTime.Now;

                db.Entry(obj).OriginalValues["RowVersion"] = teacher.RowVersion;
                db.SaveChanges();

                AddAlert(SMS.Common.AlertStyles.success, "Teacher Modified Successfully.");
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
        { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

        return View(teacher);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(TeacherVM teacher)
    {
        try
        {
            var obj = db.Teachers.Find(teacher.TeachId);
            if (obj == null)
            { throw new DbUpdateConcurrencyException(""); }
            db.Detach(obj);

            db.Entry(teacher.GetEntity()).State = EntityState.Deleted;
            db.SaveChanges();

            AddAlert(SMS.Common.AlertStyles.success, "Teacher Deleted Successfully.");
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
            AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message);
        }
        return RedirectToAction("Details", new { id = teacher.TeachId });
    }
}
}