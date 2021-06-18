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
    public class ClassTeacherVM : ClassTeacher, IModel<ClassTeacher, ClassTeacherVM>
    {
        public ClassTeacherVM()
        {
            mappings = new ObjMappings<ClassTeacher, ClassTeacherVM>();

            mappings.Add(x => $"{x.StaffMember.Title.ToEnumChar(null)} {x.StaffMember.FullName}", x => x.TeacherName);
        }

        public ClassTeacherVM(ClassTeacher obj, params string[] properties) : this()
        {
            this.SetEntity(obj, properties);
        }
        public ObjMappings<ClassTeacher, ClassTeacherVM> mappings { get; set; }

        public string TeacherName { get; set; }
    }
}