using System;
using System.Collections.Generic;

namespace StudentInformationSystem.Data.Models
{
    public partial class PermissionGradeAccess
    {
        public int GradeId { get; set; }
        public int PermissionId { get; set; }

        public virtual Grade Grade { get; set; }
        public virtual Permission Permission { get; set; }
    }
}
