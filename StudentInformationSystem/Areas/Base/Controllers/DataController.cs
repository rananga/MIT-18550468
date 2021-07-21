using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;

namespace StudentInformationSystem.Areas.Base
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

        public ActionResult GetUserPermissions(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false, List<int> idsToExcluede = null)
        {
            using (dbNalandaContext dbctx = new dbNalandaContext())
            {
                var qry = dbctx.Permissions.AsQueryable();

                if (!filter.IsBlank())
                { qry = qry.Where(searchForKey ? "PermissionID.ToString().Contains(@0)" : "Name.Contains(@0)", filter.ToLower()); }
                if (idsToExcluede != null)
                {
                    foreach (var id in idsToExcluede)
                    { qry = qry.Where("PermissionID != @0", id); }
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
                    { "Permission_ID", "PermissionID" },
                    { "Permission_Name", "Name" }
                };

                return GetDataPaginated(qry, sortBy, inReverse, startIndex, pageSize, lstSortColMap,
                    x => new
                    {
                        Permission_ID = x.PermissionId,
                        Permission_Name = x.Name
                    });
            }
        }

        public ActionResult GetStaffMembers(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false)
        {
            using (dbNalandaContext dbctx = new dbNalandaContext())
            {
                var qry = dbctx.StaffMembers.AsQueryable();

                if (!filter.IsBlank())
                { qry = qry.Where(searchForKey ? "Id.ToString().Contains(@0)" : "FullName.ToLower().Contains(@0) || StaffNumber.ToString().ToLower().Contains(@0)", filter.ToLower()); }

                int rowCount = qry.Count();
                if (pageSize <= 0)
                {
                    pageSize = 10;
                    startIndex = 0;
                }

                if (startIndex > rowCount)
                { startIndex = 0; }

                if (sortBy.IsBlank())
                { sortBy = "Staff_Number"; }

                var lstSortColMap = new Dictionary<string, string>()
                {
                    { "Staff_Number", "StaffNumber" },
                    { "Full_Name", "FullName" }
                };

                return GetDataPaginated(qry, sortBy, inReverse, startIndex, pageSize, lstSortColMap,
                    x => new
                    {
                        x.Id,
                        Staff_Number = x.StaffNumber,
                        Full_Name = x.FullName
                    });
            }
        }

        public ActionResult GetVisitors(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false)
        {
            using (dbNalandaContext dbctx = new dbNalandaContext())
            {
                var qry = dbctx.Visitors.AsQueryable();

                if (!filter.IsBlank())
                { qry = qry.Where(searchForKey ? "Id.ToString().Contains(@0)" : "FullName.ToLower().Contains(@0) || Nicno.ToString().ToLower().Contains(@0)", filter.ToLower()); }

                int rowCount = qry.Count();
                if (pageSize <= 0)
                {
                    pageSize = 10;
                    startIndex = 0;
                }

                if (startIndex > rowCount)
                { startIndex = 0; }

                if (sortBy.IsBlank())
                { sortBy = "Full_Name"; }

                var lstSortColMap = new Dictionary<string, string>()
                {
                    { "NIC_No", "Nicno" },
                    { "Full_Name", "FullName" }
                };

                return GetDataPaginated(qry, sortBy, inReverse, startIndex, pageSize, lstSortColMap,
                    x => new
                    {
                        x.Id,
                        NIC_No = x.Nicno,
                        Full_Name = x.FullName
                    });
            }
        }

        public ActionResult GetGradeClasses(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false)
        {
            using (dbNalandaContext dbctx = new dbNalandaContext())
            {
                var qry = dbctx.GradeClasses.AsQueryable();

                if (!filter.IsBlank())
                {
                    qry = qry.Where(x => searchForKey ? x.Id.ToString().Contains(filter.ToLower()) : (x.Grade.GradeNo.ToEnumChar(null) + x.Code).ToLower().Contains(filter.ToLower()));
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
                    { "Id", "Id" } ,
                    { "Grade", "GradeId" }
                };

                return GetDataPaginated(qry, sortBy, inReverse, startIndex, pageSize, lstSortColMap,
                    x => new
                    {
                        x.Id,
                        Grade = x.Grade.GradeNo.ToEnumChar(),
                        Code = x.Code
                    });
            }
        }

        public ActionResult GetSubjects(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false, int? sectionId = null, bool? isBasket = null)
        {
            using (dbNalandaContext dbctx = new dbNalandaContext())
            {
                var qry = dbctx.Subjects.AsQueryable();

                if (sectionId != null)
                {
                    qry = qry.Where(x => x.SectionId == sectionId);
                }
                if (isBasket != null)
                {
                    qry = qry.Where(x => x.SubjectCategory.IsBasket == isBasket);
                }

                if (!filter.IsBlank())
                {
                    qry = qry.Where(x => searchForKey ? x.Id.ToString().Contains(filter.ToLower()) : x.Code.ToLower().Contains(filter.ToLower()));
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
                { sortBy = "Subject_Name"; }

                var lstSortColMap = new Dictionary<string, string>()
                {
                    { "Id", "Id" } ,
                    { "Subject_Name", "Code" },
                    { "Subject_Number", "Number" }
                };

                return GetDataPaginated(qry, sortBy, inReverse, startIndex, pageSize, lstSortColMap,
                    x => new
                    {
                        x.Id,
                        Subject_Name = x.Code,
                        Subject_Number = x.Number
                    });
            }
        }

        public ActionResult GetTeachers(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false)
        {
            using (dbNalandaContext dbctx = new dbNalandaContext())
            {
                var qry = dbctx.Teachers.Where(x => x.StaffMember.Status != ActiveStatus.Inactive).AsQueryable();

                if (!filter.IsBlank())
                {
                    qry = qry.Where(x => searchForKey ? x.Id.ToString().Contains(filter.ToLower()) : (x.StaffMember.Title.ToString() + (x.StaffMember.Initials + x.StaffMember.LastName).ToString()).ToLower().Contains(filter.ToLower()));
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
                { sortBy = "Teacher_Name"; }

                var lstSortColMap = new Dictionary<string, string>()
                {
                    { "Id", "Id" } ,
                    { "Teacher_Name", "StaffMember.LastName" }
                };

                return GetDataPaginated(qry, sortBy, inReverse, startIndex, pageSize, lstSortColMap,
                    x => new
                    {
                        Id = x.StaffId,
                        Teacher_Name = x.StaffMember.Title + ". " + x.StaffMember.Initials + " " + x.StaffMember.LastName
                    });
            }
        }

        public ActionResult GetStudents(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false, bool isOldStudent = false, bool allStudents = false)
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
                    qry = qry.Where(x => searchForKey ? x.Id.ToString().Contains(filter.ToLower()) : (x.IndexNo + (x.Initials + x.LastName).ToString()).ToLower().Contains(filter.ToLower()));
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
                        x.Id,
                        Admission_No = x.IndexNo,
                        Student = x.Initials + " " + x.LastName
                    });
            }
        }

        public ActionResult GetClassRooms(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false, int? year = null)
        {
            using (dbNalandaContext dbctx = new dbNalandaContext())
            {
                var qry = dbctx.ClassRooms.AsQueryable();

                if (year != null)
                {
                    qry = qry.Where(x => x.Year == year);
                }

                if (!filter.IsBlank())
                {
                    qry = qry.Where(x => searchForKey ? x.Id.ToString().Contains(filter.ToLower()) : (x.GradeClass.Code + x.GradeClass.Grade.GradeNo.ToEnumChar(null)).Contains(filter.ToLower()));
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
                { sortBy = "Class"; }

                var lstSortColMap = new Dictionary<string, string>()
                {
                    { "Grade", "Grade" } ,
                    { "Class", "GradeClass.Code" }
                };

                return GetDataPaginated(qry, sortBy, inReverse, startIndex, pageSize, lstSortColMap,
                    x => new
                    {
                        x.Id,
                        Grade = x.GradeClass.Grade.GradeNo.ToEnumChar(),
                        Class = x.GradeClass.Code
                    });
            }
        }

        public ActionResult GetOnliceClassRooms(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false, int Year = 0, int GradeID = 0)
        {
            using (dbNalandaContext dbctx = new dbNalandaContext())
            {
                var qry = dbctx.OnlineClassRooms.AsQueryable();

                if (Year != 0)
                    qry = qry.Where(x => x.Year == Year);

                if (GradeID != 0)
                    qry = qry.Where(x => x.GradeId == GradeID);

                if (!filter.IsBlank())
                {
                    qry = qry.Where(x => searchForKey ? x.Id.ToString().Contains(filter.ToLower()) : (x.Year + x.PhysicalClassRooms.Select(y => y.ClassRoom.GradeClass.Code).Aggregate((y, z) => y + ", " + z)).Contains(filter.ToLower()));
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
                { sortBy = "Year"; }

                var lstSortColMap = new Dictionary<string, string>()
                {
                    { "Year", "Year" }
                };

                return GetDataPaginated(qry, sortBy, inReverse, startIndex, pageSize, lstSortColMap,
                    x => new
                    {
                        x.Id,
                        x.Year,
                        Class = x.PhysicalClassRooms.Select(y => y.ClassRoom.GradeClass.Code).Aggregate((y, z) => y + ", " + z),
                        Class_Teacher = x.ClassTeachers.Where(y => y.IsOwner).FirstOrDefault()?.ClassTeacher?.FullName,
                        Class_Teacher_Id = x.ClassTeachers.Where(y => y.IsOwner).FirstOrDefault()?.Id
                    });
            }
        }

        public ActionResult GetOnliceClassRoomTeachers(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false, int OCR_ID = 0)
        {
            using (dbNalandaContext dbctx = new dbNalandaContext())
            {
                var qry = dbctx.OCR_Teachers.AsQueryable();

                if (OCR_ID != 0)
                    qry = qry.Where(x => x.OCR_Id == OCR_ID);

                if (!filter.IsBlank())
                {
                    //qry = qry.Where(x => searchForKey ? x.Id.ToString().Contains(filter.ToLower()) : (x.Name + x.Grade.ToString()).Contains(filter.ToLower()));
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
                { sortBy = "Staff_Number"; }

                var lstSortColMap = new Dictionary<string, string>()
                {
                    { "Staff_Number", "ClassTeacher.StaffNumber" },
                    { "Full_Name", "ClassTeacher.FullName" }
                };

                return GetDataPaginated(qry, sortBy, inReverse, startIndex, pageSize, lstSortColMap,
                    x => new
                    {
                        x.Id,
                        Staff_Number = x.ClassTeacher.StaffNumber,
                        Full_Name = x.ClassTeacher.FullName
                    });
            }
        }

        //public ActionResult GetPeriods(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false, bool inReverseOn = false)
        //{
        //    using (dbSISContext dbctx = new dbSISContext())
        //    {
        //        var qry = dbctx.PeriodSetups.Where(x => x.IsPeriodComplete == false).OrderByDescending(y => y.PeriodId).AsQueryable();

        //        if (inReverseOn) { inReverse = true; }

        //        if (!filter.IsBlank())
        //        {  //qry = qry.Where(searchForKey ? "PeriodID.ToString().Contains(@0)" : "(PeriodStartDate.ToString()+PeriodEndDate.ToString()).Contains(@0)", filter.ToLower());
        //            qry = qry.Where(x => searchForKey ? x.PeriodId.ToString().Contains(filter.ToLower()) : (x.PeriodStartDate.ToString() + x.PeriodEndDate.ToString()).Contains(filter.ToLower()));
        //        }

        //        int rowCount = qry.Count();
        //        if (pageSize <= 0)
        //        {
        //            pageSize = 10;
        //            startIndex = 0;
        //        }

        //        if (startIndex > rowCount)
        //        { startIndex = 0; }

        //        if (sortBy.IsBlank())
        //        { sortBy = "PeriodID"; }

        //        var lstSortColMap = new Dictionary<string, string>()
        //        {
        //            { "Period_Start", "PeriodStartDate.ToString()" } ,
        //            { "Period_End", "PeriodEndDate.ToString()" }
        //        };

        //        return GetDataPaginated(qry, sortBy, inReverse, startIndex, pageSize, lstSortColMap,
        //            x => new
        //            {
        //                x.PeriodId,
        //                Period_Start = x.PeriodStartDate.ToString("yyyy-MM-dd"),
        //                Period_End = x.PeriodEndDate.ToString("yyyy-MM-dd")
        //            });
        //    }
        //}

        public ActionResult GetTeacher(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false, bool isPromotion = false, int classID = 0)
        {
            using (dbNalandaContext dbctx = new dbNalandaContext())
            {
                var qry = dbctx.Teachers.Where(x => x.StaffMember.Status == ActiveStatus.Active).AsQueryable();

                if (isPromotion && classID != 0)
                {
                    qry = qry.Where(x => x.ClassTeachers.Where(y => y.Id == classID).Count() == 0).AsQueryable();
                }

                if (!filter.IsBlank())
                {
                    qry = qry.Where(x => searchForKey ? x.Id.ToString().Contains(filter.ToLower()) : (x.StaffMember.Title.ToString() + x.StaffMember.Gender.ToString() + x.StaffMember.FullName + x.StaffMember.Initials + x.StaffMember.LastName + x.StaffMember.Nicno.ToString()).Contains(filter.ToLower()));
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
                        x.Id,
                        Teacher_Name = x.StaffMember.Title + ". " + x.StaffMember.Initials + " " + x.StaffMember.LastName,
                        NIC_No = x.StaffMember.Nicno
                    });
            }
        }

        //public ActionResult GetClassStudents(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false, int classID = 0, bool isLowerGrade = false, bool isPrefect = false, int promoteClassID = 0, List<int> idsToExclude = null, int type = -1, int periodID = 0, bool isMediRep = false)
        //{
        //    using (dbSISContext dbctx = new dbSISContext())
        //    {
        //        var qry = dbctx.ClassStudents.Where(x => x.Student.Status == StudStatus.Active).AsQueryable();
        //        Class cls = null;
        //        PeriodSetup periodSetup = null;

        //        if (classID != 0)
        //        {
        //            cls = dbctx.Classes.Where(x => x.Id == classID).FirstOrDefault();
        //            //qry = dbctx.ClassStudents.Where(x => x.PromotionClass.ClassId == classID && x.PromotionClass.PeriodSetup.IsPeriodComplete != true && x.Student.Status == StudStatus.Active).AsQueryable();
        //        }
        //        if (promoteClassID != 0)
        //        {
        //            //qry = dbctx.ClassStudents.Where(x => x.PrClId == promoteClassID && x.Student.Status == StudStatus.Active).AsQueryable();
        //        }

        //        if (periodID != 0)
        //        {
        //            periodSetup = dbctx.PeriodSetups.Find(periodID);
        //        }

        //        //if (type != -1 && periodID != 0)
        //        //{
        //        //    var otherPrefects = dbctx.PrefectStudents.Where(x => x.Type != (SMS.Common.PrefectType)type && x.PrefectGuild.PeriodStartDate == periodSetup.PeriodStartDate && x.PrefectGuild.PeriodEndDate == periodSetup.PeriodEndDate).Select(y => y.ClassStudID).ToList();

        //        //    foreach (var id in otherPrefects)
        //        //    { qry = qry.Where("ClStudID != @0", id); }
        //        //}

        //        if (idsToExclude != null && periodID != 0)
        //        {
        //            foreach (var id in idsToExclude)
        //            { qry = qry.Where("ClStudID != @0", id); }
        //        }

        //        if (isLowerGrade)
        //        {
        //            var clsStud = qry.Select(x => x.Student.IndexNo).ToList();
        //            //cls.Grade--;
        //            var lastYear = periodSetup.PeriodStartDate.AddYears(-1).Year;
        //            //qry = dbctx.ClassStudents.Where(x => x.PromotionClass.Class.Grade == cls.Grade && x.PromotionClass.Class.ClassDesc != cls.Name && !clsStud.Contains(x.Student.IndexNo) && x.PromotionClass.PeriodSetup.PeriodStartDate.Year == lastYear && x.Student.Status == StudStatus.Active).AsQueryable();
        //        }

        //        if (isMediRep)
        //        {
        //            //qry = dbctx.ClassStudents.Where(x => x.PromotionClass.PeriodSetup.IsPeriodComplete != true && x.Student.Status == StudStatus.Active).AsQueryable();
        //        }

        //        if (!filter.IsBlank())
        //        {
        //            //qry = qry.Where(x => searchForKey ? x.Id.ToString().Contains(filter.ToLower()) : (x.StudId.ToString()+x.Student.FullName+x.Student.Initials+x.Student.Lname+x.Student.IndexNo+x.PromotionClass.Class.Grade+x.PromotionClass.Class.ClassDesc+ x.PromotionClass.PeriodSetup.PeriodStartDate.ToString() + x.PromotionClass.PeriodSetup.PeriodEndDate.ToString()).Contains(filter.ToLower()));
        //            //qry = qry.Where(searchForKey ? "ClStudID.ToString().Contains(@0)" : "(StudID.ToString()+Student.FullName+Student.Initials+Student.LName+Student.IndexNo+PromotionClass.Class.Grade+PromotionClass.Class.ClassDesc).Contains(@0)", filter.ToLower());
        //        }

        //        int rowCount = qry.Count();
        //        if (pageSize <= 0)
        //        {
        //            pageSize = 10;
        //            startIndex = 0;
        //        }

        //        if (startIndex > rowCount)
        //        { startIndex = 0; }

        //        if (sortBy.IsBlank())
        //        { sortBy = "Student"; }

        //        var lstSortColMap = new Dictionary<string, string>()
        //        {
        //            {"ClStudID", "ClStudID" },
        //            {"StudID", "StudID" },
        //            { "Student", "Student.Initials+Student.LName" },
        //            { "Admission_No", "Student.IndexNo" },
        //            { "Class", "PromotionClass.Class.Grade+PromotionClass.Class.ClassDesc" },
        //            { "Period", "PromotionClass.PeriodSetup.PeriodStartDate.ToString('yyyy-MM-dd')+PromotionClass.PeriodSetup.PeriodEndDate.ToString('yyyy-MM-dd')" }
        //        };

        //        return GetDataPaginated(qry, sortBy, inReverse, startIndex, pageSize, lstSortColMap,
        //        x => new
        //        {
        //            x.Id,
        //            x.StudentId,
        //            Student = x.Student.Title + ". " + x.Student.Initials + " " + x.Student.Lname,
        //            Admission_No = x.Student.IndexNo//,
        //            //Class = x.PromotionClass.Class.Grade.ToEnumChar() + " - " + x.PromotionClass.Class.ClassDesc,
        //            //Period = x.PromotionClass.PeriodSetup.PeriodStartDate.ToString("yyyy-MM-dd") + " - " + x.PromotionClass.PeriodSetup.PeriodEndDate.ToString("yyyy-MM-dd")
        //        });
        //    }
        //}

        //public ActionResult GetClubs(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false)
        //{
        //    using (dbSISContext dbctx = new dbSISContext())
        //    {
        //        var qry = dbctx.Clubs.Where(x => x.Status == ActiveState.Active).AsQueryable();

        //        if (!filter.IsBlank())
        //        {
        //            qry = qry.Where(x => searchForKey ? x.ClubId.ToString().Contains(filter.ToLower()) : (x.Name + x.Description).Contains(filter.ToLower()));
        //            //qry = qry.Where(searchForKey ? "CID.ToString().Contains(@0)" : "Description.ToString().Contains(@0)", filter.ToLower());
        //        }

        //        int rowCount = qry.Count();
        //        if (pageSize <= 0)
        //        {
        //            pageSize = 10;
        //            startIndex = 0;
        //        }

        //        if (startIndex > rowCount)
        //        { startIndex = 0; }

        //        if (sortBy.IsBlank())
        //        { sortBy = "CID"; }

        //        var lstSortColMap = new Dictionary<string, string>()
        //        {
        //            { "Club", "Club" } ,
        //            { "Description", "Description" }
        //        };

        //        return GetDataPaginated(qry, sortBy, inReverse, startIndex, pageSize, lstSortColMap,
        //            x => new
        //            {
        //                x.ClubId,
        //                Club = x.Name,
        //                x.Description
        //            });
        //    }
        //}

        //public ActionResult GetPromotClasses(string filter = null, string sortBy = null, bool inReverse = false, int startIndex = 0, int pageSize = 5, bool searchForKey = false, bool isOldStudent = false, int PeriodID = 0)
        //{
        //    using (dbSISContext dbctx = new dbSISContext())
        //    {
        //        var qry = dbctx.PromotionClasses.Where(x => x.PeriodSetup.IsPeriodComplete == false).AsQueryable();

        //        if (PeriodID != 0)
        //        { qry = qry.Where(x => x.PeriodId == PeriodID).AsQueryable(); }

        //        if (!filter.IsBlank())
        //        {
        //            //qry = qry.Where(x => searchForKey ? x.PrClID.ToString().Contains(filter.ToLower()) : (x.Class.Grade.ToString()+x.Class.ClassDesc+x.PeriodSetup.PeriodStartDate.ToString()+x.PeriodSetup.PeriodEndDate.ToString()).Contains(filter.ToLower()));
        //            qry = qry.Where(x => searchForKey ? x.PrClId.ToString().Contains(filter.ToLower()) : ((
        //            $"Grade {x.Class.Grade.GradeId}"
        //            + " - " + x.Class.Name) + x.PeriodSetup.PeriodStartDate.ToString() + x.PeriodSetup.PeriodEndDate.ToString()).Contains(filter.ToLower()));
        //        }

        //        int rowCount = qry.Count();
        //        if (pageSize <= 0)
        //        {
        //            pageSize = 10;
        //            startIndex = 0;
        //        }

        //        if (startIndex > rowCount)
        //        { startIndex = 0; }

        //        if (sortBy.IsBlank())
        //        { sortBy = "PrClID"; }

        //        var lstSortColMap = new Dictionary<string, string>()
        //        {
        //            { "PrClID", "PrClID" } ,
        //            { "Class", "Class" } ,
        //            { "Period_Start", "PeriodSetups.PeriodStartDate.ToString()" },
        //            { "Period_End", "PeriodSetups.PeriodEndDate.ToString()" },
        //        };

        //        return GetDataPaginated(qry, sortBy, inReverse, startIndex, pageSize, lstSortColMap,
        //            x => new
        //            {
        //                x.PrClId,
        //                Class = x.Class.Grade.ToEnumChar() + " - " + x.Class.Name,
        //                Period_Start = x.PeriodSetup.PeriodStartDate.ToString("yyyy-MM-dd"),
        //                Period_End = x.PeriodSetup.PeriodEndDate.ToString("yyyy-MM-dd"),

        //            });
        //    }
        //}
    }
}