using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class TeacherPreferedSubject : BaseModel
    {
        [Required]
        [DisplayName("Teacher")]
        public int TeacherId { get; set; }
        [DisplayName("Subject")]
        public int SubjectId { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
