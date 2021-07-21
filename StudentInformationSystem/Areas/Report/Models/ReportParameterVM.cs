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
        public int GradeId { get; set; }
        [DisplayName("Online Classroom")]
        public int OCR_Id { get; set; }
        [DisplayName("Teacher")]
        public int OCR_TeacherId { get; set; }
        [DisplayName("From Date")]
        public DateTime FromDate { get; set; }
        [DisplayName("To Date")]
        public DateTime ToDate { get; set; }
        [DisplayName("By Duration")]
        public bool ByDuration { get; set; }
    }
}
