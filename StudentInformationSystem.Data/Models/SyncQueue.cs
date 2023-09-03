using System;

namespace StudentInformationSystem.Data.Models
{
    public partial class SyncQueue
    {
        public long Id { get; set; }
        public DateTime QueuedDate { get; set; }
        public SyncType SyncType { get; set; }
        public string JsonData { get; set; }
    }
}
