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
    public class ExtraActivityAcheivementVM : ExtraActivityAcheivement, IModel<ExtraActivityAcheivement, ExtraActivityAcheivementVM>
    {
        public ExtraActivityAcheivementVM()
        {
            mappings = new ObjMappings<ExtraActivityAcheivement, ExtraActivityAcheivementVM>();
        }
        public ExtraActivityAcheivementVM(ExtraActivityAcheivement obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<ExtraActivityAcheivement, ExtraActivityAcheivementVM> mappings { get;  set; }
    }
}