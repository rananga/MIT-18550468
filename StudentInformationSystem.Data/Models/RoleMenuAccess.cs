using System;
using System.Collections.Generic;

namespace StudentInformationSystem.Data.Models
{
    public partial class RoleMenuAccess
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int MenuId { get; set; }
        public int ActionId { get; set; }

        public virtual Role Role { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual MenuAction MenuAction { get; set; }
    }
}
