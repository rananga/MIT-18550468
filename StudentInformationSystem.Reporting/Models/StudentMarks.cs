using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInformationSystem.Reporting.Models
{
    public class StudentMarks
    {
        public int AdmissionNo { get; set; }
        public string StudentName { get; set; }
        public string CurrentClass { get; set; }
        public decimal MarksTerm1 { get; set; }
        public decimal MarksTerm2 { get; set; }
        public decimal MarksTerm3 { get; set; }
    }
}
