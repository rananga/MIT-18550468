using Nalanda.SMS.Data;
using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Nalanda.SMS.Areas.Student.Models
{
    public class ClubMemberVM : IModel<ClubMember,ClubMemberVM>
    {
        public ClubMemberVM()
        {
            mappings = new ObjMappings<ClubMember, ClubMemberVM>();
            mappings.Add(x => x.Student.Title + ". " + x.Student.Initials + "" + x.Student.Lname, x => x.StudentName);
            mappings.Add(x => x.Club.Name, x => x.ClubDesc);
            mappings.Add(x => x.CommiteeMemberType == CommitteeMemberType.President ? "President": x.CommiteeMemberType == CommitteeMemberType.Secretary ? "Secretary" 
                : x.CommiteeMemberType == CommitteeMemberType.Treasurer ? "Treasurer" : x.CommiteeMemberType == CommitteeMemberType.VisePresident ? "Vice President"
                : x.CommiteeMemberType == CommitteeMemberType.ViseSecretary ? "Vice Secretary": x.CommiteeMemberType == CommitteeMemberType.ViseTreasurer ? "Vice Treasurer" : "-", x => x.CmemberType);
            mappings.Add(x => x.Student.IndexNo, x => x.AdmissionNo);
        }

    public ClubMemberVM(ClubMember obj) : this()
    {
        this.SetEntity(obj);
    }
    public ObjMappings<ClubMember, ClubMemberVM> mappings { get; set; }

        public int CMID { get; set; }
        [DisplayName("Club"), Required]
        public int CID { get; set; }
        [DisplayName("Student"), Required]
        public int StudentID { get; set; }
        [DisplayName("Member Date"), Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime MemberDate { get; set; }
        [DisplayName("Membership Type"), Required]
        public MembershipType MembershipType { get; set; }
        [DisplayName("Committee Member Type"), Required]
        public CommitteeMemberType CommiteeMemberType { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }
        public ActiveState Status { get; set; }
        [DisplayName("Student")]
        public string StudentName { get; set; }
        [DisplayName("Club")]
        public string ClubDesc { get; set; }
        public string CmemberType { get; set; }
        public int AdmissionNo { get; set; }

        public virtual Club Club { get; set; }
        public virtual Nalanda.SMS.Data.Models.Student Student { get; set; }
    }
}