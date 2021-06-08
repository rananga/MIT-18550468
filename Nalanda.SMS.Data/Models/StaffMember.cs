using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nalanda.SMS.Data.Models
{
    public partial class StaffMember : BaseModel
    {
        public StaffMember()
        {
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
        [DisplayName("Teacher")]
        public int? TeacherId { get; set; }
    }
}
