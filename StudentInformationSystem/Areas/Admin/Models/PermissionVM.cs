using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentInformationSystem.Areas.Admin.Models
{
    public class PermissionVM : Permission, IModel<Permission, PermissionVM>
    {
        public PermissionVM()
        {
            MenusList = new List<Menu>();
            mappings = new ObjMappings<Permission, PermissionVM>();
            mappings.Add(x => x.PermissionMenuAccesses.Select(y => y.Menu).ToList(), x => x.MenusList);
            mappings.Add(x => x.PermissionMenuAccesses.Select(y => y.MenuId).SerializeToJson(), x => x.MenusJson);
        }
        public PermissionVM(Permission obj)
            : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<Permission, PermissionVM> mappings { get; set; }

        public List<Menu> MenusList { get; set; }
        public string MenusJson { get; set; }
    }
}
