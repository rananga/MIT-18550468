using Nalanda.SMS.Data;
using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Nalanda.SMS.Areas.Student.Models
{
    public class StudFamilyVM : StudFamily, IModel<StudFamily, StudFamilyVM>
    {
        public StudFamilyVM()
        {
            mappings = new ObjMappings<StudFamily, StudFamilyVM>();
        }

        public StudFamilyVM(StudFamily obj) : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<StudFamily, StudFamilyVM> mappings { get; set; }
    }
}