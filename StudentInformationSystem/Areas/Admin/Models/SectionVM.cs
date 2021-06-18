using StudentInformationSystem.Common;
using StudentInformationSystem.Data.Models;
using System.Web;

namespace StudentInformationSystem.Areas.Admin.Models
{
    public class SectionVM : Section, IModel<Section, SectionVM>
    {
        public SectionVM()
        {
            mappings = new ObjMappings<Section, SectionVM>();

            mappings.Add(x => x.Code + x.Description, x => SearchBy);
        }

        public SectionVM(Section obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<Section, SectionVM> mappings { get; set; }

        public string SearchBy { get; set; }
    }
}