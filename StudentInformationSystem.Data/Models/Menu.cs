using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StudentInformationSystem.Data.Models
{
    public partial class Menu
    {
        public Menu()
        {
            InverseParentMenu = new HashSet<Menu>();
            RoleMenuAccesses = new HashSet<RoleMenuAccess>();
        }

        public int MenuId { get; set; }
        public int? ParentMenuId { get; set; }
        public int DisplaySeq { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
        public string Area { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Icon { get; set; }
        public bool IsHidden { get; set; }

        public virtual Menu ParentMenu { get; set; }
        public virtual ICollection<Menu> InverseParentMenu { get; set; }
        public virtual ICollection<RoleMenuAccess> RoleMenuAccesses { get; set; }
    }
}
