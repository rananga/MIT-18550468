using SMS.Common;
using SMS.Common.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMS.Areas.Student.Models
{
    public class LeavingCertificatesVM :IModel<LeavingCertificate, LeavingCertificatesVM>
    {
        public LeavingCertificatesVM()
        {
            mappings = new ObjMappings<LeavingCertificate, LeavingCertificatesVM>();
            mappings.Add(x => x.Student.IndexNo, x => x.AdmissionNo);
            mappings.Add(x => x.Student.Title + ". " + x.Student.Initials + "" + x.Student.LName, x => x.StudentName);
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
        public SMS.Common.Conduct Conduct { get; set; }
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

        public virtual SMS.Common.DB.Student Student { get; set; }
    }
}