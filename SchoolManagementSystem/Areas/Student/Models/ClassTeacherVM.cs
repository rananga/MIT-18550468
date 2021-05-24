using SMS.Common;
using SMS.Common.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Areas.Student.Models
{
    public class ClassTeacherVM : IModel<ClassTeacher, ClassTeacherVM>
    {
        public ClassTeacherVM()
        {
            mappings = new ObjMappings<ClassTeacher, ClassTeacherVM>();
        }

        public ClassTeacherVM(ClassTeacher obj) :this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<ClassTeacher, ClassTeacherVM> mappings { get; set; }

        public int ClTeachID { get; set; }
        public int ClassID { get; set; }
        public int TeacherID { get; set; }
        public int PeriodID { get; set; }
        public Nullable<System.DateTime> PeriodStartDate { get; set; }
        public Nullable<System.DateTime> PeriodEndDate { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual Class Class { get; set; }
        public virtual PeriodSetup PeriodSetup { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}