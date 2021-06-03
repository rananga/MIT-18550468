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
    public class ClassVM : Class, IModel<Class, ClassVM>
    {
        public ClassVM()
        {
            mappings = new ObjMappings<Class, ClassVM>();
            mappings.Add(x => x.ClassDesc, x => x.ClassDesc);
        }

        public ClassVM(Class obj, params string[] properties) : this()
        {
            this.SetEntity(obj, properties);
        }
        public ObjMappings<Class, ClassVM> mappings { get; set; }

        public virtual ICollection<ClassStudent> ClassStudents { get; set; }
    }
}