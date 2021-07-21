using StudentInformationSystem.Common;
using StudentInformationSystem.Data.Models;
using System;
using System.ComponentModel;
using System.Web;

namespace StudentInformationSystem.Areas.Academic.Models
{
    public class GradeClassSubjectVM : GradeClassSubject, IModel<GradeClassSubject, GradeClassSubjectVM>
    {
        public GradeClassSubjectVM()
        {
            mappings = new ObjMappings<GradeClassSubject, GradeClassSubjectVM>();

            mappings.Add(x => x.Subject.Code, x => x.SubjectName);
            mappings.Add(x => x.Subject.SectionId, x => x.SectionId);
            mappings.Add(x => x.Subject.Section.Code, x => x.SectionName);
            mappings.Add(x => x.Subject.Medium.ToEnumChar(null), x => x.SubjectMedium);
        }

        public GradeClassSubjectVM(GradeClassSubject obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<GradeClassSubject, GradeClassSubjectVM> mappings { get; set; }

        public int SectionId { get; set; }
        [DisplayName("Subject")]
        public string SubjectName { get; set; }
        [DisplayName("Section")]
        public string SectionName { get; set; }
        [DisplayName("Medium")]
        public string SubjectMedium { get; set; }
    }
}