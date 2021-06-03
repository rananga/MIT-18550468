using Nalanda.SMS.Data;
using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Nalanda.SMS.Areas.Admin.Models
{
    public class ClubVM : IModel<Club,ClubVM>
    {
        public ClubVM()
        {
            mappings = new ObjMappings<Club, ClubVM>();
        }

        public ClubVM(Club obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<Club, ClubVM> mappings { get; set; }

        public int CID { get; set; }
        [DisplayName("Club"), Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [DisplayName("Status"), Required]
        public ActiveState Status { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual ICollection<ClubMember> ClubMembers { get; set; }

    }
}