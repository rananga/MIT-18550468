using Nalanda.SMS.Data;
using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nalanda.SMS.Areas.Admin.Models
{
    public class UserVM : User, IModel<User, UserVM>
    {
        public UserVM()
        {
            DetailsList = new List<UserRoleVM>();
            mappings = new ObjMappings<User, UserVM>();
            mappings.Add(x => x.UserRoles.Select(y => new UserRoleVM(y)).ToList(), x => x.DetailsList);
            mappings.Add(x => x.Password, x => x.Password.Encrypt());
            mappings.Add(x => x.Password.Decrypt(), x => x.Password);
            mappings.Add(x => x.Password.Decrypt(), x => x.Password);
        }
        public UserVM(User obj)
            : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<User, UserVM> mappings { get; set; }


        [DisplayName("Employee")]
        public string EmpDspStr { get; set; }
        [DisplayName("Call Center User Name")]
        public string CallCenterUserName { get; set; }

        [DisplayName("Branch")]
        public Nullable<int> BranchID { get; set; }
        [DisplayName("Department")]
        public Nullable<int> DepartmentID { get; set; }
        [DisplayName("Branch")]
        public string BranchDesc { get; set; }
        [DisplayName("Department")]
        public string DepartmentDesc { get; set; }
        public virtual ICollection<UserRoleVM> DetailsList { get; set; }
    }
}
