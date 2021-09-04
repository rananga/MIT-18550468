using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class ClassPromotionDetail : BaseModel
    {
        [Required]
        public int PromotionId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Required]
        public int FromClassId { get; set; }
        public int? ToClassId { get; set; }

        public virtual ClassPromotion ClassPromotion { get; set; }
        public virtual Student Student { get; set; }
        public virtual ClassRoom FromClass { get; set; }
        public virtual ClassRoom ToClass { get; set; }
    }
}
