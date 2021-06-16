using System;
using System.Collections.Generic;
using System.ComponentModel;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StudentInformationSystem.Data.Models
{
    public partial class UserRole
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        [DisplayName("Role")]
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
