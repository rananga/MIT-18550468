using Nalanda.SMS.Common;
using Nalanda.SMS.Data.Models;
using System.Web;

namespace Nalanda.SMS.Areas.Admin.Models
{
    public class GradeVM : Grade, IModel<Grade, GradeVM>
    {
        public GradeVM()
        {
            mappings = new ObjMappings<Grade, GradeVM>();
            mappings.Add(x => $"Grade {x.GradeId}", x => x.GradeName);
            mappings.Add(x => x.Section.Name, x => x.SectionName);
        }

        public GradeVM(Grade obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<Grade, GradeVM> mappings { get; set; }

        public string GradeName { get; set; }
        public string SectionName { get; set; }
    }
}