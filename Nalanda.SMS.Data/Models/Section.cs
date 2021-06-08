using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nalanda.SMS.Data.Models
{
    public partial class Section : BaseModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayName("Section Head")]
        public int? HeadId { get; set; }

        public virtual StaffMember SectionHead { get; set; }
    }
}
