using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentInformationSystem.Data.Migrations
{
    public partial class _03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchoolEmail",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "IndexNo",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SchoolEmail",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SchoolEmail",
                table: "StaffMembers");

            migrationBuilder.AddColumn<string>(
                name: "SchoolEmail_Google",
                table: "Visitors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SchoolEmail_MS",
                table: "Visitors",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdmissionNo",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AdmittedClassId",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BC_BackImagePath",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BC_FrontImagePath",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BirthDivSecretariat",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BirthGramaDiv",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BirthPlace",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BloodGroup",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentDivSecretariat",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CurrentGramaDiv",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DriverDetails",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "HomeLatitude",
                table: "Students",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "HomeLongitude",
                table: "Students",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "KnownIllnesses",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentsDeceasedStatus",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentsMaritalStatus",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SchoolEmail_Google",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SchoolEmail_MS",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TransportMode",
                table: "Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsEmergencyContact",
                table: "StudentFamilies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "NIC_BackImagePath",
                table: "StudentFamilies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NIC_FrontImagePath",
                table: "StudentFamilies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SchoolEmail_Google",
                table: "StaffMembers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SchoolEmail_MS",
                table: "StaffMembers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RegisterNo",
                table: "PCR_Students",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 1,
                column: "SchoolEmail_Google",
                value: "dainas@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 2,
                column: "SchoolEmail_Google",
                value: "ayomik@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 3,
                column: "SchoolEmail_Google",
                value: "apsarae@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 4,
                column: "SchoolEmail_Google",
                value: "malsham@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 5,
                column: "SchoolEmail_Google",
                value: "dayanandag@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 6,
                column: "SchoolEmail_Google",
                value: "chethanac@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 7,
                column: "SchoolEmail_Google",
                value: "himalin@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 8,
                column: "SchoolEmail_Google",
                value: "thilinic@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 9,
                column: "SchoolEmail_Google",
                value: "prabhah@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 10,
                column: "SchoolEmail_Google",
                value: "vijinih@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 11,
                column: "SchoolEmail_Google",
                value: "bdhammakiththi@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 12,
                column: "SchoolEmail_Google",
                value: "kalpau@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 13,
                column: "SchoolEmail_Google",
                value: "dilinin@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 14,
                column: "SchoolEmail_Google",
                value: "dinithif@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 25130, "25130@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24695, "24695@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24747, "24747@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 25445, "25445@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24735, "24735@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24701, "24701@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 27403, "27403@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24750, "24750@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24706, "24706@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 25145, "25145@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24785, "24785@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24685, "24685@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 27390, "27390@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24786, "24786@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24712, "24712@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24758, "24758@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 27326, "27326@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24972, "24972@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24687, "24687@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24717, "24717@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24749, "24749@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 28051, "28051@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 25425, "25425@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24755, "24755@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24781, "24781@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 29091, "29091@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24680, "24680@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24746, "24746@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 27289, "27289@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 27287, "27287@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 28647, "28647@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 25039, "25039@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24779, "24779@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 28052, "28052@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24812, "24812@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 25640, "25640@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 27364, "27364@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 25032, "25032@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 27385, "27385@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 25656, "25656@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24775, "24775@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 27327, "27327@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24757, "24757@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 27396, "27396@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24718, "24718@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24710, "24710@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24770, "24770@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 27347, "27347@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24790, "24790@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24754, "24754@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 27483, "27483@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 27482, "27482@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 25430, "25430@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 28054, "28054@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "AdmissionNo", "SchoolEmail_Google" },
                values: new object[] { 24714, "24714@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: 1,
                column: "SchoolEmail_Google",
                value: "rananga@nalandacollege.info");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AdmittedClassId",
                table: "Students",
                column: "AdmittedClassId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdmittedClass_AdmittedClassStudents",
                table: "Students",
                column: "AdmittedClassId",
                principalTable: "PhysicalClassRooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdmittedClass_AdmittedClassStudents",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_AdmittedClassId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SchoolEmail_Google",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "SchoolEmail_MS",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "AdmissionNo",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AdmittedClassId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BC_BackImagePath",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BC_FrontImagePath",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BirthDivSecretariat",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BirthGramaDiv",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BirthPlace",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "BloodGroup",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CurrentDivSecretariat",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CurrentGramaDiv",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DriverDetails",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "HomeLatitude",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "HomeLongitude",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "KnownIllnesses",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ParentsDeceasedStatus",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ParentsMaritalStatus",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SchoolEmail_Google",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SchoolEmail_MS",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "TransportMode",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "IsEmergencyContact",
                table: "StudentFamilies");

            migrationBuilder.DropColumn(
                name: "NIC_BackImagePath",
                table: "StudentFamilies");

            migrationBuilder.DropColumn(
                name: "NIC_FrontImagePath",
                table: "StudentFamilies");

            migrationBuilder.DropColumn(
                name: "SchoolEmail_Google",
                table: "StaffMembers");

            migrationBuilder.DropColumn(
                name: "SchoolEmail_MS",
                table: "StaffMembers");

            migrationBuilder.DropColumn(
                name: "RegisterNo",
                table: "PCR_Students");

            migrationBuilder.AddColumn<string>(
                name: "SchoolEmail",
                table: "Visitors",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IndexNo",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SchoolEmail",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SchoolEmail",
                table: "StaffMembers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 1,
                column: "SchoolEmail",
                value: "dainas@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 2,
                column: "SchoolEmail",
                value: "ayomik@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 3,
                column: "SchoolEmail",
                value: "apsarae@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 4,
                column: "SchoolEmail",
                value: "malsham@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 5,
                column: "SchoolEmail",
                value: "dayanandag@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 6,
                column: "SchoolEmail",
                value: "chethanac@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 7,
                column: "SchoolEmail",
                value: "himalin@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 8,
                column: "SchoolEmail",
                value: "thilinic@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 9,
                column: "SchoolEmail",
                value: "prabhah@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 10,
                column: "SchoolEmail",
                value: "vijinih@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 11,
                column: "SchoolEmail",
                value: "bdhammakiththi@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 12,
                column: "SchoolEmail",
                value: "kalpau@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 13,
                column: "SchoolEmail",
                value: "dilinin@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "StaffMembers",
                keyColumn: "Id",
                keyValue: 14,
                column: "SchoolEmail",
                value: "dinithif@nalandacollege.info");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 25130, "25130@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24695, "24695@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24747, "24747@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 25445, "25445@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24735, "24735@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24701, "24701@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 27403, "27403@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24750, "24750@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24706, "24706@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 25145, "25145@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24785, "24785@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24685, "24685@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 27390, "27390@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24786, "24786@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24712, "24712@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24758, "24758@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 27326, "27326@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24972, "24972@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24687, "24687@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24717, "24717@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24749, "24749@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 28051, "28051@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 25425, "25425@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24755, "24755@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24781, "24781@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 29091, "29091@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24680, "24680@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24746, "24746@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 27289, "27289@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 27287, "27287@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 28647, "28647@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 25039, "25039@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24779, "24779@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 28052, "28052@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24812, "24812@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 25640, "25640@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 27364, "27364@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 25032, "25032@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 27385, "27385@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 25656, "25656@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24775, "24775@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 27327, "27327@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24757, "24757@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 27396, "27396@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24718, "24718@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24710, "24710@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24770, "24770@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 27347, "27347@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24790, "24790@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24754, "24754@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 51,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 27483, "27483@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 27482, "27482@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 25430, "25430@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 28054, "28054@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 55,
                columns: new[] { "IndexNo", "SchoolEmail" },
                values: new object[] { 24714, "24714@nalandacollege.info" });

            migrationBuilder.UpdateData(
                table: "Visitors",
                keyColumn: "Id",
                keyValue: 1,
                column: "SchoolEmail",
                value: "rananga@nalandacollege.info");
        }
    }
}
