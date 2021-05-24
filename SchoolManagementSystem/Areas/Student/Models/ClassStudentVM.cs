using SMS.Common;
using SMS.Common.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMS.Areas.Student.Models
{
    public class ClassStudentVM : IModel<ClassStudent, ClassStudentVM>
    {
        public ClassStudentVM()
        {
            StudentList = new List<ClassStudentVM>();

             mappings = new ObjMappings<ClassStudent, ClassStudentVM>();
            mappings.Add(x => x.Student.Title +". "+ x.Student.Initials +""+ x.Student.LName, x => x.StudentName);
            mappings.Add(x => x.PromotionClass.Class.ClassDesc, x => x.ClassName);
            mappings.Add(x => x.PromotionClass.Class.Grade == StudGrade.Basic ? "Basic" : (x.PromotionClass.Class.Grade == StudGrade.Diploma ? "Diploma" 
                           : (x.PromotionClass.Class.Grade == StudGrade.Grade1 ? "Grade 1" : (x.PromotionClass.Class.Grade == StudGrade.Grade2 ? "Grade 2" 
                           : (x.PromotionClass.Class.Grade == StudGrade.Grade3 ? "Grade 3" : (x.PromotionClass.Class.Grade == StudGrade.Grade4 ? "Grade 4" 
                           : (x.PromotionClass.Class.Grade == StudGrade.JuniorPart1 ? "Junior Part 1" : (x.PromotionClass.Class.Grade == StudGrade.JuniorPart2 ? "Junior Part 2" 
                           : (x.PromotionClass.Class.Grade == StudGrade.SeniorPart1 ? "Senior Part 1" : "Senior Part 2")))))))) 
                                                                                    + " - " + x.PromotionClass.Class.ClassDesc, x => x.ClassGrade);
            mappings.Add(x => x.Student.School.Trim(), x => x.School);
            mappings.Add(x => x.PromotionClass.Class.Grade, x => x.Grade);
            mappings.Add(x => x.Student.IndexNo, x => x.IndexNo);
            mappings.Add(x => x.PromotionClass.Class.Grade, x => x.GradeDesc);
            mappings.Add(x => x.PromotionClass.Class.Grade.ToString()  + " - " + PromotionClass.Class.ClassDesc, x => x.GardeWithClass);
            mappings.Add(x => x.PromotionClass.PeriodSetup.PeriodStartDate, x => x.PeriodFrom);
            mappings.Add(x => x.PromotionClass.PeriodSetup.PeriodEndDate, x => x.PeriodTo);
            mappings.Add(x => x.Student, x => x.Student);
    }

        public ClassStudentVM(ClassStudent obj) : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<ClassStudent, ClassStudentVM> mappings { get; set; }

        public int ClStudID { get; set; }
        [DisplayName("Student")]
        public int StudID { get; set; }
        [DisplayName("Class")]
        public int PrClID { get; set; }
        [DisplayName("Monitor Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> PeriodStartDate { get; set; }
        [DisplayName("Monitor End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> PeriodEndDate { get; set; }
        [DisplayName("Monitor")]
        public bool IsMonitor { get; set; }
        [DisplayName("Current Monitor")]
        public bool IsCurrentMonitor { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        [DisplayName("Student")]
        public string StudentName { get; set; }
        [DisplayName("Class")]
        public int ClassID { get; set; }
        [DisplayName("Class")]
        public string ClassName { get; set; }
        [DisplayName("Class")]
        public string ClassGrade { get; set; }
        [DisplayName("School")]
        public string School { get; set; }
        [DisplayName("Grade")]
        public SMS.Common.StudGrade Grade { get; set; }
        [DisplayName("Teacher")]
        public int TeachID { get; set; }
        [DisplayName("Admission No")]
        public int IndexNo { get; set; }
        public string ClassListJson { get; set; }
        [DisplayName("Grade")]
        public StudGrade GradeDesc { get; set; }
        [DisplayName("Status")]
        public SMS.Common.StudStatus Status { get; set; }
        [DisplayName("Period Start Date")]
        public int PeriodID { get; set; }
        [DisplayName("Period End Date ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> PeriodTo { get; set; }
        [DisplayName("Period Start Date ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> PeriodFrom { get; set; }
        [DisplayName("Class")]
        public string GardeWithClass { get; set; }



        public ICollection<ClassStudentVM> StudentList { get; set; }

        public byte[] RowVersion { get; set; }

        public virtual PeriodSetup PeriodSetup { get; set; }
        public virtual PromotionClass PromotionClass { get; set; }        

        public virtual Common.DB.Student Student { get; set; }
    }
}