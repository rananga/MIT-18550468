using StudentInformationSystem.Common;
using StudentInformationSystem.Data.Models;
using System.ComponentModel;
using System.Web;

namespace StudentInformationSystem.Areas.Student.Models
{
    public class StudentExtraActivityPositionVM : StudentExtraActivityPosition, IModel<StudentExtraActivityPosition, StudentExtraActivityPositionVM>
    {
        public StudentExtraActivityPositionVM()
        {
            mappings = new ObjMappings<StudentExtraActivityPosition, StudentExtraActivityPositionVM>();

            mappings.Add(x => x.Position.Name, x => x.PositionName);
        }

        public StudentExtraActivityPositionVM(StudentExtraActivityPosition obj) : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<StudentExtraActivityPosition, StudentExtraActivityPositionVM> mappings { get; set; }

        [DisplayName("Position Name")]
        public string PositionName { get; set; }
    }
}