using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Nalanda.SMS.Areas.Admin.Models
{
    public class PeriodSetupVM : IModel<PeriodSetup, PeriodSetupVM>
    {
        public PeriodSetupVM()
        {
            mappings = new ObjMappings<PeriodSetup, PeriodSetupVM>();
        }

        public PeriodSetupVM(PeriodSetup obj) : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<PeriodSetup, PeriodSetupVM> mappings { get; set; }

        public int PeriodID { get; set; }
        [Required]
        [DisplayName("Period Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime PeriodStartDate { get; set; }
        [Required]
        [DisplayName("Period End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime PeriodEndDate { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }
        [DisplayName("Is Period Complete")]
        public bool IsPeriodComplete { get; set; }


        public virtual ICollection<ClassTeacher> ClassTeachers { get; set; }
        public virtual ICollection<ClassStudent> ClassStudents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PromotionClass> PromotionClasses { get; set; }

    }
}