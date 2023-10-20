using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentInformationSystem.Data.Migrations
{
    public partial class _01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuditTemp",
                columns: table => new
                {
                    MeetingDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CustomerId = table.Column<string>(nullable: false),
                    ParticipantEmail = table.Column<string>(maxLength: 100, nullable: false),
                    UniqueQualifier = table.Column<long>(nullable: false),
                    MeetingCode = table.Column<string>(maxLength: 100, nullable: true),
                    OrganizerEmail = table.Column<string>(maxLength: 100, nullable: true),
                    Duration = table.Column<long>(nullable: true),
                    CalendarEventId = table.Column<string>(maxLength: 100, nullable: true),
                    ConferenceID = table.Column<string>(maxLength: 100, nullable: true),
                    IsOutSide = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTemp", x => new { x.MeetingDate, x.CustomerId, x.ParticipantEmail, x.UniqueQualifier });
                });

            migrationBuilder.CreateTable(
                name: "ExtraActivities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraActivities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GradeEmails",
                columns: table => new
                {
                    Year = table.Column<int>(nullable: false),
                    Grade = table.Column<int>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeEmails", x => new { x.Year, x.Grade });
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentMenuId = table.Column<int>(nullable: true),
                    DisplaySeq = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    Area = table.Column<string>(nullable: true),
                    Controller = table.Column<string>(nullable: true),
                    Action = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    IsHidden = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                    table.ForeignKey(
                        name: "FK_MenuMenu",
                        column: x => x.ParentMenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NearbySchools",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    SchoolName = table.Column<string>(nullable: false),
                    DisplayName = table.Column<string>(nullable: false),
                    Latitude = table.Column<decimal>(type: "decimal(18,15)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(18,15)", nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NearbySchools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Title = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    Initials = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Occupation = table.Column<string>(nullable: false),
                    WorkingAddress = table.Column<string>(nullable: true),
                    OfficePhoneNo = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: false),
                    HomePhoneNo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NicNo = table.Column<string>(nullable: false),
                    NIC_FrontImagePath = table.Column<string>(nullable: true),
                    NIC_BackImagePath = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    Code = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubjectCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    Code = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    IsBasket = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SyncLogs",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Sevierity = table.Column<int>(nullable: false),
                    Message = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SyncLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SyncQueue",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QueuedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SyncType = table.Column<int>(nullable: false),
                    JsonData = table.Column<string>(type: "nvarchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SyncQueue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemParameters",
                columns: table => new
                {
                    Key = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemParameters", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Visitors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Title = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    Initials = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: false),
                    SchoolEmail_Google = table.Column<string>(nullable: true),
                    SchoolEmail_MS = table.Column<string>(nullable: true),
                    NicNo = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExtraActivityAchievements",
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
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraActivityAchievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activity_Achievements",
                        column: x => x.ActivityId,
                        principalTable: "ExtraActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExtraActivityPositions",
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
                    Name = table.Column<string>(nullable: false),
                    HierarchyOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraActivityPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activity_Positions",
                        column: x => x.ActivityId,
                        principalTable: "ExtraActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuActions",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false),
                    ActionId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuActions", x => new { x.MenuId, x.ActionId });
                    table.ForeignKey(
                        name: "FK_MenuActionMenu",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    StaffId = table.Column<int>(nullable: false),
                    SectionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Section_Teachers",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    SectionId = table.Column<int>(nullable: false),
                    SubjectCategoryId = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: false),
                    Number = table.Column<int>(nullable: true),
                    Medium = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubjectCategory_Subjects",
                        column: x => x.SubjectCategoryId,
                        principalTable: "SubjectCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleMenuAccesses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    MenuId = table.Column<int>(nullable: false),
                    ActionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleMenuAccesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menu_RoleMenuAccesses",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Role_RoleMenuAccesses",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuAction_RoleMenuAccesses",
                        columns: x => new { x.MenuId, x.ActionId },
                        principalTable: "MenuActions",
                        principalColumns: new[] { "MenuId", "ActionId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    SectionId = table.Column<int>(nullable: false),
                    GradeNo = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TeacherId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Section_Grades",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Grades_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffMembers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    StaffNumber = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    Title = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    Initials = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: false),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    MobileNo = table.Column<string>(nullable: false),
                    SchoolEmail_Google = table.Column<string>(nullable: true),
                    SchoolEmail_MS = table.Column<string>(nullable: true),
                    NicNo = table.Column<string>(nullable: false),
                    TelHome = table.Column<string>(nullable: true),
                    ImmeContactName = table.Column<string>(nullable: false),
                    ImmeContactNo = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    TeacherId = table.Column<int>(nullable: true),
                    JoinedDate = table.Column<DateTime>(type: "date", nullable: true),
                    RetiredDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffMembers_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherOffTimes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    TeacherId = table.Column<int>(nullable: false),
                    FromTime = table.Column<DateTime>(nullable: false),
                    ToTime = table.Column<DateTime>(nullable: false),
                    Reason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherOffTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teacher_OffTimes",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherQualifications",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    TeacherId = table.Column<int>(nullable: false),
                    QualificationType = table.Column<int>(nullable: false),
                    Institute = table.Column<string>(nullable: false),
                    AwardedYear = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherQualifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Teacher_TeacherQualifications",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherPreferedSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    TeacherId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherPreferedSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subject_TeacherPreferedSubjects",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teacher_TeacherPreferedSubjects",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "GradeClasses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    GradeId = table.Column<int>(nullable: false),
                    Name = table.Column<int>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Medium = table.Column<int>(nullable: false),
                    MaxStudentCount = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grade_GradeClasses",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GradeSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    GradeId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grade_GradeSubjects",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subject_GradeSubjects",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OnlineClassRooms",
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
                    SubjectId = table.Column<int>(nullable: false),
                    Medium = table.Column<int>(nullable: false),
                    GoogleClassRoomId = table.Column<string>(nullable: true),
                    GoogleClassrommLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineClassRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grade_OnlineClassRooms",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subject_OnlineClassRooms",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleGradeAccesses",
                columns: table => new
                {
                    GradeId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleGradeAccesses", x => new { x.RoleId, x.GradeId });
                    table.ForeignKey(
                        name: "FK_Grade_RoleGradeAccesses",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Role_RoleGradeAccesses",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "GradeHeads",
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
                    StaffId = table.Column<int>(nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeHeads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grade_GradeHeads",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffMember_HeadingGrades",
                        column: x => x.StaffId,
                        principalTable: "StaffMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SectionHeads",
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
                    SectionId = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false),
                    FromDate = table.Column<DateTime>(type: "date", nullable: false),
                    ToDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectionHeads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Section_SectionHeads",
                        column: x => x.SectionId,
                        principalTable: "Sections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffMember_HeadingSections",
                        column: x => x.StaffId,
                        principalTable: "StaffMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeacherQualificationSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    TeacherQualificationId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherQualificationSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subject_TeacherQualificationSubjects",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherQualification_TeacherQualificationSubjects",
                        column: x => x.TeacherQualificationId,
                        principalTable: "TeacherQualifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GradeClassSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    GradeClassId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeClassSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradeClass_GradeClassSubjects",
                        column: x => x.GradeClassId,
                        principalTable: "GradeClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subject_GradeClassSubjects",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalClassRooms",
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
                    GradeClassId = table.Column<int>(nullable: false),
                    Medium = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalClassRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradeClass_Classes",
                        column: x => x.GradeClassId,
                        principalTable: "GradeClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PhysicalClassRooms_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OCR_Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    OCR_Id = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false),
                    IsOwner = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OCR_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineClassRoom_ClassTeachers",
                        column: x => x.OCR_Id,
                        principalTable: "OnlineClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassTeacher_OCR_Teachers",
                        column: x => x.StaffId,
                        principalTable: "StaffMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OCR_ClassRooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    OCR_Id = table.Column<int>(nullable: false),
                    CR_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OCR_ClassRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassRoom_OCR_ClassRooms",
                        column: x => x.CR_Id,
                        principalTable: "PhysicalClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OnlineClassRoom_OCR_ClassRooms",
                        column: x => x.OCR_Id,
                        principalTable: "OnlineClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PCR_Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    CR_Id = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCR_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_ClassSubjects",
                        column: x => x.CR_Id,
                        principalTable: "PhysicalClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffMember_ClassSubjects",
                        column: x => x.StaffId,
                        principalTable: "StaffMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subject_ClassSubjects",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PCR_Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    CR_Id = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false),
                    FromDate = table.Column<DateTime>(type: "date", nullable: false),
                    ToDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCR_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_ClassTeachers",
                        column: x => x.CR_Id,
                        principalTable: "PhysicalClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffMember_ClassTeachers",
                        column: x => x.StaffId,
                        principalTable: "StaffMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    AdmissionNo = table.Column<int>(nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime", nullable: true),
                    FullName = table.Column<string>(nullable: false),
                    Initials = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    SchoolEmail_Google = table.Column<string>(nullable: true),
                    SchoolEmail_MS = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    EmergContactName = table.Column<string>(nullable: true),
                    EmergContactNo = table.Column<string>(nullable: true),
                    Medium = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    AdmissionDate = table.Column<DateTime>(nullable: false),
                    LeavingDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    IsLeavingIssued = table.Column<bool>(nullable: false),
                    LastClassId = table.Column<int>(nullable: true),
                    AdmittedGradeId = table.Column<int>(nullable: true),
                    AdmittedClassId = table.Column<int>(nullable: true),
                    BloodGroup = table.Column<int>(nullable: false),
                    HomeLatitude = table.Column<decimal>(nullable: false),
                    HomeLongitude = table.Column<decimal>(nullable: false),
                    ParentsMaritalStatus = table.Column<int>(nullable: false),
                    ParentsDeceasedStatus = table.Column<int>(nullable: false),
                    TransportMode = table.Column<int>(nullable: false),
                    DriverDetails = table.Column<string>(nullable: true),
                    KnownIllnesses = table.Column<string>(nullable: true),
                    BC_FrontImagePath = table.Column<string>(nullable: true),
                    BC_BackImagePath = table.Column<string>(nullable: true),
                    CurrentDivSecretariat = table.Column<int>(nullable: false),
                    CurrentGramaDiv = table.Column<string>(nullable: true),
                    BirthDivSecretariat = table.Column<int>(nullable: false),
                    BirthGramaDiv = table.Column<string>(nullable: true),
                    BirthPlace = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdmittedClass_AdmittedClassStudents",
                        column: x => x.AdmittedClassId,
                        principalTable: "PhysicalClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AdmittedGrade_GradeAdmissions",
                        column: x => x.AdmittedGradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LastClass_LastClassStudents",
                        column: x => x.LastClassId,
                        principalTable: "PhysicalClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OnlineClasses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    OCR_Id = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    FromTime = table.Column<TimeSpan>(nullable: false),
                    ToTime = table.Column<TimeSpan>(nullable: false),
                    OCR_TeacherId = table.Column<int>(nullable: false),
                    Subject = table.Column<string>(nullable: true),
                    Lesson = table.Column<string>(nullable: true),
                    CalendarEvent = table.Column<string>(nullable: true),
                    RepeatPattern = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineClasses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineClassRoom_OnlineClasses",
                        column: x => x.OCR_Id,
                        principalTable: "OnlineClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OCR_Teacher_OnlineClasses",
                        column: x => x.OCR_TeacherId,
                        principalTable: "OCR_Teachers",
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
                    ToClassId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassPromotionDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FromClass_FromClassPromotionDetails",
                        column: x => x.FromClassId,
                        principalTable: "PhysicalClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassPromotion_PromotionDetails",
                        column: x => x.PromotionId,
                        principalTable: "ClassPromotions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_ClassPromotionDetails",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ToClass_ToClassPromotionDetails",
                        column: x => x.ToClassId,
                        principalTable: "PhysicalClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeavingCertificates",
                columns: table => new
                {
                    LeavCertId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudId = table.Column<int>(nullable: false),
                    DateLeaving = table.Column<DateTime>(type: "datetime", nullable: false),
                    Reason = table.Column<string>(nullable: true),
                    Conduct = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeavingCertificates", x => x.LeavCertId);
                    table.ForeignKey(
                        name: "FK_StudentLeavingCertificate",
                        column: x => x.StudId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PCR_Monitors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    CR_Id = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    FromDate = table.Column<DateTime>(type: "date", nullable: false),
                    ToDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCR_Monitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_ClassMonitors",
                        column: x => x.CR_Id,
                        principalTable: "PhysicalClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_ClassMonitors",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PCR_Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    CR_Id = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    RegisterNo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCR_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_ClassStudents",
                        column: x => x.CR_Id,
                        principalTable: "PhysicalClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_ClassStudents",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentBasketSubjects",
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
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentBasketSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_StudentBasketSubjects",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subject_StudentBasketSubjects",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentExtraActivityAcheivements",
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
                    AcheivementId = table.Column<int>(nullable: false),
                    AwardedDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentExtraActivityAcheivements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acheivement_Students",
                        column: x => x.AcheivementId,
                        principalTable: "ExtraActivityAchievements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_ActivityAcheivements",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentExtraActivityPositions",
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
                    PositionId = table.Column<int>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    Remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentExtraActivityPositions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Position_Students",
                        column: x => x.PositionId,
                        principalTable: "ExtraActivityPositions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_ActivityPositions",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentFamilies",
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
                    ParentId = table.Column<int>(nullable: false),
                    Relationship = table.Column<int>(nullable: false),
                    IsEmergencyContact = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFamilies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParentStudFamily",
                        column: x => x.ParentId,
                        principalTable: "Parents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentStudFamily",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentSiblings",
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
                    SiblingStudentId = table.Column<int>(nullable: false),
                    Relationship = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSiblings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stud_StudSibling",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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
                        principalTable: "PhysicalClassRooms",
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
                        principalTable: "PhysicalClassRooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: true),
                    VisitorId = table.Column<int>(nullable: true),
                    ParentId = table.Column<int>(nullable: true),
                    StudentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Parents_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Parents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_StaffMembers_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Visitors_VisitorId",
                        column: x => x.VisitorId,
                        principalTable: "Visitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OC_Meetings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    OC_Id = table.Column<int>(nullable: false),
                    MeetingCode = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OC_Meetings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineClass_OC_Meetings",
                        column: x => x.OC_Id,
                        principalTable: "OnlineClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PCR_StudentSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    CR_StudentId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCR_StudentSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassStudent_StudentSubjects",
                        column: x => x.CR_StudentId,
                        principalTable: "PCR_Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subject_StudentSubjects",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_Role_UserRoles",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_UserRoles",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OC_MeetingAttendees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    OC_MeetingId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    Duration = table.Column<long>(nullable: false),
                    TimesVisited = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OC_MeetingAttendees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OC_Meeting_OC_MeetingAttendees",
                        column: x => x.OC_MeetingId,
                        principalTable: "OC_Meetings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PCR_StudentSubjectMarks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    CR_StudentSubjectId = table.Column<int>(nullable: false),
                    Term = table.Column<int>(nullable: false),
                    Marks = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCR_StudentSubjectMarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassStudentSubject_ClassStudentSubjectMarks",
                        column: x => x.CR_StudentSubjectId,
                        principalTable: "PCR_StudentSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "GradeEmails",
                columns: new[] { "Year", "Grade", "EmailAddress" },
                values: new object[,]
                {
                    { 2021, 1, "grade1-2021@nalandacollege.info" },
                    { 2021, 2, "grade2-2021@nalandacollege.info" },
                    { 2021, 3, "grade3-2021@nalandacollege.info" },
                    { 2021, 4, "grade4-2021@nalandacollege.info" },
                    { 2021, 5, "grade5-2021@nalandacollege.info" },
                    { 2021, 6, "grade6-2021@nalandacollege.info" },
                    { 2021, 7, "grade7-2021@nalandacollege.info" },
                    { 2021, 8, "grade8-2021@nalandacollege.info" },
                    { 2021, 9, "grade9-2021@nalandacollege.info" },
                    { 2021, 10, "grade10-2021@nalandacollege.info" },
                    { 2021, 11, "grade11-2021@nalandacollege.info" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "Action", "Area", "Controller", "DisplaySeq", "Icon", "IsHidden", "ParentMenuId", "Text", "Type" },
                values: new object[,]
                {
                    { 6, null, null, null, 60, "fas fa-chart-bar", false, null, "Report", "M" },
                    { 5, null, null, null, 50, "fas fa-laptop-code", false, null, "Online", "M" },
                    { 4, null, null, null, 40, "fas fa-user-graduate", false, null, "Student", "M" },
                    { 2, null, null, null, 20, "fas fa-book-reader", false, null, "Academic", "M" },
                    { 1, null, null, null, 10, "fas fa-user-tie", false, null, "Admin", "M" },
                    { 3, null, null, null, 30, "fas fa-chalkboard-teacher", false, null, "Teacher", "M" }
                });

            migrationBuilder.InsertData(
                table: "NearbySchools",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DisplayName", "IsActive", "Latitude", "Longitude", "ModifiedBy", "ModifiedDate", "SchoolName" },
                values: new object[,]
                {
                    { 117001, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Royal College", true, 6.90486623339689m, 79.8611705523619m, null, null, "Royal College" },
                    { 116014, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mahanama College", true, 6.90620308999949m, 79.8547672049854m, null, null, "Mahanama College" },
                    { 116023, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "St. Michael's College", true, 6.91384878057086m, 79.8531340450347m, null, null, "St. Michael's College" },
                    { 116025, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "St. Mary's Sin Mix.V.", true, 6.89479125981432m, 79.8573468392987m, null, null, "St. Mary's Sin Mix.V." },
                    { 116029, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kumarauthayam T.V.", true, 6.87831555443556m, 79.8772783925747m, null, null, "Kumarauthayam T.V." },
                    { 116030, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ramakrishna V.", true, 6.87583362021072m, 79.8699789316635m, null, null, "Ramakrishna V." },
                    { 116032, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hindu College", true, 6.88349697834477m, 79.8619339966584m, null, null, "Hindu College" },
                    { 116033, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Al Ameen V.", true, 6.92258269984139m, 79.8482175387863m, null, null, "Al Ameen V." },
                    { 116034, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "St Mary's T.M.V.", true, 6.89464775385252m, 79.8574150456686m, null, null, "St Mary's T.M.V." },
                    { 116035, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kollupitiya Methodist G.T.V", true, 6.91562439494181m, 79.8523067866256m, null, null, "Kollupitiya Methodist G.T.V" },
                    { 116037, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Defence Services College", true, 6.92647087644207m, 79.8508302182672m, null, null, "Defence Services College" },
                    { 117002, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ananda College", true, 6.92488224479492m, 79.8703862625047m, null, null, "Ananda College" },
                    { 117018, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Veluwana College", true, 6.92637548005991m, 79.8802618229489m, null, null, "Veluwana College" },
                    { 117005, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "St. Mattews V.", true, 6.92997975397401m, 79.877753654739m, null, null, "St. Mattews V." },
                    { 117008, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "St. John College", true, 6.9308515604204m, 79.8738018045953m, null, null, "St. John College" },
                    { 117009, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Seevali M.M.V.", true, 6.92329693001139m, 79.881352849713m, null, null, "Seevali M.M.V." },
                    { 117010, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Susamayawardhana M.V.", true, 6.91330656245148m, 79.876344346508m, null, null, "Susamayawardhana M.V." },
                    { 117012, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mahinda V.", true, 6.92657117025952m, 79.8729657170195m, null, null, "Mahinda V." },
                    { 117016, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "D.S.Senanayake V.", true, 6.90882715454139m, 79.8751636102563m, null, null, "D.S.Senanayake V." },
                    { 115009, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "St.Joseph's Boy's V.", true, 6.94780458943722m, 79.8749083843293m, null, null, "St.Joseph's Boy's V." },
                    { 117020, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asoka V.", true, 6.92279671224949m, 79.8673272027865m, null, null, "Asoka V." },
                    { 117021, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "C.W.W.Kannangara V.", true, 6.91900252199834m, 79.8771018645321m, null, null, "C.W.W.Kannangara V." },
                    { 117023, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Al Hijra Mus V.", true, 6.92900442280817m, 79.8750126513407m, null, null, "Al Hijra Mus V." },
                    { 117024, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thaninayagam T.V", true, 6.91905894900137m, 79.8852901977569m, null, null, "Thaninayagam T.V" },
                    { 117004, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thurstan College", true, 6.90374676774611m, 79.8595843379469m, null, null, "Thurstan College" },
                    { 115007, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vijayaba M.V.", true, 6.94634510785179m, 79.8722101810619m, null, null, "Vijayaba M.V." },
                    { 114029, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kotahena Methodist T.V.", true, 6.94940427037171m, 79.8617483147323m, null, null, "Kotahena Methodist T.V." },
                    { 115005, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mihindu Mawatha Sin.M.V.", true, 6.93385104871877m, 79.8581615197802m, null, null, "Mihindu Mawatha Sin.M.V." },
                    { 114001, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "De La Salle College", true, 6.9624076530508m, 79.8623517832771m, null, null, "De La Salle College" },
                    { 114004, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kumara V.", true, 6.95182372168983m, 79.8621572137206m, null, null, "Kumara V." },
                    { 114005, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mattakkuliya St.John's M.V", true, 6.97180453273626m, 79.8747070955073m, null, null, "Mattakkuliya St.John's M.V" },
                    { 114006, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "St.Lucia's College", true, 6.94866282745492m, 79.8651722806743m, null, null, "St.Lucia's College" },
                    { 114007, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cathedral Boys V.", true, 6.94965882132773m, 79.8628181135681m, null, null, "Cathedral Boys V." },
                    { 114008, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kotahen President College", true, 6.9539568314876m, 79.8628940764598m, null, null, "Kotahen President College" },
                    { 114010, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Modara Sri Medhananda V.", true, 6.96386229638963m, 79.8661038591823m, null, null, "Modara Sri Medhananda V." },
                    { 114011, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "St. John's V.", true, 6.96807460444064m, 79.8707203229669m, null, null, "St. John's V." },
                    { 114012, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ave Maria V.", true, 6.97046526369563m, 79.8777616239614m, null, null, "Ave Maria V." },
                    { 114013, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sri Sandhabodhi M.V", true, 6.95928851871108m, 79.875067000701m, null, null, "Sri Sandhabodhi M.V" },
                    { 115006, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Siri Saripuththa M.V", true, 6.92094822733301m, 79.8521389643082m, null, null, "Siri Saripuththa M.V" },
                    { 114016, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gunananda V.", true, 6.95061590587215m, 79.8627627408217m, null, null, "Gunananda V." },
                    { 114014, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bloemendhal Sin V.", true, 6.94758922654641m, 79.8706516488501m, null, null, "Bloemendhal Sin V." },
                    { 114021, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agamethi V.", true, 6.95787369604128m, 79.8682984536483m, null, null, "Agamethi V." },
                    { 115004, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rajasinghe M.V", true, 6.94143773542513m, 79.8777827908829m, null, null, "Rajasinghe M.V" },
                    { 115003, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mahabodhi V.", true, 6.91885672009994m, 79.8638850854589m, null, null, "Mahabodhi V." },
                    { 115002, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sri Sangaraja M.M.V.", true, 6.93289879900923m, 79.8631677264176m, null, null, "Sri Sangaraja M.M.V." },
                    { 114017, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mahawatta St. Anthony's Sin V.", true, 6.96088519266493m, 79.8721699600927m, null, null, "Mahawatta St. Anthony's Sin V." },
                    { 114028, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mutwal Hindu College", true, 6.96395928948056m, 79.8652081486035m, null, null, "Mutwal Hindu College" },
                    { 114030, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ananda P.V", true, 6.96573942090777m, 79.8720745765604m, null, null, "Ananda P.V" },
                    { 114025, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kalaimagal T.V", true, 6.94789012392999m, 79.8708483425539m, null, null, "Kalaimagal T.V" },
                    { 114024, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hamza Mus.V", true, 6.96283221937901m, 79.8641742184885m, null, null, "Hamza Mus.V" },
                    { 114023, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sri Razik Fareed Mus.B.V", true, 6.97181212638058m, 79.876175699137m, null, null, "Sri Razik Fareed Mus.B.V" },
                    { 114022, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thotawatta Methodist V.", true, 6.97296440908802m, 79.8783044922579m, null, null, "Thotawatta Methodist V." },
                    { 114026, "System", new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mahawatta St. Anthony's T.M.V.", true, 6.96084765909503m, 79.8720793877036m, null, null, "Mahawatta St. Anthony's T.M.V." }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "Code", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "Admin", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Administrator" },
                    { 2, "AdminUser", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Admin Department User" },
                    { 3, "Parent", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Parent" }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "Description", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { 6, "AL-Technology", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AL Technology Section", null, null },
                    { 4, "AL-Science", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AL Science Section", null, null },
                    { 5, "AL-Art & Commerce", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AL Art & Commerce Section", null, null },
                    { 2, "Junior", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Junior Section", null, null },
                    { 3, "Senior", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior Section", null, null },
                    { 1, "Primary", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primary Section", null, null }
                });

            migrationBuilder.InsertData(
                table: "StaffMembers",
                columns: new[] { "Id", "Address1", "Address2", "City", "CreatedBy", "CreatedDate", "FullName", "Gender", "ImagePath", "ImmeContactName", "ImmeContactNo", "Initials", "JoinedDate", "LastName", "MobileNo", "ModifiedBy", "ModifiedDate", "NicNo", "RetiredDate", "SchoolEmail_Google", "SchoolEmail_MS", "StaffNumber", "Status", "TeacherId", "TelHome", "Title" },
                values: new object[,]
                {
                    { 14, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dinithi Fernando", 1, null, "TestEntry", "0712345678", "Dinithi", null, "Fernando", "0712345678", null, null, "888888014V", null, "dinithif@nalandacollege.info", null, 114, 0, null, null, 6 },
                    { 13, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dilani Nilanga", 1, null, "TestEntry", "0712345678", "Dilani", null, "Nilanga", "0712345678", null, null, "888888013V", null, "dilinin@nalandacollege.info", null, 113, 0, null, null, 5 },
                    { 11, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "බැද්දේවෙල ධම්මකිත්ති හිමි", 0, null, "TestEntry", "0712345678", "බැද්දේවෙල", null, "ධම්මකිත්ති හිමි", "0712345678", null, null, "888888011V", null, "bdhammakiththi@nalandacollege.info", null, 111, 0, null, null, 1 },
                    { 10, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vijini Herath", 1, null, "TestEntry", "0712345678", "Vijini", null, "Herath", "0712345678", null, null, "888888010V", null, "vijinih@nalandacollege.info", null, 110, 0, null, null, 5 },
                    { 9, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prabha Hiroshine", 1, null, "TestEntry", "0712345678", "Prabha", null, "Hiroshine", "0712345678", null, null, "888888009V", null, "prabhah@nalandacollege.info", null, 109, 0, null, null, 5 },
                    { 8, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thilini Cooray", 1, null, "TestEntry", "0712345678", "Thilini", null, "Cooray", "0712345678", null, null, "888888008V", null, "thilinic@nalandacollege.info", null, 108, 0, null, null, 5 },
                    { 12, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kalpa Udayappriya", 0, null, "TestEntry", "0712345678", "Kalpa", null, "Udayappriya", "0712345678", null, null, "888888012V", null, "kalpau@nalandacollege.info", null, 112, 0, null, null, 4 },
                    { 6, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "D.S.Chethana", 1, null, "TestEntry", "0712345678", "D.S.", null, "Chethana", "0712345678", null, null, "888888006V", null, "chethanac@nalandacollege.info", null, 106, 0, null, null, 5 },
                    { 5, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gammanpila Dayananda", 0, null, "TestEntry", "0712345678", "Gammanpila", null, "Dayananda", "0712345678", null, null, "888888005V", null, "dayanandag@nalandacollege.info", null, 105, 0, null, null, 4 },
                    { 4, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malsha Mallawaarachchi", 1, null, "TestEntry", "0712345678", "Malsha", null, "Mallawaarachchi", "0712345678", null, null, "888888004V", null, "malsham@nalandacollege.info", null, 104, 0, null, null, 5 },
                    { 3, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apsara Vithan", 1, null, "TestEntry", "0712345678", "Apsara", null, "Vithan", "0712345678", null, null, "888888003V", null, "apsarae@nalandacollege.info", null, 103, 0, null, null, 5 },
                    { 2, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ayomi Dilhani", 1, null, "TestEntry", "0712345678", "Ayomi", null, "Dilhani", "0712345678", null, null, "888888002V", null, "ayomik@nalandacollege.info", null, 102, 0, null, null, 5 },
                    { 1, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diana Sladen", 1, null, "TestEntry", "0712345678", "Diana", null, "Sladen", "0712345678", null, null, "888888001V", null, "dainas@nalandacollege.info", null, 101, 0, null, null, 5 },
                    { 7, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Himali Nanayakkara", 1, null, "TestEntry", "0712345678", "Himali", null, "Nanayakkara", "0712345678", null, null, "888888007V", null, "himalin@nalandacollege.info", null, 107, 0, null, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address1", "Address2", "AdmissionDate", "AdmissionNo", "AdmittedClassId", "AdmittedGradeId", "BC_BackImagePath", "BC_FrontImagePath", "BirthDivSecretariat", "BirthGramaDiv", "BirthPlace", "BloodGroup", "City", "CreatedBy", "CreatedDate", "CurrentDivSecretariat", "CurrentGramaDiv", "DOB", "DriverDetails", "EmergContactName", "EmergContactNo", "FullName", "HomeLatitude", "HomeLongitude", "ImagePath", "Initials", "IsLeavingIssued", "KnownIllnesses", "LastClassId", "LastName", "LeavingDate", "Medium", "ModifiedBy", "ModifiedDate", "ParentsDeceasedStatus", "ParentsMaritalStatus", "SchoolEmail_Google", "SchoolEmail_MS", "Status", "TransportMode" },
                values: new object[,]
                {
                    { 40, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 25656, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "Seniru M.Weerasinghe", 0m, 0m, null, "Seniru", false, null, null, "M.Weerasinghe", null, 1, null, null, 0, 0, "25656@nalandacollege.info", null, 0, 0 },
                    { 39, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 27385, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "Sanuth I.E.Liyanage", 0m, 0m, null, "Sanuth I.", false, null, null, "E.Liyanage", null, 1, null, null, 0, 0, "27385@nalandacollege.info", null, 0, 0 },
                    { 38, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 25032, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "Sanuka N.Wanniarachchi", 0m, 0m, null, "Sanuka N.", false, null, null, "Wanniarachchi", null, 1, null, null, 0, 0, "25032@nalandacollege.info", null, 0, 0 },
                    { 37, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 27364, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "S.M.Pavanindu N. Egodagedara", 0m, 0m, null, "S.M.Pavanindu N.", false, null, null, "Egodagedara", null, 1, null, null, 0, 0, "27364@nalandacollege.info", null, 0, 0 },
                    { 36, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 25640, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "R.M.Sashmitha N. B.Kotu", 0m, 0m, null, "R.M.Sashmitha N. B.", false, null, null, "Kotu", null, 1, null, null, 0, 0, "25640@nalandacollege.info", null, 0, 0 },
                    { 33, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 24779, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "P.M.G.Onitha O. Gunathilake", 0m, 0m, null, "P.M.G.Onitha O.", false, null, null, "Gunathilake", null, 1, null, null, 0, 0, "24779@nalandacollege.info", null, 0, 0 },
                    { 34, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 28052, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "R.M.Thisath Dewwin Bandara", 0m, 0m, null, "R.M.Thisath Dewwin", false, null, null, "Bandara", null, 1, null, null, 0, 0, "28052@nalandacollege.info", null, 0, 0 },
                    { 31, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 28647, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "Mihisara Kaveesha Hettiarachchi", 0m, 0m, null, "Mihisara Kaveesha", false, null, null, "Hettiarachchi", null, 1, null, null, 0, 0, "28647@nalandacollege.info", null, 0, 0 },
                    { 32, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 25039, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "Minul Demith Peladagama", 0m, 0m, null, "Minul Demith", false, null, null, "Peladagama", null, 1, null, null, 0, 0, "25039@nalandacollege.info", null, 0, 0 },
                    { 41, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 24775, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "Senuja M.Gunasekara", 0m, 0m, null, "Senuja M.", false, null, null, "Gunasekara", null, 1, null, null, 0, 0, "24775@nalandacollege.info", null, 0, 0 },
                    { 35, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 24812, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "R.G.Ravishka Sathsindu", 0m, 0m, null, "R.G.Ravishka", false, null, null, "Sathsindu", null, 1, null, null, 0, 0, "24812@nalandacollege.info", null, 0, 0 },
                    { 42, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 27327, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "Sithum K.S.Rajapaksha", 0m, 0m, null, "Sithum K.S.", false, null, null, "Rajapaksha", null, 1, null, null, 0, 0, "27327@nalandacollege.info", null, 0, 0 },
                    { 50, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 24754, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "W.A.H.Nethru Weerasooriya", 0m, 0m, null, "W.A.H.Nethru", false, null, null, "Weerasooriya", null, 1, null, null, 0, 0, "24754@nalandacollege.info", null, 0, 0 },
                    { 44, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 27396, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "T.N.Hansaka Walpola", 0m, 0m, null, "T.N.Hansaka", false, null, null, "Walpola", null, 1, null, null, 0, 0, "27396@nalandacollege.info", null, 0, 0 },
                    { 45, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 24718, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "Tharul B. Dharmasena", 0m, 0m, null, "Tharul B.", false, null, null, "Dharmasena", null, 1, null, null, 0, 0, "24718@nalandacollege.info", null, 0, 0 },
                    { 46, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 24710, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "Tharusha V.Kalubowila", 0m, 0m, null, "Tharusha V.", false, null, null, "Kalubowila", null, 1, null, null, 0, 0, "24710@nalandacollege.info", null, 0, 0 },
                    { 47, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 24770, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "The min S. Wijayawardana", 0m, 0m, null, "The min S.", false, null, null, "Wijayawardana", null, 1, null, null, 0, 0, "24770@nalandacollege.info", null, 0, 0 },
                    { 48, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 27347, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "W.Sachintha Akalanka", 0m, 0m, null, "W.Sachintha", false, null, null, "Akalanka", null, 1, null, null, 0, 0, "27347@nalandacollege.info", null, 0, 0 },
                    { 49, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 24790, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "W.A.Dinushka R Perera", 0m, 0m, null, "W.A.Dinushka R", false, null, null, "Perera", null, 1, null, null, 0, 0, "24790@nalandacollege.info", null, 0, 0 },
                    { 30, null, null, new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 27287, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "M.G.Shashen R. Bandara", 0m, 0m, null, "M.G.Shashen R.", false, null, null, "Bandara", null, 1, null, null, 0, 0, "27287@nalandacollege.info", null, 0, 0 },
                    { 51, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 27483, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "W.A.Nushan Wijeweera", 0m, 0m, null, "W.A.Nushan", false, null, null, "Wijeweera", null, 1, null, null, 0, 0, "27483@nalandacollege.info", null, 0, 0 },
                    { 52, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 27482, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "W.F.Tenura T. Perera", 0m, 0m, null, "W.F.Tenura T.", false, null, null, "Perera", null, 1, null, null, 0, 0, "27482@nalandacollege.info", null, 0, 0 },
                    { 53, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 25430, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "W.M.A.Rivinaka Eragoda", 0m, 0m, null, "W.M.A.Rivinaka", false, null, null, "Eragoda", null, 1, null, null, 0, 0, "25430@nalandacollege.info", null, 0, 0 },
                    { 54, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 28054, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "Yonal B. Galagedara", 0m, 0m, null, "Yonal B.", false, null, null, "Galagedara", null, 1, null, null, 0, 0, "28054@nalandacollege.info", null, 0, 0 },
                    { 55, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 24714, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "Yumeth M.Dewapura", 0m, 0m, null, "Yumeth M.", false, null, null, "Dewapura", null, 1, null, null, 0, 0, "24714@nalandacollege.info", null, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address1", "Address2", "AdmissionDate", "AdmissionNo", "AdmittedClassId", "AdmittedGradeId", "BC_BackImagePath", "BC_FrontImagePath", "BirthDivSecretariat", "BirthGramaDiv", "BirthPlace", "BloodGroup", "City", "CreatedBy", "CreatedDate", "CurrentDivSecretariat", "CurrentGramaDiv", "DOB", "DriverDetails", "EmergContactName", "EmergContactNo", "FullName", "HomeLatitude", "HomeLongitude", "ImagePath", "Initials", "IsLeavingIssued", "KnownIllnesses", "LastClassId", "LastName", "LeavingDate", "Medium", "ModifiedBy", "ModifiedDate", "ParentsDeceasedStatus", "ParentsMaritalStatus", "SchoolEmail_Google", "SchoolEmail_MS", "Status", "TransportMode" },
                values: new object[,]
                {
                    { 43, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 24757, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "T.Thulnith I. Vithana", 0m, 0m, null, "T.Thulnith I.", false, null, null, "Vithana", null, 1, null, null, 0, 0, "24757@nalandacollege.info", null, 0, 0 },
                    { 29, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 27289, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "M.D.Savith P. Binuditha", 0m, 0m, null, "M.D.Savith P.", false, null, null, "Binuditha", null, 1, null, null, 0, 0, "27289@nalandacollege.info", null, 0, 0 },
                    { 23, null, null, new DateTime(2021, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 25425, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "K.Mithuru M. Perera", 0m, 0m, null, "K.Mithuru M.", false, null, null, "Perera", null, 1, null, null, 0, 0, "25425@nalandacollege.info", null, 0, 0 },
                    { 27, null, null, new DateTime(2021, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 24680, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "Luvya V.Seelanatha", 0m, 0m, null, "Luvya V.", false, null, null, "Seelanatha", null, 1, null, null, 0, 0, "24680@nalandacollege.info", null, 0, 0 },
                    { 1, null, null, new DateTime(2021, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 25130, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "Anuk Gunasekara", 0m, 0m, null, "Anuk", false, null, null, "Gunasekara", null, 1, null, null, 0, 0, "25130@nalandacollege.info", null, 0, 0 },
                    { 2, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 24695, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "B.A.Inuka A. Abeysekara", 0m, 0m, null, "B.A.Inuka A.", false, null, null, "Abeysekara", null, 1, null, null, 0, 0, "24695@nalandacollege.info", null, 0, 0 },
                    { 3, null, null, new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 24747, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "B.A.Thavidu T. Wimalasena", 0m, 0m, null, "B.A.Thavidu T.", false, null, null, "Wimalasena", null, 1, null, null, 0, 0, "24747@nalandacollege.info", null, 0, 0 },
                    { 4, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 25445, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "Bihandu A.Bethmage", 0m, 0m, null, "Bihandu A.", false, null, null, "Bethmage", null, 1, null, null, 0, 0, "25445@nalandacollege.info", null, 0, 0 },
                    { 5, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 24735, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "Chanuka S.Wijerathna", 0m, 0m, null, "Chanuka S.", false, null, null, "Wijerathna", null, 1, null, null, 0, 0, "24735@nalandacollege.info", null, 0, 0 },
                    { 6, null, null, new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 24701, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "D.T.K.Nethun Sanketh", 0m, 0m, null, "D.T.K.Nethun", false, null, null, "Sanketh", null, 1, null, null, 0, 0, "24701@nalandacollege.info", null, 0, 0 },
                    { 7, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 27403, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "D.W.Iran V.S.Wickramanayake", 0m, 0m, null, "D.W.Iran V.S.", false, null, null, "Wickramanayake", null, 1, null, null, 0, 0, "27403@nalandacollege.info", null, 0, 0 },
                    { 8, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 24750, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "Dimath B Kahatapitiya", 0m, 0m, null, "Dimath B", false, null, null, "Kahatapitiya", null, 1, null, null, 0, 0, "24750@nalandacollege.info", null, 0, 0 },
                    { 9, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 24706, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "Dulain S. Jayawardhana", 0m, 0m, null, "Dulain S.", false, null, null, "Jayawardhana", null, 1, null, null, 0, 0, "24706@nalandacollege.info", null, 0, 0 },
                    { 28, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 24746, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "M.A.Chathura P. Karunasekara", 0m, 0m, null, "M.A.Chathura P.", false, null, null, "Karunasekara", null, 1, null, null, 0, 0, "24746@nalandacollege.info", null, 0, 0 },
                    { 11, null, null, new DateTime(2021, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 24785, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "G.Nuran C. Perera", 0m, 0m, null, "G.Nuran C.", false, null, null, "Perera", null, 1, null, null, 0, 0, "24785@nalandacollege.info", null, 0, 0 },
                    { 12, null, null, new DateTime(2021, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 24685, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "G.A.D.Daham C. Siriwardane", 0m, 0m, null, "G.A.D.Daham C.", false, null, null, "Siriwardane", null, 1, null, null, 0, 0, "24685@nalandacollege.info", null, 0, 0 },
                    { 10, null, null, new DateTime(2021, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 25145, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "Dulina S.Gunathilake", 0m, 0m, null, "Dulina S.", false, null, null, "Gunathilake", null, 1, null, null, 0, 0, "25145@nalandacollege.info", null, 0, 0 },
                    { 14, null, null, new DateTime(2021, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 24786, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "G.V.Himasha R Peiris", 0m, 0m, null, "G.V.Himasha R", false, null, null, "Peiris", null, 1, null, null, 0, 0, "24786@nalandacollege.info", null, 0, 0 },
                    { 26, null, null, new DateTime(2021, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 29091, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "L.K.A.Y.Dissanayake", 0m, 0m, null, "L.K.A.Y.", false, null, null, "Dissanayake", null, 1, null, null, 0, 0, "29091@nalandacollege.info", null, 0, 0 },
                    { 25, null, null, new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 24781, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "Kuvidu H.Amarasinghe", 0m, 0m, null, "Kuvidu H.", false, null, null, "Amarasinghe", null, 1, null, null, 0, 0, "24781@nalandacollege.info", null, 0, 0 },
                    { 13, null, null, new DateTime(2021, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 27390, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "G.P.Dimath Senhiru", 0m, 0m, null, "G.P.Dimath", false, null, null, "Senhiru", null, 1, null, null, 0, 0, "27390@nalandacollege.info", null, 0, 0 },
                    { 22, null, null, new DateTime(2021, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 28051, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "K.Dasindu Dulwan", 0m, 0m, null, "K.Dasindu", false, null, null, "Dulwan", null, 1, null, null, 0, 0, "28051@nalandacollege.info", null, 0, 0 },
                    { 21, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 24749, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "J.M.M.Raadawa Jayasundara", 0m, 0m, null, "J.M.M.Raadawa", false, null, null, "Jayasundara", null, 1, null, null, 0, 0, "24749@nalandacollege.info", null, 0, 0 },
                    { 24, null, null, new DateTime(2021, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 24755, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "K.S.Vikum M. Kariyawasam", 0m, 0m, null, "K.S.Vikum M.", false, null, null, "Kariyawasam", null, 1, null, null, 0, 0, "24755@nalandacollege.info", null, 0, 0 },
                    { 19, null, null, new DateTime(2021, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 24687, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "I.A.Daniru Vinijith", 0m, 0m, null, "I.A.Daniru", false, null, null, "Vinijith", null, 1, null, null, 0, 0, "24687@nalandacollege.info", null, 0, 0 },
                    { 18, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 24972, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "H.M.Thimath S. Herath", 0m, 0m, null, "H.M.Thimath S.", false, null, null, "Herath", null, 1, null, null, 0, 0, "24972@nalandacollege.info", null, 0, 0 },
                    { 17, null, null, new DateTime(2021, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 27326, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "H.M.Dinuka D.B.Rajaguru", 0m, 0m, null, "H.M.Dinuka D.B.", false, null, null, "Rajaguru", null, 1, null, null, 0, 0, "27326@nalandacollege.info", null, 0, 0 },
                    { 16, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 24758, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "H.A.Ositha J. Wijayarathna", 0m, 0m, null, "H.A.Ositha J.", false, null, null, "Wijayarathna", null, 1, null, null, 0, 0, "24758@nalandacollege.info", null, 0, 0 },
                    { 15, null, null, new DateTime(2021, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 24712, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "H.A.Hirun S. Samaranayake", 0m, 0m, null, "H.A.Hirun S.", false, null, null, "Samaranayake", null, 1, null, null, 0, 0, "24712@nalandacollege.info", null, 0, 0 },
                    { 20, null, null, new DateTime(2021, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 24717, null, null, null, null, 0, null, null, 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, null, null, null, null, "J.K.Tharul M. Perera", 0m, 0m, null, "J.K.Tharul M.", false, null, null, "Perera", null, 1, null, null, 0, 0, "24717@nalandacollege.info", null, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "SubjectCategories",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "Description", "IsBasket", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { 1, "Main", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null },
                    { 2, "Basket 1", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, null, null },
                    { 3, "Basket 2", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, null, null },
                    { 4, "Basket 3", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, null, null }
                });

            migrationBuilder.InsertData(
                table: "SystemParameters",
                columns: new[] { "Key", "Value" },
                values: new object[,]
                {
                    { "SchoolLocationLongitude", "79.87495688972923" },
                    { "SchoolLocationLatitude", "6.923965293049291" }
                });

            migrationBuilder.InsertData(
                table: "Visitors",
                columns: new[] { "Id", "Address1", "Address2", "City", "CreatedBy", "CreatedDate", "FullName", "Gender", "ImagePath", "Initials", "LastName", "MobileNo", "ModifiedBy", "ModifiedDate", "NicNo", "SchoolEmail_Google", "SchoolEmail_MS", "Title" },
                values: new object[] { 1, null, null, null, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rananga Lakshitha Suraweera", 0, null, "R L", "Suraweera", "0713522384", null, null, "860272580V", "rananga@nalandacollege.info", null, 4 });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "GradeNo", "ModifiedBy", "ModifiedDate", "SectionId", "TeacherId" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primary Section Grade 1", 1, null, null, 1, null },
                    { 11, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior Section Grade 11", 11, null, null, 3, null },
                    { 10, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior Section Grade 10", 10, null, null, 3, null },
                    { 9, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior Section Grade 9", 9, null, null, 3, null },
                    { 8, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Junior Section Grade 8", 8, null, null, 2, null },
                    { 7, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Junior Section Grade 7", 7, null, null, 2, null },
                    { 6, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Junior Section Grade 6", 6, null, null, 2, null },
                    { 5, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primary Section Grade 5", 5, null, null, 1, null },
                    { 4, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primary Section Grade 4", 4, null, null, 1, null },
                    { 3, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primary Section Grade 3", 3, null, null, 1, null },
                    { 2, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primary Section Grade 2", 2, null, null, 1, null }
                });

            migrationBuilder.InsertData(
                table: "MenuActions",
                columns: new[] { "MenuId", "ActionId", "Text" },
                values: new object[,]
                {
                    { 4, 0, "All" },
                    { 3, 0, "All" },
                    { 2, 0, "All" },
                    { 5, 0, "All" },
                    { 6, 0, "All" },
                    { 1, 0, "All" }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "Action", "Area", "Controller", "DisplaySeq", "Icon", "IsHidden", "ParentMenuId", "Text", "Type" },
                values: new object[,]
                {
                    { 37, "Process", "Report", "OnlineSessionsSummary", 40, null, false, 6, "Online Sessions Summary", "I" },
                    { 36, "Process", "Report", "StudentMarks", 30, null, false, 6, "Term Wise Student Marks", "I" },
                    { 35, "Process", "Report", "StudentAttendance", 20, null, false, 6, "Student Attendance", "I" },
                    { 34, "Process", "Report", "StudentCharacter", 10, null, false, 6, "Student Character", "I" },
                    { 33, "Index", "Online", "OnlineTimeTable", 20, null, false, 5, "Online Time Table", "I" },
                    { 31, "Index", "Student", "StudentExtraActivities", 60, null, false, 4, "Student Extra Activities", "I" },
                    { 32, "Index", "Online", "OnlineClassRoom", 10, null, false, 5, "Online Classrooms", "I" },
                    { 38, "Process", "Report", "WeeklySummary", 50, null, false, 6, "Weekly Summary", "I" },
                    { 30, "Index", "Student", "ClassPromotion", 50, null, false, 4, "Class Promotion", "I" },
                    { 7, "Index", "Admin", "Section", 10, null, false, 1, "Sections", "I" },
                    { 28, "Index", "Student", "StudentMark", 40, null, false, 4, "Student Marks", "I" },
                    { 8, "Index", "Admin", "Grade", 20, null, false, 1, "Grades", "I" },
                    { 9, "Index", "Admin", "StaffMember", 30, null, false, 1, "Staff Members", "I" },
                    { 10, "Index", "Admin", "Parent", 40, null, false, 1, "Parents", "I" },
                    { 29, "Index", "Student", "TransferStudent", 50, null, false, 4, "Transfer Student", "I" },
                    { 12, "Index", "Admin", "Role", 60, null, false, 1, "Roles", "I" },
                    { 13, "Index", "Admin", "Users", 70, null, false, 1, "Users", "I" },
                    { 14, "Index", "Admin", "SectionHead", 80, null, false, 1, "Section Heads", "I" },
                    { 15, "Index", "Admin", "GradeHead", 90, null, false, 1, "Grade Heads", "I" },
                    { 16, "Index", "Admin", "ExtraActivity", 100, null, false, 1, "Extra Activities", "I" },
                    { 39, "Index", "Admin", "AdmissionMap", 110, null, false, 1, "Admission Map", "I" },
                    { 17, "Index", "Academic", "SubjectCategory", 10, null, false, 2, "Subject Categories", "I" },
                    { 11, "Index", "Admin", "Visitor", 50, null, false, 1, "Visitors", "I" },
                    { 19, "Index", "Academic", "GradeSubject", 30, null, false, 2, "Grade Subjects", "I" },
                    { 18, "Index", "Academic", "Subject", 20, null, false, 2, "Subjects", "I" },
                    { 27, "Index", "Student", "StudentAdmit", 30, null, false, 4, "Admit Student", "I" },
                    { 25, "Index", "Student", "Student", 10, null, false, 4, "Student Maintenance", "I" },
                    { 24, "Index", "Teacher", "TeacherOffTime", 30, null, false, 3, "Teacher Off Times", "I" },
                    { 26, "Index", "Student", "BasketSubject", 20, null, false, 4, "Student Basket Subjects", "I" },
                    { 23, "Index", "Teacher", "TeacherQualification", 20, null, false, 3, "Teacher Qualifications", "I" },
                    { 22, "Index", "Teacher", "Teacher", 10, null, false, 3, "Teacher Subjects", "I" },
                    { 21, "Index", "Academic", "ClassRoom", 50, null, false, 2, "Physical Classrooms", "I" },
                    { 20, "Index", "Academic", "GradeClass", 40, null, false, 2, "Grade Classes", "I" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "Description", "Medium", "ModifiedBy", "ModifiedDate", "Number", "SectionId", "SubjectCategoryId" },
                values: new object[,]
                {
                    { 9, "Civic Education", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 2 },
                    { 13, "PTS", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 4 },
                    { 12, "Western Music", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 3 },
                    { 11, "Drama", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 3 },
                    { 10, "Eastern Music", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 3 },
                    { 14, "Health", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 4 },
                    { 8, "Geography", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 2 },
                    { 3, "English", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 1 },
                    { 6, "History", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 1 },
                    { 5, "Science", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 1 },
                    { 4, "Mathematics", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 1 },
                    { 2, "සිංහල", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 1 },
                    { 1, "බුද්ධධර්මය", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 1 },
                    { 15, "ICT", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 4 },
                    { 7, "Tamil", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "ParentId", "Password", "StaffId", "Status", "StudentId", "UserName", "VisitorId" },
                values: new object[] { 1, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "1", null, 1, null, "rananga", 1 });

            migrationBuilder.InsertData(
                table: "GradeClasses",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "GradeId", "MaxStudentCount", "Medium", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "1.A", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 0, null, null, 1 },
                    { 2, "1.B", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 0, null, null, 2 },
                    { 3, "1.C", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 0, null, null, 3 },
                    { 4, "1.D", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 0, null, null, 4 },
                    { 6, "9.B", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null, 1, null, null, 2 },
                    { 7, "9.C", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null, 0, null, null, 3 },
                    { 5, "9.A", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null, 1, null, null, 1 },
                    { 9, "9.E", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null, 0, null, null, 5 },
                    { 10, "9.F", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null, 0, null, null, 6 },
                    { 11, "9.G", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null, 0, null, null, 7 },
                    { 12, "9.H", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null, 0, null, null, 8 },
                    { 13, "9.I", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null, 0, null, null, 9 },
                    { 8, "9.D", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null, 0, null, null, 4 }
                });

            migrationBuilder.InsertData(
                table: "MenuActions",
                columns: new[] { "MenuId", "ActionId", "Text" },
                values: new object[,]
                {
                    { 32, 0, "All" },
                    { 28, 0, "All" },
                    { 29, 0, "All" },
                    { 30, 0, "All" },
                    { 31, 0, "All" },
                    { 33, 0, "All" },
                    { 7, 0, "All" },
                    { 35, 0, "All" },
                    { 36, 0, "All" },
                    { 37, 0, "All" },
                    { 38, 0, "All" },
                    { 27, 0, "All" },
                    { 34, 0, "All" },
                    { 26, 0, "All" },
                    { 25, 0, "All" },
                    { 24, 0, "All" },
                    { 7, 1, "View" },
                    { 7, 2, "Create" },
                    { 7, 3, "Edit" },
                    { 7, 4, "Delete" },
                    { 8, 0, "All" },
                    { 8, 1, "View" },
                    { 8, 2, "Create" },
                    { 8, 3, "Edit" },
                    { 8, 4, "Delete" },
                    { 9, 0, "All" },
                    { 10, 0, "All" },
                    { 11, 0, "All" },
                    { 12, 0, "All" },
                    { 13, 0, "All" },
                    { 14, 0, "All" },
                    { 15, 0, "All" },
                    { 16, 0, "All" },
                    { 39, 0, "All" },
                    { 17, 0, "All" },
                    { 18, 0, "All" },
                    { 19, 0, "All" },
                    { 20, 0, "All" },
                    { 21, 0, "All" },
                    { 22, 0, "All" },
                    { 23, 0, "All" }
                });

            migrationBuilder.InsertData(
                table: "OnlineClassRooms",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "GoogleClassRoomId", "GoogleClassrommLink", "GradeId", "Medium", "ModifiedBy", "ModifiedDate", "SubjectId", "Year" },
                values: new object[] { 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 0, null, null, 1, 2021 });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleId", "RoleId", "UserId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "OCR_Teachers",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsOwner", "ModifiedBy", "ModifiedDate", "OCR_Id", "StaffId" },
                values: new object[] { 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, 1, 1 });

            migrationBuilder.InsertData(
                table: "PhysicalClassRooms",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "GradeClassId", "Medium", "ModifiedBy", "ModifiedDate", "TeacherId", "Year" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, null, null, null, 2021 },
                    { 2, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 0, null, null, null, 2021 },
                    { 3, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 0, null, null, null, 2021 },
                    { 4, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 0, null, null, null, 2021 },
                    { 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 0, null, null, null, 2021 },
                    { 6, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, 0, null, null, null, 2021 },
                    { 7, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, 0, null, null, null, 2021 },
                    { 8, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, 0, null, null, null, 2021 },
                    { 9, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, 0, null, null, null, 2021 },
                    { 10, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, 0, null, null, null, 2021 },
                    { 11, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, 0, null, null, null, 2021 },
                    { 12, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12, 0, null, null, null, 2021 },
                    { 13, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, 0, null, null, null, 2021 }
                });

            migrationBuilder.InsertData(
                table: "OCR_ClassRooms",
                columns: new[] { "Id", "CR_Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "OCR_Id" },
                values: new object[] { 1, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1 });

            migrationBuilder.InsertData(
                table: "OnlineClasses",
                columns: new[] { "Id", "CalendarEvent", "CreatedBy", "CreatedDate", "Date", "FromTime", "Lesson", "ModifiedBy", "ModifiedDate", "OCR_Id", "OCR_TeacherId", "RepeatPattern", "Subject", "ToTime" },
                values: new object[,]
                {
                    { 9, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), null, null, null, 1, 1, null, null, new TimeSpan(0, 18, 30, 0, 0) },
                    { 8, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), null, null, null, 1, 1, null, null, new TimeSpan(0, 18, 30, 0, 0) },
                    { 7, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), null, null, null, 1, 1, null, null, new TimeSpan(0, 18, 30, 0, 0) },
                    { 6, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), null, null, null, 1, 1, null, null, new TimeSpan(0, 18, 30, 0, 0) },
                    { 5, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), null, null, null, 1, 1, null, null, new TimeSpan(0, 18, 30, 0, 0) },
                    { 4, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), null, null, null, 1, 1, null, null, new TimeSpan(0, 18, 30, 0, 0) },
                    { 3, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), null, null, null, 1, 1, null, null, new TimeSpan(0, 18, 30, 0, 0) },
                    { 2, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), null, null, null, 1, 1, null, null, new TimeSpan(0, 18, 30, 0, 0) },
                    { 1, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), null, null, null, 1, 1, null, null, new TimeSpan(0, 18, 30, 0, 0) },
                    { 10, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), null, null, null, 1, 1, null, null, new TimeSpan(0, 18, 30, 0, 0) },
                    { 11, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), null, null, null, 1, 1, null, null, new TimeSpan(0, 18, 30, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "PCR_Students",
                columns: new[] { "Id", "CR_Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "RegisterNo", "StudentId" },
                values: new object[,]
                {
                    { 12, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 12 },
                    { 41, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 41 },
                    { 42, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 42 },
                    { 43, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 43 },
                    { 44, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 44 },
                    { 45, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 45 },
                    { 46, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 46 },
                    { 47, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 47 },
                    { 48, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 48 },
                    { 49, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 49 },
                    { 50, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 50 },
                    { 51, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 51 },
                    { 40, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 40 },
                    { 52, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 52 },
                    { 54, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 54 },
                    { 55, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 55 },
                    { 9, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 9 },
                    { 8, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 8 },
                    { 7, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 7 },
                    { 6, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 6 },
                    { 5, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 5 },
                    { 4, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 4 },
                    { 3, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 3 },
                    { 2, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 2 },
                    { 1, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 1 },
                    { 53, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 53 },
                    { 11, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 11 },
                    { 39, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 39 },
                    { 37, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 37 },
                    { 13, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 13 },
                    { 14, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 14 },
                    { 15, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 15 },
                    { 16, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 16 },
                    { 17, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 17 },
                    { 18, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 18 },
                    { 19, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 19 },
                    { 20, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 20 },
                    { 21, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 21 },
                    { 22, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 22 },
                    { 23, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 23 },
                    { 38, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 38 },
                    { 24, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 24 },
                    { 26, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 26 },
                    { 27, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 27 },
                    { 28, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 28 },
                    { 29, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 29 },
                    { 30, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 30 },
                    { 31, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 31 },
                    { 32, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 32 },
                    { 10, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 10 },
                    { 34, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 34 },
                    { 35, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 35 },
                    { 36, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 36 },
                    { 25, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 25 },
                    { 33, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 0, 33 }
                });

            migrationBuilder.InsertData(
                table: "OC_Meetings",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "MeetingCode", "ModifiedBy", "ModifiedDate", "OC_Id" },
                values: new object[] { 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MYEWAPPSOO", null, null, 1 });

            migrationBuilder.InsertData(
                table: "OC_Meetings",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "MeetingCode", "ModifiedBy", "ModifiedDate", "OC_Id" },
                values: new object[] { 2, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ASQWCRTUFF", null, null, 2 });

            migrationBuilder.InsertData(
                table: "OC_Meetings",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "MeetingCode", "ModifiedBy", "ModifiedDate", "OC_Id" },
                values: new object[] { 3, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IGIPEICFEK", null, null, 3 });

            migrationBuilder.InsertData(
                table: "OC_MeetingAttendees",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Duration", "ModifiedBy", "ModifiedDate", "OC_MeetingId", "StudentId", "TimesVisited" },
                values: new object[] { 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5110L, null, null, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "OC_MeetingAttendees",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Duration", "ModifiedBy", "ModifiedDate", "OC_MeetingId", "StudentId", "TimesVisited" },
                values: new object[] { 2, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4879L, null, null, 2, 11, 2 });

            migrationBuilder.InsertData(
                table: "OC_MeetingAttendees",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Duration", "ModifiedBy", "ModifiedDate", "OC_MeetingId", "StudentId", "TimesVisited" },
                values: new object[] { 3, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4805L, null, null, 3, 21, 4 });

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
                name: "IX_ClassPromotionDetails_ToClassId",
                table: "ClassPromotionDetails",
                column: "ToClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassPromotions_GradeId",
                table: "ClassPromotions",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraActivityAchievements_ActivityId",
                table: "ExtraActivityAchievements",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraActivityIncharges_ActivityId",
                table: "ExtraActivityIncharges",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraActivityIncharges_StaffId",
                table: "ExtraActivityIncharges",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraActivityPositions_ActivityId",
                table: "ExtraActivityPositions",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeClasses_GradeId",
                table: "GradeClasses",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeClassSubjects_GradeClassId",
                table: "GradeClassSubjects",
                column: "GradeClassId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeClassSubjects_SubjectId",
                table: "GradeClassSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeHeads_GradeId",
                table: "GradeHeads",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeHeads_StaffId",
                table: "GradeHeads",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_SectionId",
                table: "Grades",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_TeacherId",
                table: "Grades",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeSubjects_GradeId",
                table: "GradeSubjects",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeSubjects_SubjectId",
                table: "GradeSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_StudentLeavingCertificate",
                table: "LeavingCertificates",
                column: "StudId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ParentMenuId",
                table: "Menus",
                column: "ParentMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_OC_MeetingAttendees_OC_MeetingId",
                table: "OC_MeetingAttendees",
                column: "OC_MeetingId");

            migrationBuilder.CreateIndex(
                name: "IX_OC_Meetings_OC_Id",
                table: "OC_Meetings",
                column: "OC_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OCR_ClassRooms_CR_Id",
                table: "OCR_ClassRooms",
                column: "CR_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OCR_ClassRooms_OCR_Id",
                table: "OCR_ClassRooms",
                column: "OCR_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OCR_Teachers_OCR_Id",
                table: "OCR_Teachers",
                column: "OCR_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OCR_Teachers_StaffId",
                table: "OCR_Teachers",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineClasses_OCR_Id",
                table: "OnlineClasses",
                column: "OCR_Id");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineClasses_OCR_TeacherId",
                table: "OnlineClasses",
                column: "OCR_TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineClassRooms_GradeId",
                table: "OnlineClassRooms",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineClassRooms_SubjectId",
                table: "OnlineClassRooms",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PCR_Monitors_CR_Id",
                table: "PCR_Monitors",
                column: "CR_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PCR_Monitors_StudentId",
                table: "PCR_Monitors",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_PCR_Students_CR_Id",
                table: "PCR_Students",
                column: "CR_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PCR_Students_StudentId",
                table: "PCR_Students",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_PCR_StudentSubjectMarks_CR_StudentSubjectId",
                table: "PCR_StudentSubjectMarks",
                column: "CR_StudentSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PCR_StudentSubjects_CR_StudentId",
                table: "PCR_StudentSubjects",
                column: "CR_StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_PCR_StudentSubjects_SubjectId",
                table: "PCR_StudentSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PCR_Subjects_CR_Id",
                table: "PCR_Subjects",
                column: "CR_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PCR_Subjects_StaffId",
                table: "PCR_Subjects",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_PCR_Subjects_SubjectId",
                table: "PCR_Subjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_PCR_Teachers_CR_Id",
                table: "PCR_Teachers",
                column: "CR_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PCR_Teachers_StaffId",
                table: "PCR_Teachers",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalClassRooms_GradeClassId",
                table: "PhysicalClassRooms",
                column: "GradeClassId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalClassRooms_TeacherId",
                table: "PhysicalClassRooms",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleGradeAccesses_GradeId",
                table: "RoleGradeAccesses",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenuAccesses_RoleId",
                table: "RoleMenuAccesses",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleMenuAccesses_MenuId_ActionId",
                table: "RoleMenuAccesses",
                columns: new[] { "MenuId", "ActionId" });

            migrationBuilder.CreateIndex(
                name: "IX_SectionHeads_SectionId",
                table: "SectionHeads",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionHeads_StaffId",
                table: "SectionHeads",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffMembers_TeacherId",
                table: "StaffMembers",
                column: "TeacherId",
                unique: true,
                filter: "[TeacherId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StudentBasketSubjects_StudentId",
                table: "StudentBasketSubjects",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentBasketSubjects_SubjectId",
                table: "StudentBasketSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExtraActivityAcheivements_AcheivementId",
                table: "StudentExtraActivityAcheivements",
                column: "AcheivementId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExtraActivityAcheivements_StudentId",
                table: "StudentExtraActivityAcheivements",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExtraActivityPositions_PositionId",
                table: "StudentExtraActivityPositions",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentExtraActivityPositions_StudentId",
                table: "StudentExtraActivityPositions",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentFamilies_ParentId",
                table: "StudentFamilies",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentFamilies_StudentId",
                table: "StudentFamilies",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AdmittedClassId",
                table: "Students",
                column: "AdmittedClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AdmittedGradeId",
                table: "Students",
                column: "AdmittedGradeId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_LastClassId",
                table: "Students",
                column: "LastClassId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSiblings_StudentId",
                table: "StudentSiblings",
                column: "StudentId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SectionId",
                table: "Subjects",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SubjectCategoryId",
                table: "Subjects",
                column: "SubjectCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherOffTimes_TeacherId",
                table: "TeacherOffTimes",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherPreferedSubjects_SubjectId",
                table: "TeacherPreferedSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherPreferedSubjects_TeacherId",
                table: "TeacherPreferedSubjects",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherQualifications_TeacherId",
                table: "TeacherQualifications",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherQualificationSubjects_SubjectId",
                table: "TeacherQualificationSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherQualificationSubjects_TeacherQualificationId",
                table: "TeacherQualificationSubjects",
                column: "TeacherQualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_SectionId",
                table: "Teachers",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ParentId",
                table: "Users",
                column: "ParentId",
                unique: true,
                filter: "[ParentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StaffId",
                table: "Users",
                column: "StaffId",
                unique: true,
                filter: "[StaffId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StudentId",
                table: "Users",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_VisitorId",
                table: "Users",
                column: "VisitorId",
                unique: true,
                filter: "[VisitorId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuditTemp");

            migrationBuilder.DropTable(
                name: "ClassPromotionDetails");

            migrationBuilder.DropTable(
                name: "ExtraActivityIncharges");

            migrationBuilder.DropTable(
                name: "GradeClassSubjects");

            migrationBuilder.DropTable(
                name: "GradeEmails");

            migrationBuilder.DropTable(
                name: "GradeHeads");

            migrationBuilder.DropTable(
                name: "GradeSubjects");

            migrationBuilder.DropTable(
                name: "LeavingCertificates");

            migrationBuilder.DropTable(
                name: "NearbySchools");

            migrationBuilder.DropTable(
                name: "OC_MeetingAttendees");

            migrationBuilder.DropTable(
                name: "OCR_ClassRooms");

            migrationBuilder.DropTable(
                name: "PCR_Monitors");

            migrationBuilder.DropTable(
                name: "PCR_StudentSubjectMarks");

            migrationBuilder.DropTable(
                name: "PCR_Subjects");

            migrationBuilder.DropTable(
                name: "PCR_Teachers");

            migrationBuilder.DropTable(
                name: "RoleGradeAccesses");

            migrationBuilder.DropTable(
                name: "RoleMenuAccesses");

            migrationBuilder.DropTable(
                name: "SectionHeads");

            migrationBuilder.DropTable(
                name: "StudentBasketSubjects");

            migrationBuilder.DropTable(
                name: "StudentExtraActivityAcheivements");

            migrationBuilder.DropTable(
                name: "StudentExtraActivityPositions");

            migrationBuilder.DropTable(
                name: "StudentFamilies");

            migrationBuilder.DropTable(
                name: "StudentSiblings");

            migrationBuilder.DropTable(
                name: "StudentTransfers");

            migrationBuilder.DropTable(
                name: "SyncLogs");

            migrationBuilder.DropTable(
                name: "SyncQueue");

            migrationBuilder.DropTable(
                name: "SystemParameters");

            migrationBuilder.DropTable(
                name: "TeacherOffTimes");

            migrationBuilder.DropTable(
                name: "TeacherPreferedSubjects");

            migrationBuilder.DropTable(
                name: "TeacherQualificationSubjects");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "ClassPromotions");

            migrationBuilder.DropTable(
                name: "OC_Meetings");

            migrationBuilder.DropTable(
                name: "PCR_StudentSubjects");

            migrationBuilder.DropTable(
                name: "MenuActions");

            migrationBuilder.DropTable(
                name: "ExtraActivityAchievements");

            migrationBuilder.DropTable(
                name: "ExtraActivityPositions");

            migrationBuilder.DropTable(
                name: "TeacherQualifications");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "OnlineClasses");

            migrationBuilder.DropTable(
                name: "PCR_Students");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "ExtraActivities");

            migrationBuilder.DropTable(
                name: "Parents");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "OCR_Teachers");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "OnlineClassRooms");

            migrationBuilder.DropTable(
                name: "StaffMembers");

            migrationBuilder.DropTable(
                name: "PhysicalClassRooms");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "GradeClasses");

            migrationBuilder.DropTable(
                name: "SubjectCategories");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Sections");
        }
    }
}
