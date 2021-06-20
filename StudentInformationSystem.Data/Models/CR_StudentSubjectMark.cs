using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class CR_StudentSubjectMark : BaseModel
    {
        [Required]
        [DisplayName("Class Room Student Subject")]
        public int CR_StudentSubjectId { get; set; }
        public Term Term { get; set; }
        public int Marks { get; set; }

        public virtual CR_StudentSubject CR_StudentSubject { get; set; }
    }
}
