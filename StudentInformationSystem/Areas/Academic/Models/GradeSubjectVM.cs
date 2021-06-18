using StudentInformationSystem.Common;
using StudentInformationSystem.Data.Models;
using System;
using System.ComponentModel;
using System.Web;

namespace StudentInformationSystem.Areas.Academic.Models
{
    public class GradeSubjectVM : GradeSubject, IModel<GradeSubject, GradeSubjectVM>
    {
        public GradeSubjectVM()
        {
            mappings = new ObjMappings<GradeSubject, GradeSubjectVM>();
            mappings.Add(x => x.Grade.GradeNo.ToEnumChar(null), x => x.GradeName);
            mappings.Add(x => x.Subject.Code, x => x.SubjectName);
        }

        public GradeSubjectVM(GradeSubject obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<GradeSubject, GradeSubjectVM> mappings { get; set; }

        [DisplayName("Grade")]
        public string GradeName { get; set; }
        [DisplayName("Subject")]
        public string SubjectName { get; set; }
    }
}