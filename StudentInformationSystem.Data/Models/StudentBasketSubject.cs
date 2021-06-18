using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class StudentBasketSubject : BaseModel
    {
        [DisplayName("Student")]
        [Required]
        public int StudentId { get; set; }
        [DisplayName("Subject")]
        [Required]
        public int SubjectId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
