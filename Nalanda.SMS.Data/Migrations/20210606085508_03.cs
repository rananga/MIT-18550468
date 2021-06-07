using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nalanda.SMS.Data.Migrations
{
    public partial class _03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsBasket", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Sinhala" },
                    { 2, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "English" },
                    { 3, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, "Dancing" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Address", "ContactNo", "CreatedBy", "CreatedDate", "FullName", "Gender", "ImmeContactName", "ImmeContactNo", "InactiveReason", "Initials", "LName", "ModifiedBy", "ModifiedDate", "NICNo", "SchoolEmail", "Status", "TelHome", "Title" },
                values: new object[,]
                {
                    { 1, "test", "0714479648", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Piumali Manorika Suraweera", 1, "Malith", "0773411392", null, "P M", "Suraweera", null, null, "880272580V", null, 0, null, 5 },
                    { 2, "test", "0716669648", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Udara Rathnayaka", 0, "Umandya", "0773412392", null, "U", "Rathnayaka", null, null, "900272580V", null, 0, null, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
