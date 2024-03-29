﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class PCR_Monitor : BaseModel
    {
        [DisplayName("Classroom"), Required]
        public int CR_Id { get; set; }
        [DisplayName("Student")]
        [Required]
        public int StudentId { get; set; }
        [DisplayName("From Date")]
        public DateTime FromDate { get; set; }
        [DisplayName("To Date")]
        public DateTime ToDate { get; set; }

        public virtual PhysicalClassRoom PhysicalClassRoom { get; set; }
        public virtual Student Student { get; set; }
    }
}
