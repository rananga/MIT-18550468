using Nalanda.SMS.Data;
using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nalanda.SMS.Areas.Student.Models
{
    public class StudentVM : IModel<Nalanda.SMS.Data.Models.Student, StudentVM>
    {
        public StudentVM()
        {
            StudSiblings = new List<StudSiblingsVM>();
            StudFamilies = new List<StudFamilyVM>();
            mappings = new ObjMappings<Nalanda.SMS.Data.Models.Student, StudentVM>();

            mappings.Add(x => x.Title + ". " + x.Initials + " " + x.Lname, x => x.NameWithInt);
            mappings.Add(x => x.StudSiblings.Select(y => new StudSiblingsVM(y)).ToList(), x => x.StudSiblings);
            mappings.Add(x => x.StudFamilies.Select(y => new StudFamilyVM(y)).ToList(), x => x.StudFamilies);
        }

        public StudentVM(Nalanda.SMS.Data.Models.Student obj) :this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<Nalanda.SMS.Data.Models.Student, StudentVM> mappings { get; set; }

        public int StudID { get; set; }
        [DisplayName("Admission No")]
        public int IndexNo { get; set; }
        [Required]
        public TitleStud Title { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [DisplayName("Full Name"), DataType(DataType.MultilineText), Required]
        public string FullName { get; set; }
        [Required]
        public string Initials { get; set; }
        [DisplayName("Last Name"), Required]
        public string LName { get; set; }
        [Required, DataType(DataType.MultilineText)]
        public string Address { get; set; }
        [Required]
        public string School { get; set; }
        [DisplayName("School Address"), Required]
        public string SchoolAddress { get; set; }
        [DisplayName("Last Dhamma School"), DataType(DataType.MultilineText)]
        public string LastDhammaSchool { get; set; }
        [DisplayName("Last Dhamma School Address"), DataType(DataType.MultilineText)]
        public string LDhammaSchoolAdd { get; set; }
        [DisplayName("English Speaking"), Required]
        public Fluency EngSpeaking { get; set; }
        [DisplayName("English Writing"),Required]
        public Fluency EngWriting { get; set; }        
        [DisplayName("English Reading")]
        public Fluency EngReading { get; set; }
        [DisplayName("Emergency Contact Name"), Required]
        public string EmergencyConName { get; set; }
        [DisplayName("Emergency Contact Telephone"), Required]
        [RegularExpression(@"^(0\d{9})$", ErrorMessage = "Invalid Number")]
        public string EmergencyContactTel { get; set; }
        [DisplayName("Special Attention")]
        public string SpecialAttention { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }
        [DisplayName("Date of Birth"),Required]
        public Nullable<System.DateTime> DOB { get; set; }
        [DisplayName("Last Dhamma School Grade")]
        public string LastDhammaGrade { get; set; }
        public string ImagePath { get; set; }
        public StudStatus Status { get; set; }
        [DisplayName("Student name")]
        public string NameWithInt { get; set; }
        [DisplayName("Inactive Reason"), DataType(DataType.MultilineText)]
        public string InactiveReason { get; set; }
        [DisplayName("Is Leaving Certificate Issued")]
        public bool IsLeavingIssued { get; set; }
        public HttpPostedFileBase ProfilePic { get; set; }
        public virtual ICollection<StudSiblingsVM> StudSiblings { get; set; }
        public virtual ICollection<StudSiblingsVM> StudSiblings1 { get; set; }
        public virtual ICollection<StudFamilyVM> StudFamilies { get; set; }
        public virtual ICollection<ClassStudent> ClassStudents { get; set; }
    }
}