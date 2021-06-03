using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Nalanda.SMS.Data.Models
{
    public partial class Club
    {
        public Club()
        {
            ClubMembers = new HashSet<ClubMember>();
        }

        public int Cid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ActiveState Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual ICollection<ClubMember> ClubMembers { get; set; }
    }
}
