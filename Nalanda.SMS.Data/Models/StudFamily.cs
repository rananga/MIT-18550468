using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Nalanda.SMS.Data.Models
{
    public partial class StudFamily
    {
        public int StudFid { get; set; }
        public int StudId { get; set; }
        public string Name { get; set; }
        public Relationship Relationship { get; set; }
        public string Occupation { get; set; }
        public string WorkingAdd { get; set; }
        public string OfficeTel { get; set; }
        public string ContactMob { get; set; }
        public string ContactHome { get; set; }
        public string Email { get; set; }
        public string Nicno { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public int Title { get; set; }

        public virtual Student Stud { get; set; }
    }
}
