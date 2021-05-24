using SMS.Common;
using SMS.Common.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMS.Areas.Admin.Models
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
        public SMS.Common.ActiveState Status { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual ICollection<ClubMember> ClubMembers { get; set; }

    }
}