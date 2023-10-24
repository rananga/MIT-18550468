using System.ComponentModel;

namespace StudentInformationSystem.Areas.Admin.Models
{
    public class AdmissionMapPrintVM
    {
        [DisplayName("Applicant ID")]
        public int? ApplicantId { get; set; }
        [DisplayName("Is Anonymous")]
        public bool IsAnonymous { get; set; }
        public decimal HomeLatitude { get; set; }
        public decimal HomeLongitude { get; set; }
    }
}
