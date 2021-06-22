using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class OC_MeetingAttendee : BaseModel
    {
        [DisplayName("Online Class Meeting"), Required]
        public int OC_MeetingId { get; set; }
        [DisplayName("Student"), Required]
        public int StudentId { get; set; }
        [Required]
        public long Duration { get; set; }
        [DisplayName("Time Visited")]
        public int TimesVisited { get; set; }

        public virtual OC_Meeting OC_Meeting { get; set; }
    }
}
