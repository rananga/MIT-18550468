using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class Student : BaseModel
    {
        public Student()
        {
            ClassStudents = new HashSet<CR_Student>();
            StudentFamilies = new HashSet<StudentFamily>();
            StudentSiblings = new HashSet<StudentSibling>();
            ClassMonitors = new HashSet<CR_Monitor>();
            StudentBasketSubjects = new HashSet<StudentBasketSubject>();

            ActivityPositions = new HashSet<StudentExtraActivityPosition>();
            ActivityAcheivements = new HashSet<StudentExtraActivityAcheivement>();
            LeavingCertificates = new HashSet<LeavingCertificate>();
        }

        [DisplayName("Admission No")]
        public int IndexNo { get; set; }
        [DisplayName("Date of Birth"), Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }
        [DisplayName("Full Name"), DataType(DataType.MultilineText), Required]
        public string FullName { get; set; }
        [Required]
        public string Initials { get; set; }
        [DisplayName("Last Name"), Required]
        public string LastName { get; set; }
        [DisplayName("School Email")]
        public string SchoolEmail { get; set; }
        [DisplayName("Address")]
        [Required]
        public string Address1 { get; set; }
        [DisplayName("Street Name")]
        public string Address2 { get; set; }
        [Required]
        public string City { get; set; }
        [DisplayName("Emergency Contact Name"), Required]
        public string EmergContactName { get; set; }
        [DisplayName("Emergency Contact No"), Required]
        [RegularExpression(@"^(0\d{9})$", ErrorMessage = "Invalid Number")]
        public string EmergContactNo { get; set; }
        public Medium Medium { get; set; }
        public string ImagePath { get; set; }
        [Required]
        [DisplayName("Admission Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AdmissionDate { get; set; }
        [DisplayName("Leaving Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? LeavingDate { get; set; }
        public StudStatus Status { get; set; }
        [DisplayName("Is Leaving Certificate Issued")]
        public bool IsLeavingIssued { get; set; }
        [DisplayName("Last Class")]
        public int LastClassId { get; set; }
        [DisplayName("Admitted Class")]
        public int AdmittedClassId { get; set; }

        public virtual ICollection<CR_Student> ClassStudents { get; set; }
        public virtual ICollection<StudentFamily> StudentFamilies { get; set; }
        public virtual ICollection<StudentSibling> StudentSiblings { get; set; }
        public virtual ICollection<CR_Monitor> ClassMonitors { get; set; }
        public virtual ICollection<StudentBasketSubject> StudentBasketSubjects { get; set; }

        public virtual ICollection<StudentExtraActivityPosition> ActivityPositions { get; set; }
        public virtual ICollection<StudentExtraActivityAcheivement> ActivityAcheivements { get; set; }
        public virtual ICollection<LeavingCertificate> LeavingCertificates { get; set; }
    }
}
