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
            ClassTeachers = new HashSet<PhysicalClassRoom>();
            TeacherOffTimes = new HashSet<TeacherOffTime>();
            TeacherQualifications = new HashSet<TeacherQualification>();
            TeacherPreferredSubjects = new HashSet<TeacherPreferedSubject>();
        }

        [DisplayName("Staff Member"), Required]
        public int StaffId { get; set; }
        [DisplayName("Teacher Section"), Required]
        public int SectionId { get; set; }

        public virtual StaffMember StaffMember { get; set; }
        public virtual Section Section { get; set; }
        public virtual ICollection<Grade> HeadingGrades { get; set; }
        public virtual ICollection<PhysicalClassRoom> ClassTeachers { get; set; }
        public virtual ICollection<TeacherOffTime> TeacherOffTimes { get; set; }
        public virtual ICollection<TeacherQualification> TeacherQualifications { get; set; }
        public virtual ICollection<TeacherPreferedSubject> TeacherPreferredSubjects { get; set; }
    }
}
