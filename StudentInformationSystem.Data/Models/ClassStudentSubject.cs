using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class ClassStudentSubject : BaseModel
    {
        public ClassStudentSubject()
        {
            ClassStudentSubjectMarks = new HashSet<ClassStudentSubjectMark>();
        }

        [Required]
        [DisplayName("Class Student")]
        public int ClassStudentId { get; set; }
        [Required]
        [DisplayName("Subject")]
        public int SubjectId { get; set; }

        public virtual ClassStudent ClassStudent { get; set; }
        public virtual Subject Subject { get; set; }

        public virtual ICollection<ClassStudentSubjectMark> ClassStudentSubjectMarks { get; set; }
    }
}
