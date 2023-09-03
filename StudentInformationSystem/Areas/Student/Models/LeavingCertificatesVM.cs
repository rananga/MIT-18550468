using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace StudentInformationSystem.Areas.Student.Models
{
    public class LeavingCertificatesVM :IModel<LeavingCertificate, LeavingCertificatesVM>
    {
        public LeavingCertificatesVM()
        {
            mappings = new ObjMappings<LeavingCertificate, LeavingCertificatesVM>();
            mappings.Add(x => x.Student.AdmissionNo, x => x.AdmissionNo);
            mappings.Add(x => x.Student.Initials + " " + x.Student.LastName, x => x.StudentName);
        }

        public LeavingCertificatesVM(LeavingCertificate obj) : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<LeavingCertificate, LeavingCertificatesVM> mappings { get; set; }

        public int LeavCertID { get; set; }
        [DisplayName("Student"), Required]
        public int StudID { get; set; }
        [DisplayName("Leaving Date"), Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime DateLeaving { get; set; }
        [DisplayName("Reason"), DataType(DataType.MultilineText), Required]
        public string Reason { get; set; }
        public Conduct Conduct { get; set; }
        public string CreatedBy { get; set; }
        [DisplayName("Date Issued"), DataType(DataType.MultilineText)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }
        [DisplayName("Admission No")]
        public int AdmissionNo { get; set; }
        [DisplayName("Student")]
        public string StudentName { get; set; }

        public virtual StudentInformationSystem.Data.Models.Student Student { get; set; }
    }
}