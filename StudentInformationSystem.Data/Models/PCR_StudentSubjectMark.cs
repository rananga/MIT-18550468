using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class PCR_StudentSubjectMark : BaseModel
    {
        [Required]
        [DisplayName("Classroom Student Subject")]
        public int CR_StudentSubjectId { get; set; }
        public Term Term { get; set; }
        public decimal Marks { get; set; }

        public virtual PCR_StudentSubject CR_StudentSubject { get; set; }
    }
}
