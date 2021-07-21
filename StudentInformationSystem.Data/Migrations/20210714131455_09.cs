using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentInformationSystem.Data.Migrations
{
    public partial class _09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 21,
                column: "DisplaySeq",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 22,
                columns: new[] { "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Teacher", "TeacherAvailability", 20, 3, "Teacher Availability" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 23,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "Student", 10, "Student Maintenance" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 24,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "BasketSubject", 20, "Student Basket Subjects" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 25,
                columns: new[] { "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Student", "StudentAdmit", 30, 4, "Admit Student" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 26,
                columns: new[] { "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Student", "StudentMark", 40, 4, "Student Marks" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 27,
                columns: new[] { "Action", "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Index", "Student", "TransferStudent", 50, 4, "Transfer Student" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 28,
                columns: new[] { "Action", "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Index", "Student", "ClassPromotion", 50, 4, "Class Promotion" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 29,
                columns: new[] { "Action", "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Index", "Student", "StudentExtraActivities", 60, 4, "Student Extra Activities" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 30,
                columns: new[] { "Action", "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Index", "Online", "OnlineClassRoom", 10, 5, "Online Classrooms" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "Action", "Area", "Controller", "DisplaySeq", "Icon", "IsHidden", "ParentMenuId", "Text", "Type" },
                values: new object[,]
                {
                    { 31, "Index", "Online", "OnlineTimeTable", 20, null, false, 5, "Online Time Table", "I" },
                    { 32, "Process", "Report", "StudentCharacter", 10, null, false, 6, "Student Character", "I" },
                    { 33, "Process", "Report", "StudentAttendance", 20, null, false, 6, "Student Attendance", "I" },
                    { 34, "Process", "Report", "StudentMarks", 30, null, false, 6, "Term Wise Student Marks", "I" },
                    { 35, "Process", "Report", "OnlineSessionsSummary", 40, null, false, 6, "Online Sessions Summary", "I" },
                    { 36, "Process", "Report", "WeeklySummary", 50, null, false, 6, "Weekly Summary", "I" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 36);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 21,
                column: "DisplaySeq",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 22,
                columns: new[] { "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Student", "Student", 10, 4, "Student Maintenance" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 23,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "BasketSubject", 20, "Student Basket Subjects" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 24,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "StudentMark", 30, "Student Marks" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 25,
                columns: new[] { "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Online", "OnlineClassRoom", 10, 5, "Online Classrooms" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 26,
                columns: new[] { "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Online", "OnlineTimeTable", 20, 5, "Online Time Table" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 27,
                columns: new[] { "Action", "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Process", "Report", "StudentAttendance", 10, 6, "Student Attendance" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 28,
                columns: new[] { "Action", "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Process", "Report", "StudentMarks", 20, 6, "Term Wise Student Marks" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 29,
                columns: new[] { "Action", "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Process", "Report", "OnlineSessionsSummary", 30, 6, "Online Sessions Summary" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 30,
                columns: new[] { "Action", "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Process", "Report", "WeeklySummary", 40, 6, "Weekly Summary" });
        }
    }
}
