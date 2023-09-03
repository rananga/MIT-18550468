using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class StudentFamily : BaseModel
    {
        public int StudentId { get; set; }
        public int ParentId { get; set; }
        [Required]
        public Relationship Relationship { get; set; }
        [DisplayName("Is Emergency Contact")]
        public bool IsEmergencyContact{ get; set; }

        public virtual Student Student { get; set; }
        public virtual Parent Parent { get; set; }
    }
}
