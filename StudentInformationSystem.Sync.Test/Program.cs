using StudentInformationSystem.Data;
using System;

namespace StudentInformationSystem.Sync.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            string val;
            Console.Write("Do you want to run the Attendance Sync? (y=Yes, enter=Skip)");
            val = Console.ReadLine();

            if (val.Trim().ToLower() == "y")
                SyncAttendance.RunIt(null, new dbNalandaContext());

            Console.Write("Do you want to run the Student Sync? (y=Yes, enter=Skip)");
            val = Console.ReadLine();

            if (val.Trim().ToLower() == "y")
                SyncStudents.RunIt(null, new dbNalandaContext());

            Console.Write("Sync completed. Press any key to terminate.");
            Console.ReadLine();
        }
    }
}
