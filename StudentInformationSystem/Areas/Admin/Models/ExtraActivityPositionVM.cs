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
    public class ExtraActivityPositionVM : ExtraActivityPosition, IModel<ExtraActivityPosition, ExtraActivityPositionVM>
    {
        public ExtraActivityPositionVM()
        {
            mappings = new ObjMappings<ExtraActivityPosition, ExtraActivityPositionVM>();
        }
        public ExtraActivityPositionVM(ExtraActivityPosition obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<ExtraActivityPosition, ExtraActivityPositionVM> mappings { get;  set; }
    }
}