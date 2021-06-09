using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nalanda.SMS.Data.Models
{
    public partial class ClassTeacher : BaseModel
    {
        [DisplayName("Class"), Required]
        public int ClassId { get; set; }
        [DisplayName("Class Teacher")]
        [Required]
        public int StaffId { get; set; }
        [DisplayName("From Date")]
        public DateTime FromDate { get; set; }
        [DisplayName("To Date")]
        public DateTime ToDate { get; set; }

        public virtual Class Class { get; set; }
        public virtual StaffMember StaffMember { get; set; }
    }
}
