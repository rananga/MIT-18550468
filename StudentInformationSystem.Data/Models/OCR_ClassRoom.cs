﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class OCR_ClassRoom : BaseModel
    {
        [DisplayName("Online Class Room"), Required]
        public int OCR_Id { get; set; }
        [Required]
        [DisplayName("Physical Class Room")]
        public int CR_Id { get; set; }

        public virtual OnlineClassRoom OnlineClassRoom { get; set; }
        public virtual ClassRoom ClassRoom { get; set; }
    }
}
