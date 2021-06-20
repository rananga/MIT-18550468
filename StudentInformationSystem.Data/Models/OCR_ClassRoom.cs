using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class OCR_ClassRoom : BaseModel
    {
        [Required]
        [DisplayName("Class")]
        public int CR_Id { get; set; }

        public virtual ClassRoom ClassRoom { get; set; }
    }
}
