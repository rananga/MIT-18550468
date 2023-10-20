using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class Parent : BaseModel
    {
        public Parent()
        {
            FamilyStudents = new HashSet<StudentFamily>();
        }

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
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        [Required]
        public string Occupation { get; set; }
        [DisplayName("Working Address"), DataType(DataType.MultilineText)]
        public string WorkingAddress { get; set; }
        [DisplayName("Office Telephone")]
        [RegularExpression(@"^(0\d{9})$", ErrorMessage = "Invalid Number")]
        public string OfficePhoneNo { get; set; }
        [Required]
        [DisplayName("Mobile No")]
        [RegularExpression(@"^(0\d{9})$", ErrorMessage = "Invalid Number")]
        public string MobileNo { get; set; }
        [DisplayName("Home Phone No")]
        [RegularExpression(@"^(0\d{9})$", ErrorMessage = "Invalid Number")]
        public string HomePhoneNo { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [DisplayName("NIC No"), Required]
        public string NicNo { get; set; }
        public string NIC_FrontImagePath { get; set; }
        public string NIC_BackImagePath { get; set; }
        public string ImagePath { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<StudentFamily> FamilyStudents { get; set; }
    }
}
