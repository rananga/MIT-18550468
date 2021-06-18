using StudentInformationSystem.Common;
using StudentInformationSystem.Data.Models;
using System;
using System.ComponentModel;
using System.Web;

namespace StudentInformationSystem.Areas.Admin.Models
{
    public class GradeHeadVM : GradeHead, IModel<GradeHead, GradeHeadVM>
    {
        public GradeHeadVM()
        {
            mappings = new ObjMappings<GradeHead, GradeHeadVM>();

            mappings.Add(x => x.Grade.GradeNo.ToEnumChar(null), x => x.GradeName);
            mappings.Add(x => $"{x.StaffMember.Title.ToEnumChar(null)} {x.StaffMember.Initials} {x.StaffMember.LastName}", x => x.GradeHead);
        }

        public GradeHeadVM(GradeHead obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<GradeHead, GradeHeadVM> mappings { get; set; }

        [DisplayName("Grade")]
        public string GradeName { get; set; }
        [DisplayName("Grade Head")]
        public string GradeHead { get; set; }
    }
}