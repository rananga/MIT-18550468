using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Linq;

namespace StudentInformationSystem.Areas.Academic.Models
{
    public class CR_StudentVM : CR_Student, IModel<CR_Student, CR_StudentVM>
    {
        public CR_StudentVM()
        {
            mappings = new ObjMappings<CR_Student, CR_StudentVM>();
            //mappings.Add(x => x.Class.Grade.GradeId + x.Class.Name, x => x.ClassName);
            mappings.Add(x => x.Student.IndexNo, x => x.StudentIndex);
            mappings.Add(x => x.Student.FullName, x => x.StudentName);
            mappings.Add(x => x.Student.Medium, x => x.StudentMedium);
            mappings.Add(x => x.Student.StudentBasketSubjects.Where(y => y.Subject.SectionId == x.ClassRoom.GradeClass.Grade.SectionId).Select(y=> y.Subject.Code).Aggregate((y, z) => y + "," + z), x => x.BasketSubjects);
        }

        public CR_StudentVM(CR_Student obj, params string[] properties) : this()
        {
            this.SetEntity(obj, properties);
        }
        public ObjMappings<CR_Student, CR_StudentVM> mappings { get; set; }

        [DisplayName("Admission No")]
        public int StudentIndex { get; set; }
        [DisplayName("Name")]
        public string StudentName { get; set; }
        public Medium StudentMedium { get; set; }
        [DisplayName("Basket Subjects")]
        public string BasketSubjects { get; set; }
    }
}