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
            DetailsList = new List<UserRoleVM>();
            mappings = new ObjMappings<User, UserVM>();
            mappings.Add(x => $"{x.StaffMember.Title.ToEnumChar("")}. {x.StaffMember.Initials.Trim()} {x.StaffMember.LastName}", x => x.SatffName);
            mappings.Add(x => x.UserRoles.Select(y => new UserRoleVM(y)).ToList(), x => x.DetailsList);
        }
        public UserVM(User obj)
            : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<User, UserVM> mappings { get; set; }


        [DisplayName("Staff Member")]
        public string SatffName { get; set; }

        public virtual ICollection<UserRoleVM> DetailsList { get; set; }
    }
}
