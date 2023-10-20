using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInformationSystem.Data.Models
{
    public partial class MenuAction
    {
        public int MenuId { get; set; }
        public int ActionId { get; set; }
        public string Text { get; set; }

        public virtual Menu Menu { get; set; }
        public virtual ICollection<RoleMenuAccess> RoleMenuAccesses { get; set; }
    }
}
