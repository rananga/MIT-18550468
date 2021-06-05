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
    public class ClubVM : Club, IModel<Club,ClubVM>
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
    }
}