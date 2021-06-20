using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class CR_StudentSubject : BaseModel
    {
        public CR_StudentSubject()
        {
            ClassStudentSubjectMarks = new HashSet<CR_StudentSubjectMark>();
        }

        [Required]
        [DisplayName("Class Room Student")]
        public int CR_StudentId { get; set; }
        [Required]
        [DisplayName("Subject")]
        public int SubjectId { get; set; }

        public virtual CR_Student CR_Student { get; set; }
        public virtual Subject Subject { get; set; }

        public virtual ICollection<CR_StudentSubjectMark> ClassStudentSubjectMarks { get; set; }
    }
}
