using StudentInformationSystem.Common;
using StudentInformationSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace StudentInformationSystem.Areas.Online.Models
{
    public class OnlineClassVM : OnlineClass, IModel<OnlineClass, OnlineClassVM>
    {
        public OnlineClassVM()
        {
            mappings = new ObjMappings<OnlineClass, OnlineClassVM>();

            mappings.Add(x => x.OnlineClassRoom.Year, x => Year);
            mappings.Add(x => (int)x.OnlineClassRoom.Grade.GradeNo, x => GradeId);
            mappings.Add(x => new OnlineClassRoomVM(x.OnlineClassRoom), x => ocrVM);
            mappings.Add(x => new OCR_TeacherVM(x.OCR_Teacher), x => teacherVM);
        }

        public OnlineClassVM(OnlineClass obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<OnlineClass, OnlineClassVM> mappings { get; set; }

        public int Year { get; set; }
        [DisplayName("Grade")]
        public int GradeId { get; set; }

        public virtual OnlineClassRoomVM ocrVM { get; set; }
        public virtual OCR_TeacherVM teacherVM { get; set; }
    }
}