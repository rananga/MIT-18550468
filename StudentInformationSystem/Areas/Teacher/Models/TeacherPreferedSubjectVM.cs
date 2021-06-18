using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace StudentInformationSystem.Areas.Teacher.Models
{
    public class TeacherPreferedSubjectVM : TeacherPreferedSubject, IModel<TeacherPreferedSubject, TeacherPreferedSubjectVM>
    {

        public TeacherPreferedSubjectVM()
        {
            mappings = new ObjMappings<TeacherPreferedSubject, TeacherPreferedSubjectVM>();

            mappings.Add(x => x.Subject.Code, x => x.SubjectName);
            mappings.Add(x => x.Subject.Section.Code, x => x.SectionName);
            mappings.Add(x => x.Subject.Medium.ToEnumChar(null), x => x.SubjectMedium);
        }
        public TeacherPreferedSubjectVM(TeacherPreferedSubject obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<TeacherPreferedSubject, TeacherPreferedSubjectVM> mappings { get;  set; }

        [DisplayName("Subject")]
        public string SubjectName { get; set; }
        [DisplayName("Section")]
        public string SectionName { get; set; }
        [DisplayName("Medium")]
        public string SubjectMedium { get; set; }
    }
}