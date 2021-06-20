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
    public class CR_SubjectVM : CR_Subject, IModel<CR_Subject, CR_SubjectVM>
    {
        public CR_SubjectVM()
        {
            mappings = new ObjMappings<CR_Subject, CR_SubjectVM>();
            mappings.Add(x => x.Subject.Code, x => x.SubjectName);
            mappings.Add(x => $"{x.StaffMember.Title} {x.StaffMember.FullName}", x => x.TeacherName);
        }

        public CR_SubjectVM(CR_Subject obj, params string[] properties) : this()
        {
            this.SetEntity(obj, properties);
        }
        public ObjMappings<CR_Subject, CR_SubjectVM> mappings { get; set; }

        [DisplayName("Subject")]
        public string SubjectName { get; set; }
        [DisplayName("Teacher")]
        public string TeacherName { get; set; }
    }
}