using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class Visitor : BaseModel
    {
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
        [DisplayName("Mobile No"), Required]
        [RegularExpression(@"^(0\d{9})$", ErrorMessage = "Invalid Number")]
        public string MobileNo { get; set; }
        [DisplayName("School Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string SchoolEmail { get; set; }
        [DisplayName("NIC No")]
        public string Nicno { get; set; }
        public string ImagePath { get; set; }

        public virtual User User { get; set; }
    }
}
