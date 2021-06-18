using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class SubjectCategory : BaseModel
    {
        public SubjectCategory()
        {
            Subjects = new HashSet<Subject>();
        }

        [Required]
        public string Code { get; set; }
        public string Description { get; set; }
        public bool IsBasket { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
    }
}
