using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class ClassSubject : BaseModel
    {
        [Required]
        [DisplayName("Class")]
        public int ClassId { get; set; }
        [Required]
        [DisplayName("Subject")]
        public int SubjectId { get; set; }
        [Required]
        [DisplayName("Teacher")]
        public int StaffId { get; set; }

        public virtual Class Class { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual StaffMember StaffMember { get; set; }
    }
}
