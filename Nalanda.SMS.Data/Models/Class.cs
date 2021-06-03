using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Nalanda.SMS.Data.Models
{
    public partial class Class
    {
        public Class()
        {
            ClassTeachers = new HashSet<ClassTeacher>();
            PromotionClasses = new HashSet<PromotionClass>();
        }

        public int ClassId { get; set; }
        public StudGrade Grade { get; set; }
        [DisplayName("Class"), Required]
        public string ClassDesc { get; set; }
        public ActiveState Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual ICollection<ClassTeacher> ClassTeachers { get; set; }
        public virtual ICollection<PromotionClass> PromotionClasses { get; set; }
    }
}
