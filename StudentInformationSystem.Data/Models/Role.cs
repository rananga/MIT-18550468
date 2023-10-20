using System;
using System.Collections.Generic;

namespace StudentInformationSystem.Data.Models
{
    public partial class Role
    {
        public Role()
        {
            RoleMenuAccesses = new HashSet<RoleMenuAccess>();
            RoleGradeAccesses = new HashSet<RoleGradeAccess>();
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
        public virtual ICollection<RoleGradeAccess> RoleGradeAccesses { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
