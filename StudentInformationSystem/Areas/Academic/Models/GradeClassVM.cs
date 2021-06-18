using StudentInformationSystem.Common;
using StudentInformationSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace StudentInformationSystem.Areas.Academic.Models
{
    public class GradeClassVM : GradeClass, IModel<GradeClass, GradeClassVM>
    {
        public GradeClassVM()
        {
            mappings = new ObjMappings<GradeClass, GradeClassVM>();
            ClassSubjects = new HashSet<GradeClassSubjectVM>();

            mappings.Add(x => x.Grade.GradeNo.ToEnumChar(null), x => x.GradeName);
            mappings.Add(x => x.GradeClassSubjects.Select(y => new GradeClassSubjectVM(y)).ToList(), x => x.ClassSubjects);
        }

        public GradeClassVM(GradeClass obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<GradeClass, GradeClassVM> mappings { get; set; }

        [DisplayName("Grade")]
        public string GradeName { get; set; }

        public virtual ICollection<GradeClassSubjectVM> ClassSubjects { get; set; }
    }
}