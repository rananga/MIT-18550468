using Nalanda.SMS.Data;
using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Nalanda.SMS.Areas.Student.Models
{
    public class PrefectVM : IModel<Prefect, PrefectVM>
    {
        public PrefectVM()
        {
            mappings = new ObjMappings<Prefect, PrefectVM>();

            mappings.Add(x => x.Student.Title + ". " + x.Student.Initials + " " + x.Student.Lname, x => x.StudentName);
            mappings.Add(x => "Grade " + x.PromotionClass.Class.Grade + " - " + x.PromotionClass.Class.ClassDesc, x => x.ClassGrade);
            mappings.Add(x => x.Student.IndexNo, x => x.IndexNo);
        }

        public PrefectVM(Prefect obj) : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<Prefect, PrefectVM> mappings { get; set; }

        public int PreID { get; set; }
        [DisplayName("Student")]
        public int StudID { get; set; }
        [DisplayName("Class")]
        public int PrefClassID { get; set; }
        [DisplayName("Prefect Type")]
        public PrefectType Type { get; set; }
        [DisplayName("Effective Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime EffectiveDate { get; set; }
        [DisplayName("HP")]
        public bool IsHP { get; set; }
        [DisplayName("DHP")]
        public bool IsDHP { get; set; }
        [DisplayName("Responsibilty"), DataType(DataType.MultilineText)]
        public string Responsibilty { get; set; }
        [DisplayName("Promoted")]
        public bool IsPromoted { get; set; }
        [DisplayName("Promoted Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> PromotedDate { get; set; }
        [DisplayName("Status")]
        public ActiveState Status { get; set; }
        [DisplayName("Inactive Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> InactiveDate { get; set; }
        [DisplayName("Inactive Reason"), DataType(DataType.MultilineText)]
        public string InactiveReason { get; set; }
        [DisplayName("Student")]
        public string StudentName { get; set; }
        [DisplayName("Class")]
        public string ClassGrade { get; set; }
        [DisplayName("Senior Prefect Count")]
        public int SeniorCount { get; set; }
        [DisplayName("Junior Prefect Count")]
        public int JuniorCount { get; set; }
        [DisplayName("Pending Prefect Count")]
        public int PendingCount { get; set; }
        [DisplayName("Admission No")]
        public int IndexNo { get; set; }
        public string PrefGuildJson { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual StudentVM Student { get; set; }
        public virtual PromotionClassVM PromotionClass { get; set; }
    }
}