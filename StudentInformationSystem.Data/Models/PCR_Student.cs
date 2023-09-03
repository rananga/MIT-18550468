using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class PCR_Student : BaseModel
    {
        public PCR_Student()
        {
            StudentSubjects = new HashSet<PCR_StudentSubject>();
        }

        [Required]
        [DisplayName("Classroom")]
        public int CR_Id { get; set; }
        [Required]
        [DisplayName("Student")]
        public int StudentId { get; set; }
        public int RegisterNo { get; set; }

        public virtual PhysicalClassRoom PhysicalClassRoom { get; set; }
        public virtual Student Student { get; set; }

        public virtual ICollection<PCR_StudentSubject> StudentSubjects { get; set; }
    }
}
