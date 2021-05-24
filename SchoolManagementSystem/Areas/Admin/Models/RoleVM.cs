using SMS.Common;
using SMS.Common.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;

namespace SMS.Areas.Admin.Models
{
    public class RoleVM : IModel<Role, RoleVM>
    {
        public RoleVM()
        {
            MenusList = new List<Menu>();
            mappings = new ObjMappings<Role, RoleVM>();
            mappings.Add(x => x.Menus.ToList(), x => x.MenusList);
            mappings.Add(x => x.Menus.Select(y => y.MenuID).SerializeToJson(), x => x.MenusJson);
        }
        public RoleVM(Role obj)
            : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<Role, RoleVM> mappings { get; set; }

        public int RoleID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }

        public List<Menu> MenusList { get; set; }
        public string MenusJson { get; set; }
    }
}
