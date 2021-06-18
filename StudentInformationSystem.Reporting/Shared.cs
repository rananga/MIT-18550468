using System.IO;
using System.Reflection;

namespace StudentInformationSystem.Reporting.Models
{
    public class Shared
    {
        public static Stream GetReportStream(string reportName)
        {         
            var currentAssem = Assembly.GetExecutingAssembly();
            return currentAssem.GetManifestResourceStream($"{currentAssem.GetName().Name}.Reports.{reportName}.rdlc");
        }
    }
}
