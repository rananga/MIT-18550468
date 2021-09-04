using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class TeacherOffTime : BaseModel
    {
        [Required]
        [DisplayName("Teacher")]
        public int TeacherId { get; set; }
        [Required]
        [DisplayName("From Time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime FromTime { get; set; }
        [Required]
        [DisplayName("To Time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime ToTime { get; set; }
        public string Reason { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
