using Microsoft.EntityFrameworkCore;
using Nalanda.SMS.Data;
using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Areas.Base;
using Nalanda.SMS.Areas.Student.Models;
using Nalanda.SMS.Common;
using System;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Nalanda.SMS.Areas.Student.Controllers
{
    public class StudentClubMembershipController : BaseController
    {
        // GET: Student/StudentClubMembership
        public ActionResult Index(BaseViewModel<ClubMemberVM> vm)
        {
            vm.SetList(db.ClubMembers.AsQueryable(), "StudentName");
            return View(vm);
        }

        public ActionResult Create()
        {
            var clubmember = new ClubMemberVM() { MemberDate = DateTime.Now};
           
            return View(clubmember);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CMID,CID,StudentID,MemberDate,MembershipType,CommiteeMemberType,Status,StudentName,RowVersion")] ClubMemberVM clubmember)
        {
            try
            {
                var existMember = db.ClubMembers.Where(x => x.StudentId == clubmember.StudentID && x.Status == ActiveState.Active && x.MembershipType == clubmember.MembershipType && x.Cid == clubmember.CID).FirstOrDefault();
                if (existMember != null)
                { ModelState.AddModelError("", "Already an active member in this Club"); }


                if (ModelState.IsValid)
                {
                    clubmember.CreatedBy = this.GetCurrUser();
                    clubmember.CreatedDate = DateTime.Now;
                    var cMem = db.ClubMembers.Add(clubmember.GetEntity()).Entity;
                    db.SaveChanges();

                    AddAlert(SMS.Common.AlertStyles.success, "Club Membership created successfully.");
                    return RedirectToAction("Details", new { id = cMem.Cmid });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            return View(clubmember);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubMember Cmember = db.ClubMembers.Find(id);
            if (Cmember == null)
            {
                return HttpNotFound();
            }

            return View(new ClubMemberVM(Cmember));
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClubMember clubmember = db.ClubMembers.Find(id);
            if (clubmember == null)
            {
                return HttpNotFound();
            }
            return View(new ClubMemberVM(clubmember));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CMID,CID,StudentID,MemberDate,MembershipType,CommiteeMemberType,Status,StudentName,RowVersion")] ClubMemberVM clubmember)
        {
            byte[] curRowVersion = null;
            try
            {
                var existMember = db.ClubMembers.Where(x => x.StudentId == clubmember.StudentID && x.Status == ActiveState.Active && x.MembershipType == clubmember.MembershipType && x.Cid == clubmember.CID && x.Cmid != clubmember.CMID).FirstOrDefault();
                if (existMember != null)
                { ModelState.AddModelError("", "Already an active member in this Club"); }

                if (ModelState.IsValid)
                {
                    var obj = db.ClubMembers.Find(clubmember.CMID);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;
                    var modObj = clubmember.GetEntity();
                    modObj.CopyContent(obj, "Status");

                    obj.ModifiedBy = this.GetCurrUser();
                    obj.ModifiedDate = DateTime.Now;

                    db.Entry(obj).OriginalValues["RowVersion"] = clubmember.RowVersion;
                    db.SaveChanges();

                    AddAlert(SMS.Common.AlertStyles.success, "Club Membership modified successfully.");
                    return RedirectToAction("Details", new { id = obj.Cmid });
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.ShowConcurrencyErrors(ex);
                clubmember.RowVersion = curRowVersion;
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            return View(clubmember);
        }
    }
}