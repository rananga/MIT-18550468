using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class GradeHead : BaseModel
    {
        [Required]
        public int Year { get; set; }
        [Required]
        [DisplayName("Grade")]
        public int GradeId { get; set; }
        [Required]
        [DisplayName("Grade Head")]
        public int StaffId { get; set; }
        [Required]
        [DisplayName("From Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FromDate { get; set; }
        [Required]
        [DisplayName("To Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ToDate { get; set; }

        public virtual Grade Grade { get; set; }
        public virtual StaffMember StaffMember { get; set; }
    }
}
