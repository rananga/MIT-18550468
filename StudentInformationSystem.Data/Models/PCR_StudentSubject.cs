using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class PCR_StudentSubject : BaseModel
    {
        public PCR_StudentSubject()
        {
            ClassStudentSubjectMarks = new HashSet<PCR_StudentSubjectMark>();
        }

        [Required]
        [DisplayName("Classroom Student")]
        public int CR_StudentId { get; set; }
        [Required]
        [DisplayName("Subject")]
        public int SubjectId { get; set; }

        public virtual PCR_Student CR_Student { get; set; }
        public virtual Subject Subject { get; set; }

        public virtual ICollection<PCR_StudentSubjectMark> ClassStudentSubjectMarks { get; set; }
    }
}
