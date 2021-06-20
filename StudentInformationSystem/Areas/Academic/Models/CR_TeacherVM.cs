using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Linq;

namespace StudentInformationSystem.Areas.Academic.Models
{
    public class CR_TeacherVM : CR_Teacher, IModel<CR_Teacher, CR_TeacherVM>
    {
        public CR_TeacherVM()
        {
            mappings = new ObjMappings<CR_Teacher, CR_TeacherVM>();

            mappings.Add(x => $"{x.StaffMember.Title.ToEnumChar(null)} {x.StaffMember.FullName}", x => x.TeacherName);
        }

        public CR_TeacherVM(CR_Teacher obj, params string[] properties) : this()
        {
            this.SetEntity(obj, properties);
        }
        public ObjMappings<CR_Teacher, CR_TeacherVM> mappings { get; set; }

        [DisplayName("Teacher Name")]
        public string TeacherName { get; set; }
    }
}