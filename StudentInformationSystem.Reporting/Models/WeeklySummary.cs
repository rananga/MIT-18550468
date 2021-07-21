using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInformationSystem.Reporting.Models
{
    public class WeeklySummary
    {
        public DateTime Date { get; set; }
        public string Duration { get; set; }
        public string Subject { get; set; }
        public string Class { get; set; }
        public string Lesson { get; set; }
        public string StudentCount { get; set; }
        public string Teacher { get; set; }
    }
}
