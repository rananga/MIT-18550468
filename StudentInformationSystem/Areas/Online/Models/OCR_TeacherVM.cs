using StudentInformationSystem.Common;
using StudentInformationSystem.Data.Models;
using System;
using System.ComponentModel;
using System.Web;

namespace StudentInformationSystem.Areas.Online.Models
{
    public class OCR_TeacherVM : OCR_Teacher, IModel<OCR_Teacher, OCR_TeacherVM>
    {
        public OCR_TeacherVM()
        {
            mappings = new ObjMappings<OCR_Teacher, OCR_TeacherVM>();

            mappings.Add(x => $"{x.ClassTeacher.Title.ToEnumChar(null)} {x.ClassTeacher.FullName}", x => x.TeacherName);
        }

        public OCR_TeacherVM(OCR_Teacher obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<OCR_Teacher, OCR_TeacherVM> mappings { get; set; }

        [DisplayName("Teacher Name")]
        public string TeacherName { get; set; }
    }
}