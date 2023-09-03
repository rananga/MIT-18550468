using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Areas.Academic.Models;
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
    public class StudentAdmitController : BaseController
    {
        public ActionResult Index(int? year, int? gradeId)
        {
            var vm = new StudentAdmitVM() { Year = year ?? DateTime.Now.Year, GradeId = gradeId ?? 0 };
            return View(vm);
        }

        public ActionResult StudentClassIndex(int? year, int? gradeId)
        {
            if (year == null || gradeId == null)
                return PartialView("_StudentClassIndex", new List<PCR_StudentVM>());

            var lst = db.Students.Where(x => x.AdmittedGradeId == gradeId && x.LastClassId == null)
                .Select(x => new PCR_StudentVM
                {
                    StudentId = x.Id,
                    StudentIndex = x.AdmissionNo,
                    StudentName = x.FullName,
                    StudentMedium = x.Medium
                }).ToList();

            var classes = db.PhysicalClassRooms.Where(x => x.Year == year && x.GradeClass.GradeId == gradeId)
                .Select(x => new PhysicalClassRoomVM
                {
                    Id = x.Id,
                    ClassName = x.GradeClass.Name,
                    Medium = x.Medium,
                    StudentCount = x.ClassStudents.Count
                }).ToList();


            foreach (var stud in lst)
            {
                var cls = classes.Where(x => x.Medium == stud.StudentMedium).OrderBy(x => x.StudentCount).ThenBy(x => x.ClassName).FirstOrDefault();
                if (cls == null)
                    continue;
                stud.CR_Id = cls.Id;
                cls.StudentCount += 1;
            }

            ViewBag.smClasses = db.PhysicalClassRooms.Where(x => x.Year == year && x.GradeClass.GradeId == gradeId && x.Medium == Medium.Sinhala)
                .Select(x => new KeyValuePair<int, string>(x.Id, x.GradeClass.Code)).ToList();
            ViewBag.emClasses = db.PhysicalClassRooms.Where(x => x.Year == year && x.GradeClass.GradeId == gradeId && x.Medium == Medium.English)
                .Select(x => new KeyValuePair<int, string>(x.Id, x.GradeClass.Code)).ToList();

            return PartialView("_StudentClassIndex", lst);
        }

        [HttpPost]
        public ActionResult StudentClassUpdate(int studentId, int CR_Id)
        {
            try
            {
                var cr = db.PhysicalClassRooms.Find(CR_Id);
                var stud = db.Students.Find(studentId);

                if (cr == null || stud == null)
                {
                    AddAlert(AlertStyles.danger, "Something went wrong. Please try again");
                }
                else
                {
                    stud.LastClassId = cr.Id;
                    stud.ModifiedBy = this.GetCurrUser();
                    stud.ModifiedDate = DateTime.Now;

                    cr.ClassStudents.Add(new PCR_Student()
                    {
                        CR_Id = cr.Id,
                        StudentId = stud.Id,
                        CreatedBy = this.GetCurrUser(),
                        CreatedDate = DateTime.Now
                    });

                    db.SaveChanges();
                    AddAlert(AlertStyles.success, "Student successfully addmitted.");
                    return new HttpStatusCodeResult(HttpStatusCode.OK);
                }
            }
            catch (DbEntityValidationException dbEx)
            { this.ShowEntityErrors(dbEx); }
            catch (Exception ex)
            { AddAlert(AlertStyles.danger, ex.GetInnerException().Message); }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }

        [HttpPost]
        public ActionResult StudentClassUpdateMultiple(string info)
        {
            var trans = db.Database.BeginTransaction();
            try
            {
                var data = info.DeserializeToDynamic();
                foreach (dynamic item in data)
                {
                    var cr = db.PhysicalClassRooms.Find(int.Parse(item.CR_Id.ToString()));
                    var stud = db.Students.Find(int.Parse(item.studentId.ToString()));

                    if (cr == null || stud == null)
                        throw new Exception("Something went wrong. Please try again");
                    else
                    {
                        stud.LastClassId = cr.Id;
                        stud.ModifiedBy = this.GetCurrUser();
                        stud.ModifiedDate = DateTime.Now;

                        cr.ClassStudents.Add(new PCR_Student()
                        {
                            CR_Id = cr.Id,
                            StudentId = stud.Id,
                            CreatedBy = this.GetCurrUser(),
                            CreatedDate = DateTime.Now
                        });

                        db.SaveChanges();
                    }
                }
                trans.Commit();
                AddAlert(AlertStyles.success, "Students successfully addmitted.");
            }
            catch (DbEntityValidationException dbEx)
            {
                trans.Rollback();
                this.ShowEntityErrors(dbEx); 
            }
            catch (Exception ex)
            {
                trans.Rollback(); 
                AddAlert(AlertStyles.danger, ex.GetInnerException().Message);
            }

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}