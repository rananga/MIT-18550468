using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentInformationSystem.Data.Migrations
{
    public partial class _07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AdmittedGradeId",
                table: "Students",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 16,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 17,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 18,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 19,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 20,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 21,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 22,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 23,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 24,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 25,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 26,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 27,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 28,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 29,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 30,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 31,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 32,
                column: "AdmittedGradeId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Students_AdmittedGradeId",
                table: "Students",
                column: "AdmittedGradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmittedGrade_GradeAdmissions",
                table: "Students",
                column: "AdmittedGradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdmittedGrade_GradeAdmissions",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_AdmittedGradeId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "AdmittedGradeId",
                table: "Students",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 16,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 17,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 18,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 19,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 20,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 21,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 22,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 23,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 24,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 25,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 26,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 27,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 28,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 29,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 30,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 31,
                column: "AdmittedGradeId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 32,
                column: "AdmittedGradeId",
                value: 0);
        }
    }
}
