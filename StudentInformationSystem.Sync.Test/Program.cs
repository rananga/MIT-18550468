using StudentInformationSystem.Data;

namespace StudentInformationSystem.Sync.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            SyncAttendance.RunIt(null, new dbNalandaContext());
        }
    }
}
