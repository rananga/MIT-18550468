using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class GradeClass : BaseModel
    {
        public GradeClass()
        {
            GradeClassSubjects = new HashSet<GradeClassSubject>();
            Classes = new HashSet<PhysicalClassRoom>();
        }

        [DisplayName("Grade")]
        [Required]
        public int GradeId { get; set; }
        [Required]
        public Classes Name { get; set; }
        public string Code { get; set; }
        public Medium Medium { get; set; }
        [DisplayName("Max Student Count")]
        public int? MaxStudentCount { get; set; }

        public virtual Grade Grade { get; set; }
        public virtual ICollection<GradeClassSubject> GradeClassSubjects { get; set; }
        public virtual ICollection<PhysicalClassRoom> Classes { get; set; }
    }
}
