using System;
using System.Collections.Generic;

namespace StudentInformationSystem.Data.Models
{
    public partial class PermissionMenuAccess
    {
        public int MenuId { get; set; }
        public int PermissionId { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
