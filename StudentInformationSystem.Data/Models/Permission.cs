using System;
using System.Collections.Generic;

namespace StudentInformationSystem.Data.Models
{
    public partial class Permission
    {
        public Permission()
        {
            PermissionMenuAccesses = new HashSet<PermissionMenuAccess>();
            PermissionGradeAccesses = new HashSet<PermissionGradeAccess>();
            UserPermissions = new HashSet<UserPermission>();
        }

        public int PermissionId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual ICollection<PermissionMenuAccess> PermissionMenuAccesses { get; set; }
        public virtual ICollection<PermissionGradeAccess> PermissionGradeAccesses { get; set; }
        public virtual ICollection<UserPermission> UserPermissions { get; set; }
    }
}
