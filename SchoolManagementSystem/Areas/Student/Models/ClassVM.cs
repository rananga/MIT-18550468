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
    public class ClassVM : IModel<Class, ClassVM>
    {
        public ClassVM()
        {
            ClassStudents = new List<ClassStudentVM>();
            mappings = new ObjMappings<Class, ClassVM>();

          // mappings.Add(x => x.ClassStudents.Count(), x => x.NoOfStuds);
        }

        public ClassVM(Class obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<Class, ClassVM> mappings { get; set; }


        [DisplayName("Class"), Required]
        public int ClassID { get; set; }
        public SMS.Common.StudGrade Grade { get; set; }
        [DisplayName("Class"), Required]
        public string ClassDesc { get; set; }
        public SMS.Common.ActiveState Status { get; set; }
        [DisplayName("No of Students")]
        public int NoOfStuds { get; set; }
        [DisplayName("Teacher")]
        public int TeachID { get; set; }
        [DisplayName("Teacher Name")]
        public string TeacherName { get; set; }
        [DisplayName("Period")]
        public int PeriodID { get; set; }
        [DisplayName("Period Start Date")]
        public Nullable<System.DateTime> PeriodStartDate { get; set; }
        [DisplayName("Period End Date")]
        public Nullable<System.DateTime> PeriodEndDate { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual ICollection<ClassTeacher> ClassTeachers { get; set; }
        public virtual ICollection<ClassStudentVM> ClassStudents { get; set; }
    }
}