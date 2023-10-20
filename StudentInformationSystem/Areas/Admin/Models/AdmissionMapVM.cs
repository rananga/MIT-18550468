using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentInformationSystem.Areas.Admin.Models
{
    public class AdmissionMapVM
    {
        public AdmissionMapVM()
        {
            NearbySchools = new List<NearbySchoolVM>();
        }
        [Required]
        [DisplayFormat(DataFormatString = "{0:N15}", ApplyFormatInEditMode = true)]
        [DisplayName("School Location Latitude")]
        public decimal SchoolLocationLatitude { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:N15}", ApplyFormatInEditMode = true)]
        [DisplayName("School Location Longitude")]
        public decimal SchoolLocationLongitude { get; set; }
        public List<NearbySchoolVM> NearbySchools { get; set; }

        public string ActivityChangesJson { get; set; }
    }
}