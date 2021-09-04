using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentInformationSystem.Data.Migrations
{
    public partial class _13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassPromotions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    Year = table.Column<int>(nullable: false),
                    GradeId = table.Column<int>(nullable: false),
                    IsFinalized = table.Column<bool>(nullable: false),
                    PromotingCriteria = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassPromotions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grade_ClassPromotions",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassPromotionDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    PromotionId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    FromClassId = table.Column<int>(nullable: false),
                    ToClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassPromotionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassPromotionDetails_ClassRooms_FromClassId",
                        column: x => x.FromClassId,
                        principalTable: "ClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassPromotion_PromotionDetails",
                        column: x => x.PromotionId,
                        principalTable: "ClassPromotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToClass_ToClassPromotionDetails",
                        column: x => x.StudentId,
                        principalTable: "ClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_ClassPromotionDetails",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassPromotionDetails_FromClassId",
                table: "ClassPromotionDetails",
                column: "FromClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassPromotionDetails_PromotionId",
                table: "ClassPromotionDetails",
                column: "PromotionId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassPromotionDetails_StudentId",
                table: "ClassPromotionDetails",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassPromotions_GradeId",
                table: "ClassPromotions",
                column: "GradeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassPromotionDetails");

            migrationBuilder.DropTable(
                name: "ClassPromotions");
        }
    }
}
