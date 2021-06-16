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
    public class TeacherSubjectVM : TeacherSubject, IModel<TeacherSubject, TeacherSubjectVM>
    {

        public TeacherSubjectVM()
        {
            mappings = new ObjMappings<TeacherSubject, TeacherSubjectVM>();

            mappings.Add(x => x.Subject.Name, x => x.SubjectName);
            mappings.Add(x => $"Grade {x.Grade.GradeId}", x => x.GradeDesc);
        }
        public TeacherSubjectVM(TeacherSubject obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<TeacherSubject, TeacherSubjectVM> mappings { get;  set; }

        [DisplayName("Grade")]
        public string GradeDesc { get; set; }
        [DisplayName("Subject")]
        public string SubjectName { get; set; }
    }
}