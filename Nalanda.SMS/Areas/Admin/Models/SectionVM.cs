using Nalanda.SMS.Common;
using Nalanda.SMS.Data.Models;
using System.Web;

namespace Nalanda.SMS.Areas.Admin.Models
{
    public class SectionVM : Section, IModel<Section, SectionVM>
    {
        public SectionVM()
        {
            mappings = new ObjMappings<Section, SectionVM>();

            mappings.Add(x => x.Name + x.Description, x => SearchBy);
        }

        public SectionVM(Section obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<Section, SectionVM> mappings { get; set; }

        public string SearchBy { get; set; }
    }
}