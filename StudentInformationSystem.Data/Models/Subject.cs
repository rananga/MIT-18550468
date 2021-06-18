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
            StudentSubjects = new HashSet<ClassStudentSubject>();
            TeacherPreferedSubjects = new HashSet<TeacherPreferedSubject>();
            TeacherQualificationSubjects = new HashSet<TeacherQualificationSubject>();
            ClassSubjects = new HashSet<ClassSubject>();
            StudentBasketSubjects = new HashSet<StudentBasketSubject>();
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
        public virtual ICollection<ClassStudentSubject> StudentSubjects { get; set; }
        public virtual ICollection<TeacherPreferedSubject> TeacherPreferedSubjects { get; set; }
        public virtual ICollection<TeacherQualificationSubject> TeacherQualificationSubjects { get; set; }
        public virtual ICollection<ClassSubject> ClassSubjects { get; set; }
        public virtual ICollection<StudentBasketSubject> StudentBasketSubjects { get; set; }
    }
}
