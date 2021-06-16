using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace StudentInformationSystem.Areas.Student.Models
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