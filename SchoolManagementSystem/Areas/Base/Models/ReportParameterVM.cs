using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SMS.Areas.Base.Models
{
    public class ReportParameterVM
    {
        [DisplayName("Branch")]
        public int? BranchID { get; set; }
        [DisplayName("Department")]
        public int? DepartmentID { get; set; }
        [DisplayName("Course")]
        public int? CourseID { get; set; }
        [DisplayName("Batch")]
        public int? BatchID { get; set; }
        [DisplayName("From Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FromDate { get; set; }
        [DisplayName("To Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ToDate { get; set; }
        [DisplayName("General Code")]
        public int? NumericPara1 { get; set; }
        public int? NumericPara2 { get; set; }
        [DisplayName("Employee")]
        public int? EmployeeID { get; set; }
        [DisplayName("Vehicle No")]
        public int? VehicleID { get; set; }
        public int? SubLecID { get; set; }
        [DisplayName("Registration No")]
        public string RegistrationNo { get; set; }
        [DisplayName("Exam Schedule")]
        public int? ExamScheduleID { get; set; }
        [DisplayName("List Start Number")]
        public int? ListStart { get; set; } = 1;
        [DisplayName("List End Number")]
        public int? ListEnd { get; set; }
        [DisplayName("No of Class Students")]
        public int? NoOfCandidates { get; set; }
        [DisplayName("No of Repeat Students")]
        public int? NoOfRepeaters { get; set; }
        [DisplayName("No of Medical Students")]
        public int? NoOfMedicals { get; set; }
        [DisplayName("Total Candidates")]
        public int? TotalCandidates { get; set; }
        [DisplayName("Hall Name")]
        public string HallName { get; set; }
        [DisplayName("Hall Max Capacity")]
        public string HallExamCapacity { get; set; }
        [DisplayName("Select All Employees")]
        public bool SelectAllEmploye { get; set; }
        [DisplayName("Select All Vehicles")]
        public bool SelectAllVehicles { get; set; }

        [DisplayName("From Date 2")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FromDate2 { get; set; }
        [DisplayName("To Date 2")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ToDate2 { get; set; }

        [DisplayName("Is Special")]
        public bool IsSpecial { get; set; }
        [DisplayName("Duration From")]
        public int? KpiDateID { get; set; }
        [DisplayName("Student")]
        public int StudentID { get; set; }
        [DisplayName("Class")]
        public int ClassID { get; set; }
        [DisplayName("Period Start Date")]
        public int PeriodID { get; set; }
        [DisplayName("Period End Date")]
        public string PeriodTo { get; set; }
        [DisplayName("Meeting Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? MeetingDate { get; set; }

        [DisplayName("Period Start Date")]
        public int PeriodID2 { get; set; }
        [DisplayName("Period End Date")]
        public string PeriodTo2 { get; set; }

        public ICollection<int> BranchIDs { get; set; }
        [DisplayName("Envelope Type")]
        public SMS.Common.EnvelopType EnvelopType { get; set; }

        public Dictionary<int, List<DateTime>> FingerPrintDictionary { get; set; }
        
        public bool IsLecturer { get; set; }
        
        [DisplayName("Branch")]
        public string Branch { get; set; }
        [DisplayName("Department")]
        public string Department { get; set; }
        public bool AdminDG { get; set; }
        public bool evaluationUser { get; set; }

        
    }
}