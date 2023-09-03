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
        public TitleStaff Title { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Occupation { get; set; }
        [DisplayName("Working Address"), DataType(DataType.MultilineText)]
        public string WorkingAdd { get; set; }
        [DisplayName("Office Telephone")]
        [RegularExpression(@"^(0\d{9})$", ErrorMessage = "Invalid Number")]
        public string OfficeTel { get; set; }
        [Required]
        [DisplayName("Contact Mobile")]
        [RegularExpression(@"^(0\d{9})$", ErrorMessage = "Invalid Number")]
        public string ContactMob { get; set; }
        [DisplayName("Contact Home")]
        [RegularExpression(@"^(0\d{9})$", ErrorMessage = "Invalid Number")]
        public string ContactHome { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [DisplayName("NIC No"), Required]
        public string NicNo { get; set; }
        public string NIC_FrontImagePath { get; set; }
        public string NIC_BackImagePath { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<StudentFamily> FamilyStudents { get; set; }
    }
}
