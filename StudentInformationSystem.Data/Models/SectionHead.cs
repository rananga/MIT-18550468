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
        [Required]
        [DisplayName("Section")]
        public int SectionId { get; set; }
        [Required]
        [DisplayName("Section Head")]
        public int StaffId { get; set; }
        [DisplayName("From Date"), Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FromDate { get; set; }
        [DisplayName("To Date"), Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ToDate { get; set; }

        public virtual Section Section { get; set; }
        public virtual StaffMember StaffMember { get; set; }
    }
}
