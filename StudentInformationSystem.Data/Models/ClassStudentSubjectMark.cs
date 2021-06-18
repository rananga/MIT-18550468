using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class ClassStudentSubjectMark : BaseModel
    {
        [Required]
        [DisplayName("Class Student Subject")]
        public int ClsStudSubjectId { get; set; }
        public Term Term { get; set; }
        public int Marks { get; set; }

        public virtual ClassStudentSubject ClassStudentSubject { get; set; }
    }
}
