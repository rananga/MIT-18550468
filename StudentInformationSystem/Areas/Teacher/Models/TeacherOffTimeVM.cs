using StudentInformationSystem.Common;
using StudentInformationSystem.Data.Models;
using System.Web;

namespace StudentInformationSystem.Areas.Teacher.Models
{
    public class TeacherOffTimeVM : TeacherOffTime, IModel<TeacherOffTime, TeacherOffTimeVM>
    {

        public TeacherOffTimeVM()
        {
            mappings = new ObjMappings<TeacherOffTime, TeacherOffTimeVM>();
        }
        public TeacherOffTimeVM(TeacherOffTime obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<TeacherOffTime, TeacherOffTimeVM> mappings { get;  set; }
    }
}