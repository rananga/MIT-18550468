using Google.Apis.Admin.Reports.reports_v1;
using Google.Apis.Admin.Reports.reports_v1.Data;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace StudentInformationSystem.Sync
{
    public class GoogleApiHelper
    {
        private static GoogleApiHelper _instance;
        public static GoogleApiHelper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GoogleApiHelper();
                return _instance;
            }
        }

        public static string ReadCredentialsJson()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().First(s => s.EndsWith("credentials.json", StringComparison.CurrentCultureIgnoreCase));

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new InvalidOperationException("Could not load credentials.json.");
                }
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public ServiceAccountCredential GetCredentials(string user = null)
        {
            var jsonContent = ReadCredentialsJson();
            Newtonsoft.Json.Linq.JObject cr = (Newtonsoft.Json.Linq.JObject)JsonConvert.DeserializeObject(jsonContent);
            string pk = (string)cr.GetValue("private_key");
            string ce = (string)cr.GetValue("client_email");

            var initializer = new ServiceAccountCredential.Initializer(ce)
            {
                Scopes = new string[] {
                    //ClassroomService.Scope.ClassroomCoursesReadonly,
                    //ClassroomService.Scope.ClassroomRosters,
                    //ClassroomService.Scope.ClassroomProfileEmails,
                    //ClassroomService.Scope.ClassroomAnnouncements,
                    //CalendarService.Scope.Calendar,
                    //CalendarService.Scope.CalendarEvents,
                    ReportsService.Scope.AdminReportsAuditReadonly,
                    //DirectoryService.Scope.AdminDirectoryGroup,
                    //DirectoryService.Scope.AdminDirectoryGroupMember,
                    //DirectoryService.Scope.AdminDirectoryUser,
                    //ClassroomService.Scope.ClassroomCourseworkStudents,
                }
            };
            initializer.User = user ?? "tt@nalandacollege.info";

            return new ServiceAccountCredential(initializer.FromPrivateKey(pk));
        }

        public List<Activity> GetAuditActivities(DateTime FromDate, DateTime? ToDate = null)
        {
            if (FromDate.Year < 2000)
                FromDate = new DateTime(DateTime.Now.Year - 1, 1, 1);

            var serviceInitializer = new BaseClientService.Initializer()
            {
                HttpClientInitializer = GetCredentials()
            };

            var service = new ReportsService(serviceInitializer);

            var activities = new List<Activity>();
            string pageToken = null;
            do
            {
                ActivitiesResource.ListRequest request = service.Activities
                    .List("all", ActivitiesResource.ListRequest.ApplicationNameEnum.Meet);
                request.StartTime = FromDate.ToString("yyyy-MM-dd'T'HH:mm:ss.fff") + "+05:30";
                if (ToDate != null)
                    request.EndTime = ToDate.Value.ToString("yyyy-MM-dd'T'HH:mm:ss.fff") + "+05:30";
                request.MaxResults = 1000;
                request.PageToken = pageToken;
                var response = request.Execute();
                if (response.Items != null && response.Items.Count > 0)
                    activities.AddRange(response.Items);
                pageToken = response.NextPageToken;
            } while (pageToken != null);

            return activities;
        }
    }
}
