using StudentInformationSystem.Common;
using StudentInformationSystem.Data.Models;
using System.Web;

namespace StudentInformationSystem.Areas.Admin.Models
{
    public class SubjectVM : Subject, IModel<Subject, SubjectVM>
    {
        public SubjectVM()
        {
            mappings = new ObjMappings<Subject, SubjectVM>();
        }

        public SubjectVM(Subject obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<Subject, SubjectVM> mappings { get; set; }
    }
}