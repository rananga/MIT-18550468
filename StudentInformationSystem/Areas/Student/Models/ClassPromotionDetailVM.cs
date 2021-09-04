using StudentInformationSystem.Common;
using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using System;
using System.ComponentModel;
using System.Web;

namespace StudentInformationSystem.Areas.Student.Models
{
    public class ClassPromotionDetailVM : ClassPromotionDetail, IModel<ClassPromotionDetail, ClassPromotionDetailVM>
    {
        public ClassPromotionDetailVM()
        {
            mappings = new ObjMappings<ClassPromotionDetail, ClassPromotionDetailVM>();
            mappings.Add(x => x.Student.IndexNo, x => x.IndexNo);
            mappings.Add(x => x.Student.FullName, x => x.StudentName);
            mappings.Add(x => x.FromClass.GradeClass.Code, x => x.FromClassName);
            mappings.Add(x => x.ToClass.GradeClass.Code, x => x.ToClassName);
            mappings.Add(x => x.Student.Medium, x => x.StudentMedium);
        }

        public ClassPromotionDetailVM(ClassPromotionDetail obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<ClassPromotionDetail, ClassPromotionDetailVM> mappings { get; set; }

        [DisplayName("Admission No")]
        public int IndexNo { get; set; }
        [DisplayName("Student")]
        public string StudentName { get; set; }
        public Medium StudentMedium { get; set; }
        [DisplayName("From Class")]
        public string FromClassName { get; set; }
        [DisplayName("To Class")]
        public string ToClassName { get; set; }
    }
}