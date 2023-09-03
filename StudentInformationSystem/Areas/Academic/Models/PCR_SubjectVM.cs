using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace StudentInformationSystem.Areas.Academic.Models
{
    public class PCR_SubjectVM : PCR_Subject, IModel<PCR_Subject, PCR_SubjectVM>
    {
        public PCR_SubjectVM()
        {
            mappings = new ObjMappings<PCR_Subject, PCR_SubjectVM>();
            mappings.Add(x => x.Subject.Code, x => x.SubjectName);
            mappings.Add(x => x.StaffMember == null ? "" : $"{x.StaffMember.Title} {x.StaffMember.FullName}", x => x.TeacherName);
        }

        public PCR_SubjectVM(PCR_Subject obj, params string[] properties) : this()
        {
            this.SetEntity(obj, properties);
        }
        public ObjMappings<PCR_Subject, PCR_SubjectVM> mappings { get; set; }

        [DisplayName("Subject")]
        public string SubjectName { get; set; }
        [DisplayName("Teacher")]
        public string TeacherName { get; set; }
    }
}