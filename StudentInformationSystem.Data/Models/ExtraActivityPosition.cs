using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class ExtraActivityPosition : BaseModel
    {
        public int ActivityId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int HierarchyOrder { get; set; }

        public virtual ExtraActivity Activity { get; set; }
        public virtual ICollection<StudentExtraActivityPosition> Students { get; set; }
    }
}
