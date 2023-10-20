using StudentInformationSystem.Common;
using StudentInformationSystem.Data.Models;
using System.ComponentModel;
using System.Web;

namespace StudentInformationSystem.Areas.Admin.Models
{
    public class ParentVM : Parent, IModel<Parent, ParentVM>
    {
        public ParentVM()
        {
            mappings = new ObjMappings<Parent, ParentVM>
            {
                { x => x.Title + ". " + x.FullName, x => x.ParentName }
            };
        }
        public ParentVM(Parent obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<Parent, ParentVM> mappings { get;  set; }

        [DisplayName("Parent Name")]
        public string ParentName { get; set; }
        public HttpPostedFileBase ProfilePic { get; set; }
    }
}