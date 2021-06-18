using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace StudentInformationSystem.Areas.Student.Models
{
    public class StudSiblingsVM : StudentSibling, IModel<StudentSibling, StudSiblingsVM>
    {
        public StudSiblingsVM()
        {
            mappings = new ObjMappings<StudentSibling, StudSiblingsVM>();

            mappings.Add(x => x.SiblingStudent.Initials + " " + x.SiblingStudent.LastName, x => x.StudWithInit);
            mappings.Add(x => x.SiblingStudent.IndexNo, x => x.IndexNo);
        }

        public StudSiblingsVM(StudentSibling obj) : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<StudentSibling, StudSiblingsVM> mappings { get; set; }

        [DisplayName("Name with initials")]
        public string StudWithInit { get; set; }
        [DisplayName("Admission No")]
        public int IndexNo { get; set; }
    }
}