using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentInformationSystem.Data.Migrations
{
    public partial class _06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdmittedClassId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "AdmittedGradeId",
                table: "Students",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdmittedGradeId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "AdmittedClassId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
