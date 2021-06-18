using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Common;
using System;
using System.ComponentModel;
using System.Web;

namespace StudentInformationSystem.Areas.Admin.Models
{
    public class UserPermissionVM : UserPermission, IModel<UserPermission, UserPermissionVM>
    {
        public UserPermissionVM()
        {
            mappings = new ObjMappings<UserPermission, UserPermissionVM>();
            mappings.Add(x => x.Permission == null ? "-" : x.Permission.Name, x => x.PermissionName);
        }
        public UserPermissionVM(UserPermission obj)
            : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<UserPermission, UserPermissionVM> mappings { get; set; }

        [DisplayName("Permission")]
        public string PermissionName { get; set; }
    }
}
