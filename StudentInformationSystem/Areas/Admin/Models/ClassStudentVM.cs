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
    public class ClassStudentVM : ClassStudent, IModel<ClassStudent, ClassStudentVM>
    {
        public ClassStudentVM()
        {
            mappings = new ObjMappings<ClassStudent, ClassStudentVM>();
            //mappings.Add(x => x.Class.Grade.GradeId + x.Class.Name, x => x.ClassName);
            mappings.Add(x => x.Student.IndexNo, x => x.StudentIndex);
            mappings.Add(x => x.Student.FullName, x => x.StudentName);
        }

        public ClassStudentVM(ClassStudent obj, params string[] properties) : this()
        {
            this.SetEntity(obj, properties);
        }
        public ObjMappings<ClassStudent, ClassStudentVM> mappings { get; set; }

        public string ClassName { get; set; }
        public int StudentIndex { get; set; }
        public string StudentName { get; set; }
    }
}