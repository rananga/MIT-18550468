using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nalanda.SMS.Data.Models
{
    public partial class ExtraActivityAcheivement : BaseModel
    {
        public int ActivityId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ExtraActivity Activity { get; set; }
        public virtual ICollection<StudentExtraActivityAcheivement> Students { get; set; }
    }
}
