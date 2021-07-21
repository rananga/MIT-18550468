using StudentInformationSystem.Common;
using StudentInformationSystem.Data.Models;
using System;
using System.ComponentModel;
using System.Web;

namespace StudentInformationSystem.Areas.Student.Models
{
    public class ClassPromotionVM : ClassPromotion, IModel<ClassPromotion, ClassPromotionVM>
    {
        public ClassPromotionVM()
        {
            mappings = new ObjMappings<ClassPromotion, ClassPromotionVM>();
            mappings.Add(x => x.Grade.Description, x => x.GradeDesc);
            mappings.Add(x => x.IsFinalized ? "Finalized" : "Drafted", x => x.Status);
            mappings.Add(x => x.PromotingCriteria.ToEnumChar(null), x => x.CriteriaDesc);
        }

        public ClassPromotionVM(ClassPromotion obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<ClassPromotion, ClassPromotionVM> mappings { get; set; }

        [DisplayName("Grade")]
        public string GradeDesc { get; set; }
        public string Status { get; set; }
        [DisplayName("Promoting Criteria")]
        public string CriteriaDesc { get; set; }
    }
}