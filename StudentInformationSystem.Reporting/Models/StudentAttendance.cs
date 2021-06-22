using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInformationSystem.Reporting.Models
{
    public class StudentAttendance
    {
        public int OC_Id { get; set; }
        public DateTime MeetingDate { get; set; }
        public int AdmissionNo { get; set; }
        public string StudentClass { get; set; }
        public string StudentName { get; set; }
        public string Duration { get; set; }
        public string Subject { get; set; }
    }
}
