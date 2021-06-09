using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nalanda.SMS.Data.Models
{
    public partial class GradeHead : BaseModel
    {
        [Required]
        public int Year { get; set; }
        [DisplayName("Grade")]
        [Required]
        public Grades GradeId { get; set; }
        [DisplayName("Grade Head")]
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
