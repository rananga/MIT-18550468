using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class GradeClassSubject : BaseModel
    {
        [DisplayName("Grade Class")]
        [Required]
        public int GradeClassId { get; set; }
        [DisplayName("Subject")]
        [Required]
        public int SubjectId { get; set; }

        public virtual GradeClass GradeClass { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
