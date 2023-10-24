using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentInformationSystem.Data.Models
{
    public partial class AdmissionApplicant : BaseModel
    {
        [Required]
        [DisplayName("Year")]
        public int Year { get; set; }
        [Required]
        [DisplayName("Category")]
        public AdmissionCategory Category { get; set; }
        [Required]
        [DisplayName("Reference Number")]
        public int ReferenceNumber { get; set; }
        [Required]
        [DisplayName("Child Name")]
        public string ChildName { get; set; }
        [DisplayName("Child DOB")]
        public DateTime ChildDOB { get; set; }
        [Required]
        [DisplayName("Parent Name")]
        public string ParentName { get; set; }
        [Required]
        [DisplayName("Parent NIC No")]
        public string ParentNICNo { get; set; }
        [DisplayName("Address")]
        public string Address1 { get; set; }
        [DisplayName("Street Name")]
        public string Address2 { get; set; }
        [DisplayFormat(DataFormatString = "{0:N15}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "decimal(18,15)")]
        public decimal? HomeLatitude { get; set; }
        [DisplayFormat(DataFormatString = "{0:N15}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "decimal(18,15)")]
        public decimal? HomeLongitude { get; set; }
        [DisplayName("Is Selected")]
        public bool IsSelected { get; set; }
        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
    }
}
