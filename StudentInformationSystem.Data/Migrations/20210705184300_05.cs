using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentInformationSystem.Data.Migrations
{
    public partial class _05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 20,
                column: "Text",
                value: "Physical Classrooms");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 25,
                column: "Text",
                value: "Online Classrooms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 20,
                column: "Text",
                value: "Physical Class Rooms");

            migrationBuilder.UpdateData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 25,
                column: "Text",
                value: "Online Class Rooms");
        }
    }
}
