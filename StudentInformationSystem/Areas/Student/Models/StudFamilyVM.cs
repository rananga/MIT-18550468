using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Common;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace StudentInformationSystem.Areas.Student.Models
{
    public class StudFamilyVM : StudentFamily, IModel<StudentFamily, StudFamilyVM>
    {
        public StudFamilyVM()
        {
            mappings = new ObjMappings<StudentFamily, StudFamilyVM>();
        }

        public StudFamilyVM(StudentFamily obj) : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<StudentFamily, StudFamilyVM> mappings { get; set; }
    }
}