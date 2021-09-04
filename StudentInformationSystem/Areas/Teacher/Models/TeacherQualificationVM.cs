using StudentInformationSystem.Common;
using StudentInformationSystem.Data.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentInformationSystem.Areas.Teacher.Models
{
    public class TeacherQualificationVM : TeacherQualification, IModel<TeacherQualification, TeacherQualificationVM>
    {

        public TeacherQualificationVM()
        {
            mappings = new ObjMappings<TeacherQualification, TeacherQualificationVM>();
            QualificationSubjects = new HashSet<TeacherQualificationSubjectVM>();

            mappings.Add(x => x.TeacherQualificationSubjects.Select(y => new TeacherQualificationSubjectVM(y)).ToList(), x => x.QualificationSubjects);
        }
        public TeacherQualificationVM(TeacherQualification obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<TeacherQualification, TeacherQualificationVM> mappings { get;  set; }

        public virtual ICollection<TeacherQualificationSubjectVM> QualificationSubjects { get; set; }
    }
}