using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentInformationSystem.Areas.Report.Models
{
    public class ReportParameterVM
    {
        public int Year { get; set; }
        [DisplayName("Grade")]
        public int GradeId { get; set; }
        [DisplayName("Online Classroom")]
        public int OCR_Id { get; set; }
        [DisplayName("Teacher")]
        public int OCR_TeacherId { get; set; }
        [DisplayName("From Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FromDate { get; set; }
        [DisplayName("To Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ToDate { get; set; }
        [DisplayName("By Duration")]
        public bool ByDuration { get; set; }
    }
}
