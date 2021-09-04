using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentInformationSystem.Data.Migrations
{
    public partial class _15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 7,
                columns: new[] { "Controller", "Text" },
                values: new object[] { "Section", "Sections" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 8,
                columns: new[] { "Controller", "Text" },
                values: new object[] { "Grade", "Grades" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 11,
                columns: new[] { "Controller", "Text" },
                values: new object[] { "UserPermission", "User Permissions" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 12,
                columns: new[] { "Controller", "Text" },
                values: new object[] { "Users", "Users" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 13,
                columns: new[] { "Controller", "Text" },
                values: new object[] { "SectionHead", "Section Heads" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 7,
                columns: new[] { "Controller", "Text" },
                values: new object[] { "UserPermission", "User Permissions" });

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 8,
                columns: new[] { "Controller", "Text" },
                values: new object[] { "Users", "Users" });

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
        }
    }
}
