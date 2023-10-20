using StudentInformationSystem.Common;
using StudentInformationSystem.Data.Models;
using System.Web;

namespace StudentInformationSystem.Areas.Admin.Models
{
    public class NearbySchoolVM : NearbySchool, IModel<NearbySchool, NearbySchoolVM>
    {
        public NearbySchoolVM()
        {
            mappings = new ObjMappings<NearbySchool, NearbySchoolVM>();
        }
        public NearbySchoolVM(NearbySchool obj)
            : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<NearbySchool, NearbySchoolVM> mappings { get; set; }
    }
}
