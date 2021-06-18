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
    public class ClassSubjectVM : ClassSubject, IModel<ClassSubject, ClassSubjectVM>
    {
        public ClassSubjectVM()
        {
            mappings = new ObjMappings<ClassSubject, ClassSubjectVM>();
            mappings.Add(x => x.Subject.Code, x => x.SubjectName);
            mappings.Add(x => $"{x.StaffMember.Title} {x.StaffMember.FullName}", x => x.TeacherName);
        }

        public ClassSubjectVM(ClassSubject obj, params string[] properties) : this()
        {
            this.SetEntity(obj, properties);
        }
        public ObjMappings<ClassSubject, ClassSubjectVM> mappings { get; set; }

        public string ClassName { get; set; }
        public string SubjectName { get; set; }
        public string TeacherName { get; set; }
    }
}