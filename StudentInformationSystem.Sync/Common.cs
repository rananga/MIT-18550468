using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentInformationSystem.Data;
using System;

namespace StudentInformationSystem.Sync
{
    public static class Common
    {
        public static void LogIt(ILogger log, dbNalandaContext db, LogSevierity sevierity, string logMsg)
        {
            if (log != null)
            {
                switch (sevierity)
                {
                    case LogSevierity.Info:
                        log.LogInformation(logMsg);
                        break;
                    case LogSevierity.Warning:
                        log.LogWarning(logMsg);
                        break;
                    case LogSevierity.Error:
                        log.LogError(logMsg);
                        break;
                }
            }
            else
                Console.WriteLine(logMsg);

            var commandText = "INSERT SyncLogs (LogDate, Sevierity, Message) VALUES (@LogDate, @Sevierity, @Message)";
            var arg1 = new SqlParameter("@LogDate", DateTime.Now);
            var arg2 = new SqlParameter("@Sevierity", (int)sevierity);
            var arg3 = new SqlParameter("@Message", logMsg);
            db.Database.ExecuteSqlRaw(commandText, arg1, arg2, arg3);
        }
    }

    public enum LogSevierity
    {
        Info = 0,
        Warning = 1,
        Error = 2
    }
}