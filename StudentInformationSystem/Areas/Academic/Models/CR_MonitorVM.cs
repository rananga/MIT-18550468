using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using StudentInformationSystem.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace StudentInformationSystem.Areas.Academic.Models
{
    public class CR_MonitorVM : CR_Monitor, IModel<CR_Monitor, CR_MonitorVM>
    {
        public CR_MonitorVM()
        {
            mappings = new ObjMappings<CR_Monitor, CR_MonitorVM>();

            mappings.Add(x => x.Student.IndexNo, x => x.StudentIndex);
            mappings.Add(x => x.Student.FullName, x => x.StudentName);
        }

        public CR_MonitorVM(CR_Monitor obj, params string[] properties) : this()
        {
            this.SetEntity(obj, properties);
        }
        public ObjMappings<CR_Monitor, CR_MonitorVM> mappings { get; set; }

        [DisplayName("Admission No")]
        public int StudentIndex { get; set; }
        [DisplayName("Name")]
        public string StudentName { get; set; }
    }
}