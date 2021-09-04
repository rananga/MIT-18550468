using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentInformationSystem.Data.Migrations
{
    public partial class _18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassPromotionDetails_ClassRooms_FromClassId",
                table: "ClassPromotionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ToClass_ToClassPromotionDetails",
                table: "ClassPromotionDetails");

            migrationBuilder.AddColumn<int>(
                name: "HierarchyOrder",
                table: "ExtraActivityPositions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ExtraActivityIncharges",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    ActivityId = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraActivityIncharges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activity_Incharges",
                        column: x => x.ActivityId,
                        principalTable: "ExtraActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffMember_ExtraActivityIncharges",
                        column: x => x.StaffId,
                        principalTable: "StaffMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Primary Section Grade 1");

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Primary Section Grade 2");

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Primary Section Grade 3");

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "Primary Section Grade 4");

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Primary Section Grade 5");

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "Junior Section Grade 6");

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: "Junior Section Grade 7");

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: "Junior Section Grade 8");

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 9,
                column: "Description",
                value: "Senior Section Grade 9");

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: "Senior Section Grade 10");

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: "Senior Section Grade 11");

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Primary Section");

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Junior Section");

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "Senior Section");

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "AL Science Section");

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "AL Art & Commerce Section");

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "AL Technology Section");

            migrationBuilder.CreateIndex(
                name: "IX_ClassPromotionDetails_ToClassId",
                table: "ClassPromotionDetails",
                column: "ToClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraActivityIncharges_ActivityId",
                table: "ExtraActivityIncharges",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraActivityIncharges_StaffId",
                table: "ExtraActivityIncharges",
                column: "StaffId");

            migrationBuilder.AddForeignKey(
                name: "FK_FromClass_FromClassPromotionDetails",
                table: "ClassPromotionDetails",
                column: "FromClassId",
                principalTable: "ClassRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ToClass_ToClassPromotionDetails",
                table: "ClassPromotionDetails",
                column: "ToClassId",
                principalTable: "ClassRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FromClass_FromClassPromotionDetails",
                table: "ClassPromotionDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ToClass_ToClassPromotionDetails",
                table: "ClassPromotionDetails");

            migrationBuilder.DropTable(
                name: "ExtraActivityIncharges");

            migrationBuilder.DropIndex(
                name: "IX_ClassPromotionDetails_ToClassId",
                table: "ClassPromotionDetails");

            migrationBuilder.DropColumn(
                name: "HierarchyOrder",
                table: "ExtraActivityPositions");

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 9,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Grades",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "");

            migrationBuilder.UpdateData(
                table: "Sections",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassPromotionDetails_ClassRooms_FromClassId",
                table: "ClassPromotionDetails",
                column: "FromClassId",
                principalTable: "ClassRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ToClass_ToClassPromotionDetails",
                table: "ClassPromotionDetails",
                column: "StudentId",
                principalTable: "ClassRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
