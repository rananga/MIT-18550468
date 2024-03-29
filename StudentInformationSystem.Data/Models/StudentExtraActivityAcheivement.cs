﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class StudentExtraActivityAcheivement : BaseModel
    {
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int AcheivementId { get; set; }
        [Required]
        public DateTime AwardedDate { get; set; }
        public string Remarks { get; set; }

        public virtual Student Student { get; set; }
        public virtual ExtraActivityAcheivement Acheivement { get; set; }
    }
}
