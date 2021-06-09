using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nalanda.SMS.Data.Models
{
    public partial class User : BaseModel
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        [DisplayName("User Name")]
        public virtual string UserName { get; set; }
        [PasswordPropertyText(true)]
        public string Password { get; set; }
        public ActiveState Status { get; set; }
        [DisplayName("Staff Member")]
        public int? StaffId { get; set; }

        public virtual StaffMember StaffMember { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
