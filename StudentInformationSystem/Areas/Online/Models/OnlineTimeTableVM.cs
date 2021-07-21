using StudentInformationSystem.Areas.Base.Models;
using StudentInformationSystem.Common;
using StudentInformationSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentInformationSystem.Areas.Online.Models
{
    public class OnlineTimeTableVM
    {
        public string JsonData { get; set; }
        [DisplayName("From Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FromDate { get; set; }
        [DisplayName("To Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ToDate { get; set; }
        [DisplayName("Grade")]
        public int GradeId { get; set; }
        [DisplayName("Teacher")]
        public int? StaffId { get; set; }
    }
}