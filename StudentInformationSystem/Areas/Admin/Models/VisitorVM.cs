using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Linq;

namespace StudentInformationSystem.Areas.Admin.Models
{
    public class VisitorVM : Visitor, IModel<Visitor, VisitorVM>
    {
        public VisitorVM()
        {
            mappings = new ObjMappings<Visitor, VisitorVM>();

            mappings.Add(x => x.Title + ". " + x.FullName, x => x.VisitorName);
        }
        public VisitorVM(Visitor obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<Visitor, VisitorVM> mappings { get;  set; }

        [DisplayName("Visitor Name")]
        public string VisitorName { get; set; }
        public HttpPostedFileBase ProfilePic { get; set; }
    }
}