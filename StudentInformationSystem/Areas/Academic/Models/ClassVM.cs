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
    public class ClassVM : Class, IModel<Class, ClassVM>
    {
        public ClassVM()
        {
            mappings = new ObjMappings<Class, ClassVM>();
            Subjects = new HashSet<ClassSubjectVM>();
            Students = new HashSet<ClassStudentVM>();

            mappings.Add(x => x.GradeClass.Code, x => x.GradeClassDesc);
            mappings.Add(x => new ClassTeacherVM(x.ClassTeachers.Where(y=> y.FromDate < DateTime.Now && y.ToDate > DateTime.Now).FirstOrDefault()).TeacherName, x => x.ClassTeacherName);
            mappings.Add(x => x.ClassSubjects.Select(y => new ClassSubjectVM(y)).ToList(), x => x.Subjects);
            mappings.Add(x => x.ClassStudents.Select(y => new ClassStudentVM(y)).ToList(), x => x.Students);
        }

        public ClassVM(Class obj, params string[] properties) : this()
        {
            this.SetEntity(obj, properties);
        }
        public ObjMappings<Class, ClassVM> mappings { get; set; }

        public string GradeClassDesc { get; set; }
        public string ClassTeacherName { get; set; }
        
        public virtual ICollection<ClassSubjectVM> Subjects { get; set; }
        public virtual ICollection<ClassStudentVM> Students { get; set; }
    }
}