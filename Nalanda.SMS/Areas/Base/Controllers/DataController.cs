﻿using Nalanda.SMS.Data;
using Nalanda.SMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;

namespace Nalanda.SMS.Areas.Base
{
    public class DataController : Controller
    {
        private ActionResult GetDataPaginated<T>(IQueryable<T> qry, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, Dictionary<string, string> lstSortColMap = null, Func<T, object> selFunc = null)
        {
            int rowCount = qry.Count();
            if (pageSize <= 0)
            {
                pageSize = 10;
                startIndex = 0;
            }

            if (startIndex > rowCount)
            { startIndex = 0; }

            var qrySortBy = (lstSortColMap ?? new Dictionary<string, string>()).Where(x => x.Key == sortBy).Select(x => x.Value).FirstOrDefault() ?? sortBy;

            qry = qry.OrderBy("(" + qrySortBy + ")" + (inReverse ? " DESC" : "")).Skip(startIndex);

            if (pageSize > 0)
            { qry = qry.Take(pageSize); }

            var data = qry.ToList().Select(selFunc ?? (x => x)).ToList();

            var obj = new { RowCount = rowCount, SortBy = sortBy, InReverse = inReverse, Data = data };
            return Json(obj);
        }
        
        public ActionResult GetUserRoles(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false, List<int> idsToExcluede = null)
        {
            using (dbNalandaContext dbctx = new dbNalandaContext())
            {
                var qry = dbctx.Roles.AsQueryable();

                if (!filter.IsBlank())
                { qry = qry.Where(searchForKey ? "RoleID.ToString().Contains(@0)" : "Name.Contains(@0)", filter.ToLower()); }
                if (idsToExcluede != null)
                {
                    foreach (var id in idsToExcluede)
                    { qry = qry.Where("RoleID != @0", id); }
                }

                int rowCount = qry.Count();
                if (pageSize <= 0)
                {
                    pageSize = 10;
                    startIndex = 0;
                }

                if (startIndex > rowCount)
                { startIndex = 0; }

                if (sortBy.IsBlank())
                { sortBy = "Name"; }

                var lstSortColMap = new Dictionary<string, string>()
                {
                    { "Role_ID", "RoleID" },
                    { "Role_Name", "Name" }
                };

                return GetDataPaginated(qry, sortBy, inReverse, startIndex, pageSize, lstSortColMap,
                    x => new
                    {
                        Role_ID = x.RoleId,
                        Role_Name = x.Name
                    });
            }
        }
                
        public ActionResult GetStudents(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false, bool isOldStudent = false,bool allStudents = false)
        {
            using (dbNalandaContext dbctx = new dbNalandaContext())
            {
                var qry = dbctx.Students.Where(x => x.Status == StudStatus.Active || x.Status == StudStatus.OnLeave).AsQueryable();

                if (allStudents == true)
                {
                    qry = dbctx.Students.AsQueryable();
                }

                if (!filter.IsBlank())
                {
                    qry = qry.Where(x => searchForKey ? x.StudId.ToString().Contains(filter.ToLower()) : (x.Title.ToString()+x.Gender.ToString()+x.IndexNo+(x.Initials+x.Lname).ToString()).ToLower().Contains(filter.ToLower()));
                    //qry = qry.Where(searchForKey ? "StudID.ToString().Contains(@0)" : "(IndexNo+FullName).ToLower().Contains(@0)", filter.ToLower());
                }


                int rowCount = qry.Count();
                if (pageSize <= 0)
                {
                    pageSize = 10;
                    startIndex = 0;
                }

                if (startIndex > rowCount)
                { startIndex = 0; }

                if (sortBy.IsBlank())
                { sortBy = "Admission_No"; }

                var lstSortColMap = new Dictionary<string, string>()
                {
                    { "StudID", "StudID" } ,
                    { "Admission_No", "IndexNo" } ,
                    { "Student", "Student" }
                };

                return GetDataPaginated(qry, sortBy, inReverse, startIndex, pageSize, lstSortColMap,
                    x => new
                    {
                        x.StudId,
                        Admission_No = x.IndexNo,
                        Student = x.Title+". "+x.Initials+" "+x.Lname
                    });
            }
        }

        public ActionResult GetClasses(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false, int PeriodID = 0)
        {
            using (dbNalandaContext dbctx = new dbNalandaContext())
            {
                var qry = dbctx.Classes.Where(x => x.Status == ActiveState.Active).AsQueryable();

                if(PeriodID != 0)
                {
                    qry = qry.Where(x => x.PromotionClasses.Select(y => y.PeriodId).ToList().Contains(PeriodID));
                }

                if (!filter.IsBlank())
                {
                    qry = qry.Where(x => searchForKey ? x.ClassId.ToString().Contains(filter.ToLower()) : (x.ClassDesc+x.Grade.ToString()).Contains(filter.ToLower()));
                    //qry = qry.Where(searchForKey ? "ClassID.ToString().Contains(@0)" : "(ClassDesc).Contains(@0)", filter.ToLower());
                }

                int rowCount = qry.Count();
                if (pageSize <= 0)
                {
                    pageSize = 10;
                    startIndex = 0;
                }

                if (startIndex > rowCount)
                { startIndex = 0; }

                if (sortBy.IsBlank())
                { sortBy = "Grade"; }

                var lstSortColMap = new Dictionary<string, string>()
                {
                    { "Grade", "Grade" } ,
                    { "Class_Description", "ClassDesc" }
                };

                return GetDataPaginated(qry, sortBy, inReverse, startIndex, pageSize, lstSortColMap,
                    x => new
                    {
                        x.ClassId,
                        Grade = x.Grade == StudGrade.Grade1 ? "Grade 1": x.Grade == StudGrade.Grade2 ? "Grade 2": x.Grade == StudGrade.Grade3 ? "Grade 3": x.Grade == StudGrade.Grade4 ? "Grade 4": x.Grade.ToEnumChar(),
                        Class_Description = x.ClassDesc
                    });
            }
        }

        public ActionResult GetPeriods(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false, bool inReverseOn =false)
        {
            using (dbNalandaContext dbctx = new dbNalandaContext())
            {
                var qry = dbctx.PeriodSetups.Where(x => x.IsPeriodComplete == false).OrderByDescending(y => y.PeriodId).AsQueryable();

                if (inReverseOn) { inReverse = true; }

                if (!filter.IsBlank())
                {  //qry = qry.Where(searchForKey ? "PeriodID.ToString().Contains(@0)" : "(PeriodStartDate.ToString()+PeriodEndDate.ToString()).Contains(@0)", filter.ToLower());
                    qry = qry.Where(x => searchForKey ? x.PeriodId.ToString().Contains(filter.ToLower()) : (x.PeriodStartDate.ToString() + x.PeriodEndDate.ToString()).Contains(filter.ToLower()));
                }

                int rowCount = qry.Count();
                if (pageSize <= 0)
                {
                    pageSize = 10;
                    startIndex = 0;
                }

                if (startIndex > rowCount)
                { startIndex = 0; }

                if (sortBy.IsBlank())
                { sortBy = "PeriodID"; }

                var lstSortColMap = new Dictionary<string, string>()
                {
                    { "Period_Start", "PeriodStartDate.ToString()" } ,
                    { "Period_End", "PeriodEndDate.ToString()" }
                };

                return GetDataPaginated(qry, sortBy, inReverse, startIndex, pageSize, lstSortColMap,
                    x => new
                    {
                        x.PeriodId,
                        Period_Start = x.PeriodStartDate.ToString("yyyy-MM-dd"),
                        Period_End = x.PeriodEndDate.ToString("yyyy-MM-dd")
                    });
            }
        }

        public ActionResult GetTeacher(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false, bool isPromotion = false, int classID = 0)
        {
            using (dbNalandaContext dbctx = new dbNalandaContext())
            {
                var qry = dbctx.Teachers.Where(x => x.Status == TeacherStatus.Active).AsQueryable();

                if(isPromotion && classID != 0)
                {
                    qry = qry.Where(x => x.ClassTeachers.Where(y => y.ClassId == classID).Count() == 0).AsQueryable();
                }

                if (!filter.IsBlank())
                {
                    qry = qry.Where(x => searchForKey ? x.TeachId.ToString().Contains(filter.ToLower()) : (x.Title.ToString()+x.Gender.ToString()+x.FullName+x.Initials+x.Lname+x.Nicno.ToString()).Contains(filter.ToLower()));
                    //qry = qry.Where(searchForKey ? "TeachID.ToString().Contains(@0)" : "(Title.ToString()+Gender.ToString()+FullName+Initials+LName).Contains(@0)", filter.ToLower());
                }

                int rowCount = qry.Count();
                if (pageSize <= 0)
                {
                    pageSize = 10;
                    startIndex = 0;
                }

                if (startIndex > rowCount)
                { startIndex = 0; }

                if (sortBy.IsBlank())
                { sortBy = "FullName"; }

                var lstSortColMap = new Dictionary<string, string>()
                {
                    { "Teacher_Name", "Title.ToString()+Initials+LastName" },
                    { "NIC_No", "NICNo" }
                };

                return GetDataPaginated(qry, sortBy, inReverse, startIndex, pageSize, lstSortColMap,
                    x => new
                    {
                        x.TeachId,
                        Teacher_Name = x.Title + ". " + x.Initials + " " + x.Lname,
                        NIC_No = x.Nicno
                    });
            }
        }

        public ActionResult GetClassStudents(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false, int classID = 0, bool isLowerGrade = false, bool isPrefect = false,int promoteClassID = 0, List<int> idsToExclude = null, int type = -1, int periodID = 0, bool isMediRep =false)
        {
            using (dbNalandaContext dbctx = new dbNalandaContext())
            {
                var qry = dbctx.ClassStudents.Where(x => (x.Status == StudStatus.Active  || x.Status == StudStatus.OnLeave || x.Status == StudStatus.Transferred) && x.Student.Status == StudStatus.Active).AsQueryable();
                Class cls = null;
                PeriodSetup periodSetup = null;

                if (classID != 0)
                {
                     cls= dbctx.Classes.Where(x => x.ClassId == classID).FirstOrDefault();
                    qry = dbctx.ClassStudents.Where(x => x.PromotionClass.ClassId == classID && x.PromotionClass.PeriodSetup.IsPeriodComplete != true && x.Student.Status == StudStatus.Active).AsQueryable();
                }
                if (promoteClassID != 0)
                {
                    qry = dbctx.ClassStudents.Where(x => x.PrClId == promoteClassID && x.Student.Status == StudStatus.Active).AsQueryable();
                }

                if (periodID != 0)
                {
                    periodSetup = dbctx.PeriodSetups.Find(periodID);
                }

                //if (type != -1 && periodID != 0)
                //{
                //    var otherPrefects = dbctx.PrefectStudents.Where(x => x.Type != (SMS.Common.PrefectType)type && x.PrefectGuild.PeriodStartDate == periodSetup.PeriodStartDate && x.PrefectGuild.PeriodEndDate == periodSetup.PeriodEndDate).Select(y => y.ClassStudID).ToList();
                    
                //    foreach (var id in otherPrefects)
                //    { qry = qry.Where("ClStudID != @0", id); }
                //}

                if (idsToExclude != null && periodID != 0)
                {
                    foreach (var id in idsToExclude)
                    { qry = qry.Where("ClStudID != @0", id); }
                }

                if (isLowerGrade)
                {
                    var clsStud = qry.Select(x => x.Student.IndexNo).ToList();
                    cls.Grade--;
                    var lastYear = periodSetup.PeriodStartDate.AddYears(-1).Year;
                    qry = dbctx.ClassStudents.Where(x => x.PromotionClass.Class.Grade == cls.Grade && x.PromotionClass.Class.ClassDesc != cls.ClassDesc && !clsStud.Contains(x.Student.IndexNo) && x.PromotionClass.PeriodSetup.PeriodStartDate.Year == lastYear && x.Student.Status == StudStatus.Active).AsQueryable();
                }

                if (isMediRep)
                {
                    qry = dbctx.ClassStudents.Where(x => x.PromotionClass.PeriodSetup.IsPeriodComplete != true && x.Student.Status == StudStatus.Active).AsQueryable();
                }

                if (!filter.IsBlank())
                {
                    qry = qry.Where(x => searchForKey ? x.ClStudId.ToString().Contains(filter.ToLower()) : (x.StudId.ToString()+x.Student.FullName+x.Student.Initials+x.Student.Lname+x.Student.IndexNo+x.PromotionClass.Class.Grade+x.PromotionClass.Class.ClassDesc+ x.PromotionClass.PeriodSetup.PeriodStartDate.ToString() + x.PromotionClass.PeriodSetup.PeriodEndDate.ToString()).Contains(filter.ToLower()));
                    //qry = qry.Where(searchForKey ? "ClStudID.ToString().Contains(@0)" : "(StudID.ToString()+Student.FullName+Student.Initials+Student.LName+Student.IndexNo+PromotionClass.Class.Grade+PromotionClass.Class.ClassDesc).Contains(@0)", filter.ToLower());
                }

                int rowCount = qry.Count();
                if (pageSize <= 0)
                {
                    pageSize = 10;
                    startIndex = 0;
                }

                if (startIndex > rowCount)
                { startIndex = 0; }

                if (sortBy.IsBlank())
                { sortBy = "Student"; }

                var lstSortColMap = new Dictionary<string, string>()
                {
                    {"ClStudID", "ClStudID" },
                    {"StudID", "StudID" },
                    { "Student", "Student.Initials+Student.LName" },
                    { "Admission_No", "Student.IndexNo" },
                    { "Class", "PromotionClass.Class.Grade+PromotionClass.Class.ClassDesc" },
                    { "Period", "PromotionClass.PeriodSetup.PeriodStartDate.ToString('yyyy-MM-dd')+PromotionClass.PeriodSetup.PeriodEndDate.ToString('yyyy-MM-dd')" }
                };

                return GetDataPaginated(qry, sortBy, inReverse, startIndex, pageSize, lstSortColMap,
                x => new
                {
                    x.ClStudId,
                    x.StudId,
                    Student = x.Student.Title + ". " + x.Student.Initials + " " + x.Student.Lname,
                    Admission_No = x.Student.IndexNo,
                    Class = x.PromotionClass.Class.Grade.ToEnumChar() + " - " + x.PromotionClass.Class.ClassDesc,
                    Period = x.PromotionClass.PeriodSetup.PeriodStartDate.ToString("yyyy-MM-dd") + " - " + x.PromotionClass.PeriodSetup.PeriodEndDate.ToString("yyyy-MM-dd")
                });
            }
        }

        public ActionResult GetClubs(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false)
        {
            using (dbNalandaContext dbctx = new dbNalandaContext())
            {
                var qry = dbctx.Clubs.Where(x => x.Status == ActiveState.Active).AsQueryable();

                if (!filter.IsBlank())
                {
                    qry = qry.Where(x => searchForKey ? x.Cid.ToString().Contains(filter.ToLower()) : (x.Name+x.Description).Contains(filter.ToLower()));
                    //qry = qry.Where(searchForKey ? "CID.ToString().Contains(@0)" : "Description.ToString().Contains(@0)", filter.ToLower());
                }

                int rowCount = qry.Count();
                if (pageSize <= 0)
                {
                    pageSize = 10;
                    startIndex = 0;
                }

                if (startIndex > rowCount)
                { startIndex = 0; }

                if (sortBy.IsBlank())
                { sortBy = "CID"; }

                var lstSortColMap = new Dictionary<string, string>()
                {
                    { "Club", "Club" } ,
                    { "Description", "Description" }
                };

                return GetDataPaginated(qry, sortBy, inReverse, startIndex, pageSize, lstSortColMap,
                    x => new
                    {
                        x.Cid,
                        Club = x.Name,
                        x.Description
                    });
            }
        }

        public ActionResult GetPromotClasses(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false, bool isOldStudent = false, int PeriodID = 0)
        {
            using (dbNalandaContext dbctx = new dbNalandaContext())
            {
                var qry = dbctx.PromotionClasses.Where(x => x.PeriodSetup.IsPeriodComplete == false).AsQueryable();

                if (PeriodID != 0)
                { qry = qry.Where(x => x.PeriodId == PeriodID).AsQueryable(); }
                
                if (!filter.IsBlank())
                {
                    //qry = qry.Where(x => searchForKey ? x.PrClID.ToString().Contains(filter.ToLower()) : (x.Class.Grade.ToString()+x.Class.ClassDesc+x.PeriodSetup.PeriodStartDate.ToString()+x.PeriodSetup.PeriodEndDate.ToString()).Contains(filter.ToLower()));
                    qry = qry.Where(x => searchForKey ? x.PrClId.ToString().Contains(filter.ToLower()) : (((
                    x.Class.Grade == StudGrade.Grade1 ? "Grade 1" : 
                    x.Class.Grade == StudGrade.Grade2 ? "Grade 2" :
                    x.Class.Grade == StudGrade.Grade3 ? "Grade 3" :
                    x.Class.Grade == StudGrade.Grade4 ? "Grade 4" :
                    x.Class.Grade == StudGrade.Grade5 ? "Grade 5" :
                    x.Class.Grade == StudGrade.Grade6 ? "Grade 6" :
                    x.Class.Grade == StudGrade.Grade7 ? "Grade 7" :
                    x.Class.Grade == StudGrade.Grade8 ? "Grade 8" :
                    x.Class.Grade == StudGrade.Grade9 ? "Grade 9" :
                    x.Class.Grade == StudGrade.Grade10 ? "Grade 10" :
                    x.Class.Grade == StudGrade.Grade11 ? "Grade 11" :
                    x.Class.Grade == StudGrade.Grade12 ? "Grade 12" :
                    x.Class.Grade == StudGrade.Grade13 ? "Grade 13" :
                    x.Class.Grade.ToString())
                    
                    +" - " + x.Class.ClassDesc )+ x.PeriodSetup.PeriodStartDate.ToString() + x.PeriodSetup.PeriodEndDate.ToString()).Contains(filter.ToLower()));
                }

                int rowCount = qry.Count();
                if (pageSize <= 0)
                {
                    pageSize = 10;
                    startIndex = 0;
                }

                if (startIndex > rowCount)
                { startIndex = 0; }

                if (sortBy.IsBlank())
                { sortBy = "PrClID"; }

                var lstSortColMap = new Dictionary<string, string>()
                {
                    { "PrClID", "PrClID" } ,
                    { "Class", "Class" } ,
                    { "Period_Start", "PeriodSetups.PeriodStartDate.ToString()" },
                    { "Period_End", "PeriodSetups.PeriodEndDate.ToString()" },
                };

                return GetDataPaginated(qry, sortBy, inReverse, startIndex, pageSize, lstSortColMap,
                    x => new
                    {
                        x.PrClId,
                        Class = x.Class.Grade.ToEnumChar() + " - "+x.Class.ClassDesc,
                        Period_Start = x.PeriodSetup.PeriodStartDate.ToString("yyyy-MM-dd"),
                        Period_End = x.PeriodSetup.PeriodEndDate.ToString("yyyy-MM-dd"),

                    });
            }
        }
    }
}