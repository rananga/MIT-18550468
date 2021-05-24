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
    public class PromotionClassVM : IModel<PromotionClass, PromotionClassVM>
    {
        public PromotionClassVM()
        {
            ClassStudents = new List<ClassStudentVM>();
            mappings = new ObjMappings<PromotionClass, PromotionClassVM>();

            mappings.Add(x => x.ClassStudents.Where(z => z.Status != StudStatus.Inactive && z.Student.Status != StudStatus.Inactive).Select(y => new ClassStudentVM(y)).ToList(), x => x.ClassStudents);
            mappings.Add(x => x.Class.ClassDesc, x => x.ClassDesc);
            mappings.Add(x => x.Class.Grade, x => x.Grade);
            mappings.Add(x => x.ClassStudents.Count(), x => x.NoOfStud);
            mappings.Add(x => x.Teacher.Title + ". " + x.Teacher.Initials + " " + x.Teacher.LName, x => x.TeacherName);
            mappings.Add(x => x.PeriodSetup.PeriodStartDate, x => x.PeriodStartDate);
            mappings.Add(x => x.PeriodSetup.PeriodEndDate, x => x.PeriodEndDate);
            mappings.Add(x => Grade == StudGrade.Basic ? "Basic" : (Grade == StudGrade.Diploma ? "Diploma" : (Grade == StudGrade.Grade1 ? "Grade 1" 
                            : (Grade == StudGrade.Grade2 ? "Grade 2" : (Grade == StudGrade.Grade3 ? "Grade 3" : Grade == StudGrade.Grade4 ? "Grade 4"
                            : (Grade == StudGrade.JuniorPart1 ? "Junior Part 1" : (Grade == StudGrade.JuniorPart2 ? "Junior Part 2"
                            : (Grade == StudGrade.SeniorPart1 ? "Senior Part 1" : "Senior Part 2"))))))) + " - "+ ClassDesc, x => x.ClassGrade);
            mappings.Add(x => x.Teacher, x => x.Teacher);
        }

        public PromotionClassVM(PromotionClass obj) : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<PromotionClass, PromotionClassVM> mappings { get; set; }

        public int PrClID { get; set; }
        [DisplayName("Class")]
        public int ClassID { get; set; }
        [DisplayName("Period")]
        public int PeriodID { get; set; }
        public string MonitorStudID { get; set; }
        public string MonitorStud2ID { get; set; }
        [DisplayName("Teacher")]
        public int TeacherID { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public SMS.Common.StudGrade Grade { get; set; }
        [DisplayName("Class")]
        public string ClassDesc { get; set; }
        [DisplayName("Class")]
        public string ClassGrade { get; set; }
        [DisplayName("No of Students")]
        public int NoOfStud { get; set; }
        public string ClassListJson { get; set; }
        [DisplayName("Period Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> PeriodStartDate { get; set; }
        [DisplayName("Period End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> PeriodEndDate { get; set; }
        [DisplayName("Teacher Name")]
        public string TeacherName { get; set; }

        public virtual Class Class { get; set; }
        public virtual PeriodSetup PeriodSetup { get; set; }
        public virtual ICollection<ClassStudentVM> ClassStudents { get; set; }
        public virtual Teacher Teacher { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prefect> Prefects { get; set; }
    }
}