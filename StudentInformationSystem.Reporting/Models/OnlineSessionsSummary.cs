using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInformationSystem.Reporting.Models
{
    public class OnlineSessionsSummary
    {
        public string TeacherName { get; set; }
        public string ClassSubject { get; set; }
        public int TotalStudents { get; set; }
        public int SessionUnheld { get; set; }
        public int SessionHeld { get; set; }
        public decimal AverageAttendance { get; set; }
    }
}
