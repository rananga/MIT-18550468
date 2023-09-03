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
    public class PCR_StudentVM : PCR_Student, IModel<PCR_Student, PCR_StudentVM>
    {
        public PCR_StudentVM()
        {
            mappings = new ObjMappings<PCR_Student, PCR_StudentVM>();
            //mappings.Add(x => x.Class.Grade.GradeId + x.Class.Name, x => x.ClassName);
            mappings.Add(x => x.Student.AdmissionNo, x => x.StudentIndex);
            mappings.Add(x => x.Student.FullName, x => x.StudentName);
            mappings.Add(x => x.Student.Medium, x => x.StudentMedium);
            mappings.Add(x => x.Student.StudentBasketSubjects.Where(y => y.Subject.SectionId == x.PhysicalClassRoom.GradeClass.Grade.SectionId).Select(y=> y.Subject.Code).Aggregate((y, z) => y + "," + z), x => x.BasketSubjects);
        }

        public PCR_StudentVM(PCR_Student obj, params string[] properties) : this()
        {
            this.SetEntity(obj, properties);
        }
        public ObjMappings<PCR_Student, PCR_StudentVM> mappings { get; set; }

        [DisplayName("Admission No")]
        public int StudentIndex { get; set; }
        [DisplayName("Name")]
        public string StudentName { get; set; }
        public Medium StudentMedium { get; set; }
        [DisplayName("Basket Subjects")]
        public string BasketSubjects { get; set; }
    }
}