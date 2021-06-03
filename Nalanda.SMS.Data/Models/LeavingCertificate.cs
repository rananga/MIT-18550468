using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Nalanda.SMS.Data.Models
{
    public partial class LeavingCertificate
    {
        public int LeavCertId { get; set; }
        public int StudId { get; set; }
        public DateTime DateLeaving { get; set; }
        public string Reason { get; set; }
        public int Conduct { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual Student Student { get; set; }
    }
}
