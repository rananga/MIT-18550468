using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

        public int ClubId { get; set; }
        [DisplayName("Club"), Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DisplayName("Status"), Required]
        public ActiveState Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual ICollection<ClubMember> ClubMembers { get; set; }
    }
}
