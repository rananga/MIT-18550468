using SMS.Common;
using SMS.Common.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMS.Areas.Admin.Models
{
    public class ClassVM : IModel<Class, ClassVM>
    {
        public ClassVM()
        {
            mappings = new ObjMappings<Class, ClassVM>();
            mappings.Add(x => x.ClassDesc, x => x.ClassDesc);
        }

        public ClassVM(Class obj, params string[] properties) : this()
        {
            this.SetEntity(obj, properties);
        }
        public ObjMappings<Class, ClassVM> mappings { get; set; }

        public int ClassID { get; set; }
        public SMS.Common.StudGrade Grade { get; set; }
        [DisplayName("Class"), Required]
        public string ClassDesc { get; set; }
        public SMS.Common.ActiveState Status { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public byte[] RowVersion { get; set; }

        public virtual ICollection<ClassTeacher> ClassTeachers { get; set; }
        public virtual ICollection<ClassStudent> ClassStudents { get; set; }
    }
}