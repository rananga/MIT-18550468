using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Nalanda.SMS.Data.Models
{
    public partial class ClassTeacher
    {
        public int ClTeachId { get; set; }
        public int ClassId { get; set; }
        public int TeacherId { get; set; }
        public int PeriodId { get; set; }
        public DateTime? PeriodStartDate { get; set; }
        public DateTime? PeriodEndDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual Class Class { get; set; }
        public virtual PeriodSetup Period { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
