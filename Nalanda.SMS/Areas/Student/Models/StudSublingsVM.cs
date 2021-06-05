using Nalanda.SMS.Data;
using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Nalanda.SMS.Areas.Student.Models
{
    public class StudSiblingsVM : StudSibling, IModel<StudSibling, StudSiblingsVM>
    {
        public StudSiblingsVM()
        {
            mappings = new ObjMappings<StudSibling, StudSiblingsVM>();

            mappings.Add(x => x.SiblingStudent.Title +". "+ x.SiblingStudent.Initials +" "+ x.SiblingStudent.Lname, x => x.StudWithInit);
            mappings.Add(x => x.SiblingStudent.IndexNo, x => x.IndexNo);
        }

        public StudSiblingsVM(StudSibling obj) : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<StudSibling, StudSiblingsVM> mappings { get; set; }

        [DisplayName("Name with initials")]
        public string StudWithInit { get; set; }
        [DisplayName("Admission No")]
        public int IndexNo { get; set; }
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        public string Initials { get; set; }
        [DisplayName("Last Name")]
        public string LName { get; set; }
    }
}