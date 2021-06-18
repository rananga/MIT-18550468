using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class TeacherQualificationSubject : BaseModel
    {
        [Required]
        [DisplayName("Teacher Qualification")]
        public int TeacherQualificationId { get; set; }
        [Required]
        [DisplayName("Subject")]
        public int SubjectId { get; set; }

        public virtual TeacherQualification TeacherQualification { get; set; }
        public virtual Subject Subject { get; set; }
    }
}