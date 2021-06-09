using Nalanda.SMS.Data;
using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Linq;

namespace Nalanda.SMS.Areas.Admin.Models
{
    public class StaffMemberVM : StaffMember, IModel<StaffMember, StaffMemberVM>
    {

        public StaffMemberVM()
        {
            mappings = new ObjMappings<StaffMember, StaffMemberVM>();

            mappings.Add(x => x.Title + ". " + x.FullName, x => x.MemberName);
        }
        public StaffMemberVM(StaffMember obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<StaffMember, StaffMemberVM> mappings { get;  set; }

        [DisplayName("Teacher Name")]
        public string MemberName { get; set; }
        public HttpPostedFileBase ProfilePic { get; set; }
    }
}