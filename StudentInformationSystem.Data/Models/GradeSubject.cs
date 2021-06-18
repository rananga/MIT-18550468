using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class GradeSubject : BaseModel
    {
        [DisplayName("Grade")]
        [Required]
        public int GradeId { get; set; }
        [DisplayName("Subject")]
        [Required]
        public int SubjectId { get; set; }

        public virtual Grade Grade { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
