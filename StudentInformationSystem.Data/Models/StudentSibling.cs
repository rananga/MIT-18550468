using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class StudentSibling : BaseModel
    {
        [DisplayName("Student")]
        public int StudentId { get; set; }
        [DisplayName("Sibling Student"), Required]
        public int SiblingStudentId { get; set; }
        [Required]
        public SibRelationship Relationship { get; set; }

        public virtual Student SiblingStudent { get; set; }
    }
}
