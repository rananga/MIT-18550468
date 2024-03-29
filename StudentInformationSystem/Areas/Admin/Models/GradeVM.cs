﻿using StudentInformationSystem.Areas.Academic.Models;
using StudentInformationSystem.Common;
using StudentInformationSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace StudentInformationSystem.Areas.Admin.Models
{
    public class GradeVM : Grade, IModel<Grade, GradeVM>
    {
        public GradeVM()
        {
            mappings = new ObjMappings<Grade, GradeVM>();
            mappings.Add(x => x.GradeNo.ToEnumChar(null), x => x.GradeName);
            mappings.Add(x => x.Section.Code, x => x.SectionName);
            mappings.Add(x => x.GradeSubjects.Select(y => new GradeSubjectVM(y)).ToList(), x => x.Subjects);
        }

        public GradeVM(Grade obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<Grade, GradeVM> mappings { get; set; }

        [DisplayName("Grade")]
        public string GradeName { get; set; }
        [DisplayName("Section")]
        public string SectionName { get; set; }

        [DisplayName("Grade")]
        public new int Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        public virtual ICollection<GradeSubjectVM> Subjects { get; set; }
    }
}