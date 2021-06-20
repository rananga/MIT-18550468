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
    public class ClassRoomVM : ClassRoom, IModel<ClassRoom, ClassRoomVM>
    {
        public ClassRoomVM()
        {
            mappings = new ObjMappings<ClassRoom, ClassRoomVM>();
            Subjects = new HashSet<CR_SubjectVM>();
            Students = new HashSet<CR_StudentVM>();
            Teachers = new HashSet<CR_TeacherVM>();

            mappings.Add(x => x.GradeClass.Code, x => x.GradeClassDesc);
            mappings.Add(x => new CR_TeacherVM(x.ClassTeachers.Where(y=> y.FromDate < DateTime.Now && y.ToDate > DateTime.Now).FirstOrDefault()).TeacherName, x => x.ClassTeacherName);
            mappings.Add(x => x.ClassSubjects.Select(y => new CR_SubjectVM(y)).ToList(), x => x.Subjects);
            mappings.Add(x => x.ClassStudents.Select(y => new CR_StudentVM(y)).ToList(), x => x.Students);
            mappings.Add(x => x.ClassTeachers.Select(y => new CR_TeacherVM(y)).ToList(), x => x.Teachers);
            mappings.Add(x => x.ClassMonitors.Select(y => new CR_MonitorVM(y)).ToList(), x => x.Monitors);
        }

        public ClassRoomVM(ClassRoom obj, params string[] properties) : this()
        {
            this.SetEntity(obj, properties);
        }
        public ObjMappings<ClassRoom, ClassRoomVM> mappings { get; set; }

        [DisplayName("Grade Class")]
        public string GradeClassDesc { get; set; }
        [DisplayName("Class Teacher")]
        public string ClassTeacherName { get; set; }

        public virtual ICollection<CR_SubjectVM> Subjects { get; set; }
        public virtual ICollection<CR_StudentVM> Students { get; set; }
        public virtual ICollection<CR_TeacherVM> Teachers { get; set; }
        public virtual ICollection<CR_MonitorVM> Monitors { get; set; }
    }
}