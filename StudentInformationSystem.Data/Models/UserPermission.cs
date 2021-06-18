using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace StudentInformationSystem.Data.Models
{
    public partial class UserPermission
    {
        public int UserPermissionId { get; set; }
        public int UserId { get; set; }
        [DisplayName("Permission")]
        public int PermissionId { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual User User { get; set; }
    }
}
