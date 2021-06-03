using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Nalanda.SMS.Data.Models
{
    public partial class Prefect
    {
        public int PreId { get; set; }
        public int StudId { get; set; }
        public int PrefClassId { get; set; }
        public PrefectType Type { get; set; }
        public DateTime EffectiveDate { get; set; }
        public bool IsHp { get; set; }
        public bool IsDhp { get; set; }
        public string Responsibilty { get; set; }
        public bool IsPromoted { get; set; }
        public DateTime? PromotedDate { get; set; }
        public ActiveState Status { get; set; }
        public DateTime? InactiveDate { get; set; }
        public string InactiveReason { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual PromotionClass PromotionClass { get; set; }
        public virtual Student Student { get; set; }
    }
}
