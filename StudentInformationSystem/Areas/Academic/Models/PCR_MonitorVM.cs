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
    public class PCR_MonitorVM : PCR_Monitor, IModel<PCR_Monitor, PCR_MonitorVM>
    {
        public PCR_MonitorVM()
        {
            mappings = new ObjMappings<PCR_Monitor, PCR_MonitorVM>();

            mappings.Add(x => x.Student.AdmissionNo, x => x.StudentIndex);
            mappings.Add(x => x.Student.FullName, x => x.StudentName);
        }

        public PCR_MonitorVM(PCR_Monitor obj, params string[] properties) : this()
        {
            this.SetEntity(obj, properties);
        }
        public ObjMappings<PCR_Monitor, PCR_MonitorVM> mappings { get; set; }

        [DisplayName("Admission No")]
        public int StudentIndex { get; set; }
        [DisplayName("Name")]
        public string StudentName { get; set; }
    }
}