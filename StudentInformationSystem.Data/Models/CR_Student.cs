using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class CR_Student : BaseModel
    {
        public CR_Student()
        {
            StudentSubjects = new HashSet<CR_StudentSubject>();
        }

        [Required]
        [DisplayName("Classroom")]
        public int CR_Id { get; set; }
        [Required]
        [DisplayName("Student")]
        public int StudentId { get; set; }

        public virtual ClassRoom ClassRoom { get; set; }
        public virtual Student Student { get; set; }

        public virtual ICollection<CR_StudentSubject> StudentSubjects { get; set; }
    }
}
