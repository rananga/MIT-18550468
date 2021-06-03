using Nalanda.SMS.Data;
using Nalanda.SMS.Data.Models;
using Nalanda.SMS.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Nalanda.SMS.Areas.Admin.Models
{
    public class TeacherVM : Teacher, IModel<Teacher, TeacherVM>
    {

        public TeacherVM()
        {
            mappings = new ObjMappings<Teacher, TeacherVM>();

            mappings.Add(x => x.Title + ". " + x.Initials + " " + x.Lname, x => x.NameWithInit);
            mappings.Add(x => x.Title + ". " + x.FullName, x => x.NameWithTitle);
        }
        public TeacherVM(Teacher obj) : this()
        {
            this.SetEntity(obj);
        }
        public ObjMappings<Teacher, TeacherVM> mappings { get;  set; }

        [DisplayName("Teacher Name")]
        public string NameWithInit { get; set; }
        [DisplayName("Teacher Name")]
        public string NameWithTitle { get; set; }    
    }
}