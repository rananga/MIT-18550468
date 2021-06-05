using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nalanda.SMS.Data.Models
{
    public partial class Class : BaseModel
    {
        public Class()
        {
            ClassSubjects = new HashSet<ClassSubject>();
            ClassStudents = new HashSet<ClassStudent>();
        }

        [Required]
        public int Year { get; set; }
        [DisplayName("Grade"), Required]
        public int GradeId { get; set; }
        [DisplayName("Class"), Required]
        public string Name { get; set; }
        [DisplayName("Class Teacher"), Required]
        public int TeacherId { get; set; }
        public Medium Medium { get; set; }

        public virtual Grade Grade { get; set; }
        public virtual Teacher ClassTeacher { get; set; }
        public virtual ICollection<ClassSubject> ClassSubjects { get; set; }
        public virtual ICollection<ClassStudent> ClassStudents { get; set; }
    }
}
