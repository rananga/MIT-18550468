using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nalanda.SMS.Data.Models
{
    public partial class Teacher : BaseModel
    {
        public Teacher()
        {
            HeadingGrades = new HashSet<Grade>();
            ClassTeachers = new HashSet<Class>();
            TeacherSubjects = new HashSet<TeacherSubject>();
            //EventParticipations = new HashSet<EventParticipation>();
            //PromotionClasses = new HashSet<PromotionClass>();
        }

        [Required]
        public TitleTeacher Title { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [DisplayName("Full Name"), DataType(DataType.MultilineText), Required]
        public string FullName { get; set; }
        [Required]
        public string Initials { get; set; }
        [DisplayName("Last Name"), DataType(DataType.MultilineText)]
        public string Lname { get; set; }
        [DataType(DataType.MultilineText), Required]
        public string Address { get; set; }
        [DisplayName("Mobile No"), Required]
        [RegularExpression(@"^(0\d{9})$", ErrorMessage = "Invalid Number")]
        public string ContactNo { get; set; }
        [DisplayName("School Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string SchoolEmail { get; set; }
        [DisplayName("NIC No"), Required]
        public string Nicno { get; set; }
        [DisplayName("Home Contact No")]
        [RegularExpression(@"^(0\d{9})$", ErrorMessage = "Invalid Number")]
        public string TelHome { get; set; }
        [DisplayName("Emergency Contact No"), Required]
        [RegularExpression(@"^(0\d{9})$", ErrorMessage = "Invalid Number")]
        public string ImmeContactNo { get; set; }
        [DisplayName("Emergency Contact Name"), Required]
        public string ImmeContactName { get; set; }
        public TeacherStatus Status { get; set; }
        [DisplayName("Inactive Reason")]
        public string InactiveReason { get; set; }

        public virtual ICollection<Grade> HeadingGrades { get; set; }
        public virtual ICollection<Class> ClassTeachers { get; set; }
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
        //public virtual ICollection<EventParticipation> EventParticipations { get; set; }
        //public virtual ICollection<PromotionClass> PromotionClasses { get; set; }
    }
}
