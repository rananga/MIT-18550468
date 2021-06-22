using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text;

namespace StudentInformationSystem.Areas.Report.Models
{
    public class ReportParameterVM
    {
        public int Year { get; set; }
        [DisplayName("By Duration")]
        public bool ByDuration { get; set; }
    }
}
