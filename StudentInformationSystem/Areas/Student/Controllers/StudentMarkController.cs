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
    public class StudentMarkController : BaseController
    {
        public ActionResult Index(int? year, int? cr_Id, int? subjectId, Term? term)
        {
            var vm = new StudentMarkVM() { Year = year ?? DateTime.Now.Year, CR_Id = cr_Id ?? 0, SubjectId = subjectId ?? 0, Term = term ?? Term.Term1 };
            return View(vm);
        }

        public ActionResult StudentMarksIndex(int? year, int? cr_Id, int? subjectId, Term? term)
        {
            if (year == null || cr_Id == null || subjectId == null || term == null)
                return PartialView("_StudentMarksIndex", new List<CR_StudentSubjectMarkVM>());

            var lst = (from c in db.PhysicalClassRooms.Where(x => x.Year == year && x.Id == cr_Id)
                       from s in db.PCR_Students.Where(x => x.CR_Id == c.Id)
                       from ss in db.PCR_StudentSubjects.Where(x => x.CR_StudentId == s.Id && x.SubjectId == subjectId).DefaultIfEmpty()
                       from ssm in db.PCR_StudentSubjectMarks.Where(x => x.CR_StudentSubjectId == ss.Id && x.Term == term).DefaultIfEmpty()
                       from gc in db.GradeClasses.Where(x => x.Id == c.GradeClassId)
                       from gs in db.GradeSubjects.Where(x => x.GradeId == gc.GradeId && x.SubjectId == subjectId).DefaultIfEmpty()
                       from gcs in db.GradeClassSubjects.Where(x => x.GradeClassId == gc.Id && x.SubjectId == subjectId).DefaultIfEmpty()
                       from sbs in db.StudentBasketSubjects.Where(x => x.StudentId == s.StudentId).DefaultIfEmpty()
                       select new
                       {
                           ssm.Id,
                           s.StudentId,
                           s.Student.AdmissionNo,
                           s.Student.FullName,
                           ssm.CR_StudentSubjectId,
                           Term = term.Value,
                           Marks = ssm.Marks,
                           gsId = gs.Id,
                           gcsId = gcs.Id,
                           sbsId = sbs.Id
                       }
                      ).ToList()
                      .Where(x => x.gsId != 0 || (x.gcsId != 0 && x.sbsId != 0))
                      .GroupBy(x => x.StudentId)
                      .Select(x => new CR_StudentSubjectMarkVM()
                      {
                          Id = x.MaxOrDefault(y => y.Id),
                          StudentId = x.Key,
                          AdmissionNo = x.MaxOrDefault(y => y.AdmissionNo),
                          StudentName = x.MaxOrDefault(y => y.FullName),
                          CR_StudentSubjectId = x.MaxOrDefault(y => y.CR_StudentSubjectId),
                          Term = term.Value,
                          Marks = x.MaxOrDefault(y => y.Marks)
                      }).ToList();

            return PartialView("_StudentMarksIndex", lst);
        }

        [HttpPost]
        public ActionResult StudentMarkUpdate(int? year, int? cr_Id, int? subjectId, Term? term, string jsonData)
        {
            var trans = db.Database.BeginTransaction();
            try
            {
                foreach (var item in jsonData.DeserializeToDynamic())
                {
                    var studentId = (int?)item.studentId;
                    var marks = (decimal?)item.marks;
                    if (year == null || cr_Id == null || subjectId == null || term == null || studentId == null || marks == null)
                    {
                        trans.Rollback();
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }

                    var crStud = db.PhysicalClassRooms.Find(cr_Id).ClassStudents.Where(x => x.StudentId == studentId).FirstOrDefault();
                    var csStudSub = crStud.StudentSubjects.Where(x => x.SubjectId == subjectId).FirstOrDefault();

                    if (csStudSub == null)
                    {
                        csStudSub = new Data.Models.PCR_StudentSubject() { SubjectId = subjectId.Value, CreatedBy = GetCurrUser(), CreatedDate = DateTime.Now };
                        crStud.StudentSubjects.Add(csStudSub);
                    }

                    var csStudSubMark = csStudSub.ClassStudentSubjectMarks.Where(x => x.Term == term).FirstOrDefault();

                    if (csStudSubMark == null)
                    {
                        csStudSubMark = new Data.Models.PCR_StudentSubjectMark() { Term = term.Value, Marks = marks.Value, CreatedBy = GetCurrUser(), CreatedDate = DateTime.Now };
                        csStudSub.ClassStudentSubjectMarks.Add(csStudSubMark);
                    }
                    else
                        csStudSubMark.Marks = marks.Value;

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