using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Linq;

namespace StudentInformationSystem.Areas.Teacher.Models
{
    public class TeacherVM : Data.Models.Teacher, IModel<Data.Models.Teacher, TeacherVM>
    {

        public TeacherVM()
        {
            mappings = new ObjMappings<Data.Models.Teacher, TeacherVM>();
            PreferedSubjects = new HashSet<TeacherPreferedSubjectVM>();
            OffTimes = new HashSet<TeacherOffTimeVM>();
            Qualifications = new HashSet<TeacherQualificationVM>();

            mappings.Add(x => x.StaffMember.Title + ". " + x.StaffMember.FullName, x => x.TeacherName);
            mappings.Add(x => x.StaffMember.StaffNumber, x => x.StaffNumber);
            mappings.Add(x => x.StaffMember.Nicno, x => x.NICNo);
            mappings.Add(x => x.TeacherPreferedSubjects.Select(y=> new TeacherPreferedSubjectVM(y)).ToList(), x => x.PreferedSubjects);
            mappings.Add(x => x.TeacherOffTimes.Select(y => new TeacherOffTimeVM(y)).ToList(), x => x.OffTimes);
            mappings.Add(x => x.TeacherQualifications.Select(y => new TeacherQualificationVM(y)).ToList(), x => x.Qualifications);
        }
        public TeacherVM(Data.Models.Teacher obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<Data.Models.Teacher, TeacherVM> mappings { get;  set; }

        [DisplayName("Teacher Name")]
        public string TeacherName { get; set; }
        [DisplayName("Staff Number")]
        public int? StaffNumber { get; set; }
        [DisplayName("NIC No")]
        public string NICNo { get; set; }

        public virtual ICollection<TeacherPreferedSubjectVM> PreferedSubjects { get; set; }

        public virtual ICollection<TeacherOffTimeVM> OffTimes { get; set; }

        public virtual ICollection<TeacherQualificationVM> Qualifications { get; set; }

        [DisplayName("Teacher")]
        public new int Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }
    }
}