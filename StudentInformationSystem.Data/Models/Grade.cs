using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Data.Models
{
    public partial class Grade : BaseModel
    {
        public Grade()
        {
            GradeHeads = new HashSet<GradeHead>();
            GradeSubjects = new HashSet<GradeSubject>();
            GradeClasses = new HashSet<GradeClass>();
            OnlineClassRooms = new HashSet<OnlineClassRoom>();
            PermissionGradeAccesses = new HashSet<PermissionGradeAccess>();
        }

        [DisplayName("Section"), Required]
        public int SectionId { get; set; }
        [DisplayName("Grade"), Required]
        public Grades GradeNo { get; set; }
        public string Description { get; set; }

        public virtual Section Section { get; set; }

        public virtual ICollection<GradeHead> GradeHeads { get; set; }
        public virtual ICollection<GradeSubject> GradeSubjects { get; set; }
        public virtual ICollection<GradeClass> GradeClasses { get; set; }
        public virtual ICollection<OnlineClassRoom> OnlineClassRooms { get; set; }
        public virtual ICollection<PermissionGradeAccess> PermissionGradeAccesses { get; set; }
    }
}
