using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentInformationSystem.Areas.Admin.Models
{
    public class UserVM : User, IModel<User, UserVM>
    {
        public UserVM()
        {
            DetailsList = new List<UserPermissionVM>();
            mappings = new ObjMappings<User, UserVM>();
            mappings.Add(x => x.StaffMember == null ? "" : $"{x.StaffMember.Title.ToEnumChar("")}. {x.StaffMember.Initials.Trim()} {x.StaffMember.LastName}", x => x.SatffName);
            mappings.Add(x => x.UserPermissions.Select(y => new UserPermissionVM(y)).ToList(), x => x.DetailsList);
        }
        public UserVM(User obj)
            : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<User, UserVM> mappings { get; set; }


        [DisplayName("Staff Member")]
        public string SatffName { get; set; }

        public virtual ICollection<UserPermissionVM> DetailsList { get; set; }
    }
}
