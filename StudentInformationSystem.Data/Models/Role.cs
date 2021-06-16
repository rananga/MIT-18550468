using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StudentInformationSystem.Data.Models
{
    public partial class Role
    {
        public Role()
        {
            RoleMenuAccesses = new HashSet<RoleMenuAccess>();
            //RoleTiles = new HashSet<RoleTile>();
            UserRoles = new HashSet<UserRole>();
        }

        public int RoleId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual ICollection<RoleMenuAccess> RoleMenuAccesses { get; set; }
        //public virtual ICollection<RoleTile> RoleTiles { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
