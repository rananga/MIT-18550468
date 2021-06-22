using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class OC_Meeting : BaseModel
    {
        public OC_Meeting()
        {
            OC_MeetingAttendees = new HashSet<OC_MeetingAttendee>();
        }

        [DisplayName("Online Class"), Required]
        public int OC_Id { get; set; }
        [DisplayName("Meeting Code"), Required]
        public string MeetingCode { get; set; }

        public virtual OnlineClass OnlineClass { get; set; }

        public virtual ICollection<OC_MeetingAttendee> OC_MeetingAttendees { get; set; }
    }
}
