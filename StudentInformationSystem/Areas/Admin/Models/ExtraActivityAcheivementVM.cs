using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace StudentInformationSystem.Areas.Admin.Models
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