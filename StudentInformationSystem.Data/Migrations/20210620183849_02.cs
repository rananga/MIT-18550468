using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentInformationSystem.Data.Migrations
{
    public partial class _02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_StudentBasketSubjects",
                table: "StudentBasketSubjects");

            migrationBuilder.CreateIndex(
                name: "IX_StudentBasketSubjects_SubjectId",
                table: "StudentBasketSubjects",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_StudentBasketSubjects",
                table: "StudentBasketSubjects",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subject_StudentBasketSubjects",
                table: "StudentBasketSubjects");

            migrationBuilder.DropIndex(
                name: "IX_StudentBasketSubjects_SubjectId",
                table: "StudentBasketSubjects");

            migrationBuilder.AddForeignKey(
                name: "FK_Subject_StudentBasketSubjects",
                table: "StudentBasketSubjects",
                column: "StudentId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
