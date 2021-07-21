using StudentInformationSystem.Areas.Base.Models;
using StudentInformationSystem.Common;
using StudentInformationSystem.Data;
using StudentInformationSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentInformationSystem.Areas.Student.Models
{
    public class StudentAdmitVM
    {
        public int Year { get; set; }
        public int GradeId { get; set; }
    }
}