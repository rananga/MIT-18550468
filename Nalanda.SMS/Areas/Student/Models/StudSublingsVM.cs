using Nalanda.SMS.Data;
using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Nalanda.SMS.Areas.Student.Models
{
    public class StudSiblingsVM : IModel<StudSibling, StudSiblingsVM>
    {
        public StudSiblingsVM()
        {
            mappings = new ObjMappings<StudSibling, StudSiblingsVM>();

            mappings.Add(x => x.StudentRelation.Title +". "+ x.StudentRelation.Initials +" "+ x.StudentRelation.Lname, x => x.StudWithInit);
            mappings.Add(x => x.StudentRelation.IndexNo, x => x.IndexNo);
        }

        public StudSiblingsVM(StudSibling obj) : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<StudSibling, StudSiblingsVM> mappings { get; set; }

        public int SubID { get; set; }
        [DisplayName("Student")]
        public int SudID { get; set; }
        [DisplayName("Sibling Student"), Required]
        public int SiblingStudID { get; set; }
        [Required]
        public SibRelationship Relationship { get; set; }
        [DisplayName("Name with initials")]
        public string StudWithInit { get; set; }
        [DisplayName("Admission No")]
        public int IndexNo { get; set; }
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        public string Initials { get; set; }
        [DisplayName("Last Name")]
        public string LName { get; set; }

        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual Nalanda.SMS.Data.Models.Student Student { get; set; }
        public virtual Nalanda.SMS.Data.Models.Student StudentRelation { get; set; }

    }
}