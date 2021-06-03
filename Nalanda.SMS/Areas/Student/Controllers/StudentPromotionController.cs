using Microsoft.EntityFrameworkCore;
using Nalanda.SMS.Data;
using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Areas.Base;
using Nalanda.SMS.Areas.Student.Models;
using Nalanda.SMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Nalanda.SMS.Areas.Student.Controllers
{
    public class StudentPromotionController : BaseController
    {
        // GET: Student/StudentPromotion
        public ActionResult Index(BaseViewModel<PromotionClassVM> vm)
        {
            var qry = db.PromotionClasses.AsQueryable();
            vm.SetList(qry, "PeriodID", SortDirection.Descending);
            return View(vm);
        }

        [AllowAnonymous]
        public ActionResult ChildIndex(int? id, bool isToEdit = false, int? prid = 0, string classListJson = null)
        {
            PromotionClassVM obj = new PromotionClassVM();
            List<ClassStudent> classStudents = new List<ClassStudent>();

            if (isToEdit && Session[sskCrtdObj] is PromotionClassVM)
            { obj = (PromotionClassVM)Session[sskCrtdObj]; }
            else
            {
                if (id == null)
                { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }
            }

            if (prid != 0)
            {
                var promCls = db.PromotionClasses.Find(prid);
                obj = new PromotionClassVM(promCls);
            }

            List<ClassStudentVM> tempList = new List<ClassStudentVM>();
            if (classStudents.Count() != 0)
            {                
                foreach (var det in classStudents)
                {
                    var temp = new ClassStudentVM();
                    temp.StudID = det.StudId;
                    temp.StudentName = det.Student.Title + "." + det.Student.Initials + "." + det.Student.Lname;
                    temp.IndexNo = det.Student.IndexNo;
                    tempList.Add(temp);
                }
                obj.ClassStudents = tempList;
            }
            ViewBag.IsToEdit = isToEdit;
            
            ViewBag.ClassID = obj.ClassID == 0 ? id : obj.ClassID;
            return PartialView("_ChildIndex", obj.ClassStudents);
        }

        public List<ClassStudent>  getLowerGrade(int classID, int periodID)
        {
            List<ClassStudent> classStudents = new List<ClassStudent>(); ;
            if (classID != 0 && periodID != 0)
            {
                var selectClass = db.Classes.Where(x => x.ClassId == classID).FirstOrDefault();
                var selectPeriod = db.PeriodSetups.Where(x => x.PeriodId == periodID).FirstOrDefault();
                var currentClsStuds = db.ClassStudents.Where(x => x.PromotionClass.Class.Grade == selectClass.Grade && x.PromotionClass.Class.ClassDesc != selectClass.ClassDesc && x.PromotionClass.PeriodSetup.PeriodStartDate.Year == selectPeriod.PeriodStartDate.Year).ToList();

                selectClass.Grade--;
                var lastYear = selectPeriod.PeriodStartDate.AddYears(-1).Year;
                classStudents = db.ClassStudents.Where(x => x.Status != StudStatus.Inactive && x.Student.Status != StudStatus.Inactive && x.PromotionClass.Class.Grade == selectClass.Grade && x.PromotionClass.Class.ClassDesc == selectClass.ClassDesc && x.PromotionClass.PeriodSetup.PeriodStartDate.Year == lastYear).ToList();
                var clsStudTemp = db.ClassStudents.Where(x => x.Status != StudStatus.Inactive && x.Student.Status != StudStatus.Inactive && x.PromotionClass.Class.Grade == selectClass.Grade && x.PromotionClass.Class.ClassDesc == selectClass.ClassDesc && x.PromotionClass.PeriodSetup.PeriodStartDate.Year == lastYear).ToList();
                foreach (var det in clsStudTemp)
                {
                    var exist = currentClsStuds.Where(x => x.StudId == det.StudId).FirstOrDefault();
                    if (exist != null)
                    {
                        var curClasRec = classStudents.Where(x => x.StudId == det.StudId).FirstOrDefault();
                        classStudents.Remove(curClasRec);
                    }
                }
            }
            return classStudents;
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromotionClass promClass = db.PromotionClasses.Find(id);
            if (promClass == null)
            {
                return HttpNotFound();
            }

            var promClassVM = new PromotionClassVM(promClass);
            promClassVM.NoOfStud = promClassVM.ClassStudents.Count();

            Session.Remove(sskTempPic);
            Session.Remove(sskTempPicName);
            return View(promClassVM);
        }

        public ActionResult Create(int? classID, int? periodID)
        {
            var classPromVm = new PromotionClassVM();

            List<ClassStudent> StudList = new List<ClassStudent>();
            List<ClassStudentVM> tempList = new List<ClassStudentVM>();

            if (classID != null)
            {
                StudList = getLowerGrade(classID.Value, periodID.Value);
                foreach (var det in StudList)
                {
                    var temp = new ClassStudentVM();
                    temp.ClStudID = det.ClStudId;
                    temp.StudID = det.StudId;
                    temp.StudentName = det.Student.Title + "." + det.Student.Initials + "." + det.Student.Lname;
                    temp.IndexNo = det.Student.IndexNo;
                    tempList.Add(temp);
                }
                classPromVm.ClassStudents = tempList;
                classPromVm.ClassID = classID.Value;
                classPromVm.ClassDesc = db.Classes.Find(classID.Value).ClassDesc;
                classPromVm.Grade = db.Classes.Find(classID.Value).Grade;
                classPromVm.NoOfStud = tempList.Count();
                classPromVm.PeriodID = periodID == null ? 0 : periodID.Value;
                if (periodID != null)
                { classPromVm.PeriodEndDate = db.PeriodSetups.Where(x => x.PeriodId == periodID.Value).Select(y => y.PeriodEndDate).FirstOrDefault(); }
            }
                     
            Session[sskCrtdObj] = classPromVm;
            return View(classPromVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PrClID,ClassID,StudID,PeriodID,MonitorStudID,MonitorStud2ID,Grade,ClassDesc,PeriodStartDate,PeriodEndDate,NoOfStud,TeacherID,ClassListJson")] PromotionClassVM promClassVM)
        {
            try
            {
                var objSession = (PromotionClassVM)Session[sskCrtdObj];

                if (promClassVM.ClassID == 0)
                { ModelState.AddModelError("ClassID", "Class should be selected"); }

                if (promClassVM.TeacherID == 0)
                { ModelState.AddModelError("TeachID", "Teacher should be selected"); }

                if (promClassVM.PeriodID == 0)
                { ModelState.AddModelError("PeriodID", "Period should be selected"); }

                PromotionClass promClassId = db.PromotionClasses.Where(x => x.ClassId == promClassVM.ClassID && x.PeriodId == promClassVM.PeriodID).FirstOrDefault();

                if (promClassId != null)
                { ModelState.AddModelError("", "Existing Class Promotion"); }

                Session[sskCrtdObj] = objSession;
                UpdateMonitor(promClassVM.ClassListJson);


                if (ModelState.IsValid)
                {
                    PromotionClass dbPromID = null;
                    if (promClassId == null)
                    {
                        PromotionClassVM promClass = new PromotionClassVM();
                        promClass.TeacherID = promClassVM.TeacherID;
                        promClass.ClassID = promClassVM.ClassID;
                        promClass.PeriodID = promClassVM.PeriodID;
                        promClass.PeriodStartDate = promClassVM.PeriodStartDate;
                        promClass.PeriodEndDate = promClassVM.PeriodEndDate;
                        var monitorList = promClass.ClassStudents.Where(x => x.IsMonitor == true).Select(y => y.StudID).ToList();
                        promClass.MonitorStudID = monitorList != null ? monitorList.FirstOrDefault().ToString() : "";
                        promClass.MonitorStud2ID = monitorList != null ? monitorList.LastOrDefault().ToString() : "";
                        promClass.CreatedBy = this.GetCurrUser();
                        promClass.CreatedDate = DateTime.Now;
                        dbPromID = db.PromotionClasses.Add(promClass.GetEntity()).Entity;
                        db.SaveChanges();

                        foreach (var det in objSession.ClassStudents)
                        {
                            det.PrClID = dbPromID.PrClId;
                            det.PeriodStartDate = det.PeriodStartDate;
                            det.PeriodEndDate = det.PeriodEndDate;
                            det.CreatedBy = this.GetCurrUser();
                            det.CreatedDate = DateTime.Now;
                            db.ClassStudents.Add(det.GetEntity());
                        }

                        ClassTeacherVM classTeach = new ClassTeacherVM();
                        classTeach.ClassID = objSession.ClassID;
                        classTeach.TeacherID = promClassVM.TeacherID;
                        classTeach.PeriodID = promClassVM.PeriodID;
                        classTeach.PeriodStartDate = promClassVM.PeriodStartDate;
                        classTeach.PeriodEndDate = promClassVM.PeriodEndDate;
                        classTeach.CreatedBy = this.GetCurrUser();
                        classTeach.CreatedDate = DateTime.Now;
                        db.ClassTeachers.Add(classTeach.GetEntity());
                        db.SaveChanges();
                    }

                    AddAlert(SMS.Common.AlertStyles.success, "Promotion created successfully.");
                    return RedirectToAction("Details", new { id = dbPromID.PrClId });
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            return View(promClassVM);
        }

        [AllowAnonymous]
        public ActionResult ChildCreate(int? classID)
        {
            PromotionClassVM obj = null;
            ClassStudentVM classStudentVM = new ClassStudentVM(); ;

            obj = (PromotionClassVM)Session[sskCrtdObj];

            if (classID != 0)
            {
                if (classID == null)
                { return new HttpStatusCodeResult(HttpStatusCode.BadRequest); }

                var clss = db.ClassStudents.Where(x => x.PromotionClass.ClassId == classID).FirstOrDefault();

                classStudentVM.ClassID = classID.Value;
                classStudentVM.Status = StudStatus.Active;
            }
            ViewBag.PeriodID = obj.PeriodID;

            return PartialView("_ChildCreate", classStudentVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult ChildCreate([Bind(Include = "ClStudID,ClassID,StudID,PeriodID,PeriodStartDate,PeriodEndDate,IndexNo,StudentName,IsMonitor,ClassListJson,TeachID,TeacherName,IndexNo,Status")] ClassStudentVM classStudent)
        {
            PromotionClassVM obj;
            try
            {
                obj = (PromotionClassVM)Session[sskCrtdObj];
                UpdateMonitor(classStudent.ClassListJson);
                obj.TeacherID = classStudent.TeachID;

                if (obj.ClassStudents.Where(x => x.IndexNo == classStudent.IndexNo).Count() != 0)
                {
                    { ModelState.AddModelError("", "Student already exists in the selected."); }
                }

                if (ModelState.IsValid)
                {                    
                    classStudent.ClStudID = Math.Min(obj.ClassStudents.Select(x => x.ClStudID).MinOrDefault(), 0) - 1;
                    classStudent.StudID = db.ClassStudents.Find(classStudent.StudID).StudId;
                    obj.ClassStudents.Add(classStudent);
                    Session[sskCrtdObj] = obj;
                    AddAlert(SMS.Common.AlertStyles.success, "Student added successfully.");
                    string url = Url.Action("ChildIndex", new { id = obj.ClassID, isToEdit = true, periodId = obj.PeriodID });
                    return Json(new { success = true, url });
                }
                Session[sskCrtdObj] = obj;
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(SMS.Common.AlertStyles.danger, ex.GetInnerException().Message); }

            return PartialView("_ChildCreate", classStudent);
        }

        public ActionResult GetStudInfo(int studID)
        {
            var obj = db.Students.Where(x => x.ClassStudents.Where(y => y.ClStudId == studID).Count() != 0).FirstOrDefault();

            var IndexNo = obj.IndexNo;
            var InitName = obj.Title.ToEnumChar() + ". " + obj.Initials + " " + obj.Lname;

            return Json(new { IndexNo, InitName }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetDatePeriod(int datePeriodID)
        {
            var fDate = "";
            var tDate = "";
            using (dbNalandaContext dbctx = new dbNalandaContext())
            {
                var obj = dbctx.PeriodSetups.Where(x => x.PeriodId == datePeriodID).FirstOrDefault();
                if (obj != null)
                {
                    fDate = Convert.ToString(obj.PeriodStartDate);
                    tDate = Convert.ToString(obj.PeriodEndDate);
                }
            }

            return Json(new { fDate, tDate }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetStudCount(int classID, int periodID)
        {
            int count = 0;
            var classStudents = getLowerGrade(classID, periodID);
            count = classStudents.Count();

            return Json(new { count }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateMonitor(string dataJson)
        {
            try
            {
                if (!(Session[sskCrtdObj] is PromotionClassVM))
                { throw new Exception("Session expired."); }

                var objVM = (PromotionClassVM)Session[sskCrtdObj];
                var lst = new JavaScriptSerializer().Deserialize<List<Dictionary<string, object>>>(dataJson);
                foreach (var det in objVM.ClassStudents)
                {
                    var dct = lst.Where(x => x["id"].ToString() == det.ClStudID.ToString()).FirstOrDefault();
                    if (dct == null)
                    { continue; }
                                       
                    det.IsMonitor = dct["IsMonitor"].ConvertTo<bool>();
                    det.IsCurrentMonitor = dct["IsCurrentMonitor"].ConvertTo<bool>();
                    var perStart = dct["periodStart"].ToString();
                    if (perStart != "")
                    { det.PeriodStartDate = dct["periodStart"].ConvertTo<DateTime>(); }
                    else { det.PeriodStartDate = null; }
                    var perEnd = dct["periodEnd"].ToString();
                    if (perStart != "")
                    { det.PeriodEndDate = dct["periodEnd"].ConvertTo<DateTime>(); }
                    else { det.PeriodEndDate = null; }
                }
            }
            catch (Exception ex)
            { return Json("Error : " + ex.Message, JsonRequestBehavior.AllowGet); }

            return Json("Success", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromotionClass promotionCls = db.PromotionClasses.Find(id);
            if (promotionCls == null)
            {
                return HttpNotFound();
            }

            var obj = new PromotionClassVM(promotionCls);
            obj.NoOfStud = obj.ClassStudents.Count();

            Session[sskCrtdObj] = obj;

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PrClID,ClassID,PeriodID,,MonitorStudID,MonitorStud2ID,TeacherID,RowVersion,Grade,ClassDesc,ClassGrade,NoOfStud,ClassListJson,PeriodStartDate,PeriodEndDate,TeacherName")] PromotionClassVM promClass)
        {
            byte[] curRowVersion = null;
            try
            {                
                var sessionEvent = (PromotionClassVM)Session[sskCrtdObj];
                UpdateMonitor(promClass.ClassListJson);

                if (ModelState.IsValid)
                {
                    var obj = db.PromotionClasses.Find(promClass.PrClID);
                    if (obj == null)
                    { throw new DbUpdateConcurrencyException(); }

                    curRowVersion = obj.RowVersion;

                    db.Entry(obj).OriginalValues["RowVersion"] = promClass.RowVersion;
                    db.ClassStudents.RemoveRange(obj.ClassStudents.Where(x =>
                        !sessionEvent.ClassStudents.Select(y => y.ClStudID).ToList().Contains(x.ClStudId)));

                    var monitorCount = 0;
                    foreach (var det in sessionEvent.ClassStudents)
                    {
                        var objDet = db.ClassStudents.Find(det.ClStudID);
                        if (objDet == null)
                        {
                            det.PrClID = obj.PrClId;
                            det.PeriodStartDate = null;
                            det.PeriodEndDate = null;
                            det.CreatedBy = this.GetCurrUser();
                            det.CreatedDate = DateTime.Now;
                            db.ClassStudents.Add(det.GetEntity());
                        }
                        else
                        {
                            if (det.IsMonitor)
                            { monitorCount++; }

                            if (det.IsMonitor && monitorCount == 1)
                            { obj.MonitorStudId = det.StudID.ToString(); }
                            else if (det.IsMonitor && monitorCount == 2)
                            { obj.MonitorStud2Id = det.StudID.ToString(); }

                            obj.TeacherId = promClass.TeacherID;
                            obj.ModifiedBy = this.GetCurrUser();
                            obj.ModifiedDate = DateTime.Now;

                            var modObjDet = det.GetEntity();
                            modObjDet.CopyContent(objDet, "IsMonitor,PeriodStartDate,PeriodEndDate,IsCurrentMonitor");

                            objDet.ModifiedBy = this.GetCurrUser();
                            objDet.ModifiedDate = DateTime.Now;
                        }
                    }
                    db.SaveChanges();

                    AddAlert(AlertStyles.success, "Promotion modified successfully.");
                    return RedirectToAction("Details", new { id = promClass.PrClID });
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                this.ShowConcurrencyErrors(ex);
                promClass.RowVersion = curRowVersion;
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return View(promClass);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(PromotionClassVM promClass)
        {
            try
            {
                var obj = db.PromotionClasses.Find(promClass.PrClID);
                if (obj == null)
                { throw new DbUpdateConcurrencyException(""); }
                db.Detach(obj);
                
                var entry = db.Entry(promClass.GetEntity());
                entry.State = EntityState.Unchanged;
                entry.Collection(x => x.ClassStudents).Load();
                db.ClassStudents.RemoveRange(entry.Entity.ClassStudents);
                var objTeach = db.ClassTeachers.Where(x => x.ClassId == promClass.ClassID && x.PeriodId == promClass.PeriodID).FirstOrDefault();
                db.ClassTeachers.Remove(objTeach);
                entry.State = EntityState.Deleted;

                db.SaveChanges();

                AddAlert(AlertStyles.warning, "Promotion deleted successfully.");
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
            return RedirectToAction("Details", new { id = promClass.PrClID });
        }

        [HttpPost, ActionName("ChildDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult ChildDeleteConfirmed(int id)
        {
            string msg = string.Empty;
            try
            {
                var lst = ((PromotionClassVM)Session[sskCrtdObj]).ClassStudents;
                var obj = lst.FirstOrDefault(x => x.ClStudID == id);
                lst.Remove(obj);

                AddAlert(SMS.Common.AlertStyles.success, "Student removed successfully.");
            }
            catch (Exception ex)
            {
                msg = ex.GetInnerException().Message;
                AddAlert(SMS.Common.AlertStyles.danger, msg);
            }
            string url = "";
            if (msg.IsBlank())
            { url = Url.Action("ChildIndex", new { isToEdit = true }); }
            return Json(new { success = true, url = url, msg });
        }
    }
}