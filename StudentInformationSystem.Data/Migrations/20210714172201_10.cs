using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentInformationSystem.Data.Migrations
{
    public partial class _10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "LastClassId",
                table: "Students",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 20,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 21,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 22,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 23,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 24,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 25,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 26,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 27,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 28,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 29,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 30,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 31,
                column: "LastClassId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 32,
                column: "LastClassId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Students_LastClassId",
                table: "Students",
                column: "LastClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_LastClass_LastClassStudents",
                table: "Students",
                column: "LastClassId",
                principalTable: "ClassRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LastClass_LastClassStudents",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_LastClassId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "LastClassId",
                table: "Students",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 16,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 17,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 18,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 19,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 20,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 21,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 22,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 23,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 24,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 25,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 26,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 27,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 28,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 29,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 30,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 31,
                column: "LastClassId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 32,
                column: "LastClassId",
                value: 0);
        }
    }
}
