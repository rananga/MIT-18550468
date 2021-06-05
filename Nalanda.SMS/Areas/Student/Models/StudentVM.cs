using Nalanda.SMS.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Nalanda.SMS.Areas.Student.Models
{
    public class StudentVM : Data.Models.Student, IModel<Data.Models.Student, StudentVM>
    {
        public StudentVM()
        {
            Siblings = new List<StudSiblingsVM>();
            FamilyMembers = new List<StudFamilyVM>();
            mappings = new ObjMappings<Nalanda.SMS.Data.Models.Student, StudentVM>();

            mappings.Add(x => x.Title + ". " + x.Initials + " " + x.Lname, x => x.NameWithInt);
            mappings.Add(x => x.StudSiblings.Select(y => new StudSiblingsVM(y)).ToList(), x => x.Siblings);
            mappings.Add(x => x.StudFamilies.Select(y => new StudFamilyVM(y)).ToList(), x => x.FamilyMembers);
        }

        public StudentVM(Nalanda.SMS.Data.Models.Student obj) :this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<Nalanda.SMS.Data.Models.Student, StudentVM> mappings { get; set; }

        [DisplayName("Student name")]
        public string NameWithInt { get; set; }

        public HttpPostedFileBase ProfilePic { get; set; }
        public virtual ICollection<StudSiblingsVM> Siblings { get; set; }
        public virtual ICollection<StudFamilyVM> FamilyMembers { get; set; }
    }
}