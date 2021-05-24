using SMS.Common.DB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;

namespace SMS.Areas.Base.Controllers
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
            using (dbSMSEntities dbctx = new dbSMSEntities())
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
                        Role_ID = x.RoleID,
                        Role_Name = x.Name
                    });
            }
        }
                
        public ActionResult GetStudents(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false, bool isOldStudent = false,bool allStudents = false)
        {
            using (dbSMSEntities dbctx = new dbSMSEntities())
            {
                var qry = dbctx.Students.Where(x => x.Status == Common.StudStatus.Active || x.Status == Common.StudStatus.OnLeave).AsQueryable();

                if (allStudents == true)
                {
                    qry = dbctx.Students.AsQueryable();
                }

                if (!filter.IsBlank())
                {
                    qry = qry.Where(x => searchForKey ? x.StudID.ToString().Contains(filter.ToLower()) : (x.Title.ToString()+x.Gender.ToString()+x.IndexNo+(x.Initials+x.LName).ToString()).ToLower().Contains(filter.ToLower()));
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
                        x.StudID,
                        Admission_No = x.IndexNo,
                        Student = x.Title+". "+x.Initials+" "+x.LName
                    });
            }
        }

        public ActionResult GetClasses(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false, int PeriodID = 0)
        {
            using (dbSMSEntities dbctx = new dbSMSEntities())
            {
                var qry = dbctx.Classes.Where(x => x.Status == Common.ActiveState.Active).AsQueryable();

                if(PeriodID != 0)
                {
                    qry = qry.Where(x => x.PromotionClasses.Select(y => y.PeriodID).ToList().Contains(PeriodID));
                }

                if (!filter.IsBlank())
                {
                    qry = qry.Where(x => searchForKey ? x.ClassID.ToString().Contains(filter.ToLower()) : (x.ClassDesc+x.Grade.ToString()).Contains(filter.ToLower()));
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
                        x.ClassID,
                        Grade = x.Grade == Common.StudGrade.Grade1 ? "Grade 1": x.Grade == Common.StudGrade.Grade2 ? "Grade 2": x.Grade == Common.StudGrade.Grade3 ? "Grade 3": x.Grade == Common.StudGrade.Grade4 ? "Grade 4": x.Grade.ToEnumChar(),
                        Class_Description = x.ClassDesc
                    });
            }
        }

        public ActionResult GetPeriods(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false, bool inReverseOn =false)
        {
            using (dbSMSEntities dbctx = new dbSMSEntities())
            {
                var qry = dbctx.PeriodSetups.Where(x => x.IsPeriodComplete == false).OrderByDescending(y => y.PeriodID).AsQueryable();

                if (inReverseOn) { inReverse = true; }

                if (!filter.IsBlank())
                {  //qry = qry.Where(searchForKey ? "PeriodID.ToString().Contains(@0)" : "(PeriodStartDate.ToString()+PeriodEndDate.ToString()).Contains(@0)", filter.ToLower());
                    qry = qry.Where(x => searchForKey ? x.PeriodID.ToString().Contains(filter.ToLower()) : (x.PeriodStartDate.ToString() + x.PeriodEndDate.ToString()).Contains(filter.ToLower()));
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
                        x.PeriodID,
                        Period_Start = x.PeriodStartDate.ToString("yyyy-MM-dd"),
                        Period_End = x.PeriodEndDate.ToString("yyyy-MM-dd")
                    });
            }
        }

        public ActionResult GetTeacher(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false, bool isPromotion = false, int classID = 0)
        {
            using (dbSMSEntities dbctx = new dbSMSEntities())
            {
                var qry = dbctx.Teachers.Where(x => x.Status == Common.TeacherStatus.Active).AsQueryable();

                if(isPromotion && classID != 0)
                {
                    qry = qry.Where(x => x.ClassTeachers.Where(y => y.ClassID == classID).Count() == 0).AsQueryable();
                }

                if (!filter.IsBlank())
                {
                    qry = qry.Where(x => searchForKey ? x.TeachID.ToString().Contains(filter.ToLower()) : (x.Title.ToString()+x.Gender.ToString()+x.FullName+x.Initials+x.LName+x.NICNo.ToString()).Contains(filter.ToLower()));
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
                        x.TeachID,
                        Teacher_Name = x.Title + ". " + x.Initials + " " + x.LName,
                        NIC_No = x.NICNo
                    });
            }
        }

        public ActionResult GetClassStudents(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false, int classID = 0, bool isLowerGrade = false, bool isPrefect = false,int promoteClassID = 0, List<int> idsToExclude = null, int type = -1, int periodID = 0, bool isMediRep =false)
        {
            using (dbSMSEntities dbctx = new dbSMSEntities())
            {
                var qry = dbctx.ClassStudents.Where(x => (x.Status == Common.StudStatus.Active  || x.Status == Common.StudStatus.OnLeave || x.Status == Common.StudStatus.Transferred) && x.Student.Status == Common.StudStatus.Active).AsQueryable();
                Class cls = null;
                PeriodSetup periodSetup = null;

                if (classID != 0)
                {
                     cls= dbctx.Classes.Where(x => x.ClassID == classID).FirstOrDefault();
                    qry = dbctx.ClassStudents.Where(x => x.PromotionClass.ClassID == classID && x.PromotionClass.PeriodSetup.IsPeriodComplete != true && x.Student.Status == Common.StudStatus.Active).AsQueryable();
                }
                if (promoteClassID != 0)
                {
                    qry = dbctx.ClassStudents.Where(x => x.PrClID == promoteClassID && x.Student.Status == Common.StudStatus.Active).AsQueryable();
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
                    qry = dbctx.ClassStudents.Where(x => x.PromotionClass.Class.Grade == cls.Grade && x.PromotionClass.Class.ClassDesc != cls.ClassDesc && !clsStud.Contains(x.Student.IndexNo) && x.PromotionClass.PeriodSetup.PeriodStartDate.Year == lastYear && x.Student.Status == Common.StudStatus.Active).AsQueryable();
                }

                if (isMediRep)
                {
                    qry = dbctx.ClassStudents.Where(x => x.PromotionClass.PeriodSetup.IsPeriodComplete != true && x.Student.Status == Common.StudStatus.Active).AsQueryable();
                }

                if (!filter.IsBlank())
                {
                    qry = qry.Where(x => searchForKey ? x.ClStudID.ToString().Contains(filter.ToLower()) : (x.StudID.ToString()+x.Student.FullName+x.Student.Initials+x.Student.LName+x.Student.IndexNo+x.PromotionClass.Class.Grade+x.PromotionClass.Class.ClassDesc+ x.PromotionClass.PeriodSetup.PeriodStartDate.ToString() + x.PromotionClass.PeriodSetup.PeriodEndDate.ToString()).Contains(filter.ToLower()));
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
                    x.ClStudID,
                    x.StudID,
                    Student = x.Student.Title + ". " + x.Student.Initials + " " + x.Student.LName,
                    Admission_No = x.Student.IndexNo,
                    Class = x.PromotionClass.Class.Grade.ToEnumChar() + " - " + x.PromotionClass.Class.ClassDesc,
                    Period = x.PromotionClass.PeriodSetup.PeriodStartDate.ToString("yyyy-MM-dd") + " - " + x.PromotionClass.PeriodSetup.PeriodEndDate.ToString("yyyy-MM-dd")
                });
            }
        }

        public ActionResult GetClubs(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false)
        {
            using (dbSMSEntities dbctx = new dbSMSEntities())
            {
                var qry = dbctx.Clubs.Where(x => x.Status == Common.ActiveState.Active).AsQueryable();

                if (!filter.IsBlank())
                {
                    qry = qry.Where(x => searchForKey ? x.CID.ToString().Contains(filter.ToLower()) : (x.Name+x.Description).Contains(filter.ToLower()));
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
                        x.CID,
                        Club = x.Name,
                        x.Description
                    });
            }
        }

        public ActionResult GetPromotClasses(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false, bool isOldStudent = false, int PeriodID = 0)
        {
            using (dbSMSEntities dbctx = new dbSMSEntities())
            {
                var qry = dbctx.PromotionClasses.Where(x => x.PeriodSetup.IsPeriodComplete == false).AsQueryable();

                if (PeriodID != 0)
                { qry = qry.Where(x => x.PeriodID == PeriodID).AsQueryable(); }
                
                if (!filter.IsBlank())
                {
                    //qry = qry.Where(x => searchForKey ? x.PrClID.ToString().Contains(filter.ToLower()) : (x.Class.Grade.ToString()+x.Class.ClassDesc+x.PeriodSetup.PeriodStartDate.ToString()+x.PeriodSetup.PeriodEndDate.ToString()).Contains(filter.ToLower()));
                    qry = qry.Where(x => searchForKey ? x.PrClID.ToString().Contains(filter.ToLower()) : (((x.Class.Grade == Common.StudGrade.Grade1 ? "Grade 1" : x.Class.Grade == Common.StudGrade.Grade2 ? "Grade 2" :
                    x.Class.Grade == Common.StudGrade.Grade3 ? "Grade 3":x.Class.Grade == Common.StudGrade.Grade4 ? "Grade 4":x.Class.Grade == Common.StudGrade.JuniorPart1 ? "JuniorPart 1": x.Class.Grade == Common.StudGrade.JuniorPart2 ? "JuniorPart 2" : x.Class.Grade == Common.StudGrade.SeniorPart1 ? "SeniorPart 1": x.Class.Grade == Common.StudGrade.SeniorPart2 ? "SeniorPart 2": x.Class.Grade.ToString())+" - " + x.Class.ClassDesc )+ x.PeriodSetup.PeriodStartDate.ToString() + x.PeriodSetup.PeriodEndDate.ToString()).Contains(filter.ToLower()));
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
                        x.PrClID,
                        Class = x.Class.Grade.ToEnumChar() + " - "+x.Class.ClassDesc,
                        Period_Start = x.PeriodSetup.PeriodStartDate.ToString("yyyy-MM-dd"),
                        Period_End = x.PeriodSetup.PeriodEndDate.ToString("yyyy-MM-dd"),

                    });
            }
        }
    }
}