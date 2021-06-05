using System.Collections.Generic;
using System.ComponentModel;

namespace Nalanda.SMS.Data.Models
{
    public partial class TeacherSubject : BaseModel
    {
        public TeacherSubject()
        {
        }

        public int TeacherId { get; set; }
        [DisplayName("Grade")]
        public int GradeId { get; set; }
        [DisplayName("Subject")]
        public int SubjectId { get; set; }
        public Medium Medium { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<ClassSubject> ClassSubjects { get; set; }
    }
}
