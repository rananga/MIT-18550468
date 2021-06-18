using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class TeacherQualification : BaseModel
    {
        public TeacherQualification()
        {
            TeacherQualificationSubjects = new HashSet<TeacherQualificationSubject>();
        }

        [Required]
        [DisplayName("Teacher")]
        public int TeacherId { get; set; }
        [Required]
        [DisplayName("Qualification Type")]
        public QualificationType QualificationType { get; set; }
        [Required]
        [DisplayName("Institute")]
        public string Institute { get; set; }
        [Required]
        [DisplayName("Awarded Year")]
        public int AwardedYear { get; set; }
        public int Remarks { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<TeacherQualificationSubject> TeacherQualificationSubjects { get; set; }
    }
}
