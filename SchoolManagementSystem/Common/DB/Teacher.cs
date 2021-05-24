//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SMS.Common.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Teacher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Teacher()
        {
            this.ClassTeachers = new HashSet<ClassTeacher>();
            this.EventParticipations = new HashSet<EventParticipation>();
            this.PromotionClasses = new HashSet<PromotionClass>();
        }
    
        public int TeachID { get; set; }
        public SMS.Common.TitleTeacher Title { get; set; }
        public SMS.Common.Gender Gender { get; set; }
        public string FullName { get; set; }
        public string Initials { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public string NICNo { get; set; }
        public string TelHome { get; set; }
        public string ImmeContactNo { get; set; }
        public string ImmeContactName { get; set; }
        public SMS.Common.TeacherStatus Status { get; set; }
        public string InactiveReason { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassTeacher> ClassTeachers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventParticipation> EventParticipations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PromotionClass> PromotionClasses { get; set; }
    }
}
