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
    public class PCR_TeacherVM : PCR_Teacher, IModel<PCR_Teacher, PCR_TeacherVM>
    {
        public PCR_TeacherVM()
        {
            mappings = new ObjMappings<PCR_Teacher, PCR_TeacherVM>();

            mappings.Add(x => $"{x.StaffMember.Title.ToEnumChar(null)} {x.StaffMember.FullName}", x => x.TeacherName);
        }

        public PCR_TeacherVM(PCR_Teacher obj, params string[] properties) : this()
        {
            this.SetEntity(obj, properties);
        }
        public ObjMappings<PCR_Teacher, PCR_TeacherVM> mappings { get; set; }

        [DisplayName("Teacher Name")]
        public string TeacherName { get; set; }
    }
}