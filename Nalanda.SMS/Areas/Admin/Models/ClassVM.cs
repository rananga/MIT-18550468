using Nalanda.SMS.Data;
using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Linq;

namespace Nalanda.SMS.Areas.Admin.Models
{
    public class ClassVM : Class, IModel<Class, ClassVM>
    {
        public ClassVM()
        {
            mappings = new ObjMappings<Class, ClassVM>();
            Subjects = new HashSet<ClassSubjectVM>();
            Students = new HashSet<ClassStudentVM>();

            mappings.Add(x => "Grade " + x.Grade.GradeId, x => x.GradeDesc);
            mappings.Add(x => $"{x.ClassTeacher.Title} {x.ClassTeacher.FullName}", x => x.ClassTeacherName);
            mappings.Add(x => x.ClassSubjects.Select(y => new ClassSubjectVM(y)).ToList(), x => x.Subjects);
            mappings.Add(x => x.ClassStudents.Select(y => new ClassStudentVM(y)).ToList(), x => x.Students);
        }

        public ClassVM(Class obj, params string[] properties) : this()
        {
            this.SetEntity(obj, properties);
        }
        public ObjMappings<Class, ClassVM> mappings { get; set; }

        public string GradeDesc { get; set; }
        public string ClassTeacherName { get; set; }
        
        public virtual ICollection<ClassSubjectVM> Subjects { get; set; }
        public virtual ICollection<ClassStudentVM> Students { get; set; }
    }
}