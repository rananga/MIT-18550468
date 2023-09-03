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
    public class PhysicalClassRoomVM : PhysicalClassRoom, IModel<PhysicalClassRoom, PhysicalClassRoomVM>
    {
        public PhysicalClassRoomVM()
        {
            mappings = new ObjMappings<PhysicalClassRoom, PhysicalClassRoomVM>();
            Subjects = new HashSet<PCR_SubjectVM>();
            Students = new HashSet<PCR_StudentVM>();
            Teachers = new HashSet<PCR_TeacherVM>();

            mappings.Add(x => x.GradeClass.Code, x => x.GradeClassDesc);
            mappings.Add(x => x.GradeClass.Name, x => x.ClassName);
            mappings.Add(x => new PCR_TeacherVM(x.ClassTeachers.Where(y=> y.FromDate < DateTime.Now && y.ToDate > DateTime.Now).FirstOrDefault()).TeacherName, x => x.ClassTeacherName);
            mappings.Add(x => x.ClassSubjects.Select(y => new PCR_SubjectVM(y)).ToList(), x => x.Subjects);
            mappings.Add(x => x.ClassStudents.Select(y => new PCR_StudentVM(y)).ToList(), x => x.Students);
            mappings.Add(x => x.ClassTeachers.Select(y => new PCR_TeacherVM(y)).ToList(), x => x.Teachers);
            mappings.Add(x => x.ClassMonitors.Select(y => new PCR_MonitorVM(y)).ToList(), x => x.Monitors);
            mappings.Add(x => x.ClassStudents.Count, x => x.StudentCount);
        }

        public PhysicalClassRoomVM(PhysicalClassRoom obj, params string[] properties) : this()
        {
            this.SetEntity(obj, properties);
        }
        public ObjMappings<PhysicalClassRoom, PhysicalClassRoomVM> mappings { get; set; }

        [DisplayName("Grade Class")]
        public string GradeClassDesc { get; set; }
        [DisplayName("Class Teacher")]
        public string ClassTeacherName { get; set; }
        public int StudentCount { get; set; }
        public Classes ClassName { get; set; }

        public virtual ICollection<PCR_SubjectVM> Subjects { get; set; }
        public virtual ICollection<PCR_StudentVM> Students { get; set; }
        public virtual ICollection<PCR_TeacherVM> Teachers { get; set; }
        public virtual ICollection<PCR_MonitorVM> Monitors { get; set; }
    }
}