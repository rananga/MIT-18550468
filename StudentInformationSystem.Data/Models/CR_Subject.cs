using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class CR_Subject : BaseModel
    {
        [Required]
        [DisplayName("Class Room")]
        public int CR_Id { get; set; }
        [Required]
        [DisplayName("Subject")]
        public int SubjectId { get; set; }
        [Required]
        [DisplayName("Teacher")]
        public int StaffId { get; set; }

        public virtual ClassRoom ClassRoom { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual StaffMember StaffMember { get; set; }
    }
}
