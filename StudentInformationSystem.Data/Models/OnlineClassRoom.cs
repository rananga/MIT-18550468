using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class OnlineClassRoom : BaseModel
    {
        public OnlineClassRoom()
        {
            PhysicalClassRooms = new HashSet<OCR_ClassRoom>();
            ClassTeachers = new HashSet<OCR_Teacher>();
            OCR_ClassRooms = new HashSet<OCR_ClassRoom>();
            OnlineClasses = new HashSet<OnlineClass>();
        }

        [Required]
        public int Year { get; set; }
        public int GradeId { get; set; }
        public int SubjectId { get; set; }
        [Required]
        public Medium Medium { get; set; }
        public string GoogleClassRoomId { get; set; }

        public virtual Grade Grade { get; set; }
        public virtual Subject Subject { get; set; }

        public virtual ICollection<OCR_ClassRoom> PhysicalClassRooms { get; set; }
        public virtual ICollection<OCR_Teacher> ClassTeachers { get; set; }
        public virtual ICollection<OCR_ClassRoom> OCR_ClassRooms { get; set; }
        public virtual ICollection<OnlineClass> OnlineClasses { get; set; }
    }
}
