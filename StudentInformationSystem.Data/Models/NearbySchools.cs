using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentInformationSystem.Data.Models
{
    public partial class NearbySchool : BaseModel
    {
        [Required]
        [DisplayName("School Name")]
        public string SchoolName { get; set; }
        [Required]
        [DisplayName("Display Name")]
        public string DisplayName { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:N15}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "decimal(18,15)")]
        public decimal Latitude { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:N15}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "decimal(18,15)")]
        public decimal Longitude { get; set; }
        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
    }
}
