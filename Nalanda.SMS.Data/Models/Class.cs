using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nalanda.SMS.Data.Models
{
    public partial class Class : BaseModel
    {
        public Class()
        {
            ClassTeachers = new HashSet<ClassTeacher>();
            ClassMonitors = new HashSet<ClassMonitor>();
        }

        [Required]
        public int Year { get; set; }
        [DisplayName("Grade Class"), Required]
        public int GradeClassId { get; set; }
        [Required]
        public Medium Medium { get; set; }

        public virtual GradeClass GradeClass { get; set; }
        public virtual ICollection<ClassTeacher> ClassTeachers { get; set; }
        public virtual ICollection<ClassMonitor> ClassMonitors { get; set; }
    }
}
