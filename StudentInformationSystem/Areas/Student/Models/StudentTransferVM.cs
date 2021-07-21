using StudentInformationSystem.Common;
using StudentInformationSystem.Data.Models;
using System.ComponentModel;
using System.Web;

namespace StudentInformationSystem.Areas.Student.Models
{
    public class StudentTransferVM : StudentTransfer, IModel<StudentTransfer, StudentTransferVM>
    {
        public StudentTransferVM()
        {
            mappings = new ObjMappings<StudentTransfer, StudentTransferVM>();
            mappings.Add(x => x.Student.IndexNo, x => x.IndexNo);
            mappings.Add(x => x.Student.FullName, x => x.StudentName);
            mappings.Add(x => x.FromClass.GradeClass.Code, x => x.FromClassName);
            mappings.Add(x => x.ToClass.GradeClass.Code, x => x.ToClassName);
        }

        public StudentTransferVM(StudentTransfer obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<StudentTransfer, StudentTransferVM> mappings { get; set; }

        [DisplayName("Admission No")]
        public int IndexNo { get; set; }
        [DisplayName("Student")]
        public string StudentName { get; set; }
        [DisplayName("From Class")]
        public string FromClassName { get; set; }
        [DisplayName("To Class")]
        public string ToClassName { get; set; }
    }
}