using Microsoft.EntityFrameworkCore;
using Nalanda.SMS.Data;
using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Areas.Base;
using Nalanda.SMS.Areas.Student.Models;
using Nalanda.SMS.Common;
using System;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Nalanda.SMS.Areas.Student.Controllers
{
    public class EventParticipationsController : BaseController
    {
        // GET: Student/EventParticipations
        public ActionResult Index(BaseViewModel<EventParticipationsVM> vm)
        {
            vm.SetList(db.EventParticipations.AsQueryable(), "StudentName");
            return View(vm);
        }
        public ActionResult Create()
        {
            var eventParticipations = new EventParticipationsVM() { Date = DateTime.Now};
            return View(eventParticipations);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EPID,StudID,Date,EventDesc,IsWinner,WinningDetails,TeacherInCharge,RowVersion")] EventParticipationsVM EveParticipations)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EveParticipations.CreatedBy = this.GetCurrUser();
                    EveParticipations.CreatedDate = DateTime.Now;
                    db.EventParticipations.Add(EveParticipations.GetEntity());
                    db.SaveChanges();

                    AddAlert(SMS.Common.AlertStyles.success, "Event participation created successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            return View(EveParticipations);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventParticipation EveParticipations = db.EventParticipations.Find(id);
            if (EveParticipations == null)
            {
                return HttpNotFound();
            }
            return View(new EventParticipationsVM(EveParticipations));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventParticipation eventParticipation = db.EventParticipations.Find(id);
            if (eventParticipation == null)
            {
                return HttpNotFound();
            }
            return View(new EventParticipationsVM(eventParticipation));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EPID,StudID,Date,EventDesc,IsWinner,WinningDetails,TeacherInCharge,RowVersion")] EventParticipationsVM EveParticipations)
        {
            byte[] curRowVersion = null;
            try
            {
                if (ModelState.IsValid)
                {
                    var obj = db.EventParticipations.Find(EveParticipations.EPID);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = EveParticipations.GetEntity();
                    modObj.CopyContent(obj, "EventDesc,IsWinner,WinningDetails,TeacherInCharge");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.Entry(obj).OriginalValues["RowVersion"] = EveParticipations.RowVersion;
                    db.SaveChanges();

                    AddAlert(SMS.Common.AlertStyles.success, "Event participation  modified successfully.");
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.ShowConcurrencyErrors(ex);
                EveParticipations.RowVersion = curRowVersion;
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            return View(EveParticipations);
        }
    }


}