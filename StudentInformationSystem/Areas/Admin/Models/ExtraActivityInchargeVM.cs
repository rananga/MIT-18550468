using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace StudentInformationSystem.Areas.Admin.Models
{
    public class ExtraActivityInchargeVM : ExtraActivityIncharge, IModel<ExtraActivityIncharge, ExtraActivityInchargeVM>
    {
        public ExtraActivityInchargeVM()
        {
            mappings = new ObjMappings<ExtraActivityIncharge, ExtraActivityInchargeVM>();

            mappings.Add(x => $"{x.StaffMember.Title.ToEnumChar(null)} {x.StaffMember.Initials} {x.StaffMember.LastName}", x => x.MasterName);
        }
        public ExtraActivityInchargeVM(ExtraActivityIncharge obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<ExtraActivityIncharge, ExtraActivityInchargeVM> mappings { get;  set; }

        [DisplayName("Master In Charge")]
        public string MasterName { get; set; }
    }
}