using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentInformationSystem.Data.Migrations
{
    public partial class _03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 24,
                column: "DisplaySeq",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 25,
                column: "DisplaySeq",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 26,
                column: "DisplaySeq",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 27,
                column: "DisplaySeq",
                value: 20);

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "Action", "Area", "Controller", "DisplaySeq", "Icon", "IsHidden", "ParentMenuId", "Text", "Type" },
                values: new object[] { 29, "Process", "Report", "WeeklySummary", 40, null, false, 6, "Weekly Summary", "I" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 29);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 24,
                column: "DisplaySeq",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 25,
                column: "DisplaySeq",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 26,
                column: "DisplaySeq",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 27,
                column: "DisplaySeq",
                value: 30);
        }
    }
}
