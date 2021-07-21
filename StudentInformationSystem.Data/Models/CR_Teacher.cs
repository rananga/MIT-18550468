using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class CR_Teacher : BaseModel
    {
        [DisplayName("Classroom"), Required]
        public int CR_Id { get; set; }
        [DisplayName("Class Teacher")]
        [Required]
        public int StaffId { get; set; }
        [DisplayName("From Date")]  
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FromDate { get; set; }
        [DisplayName("To Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ToDate { get; set; }

        public virtual ClassRoom ClassRoom { get; set; }
        public virtual StaffMember StaffMember { get; set; }
    }
}
