using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentInformationSystem.Data.Migrations
{
    public partial class _04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Visitors",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 10,
                columns: new[] { "Controller", "Text" },
                values: new object[] { "Visitor", "Visitors" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 11,
                columns: new[] { "Controller", "Text" },
                values: new object[] { "Section", "Sections" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 12,
                columns: new[] { "Controller", "Text" },
                values: new object[] { "SectionHead", "Section Heads" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 13,
                columns: new[] { "Controller", "Text" },
                values: new object[] { "Grade", "Grades" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 14,
                columns: new[] { "Controller", "Text" },
                values: new object[] { "GradeHead", "Grade Heads" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 15,
                columns: new[] { "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Admin", "ExtraActivity", 90, 1, "Extra Activities" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 16,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "SubjectCategory", 10, "Subject Categories" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 17,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "Subject", 20, "Subjects" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 18,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "GradeSubject", 30, "Grade Subjects" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 19,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "GradeClass", 40, "Grade Classes" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 20,
                columns: new[] { "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Academic", "ClassRoom", 50, 2, "Physical Class Rooms" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 21,
                columns: new[] { "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Teacher", "Teacher", 20, 3, "Teacher Information" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 22,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "Student", 10, "Student Maintenance" });

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
                columns: new[] { "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Student", "StudentMark", 30, 4, "Student Marks" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 25,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "OnlineClassRoom", 10, "Online Class Rooms" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 26,
                columns: new[] { "Action", "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Index", "Online", "OnlineTimeTable", 20, 5, "Online Time Table" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 27,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "StudentAttendance", 10, "Student Attendance" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 28,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "StudentMarks", 20, "Term Wise Student Marks" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 29,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "OnlineSessionsSummary", 30, "Online Sessions Summary" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "Action", "Area", "Controller", "DisplaySeq", "Icon", "IsHidden", "ParentMenuId", "Text", "Type" },
                values: new object[] { 30, "Process", "Report", "WeeklySummary", 40, null, false, 6, "Weekly Summary", "I" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 30);

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Visitors");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 10,
                columns: new[] { "Controller", "Text" },
                values: new object[] { "Section", "Sections" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 11,
                columns: new[] { "Controller", "Text" },
                values: new object[] { "SectionHead", "Section Heads" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 12,
                columns: new[] { "Controller", "Text" },
                values: new object[] { "Grade", "Grades" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 13,
                columns: new[] { "Controller", "Text" },
                values: new object[] { "GradeHead", "Grade Heads" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 14,
                columns: new[] { "Controller", "Text" },
                values: new object[] { "ExtraActivity", "Extra Activities" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 15,
                columns: new[] { "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Academic", "SubjectCategory", 10, 2, "Subject Categories" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 16,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "Subject", 20, "Subjects" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 17,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "GradeSubject", 30, "Grade Subjects" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 18,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "GradeClass", 40, "Grade Classes" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 19,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "ClassRoom", 50, "Physical Class Rooms" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 20,
                columns: new[] { "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Teacher", "Teacher", 20, 3, "Teacher Information" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 21,
                columns: new[] { "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Student", "Student", 10, 4, "Student Maintenance" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 22,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "BasketSubject", 20, "Student Basket Subjects" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 23,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "StudentMark", 30, "Student Marks" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 24,
                columns: new[] { "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Online", "OnlineClassRoom", 10, 5, "Online Class Rooms" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 25,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "OnlineTimeTable", 20, "Online Time Table" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 26,
                columns: new[] { "Action", "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Process", "Report", "StudentAttendance", 10, 6, "Student Attendance" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 27,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "StudentMarks", 20, "Term Wise Student Marks" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 28,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "OnlineSessionsSummary", 30, "Online Sessions Summary" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 29,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "WeeklySummary", 40, "Weekly Summary" });
        }
    }
}
