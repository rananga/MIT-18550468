using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class ClassPromotion : BaseModel
    {
        public ClassPromotion()
        {
            ClassPromotionDetails = new HashSet<ClassPromotionDetail>();
        }

        [Required]
        public int Year { get; set; }
        [Required]
        [DisplayName("From Grade")]
        public int GradeId { get; set; }
        [Required]
        public bool IsFinalized { get; set; }
        [Required]
        [DisplayName("Promoting Criteria")]
        public PromotingCriteria PromotingCriteria { get; set; }

        public virtual Grade Grade { get; set; }

        public virtual ICollection<ClassPromotionDetail> ClassPromotionDetails { get; set; }
    }
}
