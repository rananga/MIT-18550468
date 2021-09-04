using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class StaffMember : BaseModel
    {
        public StaffMember()
        {
            HeadingSections = new HashSet<SectionHead>();
            HeadingGrades = new HashSet<GradeHead>();
            ClassTeachers = new HashSet<CR_Teacher>();
            ClassSubjects = new HashSet<CR_Subject>();
            OCR_Teachers = new HashSet<OCR_Teacher>();
            ExtraActivityIncharges = new HashSet<ExtraActivityIncharge>();
        }

        [DisplayName("Staff Number"), Required]
        public int? StaffNumber { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public TitleStaff Title { get; set; }
        [DisplayName("Full Name"), DataType(DataType.MultilineText), Required]
        public string FullName { get; set; }
        [Required]
        public string Initials { get; set; }
        [DisplayName("Last Name"), DataType(DataType.MultilineText)]
        public string LastName { get; set; }
        [Required]
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        [Required]
        public string City { get; set; }
        [DisplayName("Mobile No"), Required]
        [RegularExpression(@"^(0\d{9})$", ErrorMessage = "Invalid Number")]
        public string MobileNo { get; set; }
        [DisplayName("School Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string SchoolEmail { get; set; }
        [DisplayName("NIC No"), Required]
        public string Nicno { get; set; }
        [DisplayName("Home Contact No")]
        [RegularExpression(@"^(0\d{9})$", ErrorMessage = "Invalid Number")]
        public string TelHome { get; set; }
        [DisplayName("Emergency Contact Name"), Required]
        public string ImmeContactName { get; set; }
        [DisplayName("Emergency Contact No"), Required]
        [RegularExpression(@"^(0\d{9})$", ErrorMessage = "Invalid Number")]
        public string ImmeContactNo { get; set; }
        public ActiveStatus Status { get; set; }
        public string ImagePath { get; set; }
        [DisplayName("Teacher")]
        public int? TeacherId { get; set; }
        [DisplayName("Joined Date")]
        public DateTime? JoinedDate { get; set; }
        [DisplayName("Retired Date")]
        public DateTime? RetiredDate { get; set; }

        public virtual User User { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<SectionHead> HeadingSections { get; set; }
        public virtual ICollection<GradeHead> HeadingGrades { get; set; }
        public virtual ICollection<CR_Teacher> ClassTeachers { get; set; }
        public virtual ICollection<CR_Subject> ClassSubjects { get; set; }
        public virtual ICollection<OCR_Teacher> OCR_Teachers { get; set; }
        public virtual ICollection<ExtraActivityIncharge> ExtraActivityIncharges { get; set; }
    }
}
