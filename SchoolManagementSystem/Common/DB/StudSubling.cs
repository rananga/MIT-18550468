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
    
    public partial class StudSubling
    {
        public int SubID { get; set; }
        public int SudID { get; set; }
        public int SublingStudID { get; set; }
        public SMS.Common.SibRelationship Relationship { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual Student Student { get; set; }
        public virtual Student StudentRelation { get; set; }
    }
}
