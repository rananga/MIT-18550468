using SMS.Common;
using SMS.Common.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMS.Areas.Student.Models
{
    public class StudFamilyVM : IModel<StudFamily, StudFamilyVM>
    {
        public StudFamilyVM()
        {
            mappings = new ObjMappings<StudFamily, StudFamilyVM>();
        }

        public StudFamilyVM(StudFamily obj) : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<StudFamily, StudFamilyVM> mappings { get; set; }

        public int StudFID { get; set; }
        public int StudID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public SMS.Common.Relationship Relationship { get; set; }
        [Required]
        public string Occupation { get; set; }
        [DisplayName("Working Address"), DataType(DataType.MultilineText), Required]
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
        public string NICNo { get; set; }
        public SMS.Common.TitleTeacher Title { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual Common.DB.Student Student { get; set; }
    }
}