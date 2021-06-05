using Nalanda.SMS.Data;
using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Linq;

namespace Nalanda.SMS.Areas.Admin.Models
{
    public class TeacherVM : Teacher, IModel<Teacher, TeacherVM>
    {

        public TeacherVM()
        {
            mappings = new ObjMappings<Teacher, TeacherVM>();
            Subjects = new HashSet<TeacherSubjectVM>();

            mappings.Add(x => x.Title + ". " + x.FullName, x => x.TeacherName);
            mappings.Add(x => x.TeacherSubjects.Select(y=> new TeacherSubjectVM(y)).ToList(), x => x.Subjects);
        }
        public TeacherVM(Teacher obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<Teacher, TeacherVM> mappings { get;  set; }

        [DisplayName("Teacher Name")]
        public string TeacherName { get; set; }

        public virtual ICollection<TeacherSubjectVM> Subjects { get; set; }
    }
}