using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class Subject : BaseModel
    {
        public Subject()
        {
            GradeSubjects = new HashSet<GradeSubject>();
            GradeClassSubjects = new HashSet<GradeClassSubject>();
            StudentSubjects = new HashSet<PCR_StudentSubject>();
            TeacherPreferedSubjects = new HashSet<TeacherPreferedSubject>();
            TeacherQualificationSubjects = new HashSet<TeacherQualificationSubject>();
            ClassSubjects = new HashSet<PCR_Subject>();
            StudentBasketSubjects = new HashSet<StudentBasketSubject>();
            OnlineClassRooms = new HashSet<OnlineClassRoom>();
        }

        [DisplayName("Section"), Required]
        public int SectionId { get; set; }
        [DisplayName("Subject Category")]
        public int SubjectCategoryId { get; set; }
        [DisplayName("Subject"), Required]
        public string Code { get; set; }
        [DisplayName("Subject Number")]
        public int? Number { get; set; }
        public Medium Medium { get; set; }
        public string Description { get; set; }

        public virtual Section Section { get; set; }
        public virtual SubjectCategory SubjectCategory { get; set; }

        public virtual ICollection<GradeSubject> GradeSubjects { get; set; }
        public virtual ICollection<GradeClassSubject> GradeClassSubjects { get; set; }
        public virtual ICollection<PCR_StudentSubject> StudentSubjects { get; set; }
        public virtual ICollection<TeacherPreferedSubject> TeacherPreferedSubjects { get; set; }
        public virtual ICollection<TeacherQualificationSubject> TeacherQualificationSubjects { get; set; }
        public virtual ICollection<PCR_Subject> ClassSubjects { get; set; }
        public virtual ICollection<StudentBasketSubject> StudentBasketSubjects { get; set; }
        public virtual ICollection<OnlineClassRoom> OnlineClassRooms { get; set; }
    }
}
