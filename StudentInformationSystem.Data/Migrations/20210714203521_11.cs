using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentInformationSystem.Data.Migrations
{
    public partial class _11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudentTransfers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    FromCR_Id = table.Column<int>(nullable: false),
                    ToCR_Id = table.Column<int>(nullable: false),
                    Reason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTransfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FromClass_FromTransfers",
                        column: x => x.FromCR_Id,
                        principalTable: "ClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_StudentTransfers",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToClass_ToTransfers",
                        column: x => x.ToCR_Id,
                        principalTable: "ClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentTransfers_FromCR_Id",
                table: "StudentTransfers",
                column: "FromCR_Id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTransfers_StudentId",
                table: "StudentTransfers",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTransfers_ToCR_Id",
                table: "StudentTransfers",
                column: "ToCR_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentTransfers");
        }
    }
}
