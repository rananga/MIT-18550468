using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nalanda.SMS.Data.Models
{
    public partial class Grade : BaseModel
    {
        public Grade()
        {
            GradeClasses = new HashSet<Class>();
            TeacherSubjects = new HashSet<TeacherSubject>();
        }

        [Required]
        [Range(1, 13)]
        [DisplayName("Grade")]
        public int GradeId { get; set; }
        [DisplayName("Head Teacher")]
        public int? HeadTeacherId { get; set; }

        public virtual Teacher HeadTeacher { get; set; }
        public virtual ICollection<Class> GradeClasses { get; set; }
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}
