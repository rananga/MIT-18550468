using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentInformationSystem.Areas.Admin.Models
{
    public class RoleVM : Role, IModel<Role, RoleVM>
    {
        public RoleVM()
        {
            MenusList = new List<Menu>();
            mappings = new ObjMappings<Role, RoleVM>
            {
                { x => x.RoleMenuAccesses.Select(y => y.Menu).ToList(), x => x.MenusList },
                { x => x.RoleMenuAccesses.Select(y => new MenusJsonItem { MenuId = y.MenuId, ActionId = y.ActionId }).SerializeToJson(), x => x.MenusJson },
                { x => x.RoleGradeAccesses.Select(y => y.GradeId).SerializeToJson(), x => x.GradesJson }
            };
        }
        public RoleVM(Role obj)
            : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<Role, RoleVM> mappings { get; set; }

        public List<Menu> MenusList { get; set; }
        public string MenusJson { get; set; }
        public string GradesJson { get; set; }
    }

    public class MenusJsonItem
    {
        public int MenuId { get; set;}
        public int ActionId { get; set;}
    }
}
