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
    public class PrefectVM : IModel<Prefect, PrefectVM>
    {
        public PrefectVM()
        {
            mappings = new ObjMappings<Prefect, PrefectVM>();

            mappings.Add(x => x.Student.Title + ". " + x.Student.Initials + " " + x.Student.LName, x => x.StudentName);
            mappings.Add(x => x.PromotionClass.Class.Grade == StudGrade.Basic ? "Basic" : (x.PromotionClass.Class.Grade == StudGrade.Diploma ? "Diploma"
                           : (x.PromotionClass.Class.Grade == StudGrade.Grade1 ? "Grade 1" : (x.PromotionClass.Class.Grade == StudGrade.Grade2 ? "Grade 2"
                           : (x.PromotionClass.Class.Grade == StudGrade.Grade3 ? "Grade 3" : (x.PromotionClass.Class.Grade == StudGrade.Grade4 ? "Grade 4"
                           : (x.PromotionClass.Class.Grade == StudGrade.JuniorPart1 ? "Junior Part 1" : (x.PromotionClass.Class.Grade == StudGrade.JuniorPart2 ? "Junior Part 2"
                           : (x.PromotionClass.Class.Grade == StudGrade.SeniorPart1 ? "Senior Part 1" : "Senior Part 2"))))))))
                                                                                    + " - " + x.PromotionClass.Class.ClassDesc, x => x.ClassGrade);
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
        public SMS.Common.PrefectType Type { get; set; }
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
        public SMS.Common.ActiveState Status { get; set; }
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