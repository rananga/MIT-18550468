using Microsoft.Reporting.WebForms;
using StudentInformationSystem.Areas.Base;
using StudentInformationSystem.Areas.Report.Models;
using StudentInformationSystem.Reporting.Models;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;

namespace StudentInformationSystem.Areas.Report.Controllers
{
    public class StudentMarksController : BaseController
    {
        public ActionResult Process(bool? viewIt)
        {
            if (viewIt != true)
            {
                return View();
            }

            return GetPdfStream();
        }

        [HttpPost]
        public ActionResult Process(ReportParameterVM para)
        {
            return Json(new { viewIt = true });
        }
        [HttpPost]
        public ActionResult Excel(ReportParameterVM para)
        {
            return Json(new { viewIt = true });
        }

        private List<StudentMarks> GetStudentMarks()
        {
            var lst = new List<StudentMarks>()
            {
                new StudentMarks(){ AdmissionNo = 27616, CurrentClass = "6A", MarksTerm1 = 851, MarksTerm2 = 851, MarksTerm3 = 851, StudentName = "H.S.C.Ayan Perera" },
                new StudentMarks(){ AdmissionNo = 28533, CurrentClass = "6A", MarksTerm1 = 842, MarksTerm2 = 842, MarksTerm3 = 842, StudentName = "S. D. Epa Seneviratne" },
                new StudentMarks(){ AdmissionNo = 27691, CurrentClass = "6A", MarksTerm1 = 833, MarksTerm2 = 833, MarksTerm3 = 833, StudentName = "V. Linash Alahendra" },
                new StudentMarks(){ AdmissionNo = 27701, CurrentClass = "6A", MarksTerm1 = 824, MarksTerm2 = 824, MarksTerm3 = 824, StudentName = "U. Rasul Premarathna" },
                new StudentMarks(){ AdmissionNo = 27911, CurrentClass = "6A", MarksTerm1 = 815, MarksTerm2 = 815, MarksTerm3 = 815, StudentName = "H. K. S. R. Amarakeerthi" },
                new StudentMarks(){ AdmissionNo = 27653, CurrentClass = "6A", MarksTerm1 = 806, MarksTerm2 = 806, MarksTerm3 = 806, StudentName = "Manjitha N. L. Rajapaksha" },
                new StudentMarks(){ AdmissionNo = 27671, CurrentClass = "6A", MarksTerm1 = 817, MarksTerm2 = 817, MarksTerm3 = 817, StudentName = "D. M. Kashyapa D. R. Dissanayake" },
                new StudentMarks(){ AdmissionNo = 27710, CurrentClass = "6A", MarksTerm1 = 828, MarksTerm2 = 828, MarksTerm3 = 828, StudentName = "S. Nethmika Vithana" },
                new StudentMarks(){ AdmissionNo = 27676, CurrentClass = "6A", MarksTerm1 = 839, MarksTerm2 = 839, MarksTerm3 = 839, StudentName = "U. P. A. Keshawa D. Amarasinghe" },
                new StudentMarks(){ AdmissionNo = 27751, CurrentClass = "6A", MarksTerm1 = 840, MarksTerm2 = 840, MarksTerm3 = 840, StudentName = "T. M. Thisuka D. Rodrigo" },
                new StudentMarks(){ AdmissionNo = 27730, CurrentClass = "6A", MarksTerm1 = 859, MarksTerm2 = 859, MarksTerm3 = 859, StudentName = "H. K. S. Dinsara Habaraduwa" },
                new StudentMarks(){ AdmissionNo = 27630, CurrentClass = "6A", MarksTerm1 = 868, MarksTerm2 = 868, MarksTerm3 = 868, StudentName = "T. V. D. Akindu Mandiw Vitharana" },
                new StudentMarks(){ AdmissionNo = 27696, CurrentClass = "6B", MarksTerm1 = 877, MarksTerm2 = 877, MarksTerm3 = 877, StudentName = "P. D. B. Devmith Padukka" },
                new StudentMarks(){ AdmissionNo = 27720, CurrentClass = "6B", MarksTerm1 = 886, MarksTerm2 = 886, MarksTerm3 = 886, StudentName = "K. A. V. Hemsandu Thilakarathna" },
                new StudentMarks(){ AdmissionNo = 27626, CurrentClass = "6B", MarksTerm1 = 895, MarksTerm2 = 895, MarksTerm3 = 895, StudentName = "D. K. Yenula Manumitha Dissanayake" },
                new StudentMarks(){ AdmissionNo = 27641, CurrentClass = "6B", MarksTerm1 = 884, MarksTerm2 = 884, MarksTerm3 = 884, StudentName = "K. P. A. Vinuka Kathriarachchi" },
                new StudentMarks(){ AdmissionNo = 28414, CurrentClass = "6B", MarksTerm1 = 873, MarksTerm2 = 873, MarksTerm3 = 873, StudentName = "Vihas Dintharu Karunaratne" },
                new StudentMarks(){ AdmissionNo = 28882, CurrentClass = "6B", MarksTerm1 = 862, MarksTerm2 = 862, MarksTerm3 = 862, StudentName = "Ositha H. Gunasekara J. H." },
                new StudentMarks(){ AdmissionNo = 27746, CurrentClass = "6B", MarksTerm1 = 851, MarksTerm2 = 851, MarksTerm3 = 851, StudentName = "C. Devmeth Jayawardana" },
                new StudentMarks(){ AdmissionNo = 27715, CurrentClass = "6B", MarksTerm1 = 840, MarksTerm2 = 840, MarksTerm3 = 840, StudentName = "H. Danuja D. Hettiarachchi" },
                new StudentMarks(){ AdmissionNo = 27735, CurrentClass = "6B", MarksTerm1 = 830, MarksTerm2 = 830, MarksTerm3 = 830, StudentName = "R. Manura Pabasara" },
                new StudentMarks(){ AdmissionNo = 27636, CurrentClass = "6B", MarksTerm1 = 821, MarksTerm2 = 821, MarksTerm3 = 821, StudentName = "G. B. C. Dulnith Senevirathna" },
                new StudentMarks(){ AdmissionNo = 27725, CurrentClass = "6B", MarksTerm1 = 812, MarksTerm2 = 812, MarksTerm3 = 812, StudentName = "H. D. Vinuka T. Pudasara" },
                new StudentMarks(){ AdmissionNo = 27849, CurrentClass = "6B", MarksTerm1 = 823, MarksTerm2 = 823, MarksTerm3 = 823, StudentName = "Vethum Damsak Vithanawasam" },
                new StudentMarks(){ AdmissionNo = 27666, CurrentClass = "6C", MarksTerm1 = 834, MarksTerm2 = 834, MarksTerm3 = 834, StudentName = "K. M. D. Boseth Kaluwila" },
                new StudentMarks(){ AdmissionNo = 27602, CurrentClass = "6C", MarksTerm1 = 845, MarksTerm2 = 845, MarksTerm3 = 845, StudentName = "M. Sithula Gunawardana" },
                new StudentMarks(){ AdmissionNo = 27657, CurrentClass = "6C", MarksTerm1 = 856, MarksTerm2 = 856, MarksTerm3 = 856, StudentName = "S. A. D. R. Vilan Samaratunge" },
                new StudentMarks(){ AdmissionNo = 27601, CurrentClass = "6C", MarksTerm1 = 867, MarksTerm2 = 867, MarksTerm3 = 867, StudentName = "M. Aritha Gunawardana" },
                new StudentMarks(){ AdmissionNo = 27696, CurrentClass = "6C", MarksTerm1 = 878, MarksTerm2 = 878, MarksTerm3 = 878, StudentName = "Saman Dissanayake" },
                new StudentMarks(){ AdmissionNo = 27611, CurrentClass = "6C", MarksTerm1 = 889, MarksTerm2 = 889, MarksTerm3 = 889, StudentName = "P. D. B. Devmith Padukka" },
                new StudentMarks(){ AdmissionNo = 28025, CurrentClass = "6C", MarksTerm1 = 891, MarksTerm2 = 891, MarksTerm3 = 891, StudentName = "E. E. A. P. Karunarathne" },
                new StudentMarks(){ AdmissionNo = 27696, CurrentClass = "6C", MarksTerm1 = 802, MarksTerm2 = 802, MarksTerm3 = 802, StudentName = "Dinethya Indumina Senarath H. A." },
                new StudentMarks(){ AdmissionNo = 28652, CurrentClass = "6C", MarksTerm1 = 813, MarksTerm2 = 813, MarksTerm3 = 813, StudentName = "P. D. B. Devmith Padukka" },
                new StudentMarks(){ AdmissionNo = 27844, CurrentClass = "6C", MarksTerm1 = 824, MarksTerm2 = 824, MarksTerm3 = 824, StudentName = "Hasandu Kethmira Weerasooriya Arachchige" },
                new StudentMarks(){ AdmissionNo = 27686, CurrentClass = "6C", MarksTerm1 = 835, MarksTerm2 = 835, MarksTerm3 = 835, StudentName = "B. A. T. Sendika Balasuriya" },
                new StudentMarks(){ AdmissionNo = 27706, CurrentClass = "6C", MarksTerm1 = 846, MarksTerm2 = 846, MarksTerm3 = 846, StudentName = "D. S. D. Sachintha Sekara" }
            };

            return lst;
        }

        private FileStreamResult GetPdfStream()
        {
            LocalReport report = new LocalReport();
            report.LoadReportDefinition(Shared.GetReportStream("StudentMarks"));

            report.SetParameters(new ReportParameter("Year", "2021"));
            report.SetParameters(new ReportParameter("Grade", "6"));
            report.SetParameters(new ReportParameter("OrderBy", "2"));

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "StudentMarks";
            rds.Value = GetStudentMarks();
            report.DataSources.Add(rds);

            byte[] mybytes = report.Render("PDF");

            Response.AppendHeader("content-disposition", "inline; filename=file.pdf");
            return new FileStreamResult(new MemoryStream(mybytes), "application/pdf");
        }
    }
}