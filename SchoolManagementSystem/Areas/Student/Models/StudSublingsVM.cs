using SMS.Common;
using SMS.Common.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMS.Areas.Student.Models
{
    public class StudSublingsVM : IModel<StudSubling, StudSublingsVM>
    {
        public StudSublingsVM()
        {
            mappings = new ObjMappings<StudSubling, StudSublingsVM>();

            mappings.Add(x => x.StudentRelation.Title +". "+ x.StudentRelation.Initials +" "+ x.StudentRelation.LName, x => x.StudWithInit);
            mappings.Add(x => x.StudentRelation.IndexNo, x => x.IndexNo);
        }

        public StudSublingsVM(StudSubling obj) : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<StudSubling, StudSublingsVM> mappings { get; set; }

        public int SubID { get; set; }
        [DisplayName("Student")]
        public int SudID { get; set; }
        [DisplayName("Sibling Student"), Required]
        public int SublingStudID { get; set; }
        [Required]
        public SMS.Common.SibRelationship Relationship { get; set; }
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

        public virtual Common.DB.Student Student { get; set; }
        public virtual Common.DB.Student StudentRelation { get; set; }

    }
}