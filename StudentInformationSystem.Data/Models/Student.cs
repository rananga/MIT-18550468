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
            ClassStudents = new HashSet<PCR_Student>();
            StudentFamilies = new HashSet<StudentFamily>();
            StudentSiblings = new HashSet<StudentSibling>();
            ClassMonitors = new HashSet<PCR_Monitor>();
            StudentBasketSubjects = new HashSet<StudentBasketSubject>();
            StudentTransfers = new HashSet<StudentTransfer>();

            ActivityPositions = new HashSet<StudentExtraActivityPosition>();
            ActivityAcheivements = new HashSet<StudentExtraActivityAcheivement>();
            LeavingCertificates = new HashSet<LeavingCertificate>();
            ClassPromotionDetails = new HashSet<ClassPromotionDetail>();
        }

        [DisplayName("Admission No")]
        public int AdmissionNo { get; set; }
        [DisplayName("Date of Birth"), Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }
        [DisplayName("Full Name"), DataType(DataType.MultilineText), Required]
        public string FullName { get; set; }
        [Required]
        public string Initials { get; set; }
        [DisplayName("Last Name"), Required]
        public string LastName { get; set; }
        [DisplayName("School Email - Google")]
        public string SchoolEmail_Google { get; set; }
        [DisplayName("School Email - Microsoft")]
        public string SchoolEmail_MS { get; set; }
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
        public int? LastClassId { get; set; }
        [Required]
        [DisplayName("Admitted Grade")]
        public int? AdmittedGradeId { get; set; }
        [DisplayName("Admitted Class")]
        public int? AdmittedClassId { get; set; }

        public BloodGroup BloodGroup { get; set; }
        public decimal HomeLatitude { get; set; }
        public decimal HomeLongitude { get; set; }
        public MaritalStatus ParentsMaritalStatus { get; set; }
        public ParentsDeceased ParentsDeceasedStatus { get; set; }
        public TransportMode TransportMode { get; set; }
        public string DriverDetails { get; set; }
        [DisplayName("Known Illnesses or Allergies")]
        public string KnownIllnesses { get; set; }
        public string BC_FrontImagePath { get; set; }
        public string BC_BackImagePath { get; set; }
        public DivisionalSecretariat CurrentDivSecretariat { get; set; }
        public string CurrentGramaDiv { get; set; }
        public DivisionalSecretariat BirthDivSecretariat { get; set; }
        public string BirthGramaDiv { get; set; }
        public string BirthPlace { get; set; }

        public virtual Grade AdmittedGrade { get; set; }
        public virtual PhysicalClassRoom LastClass { get; set; }
        public virtual PhysicalClassRoom AdmittedClass { get; set; }
        public virtual ICollection<PCR_Student> ClassStudents { get; set; }
        public virtual ICollection<StudentFamily> StudentFamilies { get; set; }
        public virtual ICollection<StudentSibling> StudentSiblings { get; set; }
        public virtual ICollection<PCR_Monitor> ClassMonitors { get; set; }
        public virtual ICollection<StudentBasketSubject> StudentBasketSubjects { get; set; }
        public virtual ICollection<StudentTransfer> StudentTransfers { get; set; }

        public virtual ICollection<StudentExtraActivityPosition> ActivityPositions { get; set; }
        public virtual ICollection<StudentExtraActivityAcheivement> ActivityAcheivements { get; set; }
        public virtual ICollection<LeavingCertificate> LeavingCertificates { get; set; }
        public virtual ICollection<ClassPromotionDetail> ClassPromotionDetails { get; set; }
    }
}
