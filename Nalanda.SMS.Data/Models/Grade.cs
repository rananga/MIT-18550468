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
        [DisplayName("Section")]
        public int SectionId { get; set; }
        [DisplayName("Grade Head")]
        public int? HeadId { get; set; }

        public virtual StaffMember GradeHead { get; set; }
        public virtual ICollection<Class> GradeClasses { get; set; }
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}
