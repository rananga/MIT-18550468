using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Nalanda.SMS.Data.Migrations
{
    public partial class Migration_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<int>(nullable: false),
                    ClassDesc = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.ClassID);
                });

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    CID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.CID);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentMenuID = table.Column<int>(nullable: true),
                    DisplaySeq = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Area = table.Column<string>(nullable: true),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuID);
                    table.ForeignKey(
                        name: "FK_MenuMenu",
                        column: x => x.ParentMenuID,
                        principalTable: "Menus",
                        principalColumn: "MenuID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PeriodSetups",
                columns: table => new
                {
                    PeriodID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeriodStartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    PeriodEndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsPeriodComplete = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodSetups", x => x.PeriodID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndexNo = table.Column<int>(nullable: false),
                    Title = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    Initials = table.Column<string>(nullable: false),
                    LName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    School = table.Column<string>(nullable: false),
                    SchoolAddress = table.Column<string>(nullable: true),
                    LastDhammaSchool = table.Column<string>(nullable: true),
                    LDhammaSchoolAdd = table.Column<string>(nullable: true),
                    EngSpeaking = table.Column<int>(nullable: false),
                    EngWriting = table.Column<int>(nullable: false),
                    EngReading = table.Column<int>(nullable: false),
                    EmergencyConName = table.Column<string>(nullable: false),
                    EmergencyContactTel = table.Column<string>(nullable: false),
                    SpecialAttention = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastDhammaGrade = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    InactiveReason = table.Column<string>(nullable: true),
                    IsLeavingIssued = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudID);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeachID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    Initials = table.Column<string>(nullable: false),
                    LName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    ContactNo = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    NICNo = table.Column<string>(nullable: false),
                    TelHome = table.Column<string>(nullable: true),
                    ImmeContactNo = table.Column<string>(nullable: false),
                    ImmeContactName = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    InactiveReason = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeachID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "RoleMenuAccesses",
                columns: table => new
                {
                    MenuID = table.Column<int>(nullable: false),
                    RoleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMenuAccesses", x => new { x.MenuID, x.RoleID });
                    table.ForeignKey(
                        name: "FK_RoleMenuAccesses_Menus",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "MenuID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoleMenuAccesses_Roles",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleTiles",
                columns: table => new
                {
                    RoleTileID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TileID = table.Column<int>(nullable: false),
                    RoleID = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleTiles", x => x.RoleTileID);
                    table.ForeignKey(
                        name: "FK_RoleRoleTiles",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClubMembers",
                columns: table => new
                {
                    CMID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CID = table.Column<int>(nullable: false),
                    StudentID = table.Column<int>(nullable: false),
                    MemberDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    MembershipType = table.Column<int>(nullable: false),
                    CommiteeMemberType = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClubMembers", x => x.CMID);
                    table.ForeignKey(
                        name: "FK_ClubClubMember",
                        column: x => x.CID,
                        principalTable: "Clubs",
                        principalColumn: "CID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentClubMember",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeavingCertificates",
                columns: table => new
                {
                    LeavCertID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudID = table.Column<int>(nullable: false),
                    DateLeaving = table.Column<DateTime>(type: "datetime", nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    Conduct = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeavingCertificates", x => x.LeavCertID);
                    table.ForeignKey(
                        name: "FK_StudentLeavingCertificate",
                        column: x => x.StudID,
                        principalTable: "Students",
                        principalColumn: "StudID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudFamilies",
                columns: table => new
                {
                    StudFID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Relationship = table.Column<int>(nullable: false),
                    Occupation = table.Column<string>(nullable: false),
                    WorkingAdd = table.Column<string>(nullable: false),
                    OfficeTel = table.Column<string>(nullable: true),
                    ContactMob = table.Column<string>(nullable: false),
                    ContactHome = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    NICNo = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    Title = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudFamilies", x => x.StudFID);
                    table.ForeignKey(
                        name: "FK_StudentStudFamily",
                        column: x => x.StudID,
                        principalTable: "Students",
                        principalColumn: "StudID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudSiblings",
                columns: table => new
                {
                    SubID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SudID = table.Column<int>(nullable: false),
                    SiblingStudID = table.Column<int>(nullable: false),
                    Relationship = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudSiblings", x => x.SubID);
                    table.ForeignKey(
                        name: "FK_StudentStudSibling",
                        column: x => x.SudID,
                        principalTable: "Students",
                        principalColumn: "StudID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassTeachers",
                columns: table => new
                {
                    ClTeachID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassID = table.Column<int>(nullable: false),
                    TeacherID = table.Column<int>(nullable: false),
                    PeriodID = table.Column<int>(nullable: false),
                    PeriodStartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PeriodEndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTeachers", x => x.ClTeachID);
                    table.ForeignKey(
                        name: "FK_ClassClassTeacher",
                        column: x => x.ClassID,
                        principalTable: "Classes",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodSetupClassTeacher",
                        column: x => x.PeriodID,
                        principalTable: "PeriodSetups",
                        principalColumn: "PeriodID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherClassTeacher",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeachID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventParticipations",
                columns: table => new
                {
                    EPID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    EventDesc = table.Column<string>(nullable: false),
                    IsWinner = table.Column<bool>(nullable: false),
                    WinningDetails = table.Column<string>(nullable: true),
                    TeacherInCharge = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipations", x => x.EPID);
                    table.ForeignKey(
                        name: "FK_StudentEventParticipation",
                        column: x => x.StudID,
                        principalTable: "Students",
                        principalColumn: "StudID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherEventParticipation",
                        column: x => x.TeacherInCharge,
                        principalTable: "Teachers",
                        principalColumn: "TeachID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PromotionClasses",
                columns: table => new
                {
                    PrClID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassID = table.Column<int>(nullable: false),
                    PeriodID = table.Column<int>(nullable: false),
                    MonitorStudID = table.Column<string>(nullable: false),
                    MonitorStud2ID = table.Column<string>(nullable: true),
                    TeacherID = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromotionClasses", x => x.PrClID);
                    table.ForeignKey(
                        name: "FK_ClassPromotionClass",
                        column: x => x.ClassID,
                        principalTable: "Classes",
                        principalColumn: "ClassID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PeriodSetupPromotionClass",
                        column: x => x.PeriodID,
                        principalTable: "PeriodSetups",
                        principalColumn: "PeriodID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherPromotionClass",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "TeachID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<int>(nullable: false),
                    RoleID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleID);
                    table.ForeignKey(
                        name: "FK_RoleUserRole",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserUserRole",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassStudents",
                columns: table => new
                {
                    ClStudID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrClID = table.Column<int>(nullable: false),
                    StudID = table.Column<int>(nullable: false),
                    PeriodStartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PeriodEndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsMonitor = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    Status = table.Column<int>(nullable: false),
                    IsCurrentMonitor = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassStudents", x => x.ClStudID);
                    table.ForeignKey(
                        name: "FK_PromotionClassClassStudent",
                        column: x => x.PrClID,
                        principalTable: "PromotionClasses",
                        principalColumn: "PrClID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentClassStudent",
                        column: x => x.StudID,
                        principalTable: "Students",
                        principalColumn: "StudID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prefects",
                columns: table => new
                {
                    PreID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudID = table.Column<int>(nullable: false),
                    PrefClassID = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsHP = table.Column<bool>(nullable: false),
                    IsDHP = table.Column<bool>(nullable: false),
                    Responsibilty = table.Column<string>(nullable: true),
                    IsPromoted = table.Column<bool>(nullable: false),
                    PromotedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Status = table.Column<int>(nullable: false),
                    InactiveDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    InactiveReason = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prefects", x => x.PreID);
                    table.ForeignKey(
                        name: "FK_PromotionClassPrefect",
                        column: x => x.PrefClassID,
                        principalTable: "PromotionClasses",
                        principalColumn: "PrClID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentPrefect",
                        column: x => x.StudID,
                        principalTable: "Students",
                        principalColumn: "StudID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuID", "Action", "Area", "Controller", "DisplaySeq", "ParentMenuID", "Text", "Type" },
                values: new object[] { 1, null, null, null, 10, null, "Admin", "M" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "Code", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "Admin", "System", new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Administrator" },
                    { 2, "AdminUser", "System", new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Admin Department User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Password", "Status", "UserName" },
                values: new object[] { 1, "System", new DateTime(2015, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "1", 1, "rananga" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuID", "Action", "Area", "Controller", "DisplaySeq", "ParentMenuID", "Text", "Type" },
                values: new object[,]
                {
                    { 2, "Index", "Admin", "Users", 10, 1, "User Role Maintenance", "I" },
                    { 3, "Index", "Admin", "UserRoles", 20, 1, "User Maintenance", "I" },
                    { 4, "Index", "Admin", "Teacher", 30, 1, "Teacher Maintenance", "I" },
                    { 5, null, null, null, 40, 1, "-", "D" },
                    { 6, "Index", "Admin", "Class", 50, 1, "Class Definition", "I" },
                    { 7, "Index", "Admin", "Club", 60, 1, "Club Definition", "I" }
                });

            migrationBuilder.InsertData(
                table: "RoleMenuAccesses",
                columns: new[] { "MenuID", "RoleID" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleID", "RoleID", "UserID" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_FK_PromotionClassClassStudent",
                table: "ClassStudents",
                column: "PrClID");

            migrationBuilder.CreateIndex(
                name: "IX_FK_StudentClassStudent",
                table: "ClassStudents",
                column: "StudID");

            migrationBuilder.CreateIndex(
                name: "IX_FK_ClassClassTeacher",
                table: "ClassTeachers",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_FK_PeriodSetupClassTeacher",
                table: "ClassTeachers",
                column: "PeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_FK_TeacherClassTeacher",
                table: "ClassTeachers",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_FK_ClubClubMember",
                table: "ClubMembers",
                column: "CID");

            migrationBuilder.CreateIndex(
                name: "IX_FK_StudentClubMember",
                table: "ClubMembers",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_FK_StudentEventParticipation",
                table: "EventParticipations",
                column: "StudID");

            migrationBuilder.CreateIndex(
                name: "IX_FK_TeacherEventParticipation",
                table: "EventParticipations",
                column: "TeacherInCharge");

            migrationBuilder.CreateIndex(
                name: "IX_FK_StudentLeavingCertificate",
                table: "LeavingCertificates",
                column: "StudID");

            migrationBuilder.CreateIndex(
                name: "IX_FK_MenuMenu",
                table: "Menus",
                column: "ParentMenuID");

            migrationBuilder.CreateIndex(
                name: "IX_FK_PromotionClassPrefect",
                table: "Prefects",
                column: "PrefClassID");

            migrationBuilder.CreateIndex(
                name: "IX_FK_StudentPrefect",
                table: "Prefects",
                column: "StudID");

            migrationBuilder.CreateIndex(
                name: "IX_FK_ClassPromotionClass",
                table: "PromotionClasses",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IX_FK_PeriodSetupPromotionClass",
                table: "PromotionClasses",
                column: "PeriodID");

            migrationBuilder.CreateIndex(
                name: "IX_FK_TeacherPromotionClass",
                table: "PromotionClasses",
                column: "TeacherID");

            migrationBuilder.CreateIndex(
                name: "IX_FK_RoleMenuAccesses_Roles",
                table: "RoleMenuAccesses",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_FK_RoleRoleTiles",
                table: "RoleTiles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_FK_StudentStudFamily",
                table: "StudFamilies",
                column: "StudID");

            migrationBuilder.CreateIndex(
                name: "IX_FK_StudentStudSibling1",
                table: "StudSiblings",
                column: "SiblingStudID");

            migrationBuilder.CreateIndex(
                name: "IX_FK_StudentStudSibling",
                table: "StudSiblings",
                column: "SudID");

            migrationBuilder.CreateIndex(
                name: "IX_FK_RoleUserRole",
                table: "UserRoles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_FK_UserUserRole",
                table: "UserRoles",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassStudents");

            migrationBuilder.DropTable(
                name: "ClassTeachers");

            migrationBuilder.DropTable(
                name: "ClubMembers");

            migrationBuilder.DropTable(
                name: "EventParticipations");

            migrationBuilder.DropTable(
                name: "LeavingCertificates");

            migrationBuilder.DropTable(
                name: "Prefects");

            migrationBuilder.DropTable(
                name: "RoleMenuAccesses");

            migrationBuilder.DropTable(
                name: "RoleTiles");

            migrationBuilder.DropTable(
                name: "StudFamilies");

            migrationBuilder.DropTable(
                name: "StudSiblings");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Clubs");

            migrationBuilder.DropTable(
                name: "PromotionClasses");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "PeriodSetups");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
