using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Common;
using System;
using System.ComponentModel;
using System.Web;

namespace Nalanda.SMS.Areas.Admin.Models
{
    public class UserRoleVM : UserRole, IModel<UserRole, UserRoleVM>
    {
        public UserRoleVM()
        {
            mappings = new ObjMappings<UserRole, UserRoleVM>();
            mappings.Add(x => x.Role == null ? "-" : x.Role.Name, x => x.RoleName);
        }
        public UserRoleVM(UserRole obj)
            : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<UserRole, UserRoleVM> mappings { get; set; }

        [DisplayName("Role")]
        public string RoleName { get; set; }
    }
}
