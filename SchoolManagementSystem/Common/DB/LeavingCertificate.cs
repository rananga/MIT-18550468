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
    
    public partial class LeavingCertificate
    {
        public int LeavCertID { get; set; }
        public int StudID { get; set; }
        public System.DateTime DateLeaving { get; set; }
        public string Reason { get; set; }
        public SMS.Common.Conduct Conduct { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }
    
        public virtual Student Student { get; set; }
    }
}
