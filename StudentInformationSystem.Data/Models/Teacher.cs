using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class Teacher : BaseModel
    {
        public Teacher()
        {
            HeadingGrades = new HashSet<Grade>();
            ClassTeachers = new HashSet<ClassRoom>();
            TeacherQualifications = new HashSet<TeacherQualification>();
            TeacherPreferedSubjects = new HashSet<TeacherPreferedSubject>();
        }

        [DisplayName("Staff Member"), Required]
        public int StaffId { get; set; }
        [DisplayName("Teacher Section"), Required]
        public int SectionId { get; set; }

        public virtual StaffMember StaffMember { get; set; }
        public virtual Section Section { get; set; }
        public virtual ICollection<Grade> HeadingGrades { get; set; }
        public virtual ICollection<ClassRoom> ClassTeachers { get; set; }
        public virtual ICollection<TeacherQualification> TeacherQualifications { get; set; }
        public virtual ICollection<TeacherPreferedSubject> TeacherPreferedSubjects { get; set; }
    }
}
