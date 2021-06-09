using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nalanda.SMS.Data.Models
{
    public partial class GradeClass : BaseModel
    {
        public GradeClass()
        {
            Classes = new HashSet<Class>();
        }

        [DisplayName("Grade")]
        [Required]
        public int GradeId { get; set; }
        [Required]
        public Classes Name { get; set; }
        public string Description { get; set; }

        public virtual Grade Grade { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}
