using System.ComponentModel.DataAnnotations;

namespace Nalanda.SMS.Data.Models
{
    public partial class ClassSubject : BaseModel
    {
        public ClassSubject()
        {
        }

        [Required]
        public int ClassId { get; set; }
        [Required]
        public int TeacherSubjectId { get; set; }

        public virtual Class Class { get; set; }
        public virtual TeacherSubject TeacherSubject { get; set; }
    }
}
