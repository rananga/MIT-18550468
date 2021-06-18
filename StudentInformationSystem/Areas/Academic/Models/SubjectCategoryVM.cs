using StudentInformationSystem.Common;
using StudentInformationSystem.Data.Models;
using System.Web;

namespace StudentInformationSystem.Areas.Academic.Models
{
    public class SubjectCategoryVM : SubjectCategory, IModel<SubjectCategory, SubjectCategoryVM>
    {
        public SubjectCategoryVM()
        {
            mappings = new ObjMappings<SubjectCategory, SubjectCategoryVM>();
        }
        public SubjectCategoryVM(SubjectCategory obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<SubjectCategory, SubjectCategoryVM> mappings { get;  set; }
    }
}