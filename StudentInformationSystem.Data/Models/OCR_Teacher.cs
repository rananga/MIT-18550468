using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class OCR_Teacher : BaseModel
    {
        public OCR_Teacher()
        {
            OnlineClasses = new HashSet<OnlineClass>();
        }

        [DisplayName("Online Class Room"), Required]
        public int OCR_Id { get; set; }
        [DisplayName("Class Teacher")]
        [Required]
        public int StaffId { get; set; }
        [DisplayName("Is Owner")]
        public bool IsOwner { get; set; }

        public virtual OnlineClassRoom OnlineClassRoom { get; set; }
        public virtual StaffMember ClassTeacher { get; set; }

        public virtual ICollection<OnlineClass> OnlineClasses { get; set; }
    }
}
