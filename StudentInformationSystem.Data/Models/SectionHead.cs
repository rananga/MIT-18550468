using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class SectionHead : BaseModel
    {
        [Required]
        public int Year { get; set; }
        [DisplayName("Section")]
        [Required]
        public int SectionId { get; set; }
        [DisplayName("Section Head")]
        [Required]
        public int StaffId { get; set; }
        [DisplayName("From Date")]
        public DateTime FromDate { get; set; }
        [DisplayName("To Date")]
        public DateTime ToDate { get; set; }

        public virtual Section Section { get; set; }
        public virtual StaffMember StaffMember { get; set; }
    }
}
