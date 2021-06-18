using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Linq;

namespace StudentInformationSystem.Areas.Admin.Models
{
    public class StaffMemberVM : StaffMember, IModel<StaffMember, StaffMemberVM>
    {
        public StaffMemberVM()
        {
            mappings = new ObjMappings<StaffMember, StaffMemberVM>();

            mappings.Add(x => x.Title + ". " + x.FullName, x => x.MemberName);
            mappings.Add(x => x.Teacher, x => x.Teacher);
            mappings.Add(x => x.Teacher != null, x => x.IsTeacher);
            mappings.Add(x => x.Teacher == null ? null : (int?)x.Teacher.SectionId, x => x.TeacherSectionId);
            mappings.Add(x => x.Teacher == null ? null : x.Teacher.Section.Code, x => x.TeacherSectionName);
        }
        public StaffMemberVM(StaffMember obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<StaffMember, StaffMemberVM> mappings { get;  set; }

        [DisplayName("Teacher Name")]
        public string MemberName { get; set; }
        public HttpPostedFileBase ProfilePic { get; set; }
        [DisplayName("Is Teacher")]
        public bool IsTeacher { get; set; }
        [DisplayName("Teacher Section")]
        public int? TeacherSectionId { get; set; }
        [DisplayName("Teacher Section")]
        public string TeacherSectionName { get; set; }
    }
}