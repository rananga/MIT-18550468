using StudentInformationSystem.Common;
using StudentInformationSystem.Data.Models;
using System;
using System.ComponentModel;
using System.Web;

namespace StudentInformationSystem.Areas.Student.Models
{
    public class StudentBasketSubjectVM : StudentBasketSubject, IModel<StudentBasketSubject, StudentBasketSubjectVM>
    {
        public StudentBasketSubjectVM()
        {
            mappings = new ObjMappings<StudentBasketSubject, StudentBasketSubjectVM>();
            mappings.Add(x => x.Subject.Code, x => x.SubjectName);
        }

        public StudentBasketSubjectVM(StudentBasketSubject obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<StudentBasketSubject, StudentBasketSubjectVM> mappings { get; set; }

        [DisplayName("Subject")]
        public string SubjectName { get; set; }
    }
}