using StudentInformationSystem.Common;
using StudentInformationSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace StudentInformationSystem.Areas.Online.Models
{
    public class OnlineClassRoomVM : OnlineClassRoom, IModel<OnlineClassRoom, OnlineClassRoomVM>
    {
        public OnlineClassRoomVM()
        {
            mappings = new ObjMappings<OnlineClassRoom, OnlineClassRoomVM>();
            ClassRooms = new HashSet<OCR_ClassRoomVM>();
            Teachers = new HashSet<OCR_TeacherVM>();

            mappings.Add(x => x.Grade.GradeNo.ToEnumChar(null), x => x.GradeName);
            mappings.Add(x => x.Subject.Code, x => x.SubjectName);
            mappings.Add(x => x.PhysicalClassRooms.Count == 0 ? x.Grade.GradeNo.ToEnumChar(null) : x.PhysicalClassRooms.Select(y => y.ClassRoom.GradeClass.Code).AggregateOrDefault((y, z) => y + ", " + z), x => x.ClassCode);
            mappings.Add(x => new OCR_TeacherVM(x.ClassTeachers.Where(y => y.IsOwner).FirstOrDefault()).TeacherName, x => x.TeacherName);
            mappings.Add(x => x.PhysicalClassRooms.Select(y => new OCR_ClassRoomVM(y)).ToList(), x => x.ClassRooms);
            mappings.Add(x => x.ClassTeachers.Select(y => new OCR_TeacherVM(y)).ToList(), x => x.Teachers);
        }

        public OnlineClassRoomVM(OnlineClassRoom obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<OnlineClassRoom, OnlineClassRoomVM> mappings { get; set; }

        [DisplayName("Grade")]
        public string GradeName { get; set; }
        [DisplayName("Subject")]
        public string SubjectName { get; set; }
        [DisplayName("Class Teacher")]
        public string TeacherName { get; set; }
        [DisplayName("Class Code")]
        public string ClassCode { get; set; }

        public virtual ICollection<OCR_ClassRoomVM> ClassRooms { get; set; }
        public virtual ICollection<OCR_TeacherVM> Teachers { get; set; }
    }
}