using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class OCR_Teacher : BaseModel
    {
        [DisplayName("Class Teacher")]
        [Required]
        public int StaffId { get; set; }
        [DisplayName("Is Owner")]
        public bool IsOwner { get; set; }

        public virtual StaffMember StaffMember { get; set; }
    }
}
