using StudentInformationSystem.Common;
using StudentInformationSystem.Data.Models;
using System;
using System.ComponentModel;
using System.Web;

namespace StudentInformationSystem.Areas.Admin.Models
{
    public class SectionHeadVM : SectionHead, IModel<SectionHead, SectionHeadVM>
    {
        public SectionHeadVM()
        {
            mappings = new ObjMappings<SectionHead, SectionHeadVM>();

            mappings.Add(x => x.Section.Code, x => x.SectionName);
            mappings.Add(x => $"{x.StaffMember.Title.ToEnumChar(null)} {x.StaffMember.Initials} {x.StaffMember.LastName}", x => x.SectionHead);
        }

        public SectionHeadVM(SectionHead obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<SectionHead, SectionHeadVM> mappings { get; set; }

        [DisplayName("Section")]
        public string SectionName { get; set; }
        [DisplayName("Section Head")]
        public string SectionHead { get; set; }
    }
}