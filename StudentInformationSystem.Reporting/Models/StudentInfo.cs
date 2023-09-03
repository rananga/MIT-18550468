using System;
using System.Collections.Generic;
using System.Text;

namespace StudentInformationSystem.Reporting.Models
{
    public class StudentInfo
    {
        public int AdmissionNo { get; set; }
        public DateTime AddmittedDate { get; set; }
        public string NameWithInitials { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public DateTime? DOB { get; set; }
        public string EmmergencyContactName { get; set; }
        public string EmmergencyContactTelno { get; set; }
    }

    public class StudentFamily
    {
        public string Name { get; set; }
        public string Relationship { get; set; }
        public string Occupation { get; set; }
        public string WorkingAdd { get; set; }
        public string OfficeTel { get; set; }
        public string ContactHome { get; set; }
        public string ContactMob { get; set; }
    }

    public class StudentSibling
    {
        public string Name { get; set; }
        public string Relationship { get; set; }
        public string Class { get; set; }
    }

    public class StudentAcheivements
    {
        public string Description { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
