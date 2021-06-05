using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nalanda.SMS.Data.Models
{
    public partial class Subject : BaseModel
    {
        public Subject()
        {
            StudentSubjects = new HashSet<ClassStudentSubject>();
            TeacherSubjects = new HashSet<TeacherSubject>();
        }

        [DisplayName("Subject"), Required]
        public string Name { get; set; }
        [DisplayName("Is Basket Subject")]
        public bool IsBasket { get; set; }

        public virtual ICollection<ClassStudentSubject> StudentSubjects { get; set; }
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}
