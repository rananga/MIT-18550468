using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nalanda.SMS.Data.Models
{
    public partial class StudSibling : BaseModel
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
