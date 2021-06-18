using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class Section : BaseModel
    {
        public Section()
        {
            Grades = new HashSet<Grade>();
            SectionHeads = new HashSet<SectionHead>();
            Teachers = new HashSet<Teacher>();
        }

        [Required]
        public string Code { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Grade> Grades { get; set; }
        public virtual ICollection<SectionHead> SectionHeads { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
}
