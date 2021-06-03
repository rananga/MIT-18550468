using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Nalanda.SMS.Data.Models
{
    public partial class Student
    {
        public Student()
        {
            ClassStudents = new HashSet<ClassStudent>();
            ClubMembers = new HashSet<ClubMember>();
            EventParticipations = new HashSet<EventParticipation>();
            LeavingCertificates = new HashSet<LeavingCertificate>();
            Prefects = new HashSet<Prefect>();
            StudFamilies = new HashSet<StudFamily>();
            StudSiblings = new HashSet<StudSibling>();
        }

        public int StudId { get; set; }
        public int IndexNo { get; set; }
        public TitleStud Title { get; set; }
        public Gender Gender { get; set; }
        public string FullName { get; set; }
        public string Initials { get; set; }
        public string Lname { get; set; }
        public string Address { get; set; }
        public string School { get; set; }
        public string SchoolAddress { get; set; }
        public string LastDhammaSchool { get; set; }
        public string LdhammaSchoolAdd { get; set; }
        public Fluency EngSpeaking { get; set; }
        public Fluency EngWriting { get; set; }
        public Fluency EngReading { get; set; }
        public string EmergencyConName { get; set; }
        public string EmergencyContactTel { get; set; }
        public string SpecialAttention { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public string ImagePath { get; set; }
        public DateTime? Dob { get; set; }
        public string LastDhammaGrade { get; set; }
        public StudStatus Status { get; set; }
        public string InactiveReason { get; set; }
        public bool IsLeavingIssued { get; set; }

        public virtual ICollection<ClassStudent> ClassStudents { get; set; }
        public virtual ICollection<ClubMember> ClubMembers { get; set; }
        public virtual ICollection<EventParticipation> EventParticipations { get; set; }
        public virtual ICollection<LeavingCertificate> LeavingCertificates { get; set; }
        public virtual ICollection<Prefect> Prefects { get; set; }
        public virtual ICollection<StudFamily> StudFamilies { get; set; }
        public virtual ICollection<StudSibling> StudSiblings { get; set; }
    }
}
