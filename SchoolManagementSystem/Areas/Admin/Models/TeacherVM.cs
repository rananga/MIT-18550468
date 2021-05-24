using SMS.Common;
using SMS.Common.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMS.Areas.Admin.Models
{
    public class TeacherVM : IModel<Teacher, TeacherVM>
    {

        public TeacherVM()
        {
            mappings = new ObjMappings<Teacher, TeacherVM>();

            mappings.Add(x => x.Title + ". " + x.Initials + " " + x.LName, x => x.NameWithInit);
            mappings.Add(x => x.Title + ". " + x.FullName, x => x.NameWithTitle);
        }
        public TeacherVM(Teacher obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<Teacher, TeacherVM> mappings { get;  set; }

        public int TeachID { get; set; }
        [Required]
        public SMS.Common.TitleTeacher Title { get; set; }
        [Required]
        public SMS.Common.Gender Gender { get; set; }
        [DisplayName("Full Name"), DataType(DataType.MultilineText), Required]
        public string FullName { get; set; }
        public string Initials { get; set; }
        [DisplayName("Last Name"), DataType(DataType.MultilineText)]
        public string LName { get; set; }
        [DataType(DataType.MultilineText), Required]
        public string Address { get; set; }
        [DisplayName("Mobile No"), Required]
        [RegularExpression(@"^(0\d{9})$", ErrorMessage = "Invalid Number")]
        public string ContactNo { get; set; }
        [DisplayName("E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [DisplayName("NIC No"), Required]
        public string NICNo { get; set; }
        [DisplayName("Home Contact No")]
        [RegularExpression(@"^(0\d{9})$", ErrorMessage = "Invalid Number")]
        public string TelHome { get; set; }
        [DisplayName("Emergency Contact No"), Required]
        [RegularExpression(@"^(0\d{9})$", ErrorMessage = "Invalid Number")]
        public string ImmeContactNo { get; set; }
        [DisplayName("Emergency Contact Name"), Required]
        public string ImmeContactName { get; set; }
        public SMS.Common.TeacherStatus Status { get; set; }
        [DisplayName("Inactive Reason")]
        public string InactiveReason { get; set; }
        [DisplayName("Teacher Name")]
        public string NameWithInit { get; set; }
        [DisplayName("Teacher Name")]
        public string NameWithTitle { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public virtual ICollection<ClassTeacher> ClassTeachers { get; set; }        
    }
}