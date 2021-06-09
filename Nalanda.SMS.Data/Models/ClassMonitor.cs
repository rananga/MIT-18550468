using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nalanda.SMS.Data.Models
{
    public partial class ClassMonitor : BaseModel
    {
        [DisplayName("Class"), Required]
        public int ClassId { get; set; }
        [DisplayName("Student")]
        [Required]
        public int StudentId { get; set; }
        [DisplayName("From Date")]
        public DateTime FromDate { get; set; }
        [DisplayName("To Date")]
        public DateTime ToDate { get; set; }

        public virtual Class Class { get; set; }
        public virtual Student Student { get; set; }
    }
}
