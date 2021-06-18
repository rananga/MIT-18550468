using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class Class : BaseModel
    {
        public Class()
        {
            ClassTeachers = new HashSet<ClassTeacher>();
            ClassMonitors = new HashSet<ClassMonitor>();
            ClassSubjects = new HashSet<ClassSubject>();
            ClassStudents = new HashSet<ClassStudent>();
        }

        [Required]
        public int Year { get; set; }
        [DisplayName("Grade Class"), Required]
        public int GradeClassId { get; set; }
        [Required]
        public Medium Medium { get; set; }

        public virtual GradeClass GradeClass { get; set; }
        public virtual ICollection<ClassTeacher> ClassTeachers { get; set; }
        public virtual ICollection<ClassMonitor> ClassMonitors { get; set; }
        public virtual ICollection<ClassSubject> ClassSubjects { get; set; }
        public virtual ICollection<ClassStudent> ClassStudents { get; set; }
    }
}
