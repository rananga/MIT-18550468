using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nalanda.SMS.Data.Models
{
    public partial class StudentExtraActivityPosition : BaseModel
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int PositionId { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public DateTime ToDate { get; set; }
        public string Remarks { get; set; }

        public virtual Student Student { get; set; }
        public virtual ExtraActivityPosition Position { get; set; }
    }
}
