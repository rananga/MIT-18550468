using System;
using System.Collections.Generic;

namespace StudentInformationSystem.Data.Models
{
    public partial class RoleGradeAccess
    {
        public int GradeId { get; set; }
        public int RoleId { get; set; }

        public virtual Grade Grade { get; set; }
        public virtual Role Role { get; set; }
    }
}
