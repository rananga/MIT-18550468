using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nalanda.SMS.Data.Models
{
    public partial class Grade : BaseModel
    {
        public Grade()
        {
            GradeClasses = new HashSet<GradeClass>();
            TeacherSubjects = new HashSet<TeacherSubject>();
        }

        [Required]
        public Grades GradeId { get; set; }
        [DisplayName("Section"), Required]
        public int SectionId { get; set; }
        public string Description { get; set; }

        public virtual Section Section { get; set; }
        public virtual ICollection<GradeClass> GradeClasses { get; set; }
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}
