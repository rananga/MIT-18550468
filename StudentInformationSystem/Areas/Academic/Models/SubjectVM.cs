using StudentInformationSystem.Common;
using StudentInformationSystem.Data.Models;
using System.Web;

namespace StudentInformationSystem.Areas.Academic.Models
{
    public class SubjectVM : Subject, IModel<Subject, SubjectVM>
    {
        public SubjectVM()
        {
            mappings = new ObjMappings<Subject, SubjectVM>();

            mappings.Add(x => x.SubjectCategory.Code, x => x.CategoryName);
            mappings.Add(x => x.Section.Code, x => x.SectionName);
        }

        public SubjectVM(Subject obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<Subject, SubjectVM> mappings { get; set; }

        public string CategoryName { get; set; }
        public string SectionName { get; set; }
    }
}