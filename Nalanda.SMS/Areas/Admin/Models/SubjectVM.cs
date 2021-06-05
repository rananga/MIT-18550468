using Nalanda.SMS.Common;
using Nalanda.SMS.Data.Models;
using System.Web;

namespace Nalanda.SMS.Areas.Admin.Models
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