using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class User : BaseModel
    {
        public User()
        {
            UserRoles = new HashSet<UserRole>();
        }

        [Required]
        [DisplayName("User Name")]
        public virtual string UserName { get; set; }
        [PasswordPropertyText(true)]
        public string Password { get; set; }
        public ActiveState Status { get; set; }
        [DisplayName("Staff Member")]
        public int? StaffId { get; set; }
        [DisplayName("Visitor")]
        public int? VisitorId { get; set; }
        [DisplayName("Parent")]
        public int? ParentId { get; set; }
        [DisplayName("Student")]
        public int? StudentId { get; set; }
        public bool? MustResetPassword { get; set; }

        public virtual StaffMember StaffMember { get; set; }
        public virtual Visitor Visitor { get; set; }
        public virtual Parent Parent { get; set; }
        public virtual Student Student { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
