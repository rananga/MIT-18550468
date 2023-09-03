using System;

namespace StudentInformationSystem.Data.Models
{
    public partial class GradeEmail
    {
        public int Year { get; set; }
        public int Grade { get; set; }
        public string EmailAddress { get; set; }
    }
}
