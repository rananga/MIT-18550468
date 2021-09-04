using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentInformationSystem.Data.Migrations
{
    public partial class _16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeacherOffTimes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    TeacherId = table.Column<int>(nullable: false),
                    FromTime = table.Column<DateTime>(nullable: false),
                    ToTime = table.Column<DateTime>(nullable: false),
                    Reason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherOffTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teacher_OffTimes",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 21,
                column: "Text",
                value: "Teacher Subjects");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 22,
                columns: new[] { "Controller", "Text" },
                values: new object[] { "TeacherQualification", "Teacher Qualifications" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 23,
                columns: new[] { "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Teacher", "TeacherOffTime", 30, 3, "Teacher Off Times" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 24,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "Student", 10, "Student Maintenance" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 25,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "BasketSubject", 20, "Student Basket Subjects" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 26,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "StudentAdmit", 30, "Admit Student" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 27,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "StudentMark", 40, "Student Marks" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 28,
                columns: new[] { "Controller", "Text" },
                values: new object[] { "TransferStudent", "Transfer Student" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 29,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "ClassPromotion", 50, "Class Promotion" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 30,
                columns: new[] { "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Student", "StudentExtraActivities", 60, 4, "Student Extra Activities" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 31,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "OnlineClassRoom", 10, "Online Classrooms" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 32,
                columns: new[] { "Action", "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Index", "Online", "OnlineTimeTable", 20, 5, "Online Time Table" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 33,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "StudentCharacter", 10, "Student Character" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 34,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "StudentAttendance", 20, "Student Attendance" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 35,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "StudentMarks", 30, "Term Wise Student Marks" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 36,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "OnlineSessionsSummary", 40, "Online Sessions Summary" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "Action", "Area", "Controller", "DisplaySeq", "Icon", "IsHidden", "ParentMenuId", "Text", "Type" },
                values: new object[] { 37, "Process", "Report", "WeeklySummary", 50, null, false, 6, "Weekly Summary", "I" });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherOffTimes_TeacherId",
                table: "TeacherOffTimes",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherOffTimes");

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 37);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 21,
                column: "Text",
                value: "Teacher Information");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 22,
                columns: new[] { "Controller", "Text" },
                values: new object[] { "TeacherAvailability", "Teacher Availability" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 23,
                columns: new[] { "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Student", "Student", 10, 4, "Student Maintenance" });

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
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "StudentAdmit", 30, "Admit Student" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 26,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "StudentMark", 40, "Student Marks" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 27,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "TransferStudent", 50, "Transfer Student" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 28,
                columns: new[] { "Controller", "Text" },
                values: new object[] { "ClassPromotion", "Class Promotion" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 29,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "StudentExtraActivities", 60, "Student Extra Activities" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 30,
                columns: new[] { "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Online", "OnlineClassRoom", 10, 5, "Online Classrooms" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 31,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "OnlineTimeTable", 20, "Online Time Table" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 32,
                columns: new[] { "Action", "Area", "Controller", "DisplaySeq", "ParentMenuId", "Text" },
                values: new object[] { "Process", "Report", "StudentCharacter", 10, 6, "Student Character" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 33,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "StudentAttendance", 20, "Student Attendance" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 34,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "StudentMarks", 30, "Term Wise Student Marks" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 35,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "OnlineSessionsSummary", 40, "Online Sessions Summary" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 36,
                columns: new[] { "Controller", "DisplaySeq", "Text" },
                values: new object[] { "WeeklySummary", 50, "Weekly Summary" });
        }
    }
}
