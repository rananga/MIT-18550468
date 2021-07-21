using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class ClassPromotion : BaseModel
    {
        public ClassPromotion()
        {
            PromotionDetails = new HashSet<ClassPromotionDetail>();
        }

        [Required]
        public int Year { get; set; }
        [Required]
        public int GradeId { get; set; }
        [Required]
        public bool IsFinalized { get; set; }
        [Required]
        public PromotingCriteria PromotingCriteria { get; set; }

        public virtual Grade Grade { get; set; }

        public virtual ICollection<ClassPromotionDetail> PromotionDetails { get; set; }
    }
}
