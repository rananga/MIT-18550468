using System;

namespace StudentInformationSystem.Data.Models
{
    public partial class SyncLog
    {
        public long Id { get; set; }
        public DateTime LogDate { get; set; }
        public int Sevierity { get; set; }
        public string Message { get; set; }
    }
}
