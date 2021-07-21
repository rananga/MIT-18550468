using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class StudentTransfer : BaseModel
    {
        [DisplayName("Student")]
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int Year { get; set; }
        [DisplayName("From Class")]
        [Required]
        public int FromCR_Id { get; set; }
        [DisplayName("To Class")]
        [Required]
        public int ToCR_Id { get; set; }
        public string Reason { get; set; }

        public virtual Student Student { get; set; }
        public virtual ClassRoom FromClass { get; set; }
        public virtual ClassRoom ToClass { get; set; }
    }
}
