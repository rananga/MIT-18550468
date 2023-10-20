using StudentInformationSystem.Common;
using StudentInformationSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            mappings.Add(x => x.StaffMember == null ? "" : $"{x.StaffMember.Title.ToEnumChar("")}. {x.StaffMember.Initials.Trim()} {x.StaffMember.LastName}", x => x.StaffName);
            mappings.Add(x => x.Parent == null ? "" : $"{x.Parent.Title.ToEnumChar("")}. {x.Parent.FullName.Trim()}", x => x.ParentName);
            mappings.Add(x => x.Visitor == null ? "" : $"{x.Visitor.Title.ToEnumChar("")}. {x.Visitor.Initials.Trim()} {x.Visitor.LastName}", x => x.VisitorName);
            mappings.Add(x => x.UserRoles.Select(y => new UserRoleVM(y)).ToList(), x => x.DetailsList);
        }
        public UserVM(User obj)
            : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<User, UserVM> mappings { get; set; }


        [DisplayName("Staff Member")]
        public string StaffName { get; set; }

        [DisplayName("Parent")]
        public string ParentName { get; set; }

        [DisplayName("Visitor")]
        public string VisitorName { get; set; }

        public virtual ICollection<UserRoleVM> DetailsList { get; set; }
    }
}
