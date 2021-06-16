using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class ClassStudent : BaseModel
    {
        public ClassStudent()
        {
            StudentSubjects = new HashSet<ClassStudentSubject>();
        }

        [Required]
        public int ClassId { get; set; }
        [Required]
        public int StudentId { get; set; }

        public virtual Class Class { get; set; }
        public virtual Student Student { get; set; }

        public virtual ICollection<ClassStudentSubject> StudentSubjects { get; set; }
    }
}
