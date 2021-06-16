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
    public class ExtraActivityVM : ExtraActivity, IModel<ExtraActivity, ExtraActivityVM>
    {
        public ExtraActivityVM()
        {
            mappings = new ObjMappings<ExtraActivity, ExtraActivityVM>();
            vmAcheivements = new HashSet<ExtraActivityAcheivementVM>();
            vmPositions = new HashSet<ExtraActivityPositionVM>();

            mappings.Add(x => x.Acheivements.Select(y => new ExtraActivityAcheivementVM(y)).ToList(), x => x.vmAcheivements);
            mappings.Add(x => x.Positions.Select(y => new ExtraActivityPositionVM(y)).ToList(), x => x.vmPositions);
        }
        public ExtraActivityVM(ExtraActivity obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<ExtraActivity, ExtraActivityVM> mappings { get;  set; }

        public virtual ICollection<ExtraActivityAcheivementVM> vmAcheivements { get; set; }
        public virtual ICollection<ExtraActivityPositionVM> vmPositions { get; set; }
    }
}