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
            ClassStudents = new HashSet<ClassStudent>();
            //ClubMembers = new HashSet<ClubMember>();
            //EventParticipations = new HashSet<EventParticipation>();
            LeavingCertificates = new HashSet<LeavingCertificate>();
            //Prefects = new HashSet<Prefect>();
            StudFamilies = new HashSet<StudFamily>();
            StudSiblings = new HashSet<StudSibling>();
            ClassMonitors = new HashSet<ClassMonitor>();
        }

        [DisplayName("Admission No")]
        public int IndexNo { get; set; }
        [Required]
        public TitleStud Title { get; set; }
        [DisplayName("Full Name"), DataType(DataType.MultilineText), Required]
        public string FullName { get; set; }
        public string Initials { get; set; }
        [DisplayName("Last Name"), Required]
        public string Lname { get; set; }
        public string SchoolEmail { get; set; }
        [Required, DataType(DataType.MultilineText)]
        public string Address { get; set; }
        [DisplayName("Emergency Contact Name"), Required]
        public string EmergencyConName { get; set; }
        [DisplayName("Emergency Contact Telephone"), Required]
        [RegularExpression(@"^(0\d{9})$", ErrorMessage = "Invalid Number")]
        public string EmergencyContactTel { get; set; }
        public Medium Medium { get; set; }
        public string ImagePath { get; set; }
        [DisplayName("Date of Birth"), Required]
        public DateTime? Dob { get; set; }
        [DisplayName("Last Grade")]
        public string LastGrade { get; set; }
        public StudStatus Status { get; set; }
        [DisplayName("Inactive Reason"), DataType(DataType.MultilineText)]
        public string InactiveReason { get; set; }
        [DisplayName("Is Leaving Certificate Issued")]
        public bool IsLeavingIssued { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AdmissionDate { get; set; }
        public int AdmittedClassId { get; set; }

        public virtual ICollection<ClassStudent> ClassStudents { get; set; }
        //public virtual ICollection<ClubMember> ClubMembers { get; set; }
        //public virtual ICollection<EventParticipation> EventParticipations { get; set; }
        public virtual ICollection<LeavingCertificate> LeavingCertificates { get; set; }
        //public virtual ICollection<Prefect> Prefects { get; set; }
        public virtual ICollection<StudFamily> StudFamilies { get; set; }
        public virtual ICollection<StudSibling> StudSiblings { get; set; }
        public virtual ICollection<StudentExtraActivityPosition> ActivityPositions { get; set; }
        public virtual ICollection<StudentExtraActivityAcheivement> ActivityAcheivements { get; set; }
        public virtual ICollection<ClassMonitor> ClassMonitors { get; set; }
    }
}
