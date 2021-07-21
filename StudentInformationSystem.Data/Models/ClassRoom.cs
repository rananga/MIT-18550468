using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class ClassRoom : BaseModel
    {
        public ClassRoom()
        {
            ClassTeachers = new HashSet<CR_Teacher>();
            ClassMonitors = new HashSet<CR_Monitor>();
            ClassSubjects = new HashSet<CR_Subject>();
            ClassStudents = new HashSet<CR_Student>();
            OCR_ClassRooms = new HashSet<OCR_ClassRoom>();
            LastClassStudents = new HashSet<Student>();
            FromTransfers = new HashSet<StudentTransfer>();
            ToTransfers = new HashSet<StudentTransfer>();
            FromClassPromotionDetails = new HashSet<ClassPromotionDetail>();
            ToClassPromotionDetails = new HashSet<ClassPromotionDetail>();
        }

        [Required]
        public int Year { get; set; }
        [DisplayName("Grade Class"), Required]
        public int GradeClassId { get; set; }
        [Required]
        public Medium Medium { get; set; }

        public virtual GradeClass GradeClass { get; set; }
        public virtual ICollection<CR_Teacher> ClassTeachers { get; set; }
        public virtual ICollection<CR_Monitor> ClassMonitors { get; set; }
        public virtual ICollection<CR_Subject> ClassSubjects { get; set; }
        public virtual ICollection<CR_Student> ClassStudents { get; set; }
        public virtual ICollection<OCR_ClassRoom> OCR_ClassRooms { get; set; }
        public virtual ICollection<Student> LastClassStudents { get; set; }
        public virtual ICollection<StudentTransfer> FromTransfers { get; set; }
        public virtual ICollection<StudentTransfer> ToTransfers { get; set; }
        public virtual ICollection<ClassPromotionDetail> FromClassPromotionDetails { get; set; }
        public virtual ICollection<ClassPromotionDetail> ToClassPromotionDetails { get; set; }
    }
}
