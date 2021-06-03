using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nalanda.SMS.Areas.Admin.Models
{
    public class RoleVM : Role, IModel<Role, RoleVM>
    {
        public RoleVM()
        {
            MenusList = new List<Menu>();
            mappings = new ObjMappings<Role, RoleVM>();
            mappings.Add(x => x.RoleMenuAccesses.Select(y => y.Menu).ToList(), x => x.MenusList);
            mappings.Add(x => x.RoleMenuAccesses.Select(y => y.MenuId).SerializeToJson(), x => x.MenusJson);
        }
        public RoleVM(Role obj)
            : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<Role, RoleVM> mappings { get; set; }

        public List<Menu> MenusList { get; set; }
        public string MenusJson { get; set; }
    }
}
