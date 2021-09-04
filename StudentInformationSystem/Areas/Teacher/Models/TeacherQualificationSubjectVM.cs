using StudentInformationSystem.Common;
using StudentInformationSystem.Data.Models;
using System;
using System.ComponentModel;
using System.Web;

namespace StudentInformationSystem.Areas.Teacher.Models
{
    public class TeacherQualificationSubjectVM : TeacherQualificationSubject, IModel<TeacherQualificationSubject, TeacherQualificationSubjectVM>
    {

        public TeacherQualificationSubjectVM()
        {
            mappings = new ObjMappings<TeacherQualificationSubject, TeacherQualificationSubjectVM>();

            mappings.Add(x => x.Subject.Code, x => x.SubjectName);
            mappings.Add(x => x.Subject.Section.Code, x => x.SectionName);
            mappings.Add(x => x.Subject.Medium.ToEnumChar(null), x => x.SubjectMedium);
        }
        public TeacherQualificationSubjectVM(TeacherQualificationSubject obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<TeacherQualificationSubject, TeacherQualificationSubjectVM> mappings { get;  set; }

        [DisplayName("Subject")]
        public string SubjectName { get; set; }
        [DisplayName("Section")]
        public string SectionName { get; set; }
        [DisplayName("Medium")]
        public string SubjectMedium { get; set; }
    }
}