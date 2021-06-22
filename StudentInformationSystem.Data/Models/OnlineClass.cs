using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class OnlineClass : BaseModel
    {
        public OnlineClass()
        {
            OC_Meetings = new HashSet<OC_Meeting>();
        }

        [DisplayName("Online Class Room"), Required]
        public int OCR_Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [DisplayName("From Time"), Required]
        public TimeSpan FromTime { get; set; }
        [DisplayName("To Time"), Required]
        public TimeSpan ToTime { get; set; }
        [DisplayName("Teacher"), Required]
        public int OCR_TeacherId { get; set; }
        public string Subject { get; set; }
        public string Lesson { get; set; }
        public string CalendarEvent { get; set; }

        public virtual OnlineClassRoom OnlineClassRoom { get; set; }
        public virtual OCR_Teacher OCR_Teacher { get; set; }

        public virtual ICollection<OC_Meeting> OC_Meetings { get; set; }
    }
}
