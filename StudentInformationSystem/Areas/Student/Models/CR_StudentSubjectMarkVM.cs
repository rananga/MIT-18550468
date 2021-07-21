using StudentInformationSystem.Areas.Base.Models;
using StudentInformationSystem.Common;
using StudentInformationSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentInformationSystem.Areas.Student.Models
{
    public class CR_StudentSubjectMarkVM : CR_StudentSubjectMark, IModel<CR_StudentSubjectMark, CR_StudentSubjectMarkVM>
    {
        public CR_StudentSubjectMarkVM()
        {
            mappings = new ObjMappings<CR_StudentSubjectMark, CR_StudentSubjectMarkVM>();

            mappings.Add(x => x.CR_StudentSubject.CR_Student.StudentId, x => x.StudentId);
            mappings.Add(x => x.CR_StudentSubject.CR_Student.Student.FullName, x => x.StudentName);
        }

        public CR_StudentSubjectMarkVM(CR_StudentSubjectMark obj) : this()
        {
            this.SetEntity(obj);
        }

        public ObjMappings<CR_StudentSubjectMark, CR_StudentSubjectMarkVM> mappings { get; set; }

        public int StudentId { get; set; }
        public int IndexNo { get; set; }
        public string StudentName { get; set; }
    }
}