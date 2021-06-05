using System;

namespace Nalanda.SMS.Data.Models
{
    public partial class ClassTeacher : BaseModel
    {
        public int ClassId { get; set; }
        public int TeacherId { get; set; }
        public int PeriodId { get; set; }
        public DateTime? PeriodStartDate { get; set; }
        public DateTime? PeriodEndDate { get; set; }

        public virtual Class Class { get; set; }
        //public virtual PeriodSetup Period { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
