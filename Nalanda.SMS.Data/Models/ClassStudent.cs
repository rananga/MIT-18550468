using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Nalanda.SMS.Data.Models
{
    public partial class ClassStudent
    {
        public int ClStudId { get; set; }
        public int PrClId { get; set; }
        public int StudId { get; set; }
        public DateTime? PeriodStartDate { get; set; }
        public DateTime? PeriodEndDate { get; set; }
        public bool IsMonitor { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public StudStatus Status { get; set; }
        public bool IsCurrentMonitor { get; set; }

        public virtual PromotionClass PromotionClass { get; set; }
        public virtual Student Student { get; set; }
    }
}
