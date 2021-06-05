using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nalanda.SMS.Data.Models
{
    public partial class StudFamily : BaseModel
    {
        public int StudentId { get; set; }
        public TitleTeacher Title { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Relationship Relationship { get; set; }
        [Required]
        public string Occupation { get; set; }
        [DisplayName("Working Address"), DataType(DataType.MultilineText)]
        public string WorkingAdd { get; set; }
        [DisplayName("Office Telephone")]
        [RegularExpression(@"^(0\d{9})$", ErrorMessage = "Invalid Number")]
        public string OfficeTel { get; set; }
        [DisplayName("Contact Mobile"), Required]
        [RegularExpression(@"^(0\d{9})$", ErrorMessage = "Invalid Number")]
        public string ContactMob { get; set; }
        [DisplayName("Contact Home")]
        [RegularExpression(@"^(0\d{9})$", ErrorMessage = "Invalid Number")]
        public string ContactHome { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [DisplayName("NIC No"), Required]
        public string Nicno { get; set; }

        public virtual Student Student { get; set; }
    }
}
