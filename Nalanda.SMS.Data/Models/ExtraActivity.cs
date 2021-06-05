using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nalanda.SMS.Data.Models
{
    public partial class ExtraActivity : BaseModel
    {
        public ExtraActivity()
        {
            Acheivements = new HashSet<ExtraActivityAcheivement>();
            Positions = new HashSet<ExtraActivityPosition>();
        }

        [Required]
        public string Name { get; set; }
        [DisplayName("Status"), Required]
        public ActiveState Status { get; set; }

        public virtual ICollection<ExtraActivityAcheivement> Acheivements { get; set; }
        public virtual ICollection<ExtraActivityPosition> Positions { get; set; }
    }
}
