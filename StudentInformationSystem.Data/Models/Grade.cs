using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class Grade : BaseModel
    {
        public Grade()
        {
            GradeAdmissions = new HashSet<Student>();
            GradeHeads = new HashSet<GradeHead>();
            GradeSubjects = new HashSet<GradeSubject>();
            GradeClasses = new HashSet<GradeClass>();
            OnlineClassRooms = new HashSet<OnlineClassRoom>();
            RoleGradeAccesses = new HashSet<RoleGradeAccess>();
            ClassPromotions = new HashSet<ClassPromotion>();
        }

        [DisplayName("Section"), Required]
        public int SectionId { get; set; }
        [DisplayName("Grade"), Required]
        public Grades GradeNo { get; set; }
        public string Description { get; set; }

        public virtual Section Section { get; set; }

        public virtual ICollection<Student> GradeAdmissions { get; set; }
        public virtual ICollection<GradeHead> GradeHeads { get; set; }
        public virtual ICollection<GradeSubject> GradeSubjects { get; set; }
        public virtual ICollection<GradeClass> GradeClasses { get; set; }
        public virtual ICollection<OnlineClassRoom> OnlineClassRooms { get; set; }
        public virtual ICollection<RoleGradeAccess> RoleGradeAccesses { get; set; }
        public virtual ICollection<ClassPromotion> ClassPromotions { get; set; }
    }
}
