using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nalanda.SMS.Data.Models
{
    public partial class Section : BaseModel
    {
        public Section()
        {
            SectionHeads = new HashSet<SectionHead>();
            Grades = new HashSet<Grade>();
        }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<SectionHead> SectionHeads { get; set; }
        public virtual ICollection<Grade> Grades { get; set; }
    }
}
