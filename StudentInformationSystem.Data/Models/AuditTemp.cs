using System;

namespace StudentInformationSystem.Data.Models
{
    public partial class AuditTemp
    {
        public DateTime MeetingDate { get; set; }
        public string CustomerId { get; set; }
        public string ParticipantEmail { get; set; }
        public long UniqueQualifier { get; set; }
        public string MeetingCode { get; set; }
        public string OrganizerEmail { get; set; }
        public long? Duration { get; set; }
        public string CalendarEventId { get; set; }
        public string ConferenceId { get; set; }
        public bool IsOutSide { get; set; }
    }
}
