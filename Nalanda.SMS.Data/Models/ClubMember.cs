using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Nalanda.SMS.Data.Models
{
    public partial class ClubMember
    {
        public int Cmid { get; set; }
        public int Cid { get; set; }
        public int StudentId { get; set; }
        public DateTime MemberDate { get; set; }
        public MembershipType MembershipType { get; set; }
        public CommitteeMemberType CommiteeMemberType { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public ActiveState Status { get; set; }

        public virtual Club Club { get; set; }
        public virtual Student Student { get; set; }
    }
}
