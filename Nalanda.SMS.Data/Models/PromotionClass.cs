using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Nalanda.SMS.Data.Models
{
    public partial class PromotionClass
    {
        public PromotionClass()
        {
            ClassStudents = new HashSet<ClassStudent>();
            Prefects = new HashSet<Prefect>();
        }

        public int PrClId { get; set; }
        public int ClassId { get; set; }
        public int PeriodId { get; set; }
        public string MonitorStudId { get; set; }
        public string MonitorStud2Id { get; set; }
        public int TeacherId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual Class Class { get; set; }
        public virtual PeriodSetup PeriodSetup { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<ClassStudent> ClassStudents { get; set; }
        public virtual ICollection<Prefect> Prefects { get; set; }
    }
}
