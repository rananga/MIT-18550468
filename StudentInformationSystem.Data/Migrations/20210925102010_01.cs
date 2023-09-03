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
                    ParticipantEmail = table.Column<string>(maxLength: 30, nullable: false),
                    UniqueQualifier = table.Column<long>(nullable: false),
                    MeetingCode = table.Column<string>(maxLength: 30, nullable: true),
                    OrganizerEmail = table.Column<string>(maxLength: 30, nullable: true),
                    Duration = table.Column<long>(nullable: true),
                    CalendarEventId = table.Column<string>(maxLength: 50, nullable: true),
                    ConferenceID = table.Column<string>(maxLength: 50, nullable: true),
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
                name: "Permissions",
                columns: table => new
                {
                    PermissionId = table.Column<int>(nullable: false)
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
                    table.PrimaryKey("PK_Permissions", x => x.PermissionId);
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
                    SchoolEmail = table.Column<string>(nullable: true),
                    Nicno = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExtraActivityAcheivements",
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
                    table.PrimaryKey("PK_ExtraActivityAcheivements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activity_Acheivements",
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
                name: "PermissionMenuAccesses",
                columns: table => new
                {
                    MenuId = table.Column<int>(nullable: false),
                    PermissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionMenuAccesses", x => new { x.MenuId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_Menu_PermissionMenuAccesses",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Permission_PermissionMenuAccesses",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Restrict);
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
                    SchoolEmail = table.Column<string>(nullable: true),
                    Nicno = table.Column<string>(nullable: false),
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
                name: "PermissionGradeAccesses",
                columns: table => new
                {
                    GradeId = table.Column<int>(nullable: false),
                    PermissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionGradeAccesses", x => new { x.GradeId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_Grade_PermissionGradeAccesses",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Permission_PermissionGradeAccesses",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "PermissionId",
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
                    VisitorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_StaffMembers_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffMembers",
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
                name: "UserPermissions",
                columns: table => new
                {
                    UserPermissionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    PermissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissions", x => x.UserPermissionId);
                    table.ForeignKey(
                        name: "FK_Permission_UserPermissions",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "PermissionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_UserPermissions",
                        column: x => x.UserId,
                        principalTable: "Users",
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
                    IndexNo = table.Column<int>(nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime", nullable: true),
                    FullName = table.Column<string>(nullable: false),
                    Initials = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    SchoolEmail = table.Column<string>(nullable: true),
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
                    AdmittedGradeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
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
                    StudentId = table.Column<int>(nullable: false)
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
                        principalTable: "ExtraActivityAcheivements",
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
                    Title = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Relationship = table.Column<int>(nullable: false),
                    Occupation = table.Column<string>(nullable: false),
                    WorkingAdd = table.Column<string>(nullable: true),
                    OfficeTel = table.Column<string>(nullable: true),
                    ContactMob = table.Column<string>(nullable: false),
                    ContactHome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Nicno = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentFamilies", x => x.Id);
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
                    { 4, null, null, null, 40, "fas fa-user-graduate", false, null, "Student", "M" },
                    { 5, null, null, null, 50, "fas fa-laptop-code", false, null, "Online", "M" },
                    { 2, null, null, null, 20, "fas fa-book-reader", false, null, "Academic", "M" },
                    { 1, null, null, null, 10, "fas fa-user-tie", false, null, "Admin", "M" },
                    { 3, null, null, null, 30, "fas fa-chalkboard-teacher", false, null, "Teacher", "M" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "PermissionId", "Code", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "Admin", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Administrator" },
                    { 2, "AdminUser", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Admin Department User" }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "Description", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { 6, "AL-Technology", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AL Technology Section", null, null },
                    { 5, "AL-Art & Commerce", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AL Art & Commerce Section", null, null },
                    { 4, "AL-Science", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "AL Science Section", null, null },
                    { 2, "Junior", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Junior Section", null, null },
                    { 1, "Primary", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primary Section", null, null },
                    { 3, "Senior", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior Section", null, null }
                });

            migrationBuilder.InsertData(
                table: "StaffMembers",
                columns: new[] { "Id", "Address1", "Address2", "City", "CreatedBy", "CreatedDate", "FullName", "Gender", "ImagePath", "ImmeContactName", "ImmeContactNo", "Initials", "JoinedDate", "LastName", "MobileNo", "ModifiedBy", "ModifiedDate", "Nicno", "RetiredDate", "SchoolEmail", "StaffNumber", "Status", "TeacherId", "TelHome", "Title" },
                values: new object[,]
                {
                    { 10, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vijini Herath", 1, null, "TestEntry", "0712345678", "Vijini", null, "Herath", "0712345678", null, null, "888888010V", null, "vijinih@nalandacollege.info", 110, 0, null, null, 5 },
                    { 14, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dinithi Fernando", 1, null, "TestEntry", "0712345678", "Dinithi", null, "Fernando", "0712345678", null, null, "888888014V", null, "dinithif@nalandacollege.info", 114, 0, null, null, 6 },
                    { 13, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dilani Nilanga", 1, null, "TestEntry", "0712345678", "Dilani", null, "Nilanga", "0712345678", null, null, "888888013V", null, "dilinin@nalandacollege.info", 113, 0, null, null, 5 },
                    { 12, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kalpa Udayappriya", 0, null, "TestEntry", "0712345678", "Kalpa", null, "Udayappriya", "0712345678", null, null, "888888012V", null, "kalpau@nalandacollege.info", 112, 0, null, null, 4 },
                    { 11, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "බැද්දේවෙල ධම්මකිත්ති හිමි", 0, null, "TestEntry", "0712345678", "බැද්දේවෙල", null, "ධම්මකිත්ති හිමි", "0712345678", null, null, "888888011V", null, "bdhammakiththi@nalandacollege.info", 111, 0, null, null, 1 },
                    { 9, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Prabha Hiroshine", 1, null, "TestEntry", "0712345678", "Prabha", null, "Hiroshine", "0712345678", null, null, "888888009V", null, "prabhah@nalandacollege.info", 109, 0, null, null, 5 },
                    { 8, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Thilini Cooray", 1, null, "TestEntry", "0712345678", "Thilini", null, "Cooray", "0712345678", null, null, "888888008V", null, "thilinic@nalandacollege.info", 108, 0, null, null, 5 },
                    { 6, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "D.S.Chethana", 1, null, "TestEntry", "0712345678", "D.S.", null, "Chethana", "0712345678", null, null, "888888006V", null, "chethanac@nalandacollege.info", 106, 0, null, null, 5 },
                    { 5, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gammanpila Dayananda", 0, null, "TestEntry", "0712345678", "Gammanpila", null, "Dayananda", "0712345678", null, null, "888888005V", null, "dayanandag@nalandacollege.info", 105, 0, null, null, 4 },
                    { 4, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malsha Mallawaarachchi", 1, null, "TestEntry", "0712345678", "Malsha", null, "Mallawaarachchi", "0712345678", null, null, "888888004V", null, "malsham@nalandacollege.info", 104, 0, null, null, 5 },
                    { 3, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Apsara Vithan", 1, null, "TestEntry", "0712345678", "Apsara", null, "Vithan", "0712345678", null, null, "888888003V", null, "apsarae@nalandacollege.info", 103, 0, null, null, 5 },
                    { 2, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ayomi Dilhani", 1, null, "TestEntry", "0712345678", "Ayomi", null, "Dilhani", "0712345678", null, null, "888888002V", null, "ayomik@nalandacollege.info", 102, 0, null, null, 5 },
                    { 1, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Diana Sladen", 1, null, "TestEntry", "0712345678", "Diana", null, "Sladen", "0712345678", null, null, "888888001V", null, "dainas@nalandacollege.info", 101, 0, null, null, 5 },
                    { 7, "TestEntry", "TestEntry", "Colombo", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Himali Nanayakkara", 1, null, "TestEntry", "0712345678", "Himali", null, "Nanayakkara", "0712345678", null, null, "888888007V", null, "himalin@nalandacollege.info", 107, 0, null, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address1", "Address2", "AdmissionDate", "AdmittedGradeId", "City", "CreatedBy", "CreatedDate", "DOB", "EmergContactName", "EmergContactNo", "FullName", "ImagePath", "IndexNo", "Initials", "IsLeavingIssued", "LastClassId", "LastName", "LeavingDate", "Medium", "ModifiedBy", "ModifiedDate", "SchoolEmail", "Status" },
                values: new object[,]
                {
                    { 30, null, null, new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "M.G.Shashen R. Bandara", null, 27287, "M.G.Shashen R.", false, null, "Bandara", null, 1, null, null, "27287@nalandacollege.info", 0 },
                    { 40, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Seniru M.Weerasinghe", null, 25656, "Seniru", false, null, "M.Weerasinghe", null, 1, null, null, "25656@nalandacollege.info", 0 },
                    { 39, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Sanuth I.E.Liyanage", null, 27385, "Sanuth I.", false, null, "E.Liyanage", null, 1, null, null, "27385@nalandacollege.info", 0 },
                    { 38, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Sanuka N.Wanniarachchi", null, 25032, "Sanuka N.", false, null, "Wanniarachchi", null, 1, null, null, "25032@nalandacollege.info", 0 },
                    { 37, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "S.M.Pavanindu N. Egodagedara", null, 27364, "S.M.Pavanindu N.", false, null, "Egodagedara", null, 1, null, null, "27364@nalandacollege.info", 0 },
                    { 33, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "P.M.G.Onitha O. Gunathilake", null, 24779, "P.M.G.Onitha O.", false, null, "Gunathilake", null, 1, null, null, "24779@nalandacollege.info", 0 },
                    { 35, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "R.G.Ravishka Sathsindu", null, 24812, "R.G.Ravishka", false, null, "Sathsindu", null, 1, null, null, "24812@nalandacollege.info", 0 },
                    { 34, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "R.M.Thisath Dewwin Bandara", null, 28052, "R.M.Thisath Dewwin", false, null, "Bandara", null, 1, null, null, "28052@nalandacollege.info", 0 },
                    { 41, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Senuja M.Gunasekara", null, 24775, "Senuja M.", false, null, "Gunasekara", null, 1, null, null, "24775@nalandacollege.info", 0 },
                    { 32, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Minul Demith Peladagama", null, 25039, "Minul Demith", false, null, "Peladagama", null, 1, null, null, "25039@nalandacollege.info", 0 },
                    { 31, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Mihisara Kaveesha Hettiarachchi", null, 28647, "Mihisara Kaveesha", false, null, "Hettiarachchi", null, 1, null, null, "28647@nalandacollege.info", 0 },
                    { 36, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "R.M.Sashmitha N. B.Kotu", null, 25640, "R.M.Sashmitha N. B.", false, null, "Kotu", null, 1, null, null, "25640@nalandacollege.info", 0 },
                    { 42, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Sithum K.S.Rajapaksha", null, 27327, "Sithum K.S.", false, null, "Rajapaksha", null, 1, null, null, "27327@nalandacollege.info", 0 },
                    { 46, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Tharusha V.Kalubowila", null, 24710, "Tharusha V.", false, null, "Kalubowila", null, 1, null, null, "24710@nalandacollege.info", 0 },
                    { 44, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "T.N.Hansaka Walpola", null, 27396, "T.N.Hansaka", false, null, "Walpola", null, 1, null, null, "27396@nalandacollege.info", 0 },
                    { 45, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Tharul B. Dharmasena", null, 24718, "Tharul B.", false, null, "Dharmasena", null, 1, null, null, "24718@nalandacollege.info", 0 },
                    { 47, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "The min S. Wijayawardana", null, 24770, "The min S.", false, null, "Wijayawardana", null, 1, null, null, "24770@nalandacollege.info", 0 },
                    { 48, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "W.Sachintha Akalanka", null, 27347, "W.Sachintha", false, null, "Akalanka", null, 1, null, null, "27347@nalandacollege.info", 0 },
                    { 49, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "W.A.Dinushka R Perera", null, 24790, "W.A.Dinushka R", false, null, "Perera", null, 1, null, null, "24790@nalandacollege.info", 0 },
                    { 50, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "W.A.H.Nethru Weerasooriya", null, 24754, "W.A.H.Nethru", false, null, "Weerasooriya", null, 1, null, null, "24754@nalandacollege.info", 0 },
                    { 51, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "W.A.Nushan Wijeweera", null, 27483, "W.A.Nushan", false, null, "Wijeweera", null, 1, null, null, "27483@nalandacollege.info", 0 },
                    { 52, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "W.F.Tenura T. Perera", null, 27482, "W.F.Tenura T.", false, null, "Perera", null, 1, null, null, "27482@nalandacollege.info", 0 },
                    { 53, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "W.M.A.Rivinaka Eragoda", null, 25430, "W.M.A.Rivinaka", false, null, "Eragoda", null, 1, null, null, "25430@nalandacollege.info", 0 },
                    { 54, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Yonal B. Galagedara", null, 28054, "Yonal B.", false, null, "Galagedara", null, 1, null, null, "28054@nalandacollege.info", 0 },
                    { 55, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Yumeth M.Dewapura", null, 24714, "Yumeth M.", false, null, "Dewapura", null, 1, null, null, "24714@nalandacollege.info", 0 },
                    { 43, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "T.Thulnith I. Vithana", null, 24757, "T.Thulnith I.", false, null, "Vithana", null, 1, null, null, "24757@nalandacollege.info", 0 },
                    { 29, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "M.D.Savith P. Binuditha", null, 27289, "M.D.Savith P.", false, null, "Binuditha", null, 1, null, null, "27289@nalandacollege.info", 0 },
                    { 11, null, null, new DateTime(2021, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "G.Nuran C. Perera", null, 24785, "G.Nuran C.", false, null, "Perera", null, 1, null, null, "24785@nalandacollege.info", 0 },
                    { 27, null, null, new DateTime(2021, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Luvya V.Seelanatha", null, 24680, "Luvya V.", false, null, "Seelanatha", null, 1, null, null, "24680@nalandacollege.info", 0 },
                    { 1, null, null, new DateTime(2021, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Anuk Gunasekara", null, 25130, "Anuk", false, null, "Gunasekara", null, 1, null, null, "25130@nalandacollege.info", 0 },
                    { 2, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "B.A.Inuka A. Abeysekara", null, 24695, "B.A.Inuka A.", false, null, "Abeysekara", null, 1, null, null, "24695@nalandacollege.info", 0 },
                    { 3, null, null, new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "B.A.Thavidu T. Wimalasena", null, 24747, "B.A.Thavidu T.", false, null, "Wimalasena", null, 1, null, null, "24747@nalandacollege.info", 0 },
                    { 4, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Bihandu A.Bethmage", null, 25445, "Bihandu A.", false, null, "Bethmage", null, 1, null, null, "25445@nalandacollege.info", 0 },
                    { 5, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Chanuka S.Wijerathna", null, 24735, "Chanuka S.", false, null, "Wijerathna", null, 1, null, null, "24735@nalandacollege.info", 0 },
                    { 6, null, null, new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "D.T.K.Nethun Sanketh", null, 24701, "D.T.K.Nethun", false, null, "Sanketh", null, 1, null, null, "24701@nalandacollege.info", 0 },
                    { 7, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "D.W.Iran V.S.Wickramanayake", null, 27403, "D.W.Iran V.S.", false, null, "Wickramanayake", null, 1, null, null, "27403@nalandacollege.info", 0 },
                    { 8, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Dimath B Kahatapitiya", null, 24750, "Dimath B", false, null, "Kahatapitiya", null, 1, null, null, "24750@nalandacollege.info", 0 },
                    { 9, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Dulain S. Jayawardhana", null, 24706, "Dulain S.", false, null, "Jayawardhana", null, 1, null, null, "24706@nalandacollege.info", 0 },
                    { 10, null, null, new DateTime(2021, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Dulina S.Gunathilake", null, 25145, "Dulina S.", false, null, "Gunathilake", null, 1, null, null, "25145@nalandacollege.info", 0 },
                    { 28, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "M.A.Chathura P. Karunasekara", null, 24746, "M.A.Chathura P.", false, null, "Karunasekara", null, 1, null, null, "24746@nalandacollege.info", 0 },
                    { 13, null, null, new DateTime(2021, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "G.P.Dimath Senhiru", null, 27390, "G.P.Dimath", false, null, "Senhiru", null, 1, null, null, "27390@nalandacollege.info", 0 },
                    { 12, null, null, new DateTime(2021, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "G.A.D.Daham C. Siriwardane", null, 24685, "G.A.D.Daham C.", false, null, "Siriwardane", null, 1, null, null, "24685@nalandacollege.info", 0 },
                    { 15, null, null, new DateTime(2021, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "H.A.Hirun S. Samaranayake", null, 24712, "H.A.Hirun S.", false, null, "Samaranayake", null, 1, null, null, "24712@nalandacollege.info", 0 },
                    { 26, null, null, new DateTime(2021, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "L.K.A.Y.Dissanayake", null, 29091, "L.K.A.Y.", false, null, "Dissanayake", null, 1, null, null, "29091@nalandacollege.info", 0 },
                    { 25, null, null, new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Kuvidu H.Amarasinghe", null, 24781, "Kuvidu H.", false, null, "Amarasinghe", null, 1, null, null, "24781@nalandacollege.info", 0 },
                    { 24, null, null, new DateTime(2021, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "K.S.Vikum M. Kariyawasam", null, 24755, "K.S.Vikum M.", false, null, "Kariyawasam", null, 1, null, null, "24755@nalandacollege.info", 0 },
                    { 23, null, null, new DateTime(2021, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "K.Mithuru M. Perera", null, 25425, "K.Mithuru M.", false, null, "Perera", null, 1, null, null, "25425@nalandacollege.info", 0 },
                    { 14, null, null, new DateTime(2021, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "G.V.Himasha R Peiris", null, 24786, "G.V.Himasha R", false, null, "Peiris", null, 1, null, null, "24786@nalandacollege.info", 0 },
                    { 21, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "J.M.M.Raadawa Jayasundara", null, 24749, "J.M.M.Raadawa", false, null, "Jayasundara", null, 1, null, null, "24749@nalandacollege.info", 0 },
                    { 22, null, null, new DateTime(2021, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "K.Dasindu Dulwan", null, 28051, "K.Dasindu", false, null, "Dulwan", null, 1, null, null, "28051@nalandacollege.info", 0 },
                    { 19, null, null, new DateTime(2021, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "I.A.Daniru Vinijith", null, 24687, "I.A.Daniru", false, null, "Vinijith", null, 1, null, null, "24687@nalandacollege.info", 0 },
                    { 18, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "H.M.Thimath S. Herath", null, 24972, "H.M.Thimath S.", false, null, "Herath", null, 1, null, null, "24972@nalandacollege.info", 0 },
                    { 17, null, null, new DateTime(2021, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "H.M.Dinuka D.B.Rajaguru", null, 27326, "H.M.Dinuka D.B.", false, null, "Rajaguru", null, 1, null, null, "27326@nalandacollege.info", 0 },
                    { 16, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "H.A.Ositha J. Wijayarathna", null, 24758, "H.A.Ositha J.", false, null, "Wijayarathna", null, 1, null, null, "24758@nalandacollege.info", 0 },
                    { 20, null, null, new DateTime(2021, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "J.K.Tharul M. Perera", null, 24717, "J.K.Tharul M.", false, null, "Perera", null, 1, null, null, "24717@nalandacollege.info", 0 }
                });

            migrationBuilder.InsertData(
                table: "SubjectCategories",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "Description", "IsBasket", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { 4, "Basket 3", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, null, null },
                    { 1, "Main", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, null },
                    { 2, "Basket 1", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, null, null },
                    { 3, "Basket 2", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, null, null }
                });

            migrationBuilder.InsertData(
                table: "Visitors",
                columns: new[] { "Id", "Address1", "Address2", "City", "CreatedBy", "CreatedDate", "FullName", "Gender", "ImagePath", "Initials", "LastName", "MobileNo", "ModifiedBy", "ModifiedDate", "Nicno", "SchoolEmail", "Title" },
                values: new object[] { 1, null, null, null, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rananga Lakshitha Suraweera", 0, null, "R L", "Suraweera", "0713522384", null, null, "860272580V", "rananga@nalandacollege.info", 4 });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "GradeNo", "ModifiedBy", "ModifiedDate", "SectionId", "TeacherId" },
                values: new object[,]
                {
                    { 2, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primary Section Grade 2", 2, null, null, 1, null },
                    { 11, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior Section Grade 11", 11, null, null, 3, null },
                    { 10, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior Section Grade 10", 10, null, null, 3, null },
                    { 9, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Senior Section Grade 9", 9, null, null, 3, null },
                    { 8, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Junior Section Grade 8", 8, null, null, 2, null },
                    { 7, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Junior Section Grade 7", 7, null, null, 2, null },
                    { 6, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Junior Section Grade 6", 6, null, null, 2, null },
                    { 5, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primary Section Grade 5", 5, null, null, 1, null },
                    { 4, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primary Section Grade 4", 4, null, null, 1, null },
                    { 3, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primary Section Grade 3", 3, null, null, 1, null },
                    { 1, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primary Section Grade 1", 1, null, null, 1, null }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "Action", "Area", "Controller", "DisplaySeq", "Icon", "IsHidden", "ParentMenuId", "Text", "Type" },
                values: new object[,]
                {
                    { 30, "Index", "Student", "StudentExtraActivities", 60, null, false, 4, "Student Extra Activities", "I" },
                    { 31, "Index", "Online", "OnlineClassRoom", 10, null, false, 5, "Online Classrooms", "I" },
                    { 32, "Index", "Online", "OnlineTimeTable", 20, null, false, 5, "Online Time Table", "I" },
                    { 33, "Process", "Report", "StudentCharacter", 10, null, false, 6, "Student Character", "I" },
                    { 7, "Index", "Admin", "Section", 10, null, false, 1, "Sections", "I" },
                    { 35, "Process", "Report", "StudentMarks", 30, null, false, 6, "Term Wise Student Marks", "I" },
                    { 37, "Process", "Report", "WeeklySummary", 50, null, false, 6, "Weekly Summary", "I" },
                    { 29, "Index", "Student", "ClassPromotion", 50, null, false, 4, "Class Promotion", "I" },
                    { 34, "Process", "Report", "StudentAttendance", 20, null, false, 6, "Student Attendance", "I" },
                    { 28, "Index", "Student", "TransferStudent", 50, null, false, 4, "Transfer Student", "I" },
                    { 36, "Process", "Report", "OnlineSessionsSummary", 40, null, false, 6, "Online Sessions Summary", "I" },
                    { 26, "Index", "Student", "StudentAdmit", 30, null, false, 4, "Admit Student", "I" },
                    { 8, "Index", "Admin", "Grade", 20, null, false, 1, "Grades", "I" },
                    { 9, "Index", "Admin", "StaffMember", 30, null, false, 1, "Staff Members", "I" },
                    { 27, "Index", "Student", "StudentMark", 40, null, false, 4, "Student Marks", "I" },
                    { 11, "Index", "Admin", "UserPermission", 50, null, false, 1, "User Permissions", "I" },
                    { 12, "Index", "Admin", "Users", 60, null, false, 1, "Users", "I" },
                    { 13, "Index", "Admin", "SectionHead", 70, null, false, 1, "Section Heads", "I" },
                    { 14, "Index", "Admin", "GradeHead", 80, null, false, 1, "Grade Heads", "I" },
                    { 15, "Index", "Admin", "ExtraActivity", 90, null, false, 1, "Extra Activities", "I" },
                    { 16, "Index", "Academic", "SubjectCategory", 10, null, false, 2, "Subject Categories", "I" },
                    { 17, "Index", "Academic", "Subject", 20, null, false, 2, "Subjects", "I" },
                    { 10, "Index", "Admin", "Visitor", 40, null, false, 1, "Visitors", "I" },
                    { 19, "Index", "Academic", "GradeClass", 40, null, false, 2, "Grade Classes", "I" },
                    { 20, "Index", "Academic", "ClassRoom", 50, null, false, 2, "Physical Classrooms", "I" },
                    { 21, "Index", "Teacher", "Teacher", 10, null, false, 3, "Teacher Subjects", "I" },
                    { 22, "Index", "Teacher", "TeacherQualification", 20, null, false, 3, "Teacher Qualifications", "I" },
                    { 23, "Index", "Teacher", "TeacherOffTime", 30, null, false, 3, "Teacher Off Times", "I" },
                    { 24, "Index", "Student", "Student", 10, null, false, 4, "Student Maintenance", "I" },
                    { 25, "Index", "Student", "BasketSubject", 20, null, false, 4, "Student Basket Subjects", "I" },
                    { 18, "Index", "Academic", "GradeSubject", 30, null, false, 2, "Grade Subjects", "I" }
                });

            migrationBuilder.InsertData(
                table: "PermissionMenuAccesses",
                columns: new[] { "MenuId", "PermissionId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "Description", "Medium", "ModifiedBy", "ModifiedDate", "Number", "SectionId", "SubjectCategoryId" },
                values: new object[,]
                {
                    { 14, "Health", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 4 },
                    { 13, "PTS", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 4 },
                    { 12, "Western Music", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 3 },
                    { 11, "Drama", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 3 },
                    { 10, "Eastern Music", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 3 },
                    { 9, "Civic Education", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 2 },
                    { 8, "Geography", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 2 },
                    { 4, "Mathematics", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 1 },
                    { 6, "History", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 1 },
                    { 5, "Science", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 1 },
                    { 3, "English", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 1 },
                    { 2, "සිංහල", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 1 },
                    { 1, "බුද්ධධර්මය", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 1 },
                    { 15, "ICT", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 4 },
                    { 7, "Tamil", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Password", "StaffId", "Status", "UserName", "VisitorId" },
                values: new object[] { 1, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, 1, "rananga", 1 });

            migrationBuilder.InsertData(
                table: "GradeClasses",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "GradeId", "MaxStudentCount", "Medium", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "1.A", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 0, null, null, 1 },
                    { 2, "1.B", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 0, null, null, 2 },
                    { 3, "1.C", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 0, null, null, 3 },
                    { 4, "1.D", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 0, null, null, 4 },
                    { 5, "9.A", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null, 1, null, null, 1 },
                    { 6, "9.B", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null, 1, null, null, 2 },
                    { 7, "9.C", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null, 0, null, null, 3 },
                    { 8, "9.D", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null, 0, null, null, 4 },
                    { 9, "9.E", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null, 0, null, null, 5 },
                    { 10, "9.F", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null, 0, null, null, 6 },
                    { 11, "9.G", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null, 0, null, null, 7 },
                    { 12, "9.H", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null, 0, null, null, 8 },
                    { 13, "9.I", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null, 0, null, null, 9 }
                });

            migrationBuilder.InsertData(
                table: "OnlineClassRooms",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "GoogleClassRoomId", "GoogleClassrommLink", "GradeId", "Medium", "ModifiedBy", "ModifiedDate", "SubjectId", "Year" },
                values: new object[] { 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 0, null, null, 1, 2021 });

            migrationBuilder.InsertData(
                table: "UserPermissions",
                columns: new[] { "UserPermissionId", "PermissionId", "UserId" },
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
                columns: new[] { "Id", "CR_Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "StudentId" },
                values: new object[,]
                {
                    { 12, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 12 },
                    { 41, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 41 },
                    { 42, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 42 },
                    { 43, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 43 },
                    { 44, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 44 },
                    { 45, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 45 },
                    { 46, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 46 },
                    { 47, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 47 },
                    { 48, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 48 },
                    { 49, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 49 },
                    { 50, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 50 },
                    { 51, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 51 },
                    { 40, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 40 },
                    { 52, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 52 },
                    { 54, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 54 },
                    { 55, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 55 },
                    { 9, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 9 },
                    { 8, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 8 },
                    { 7, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 7 },
                    { 6, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 6 },
                    { 5, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 5 },
                    { 4, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 4 },
                    { 3, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3 },
                    { 2, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2 },
                    { 1, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1 },
                    { 53, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 53 },
                    { 11, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 11 },
                    { 39, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 39 },
                    { 37, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 37 },
                    { 13, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 13 },
                    { 14, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 14 },
                    { 15, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 15 },
                    { 16, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 16 },
                    { 17, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 17 },
                    { 18, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 18 },
                    { 19, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 19 },
                    { 20, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 20 },
                    { 21, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 21 },
                    { 22, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 22 },
                    { 23, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 23 },
                    { 38, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 38 },
                    { 24, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 24 },
                    { 26, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 26 },
                    { 27, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 27 },
                    { 28, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 28 },
                    { 29, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 29 },
                    { 30, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 30 },
                    { 31, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 31 },
                    { 32, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 32 },
                    { 10, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 10 },
                    { 34, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 34 },
                    { 35, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 35 },
                    { 36, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 36 },
                    { 25, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 25 },
                    { 33, 5, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 33 }
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
                name: "IX_ExtraActivityAcheivements_ActivityId",
                table: "ExtraActivityAcheivements",
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
                name: "IX_PermissionGradeAccesses_PermissionId",
                table: "PermissionGradeAccesses",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionMenuAccesses_PermissionId",
                table: "PermissionMenuAccesses",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalClassRooms_GradeClassId",
                table: "PhysicalClassRooms",
                column: "GradeClassId");

            migrationBuilder.CreateIndex(
                name: "IX_PhysicalClassRooms_TeacherId",
                table: "PhysicalClassRooms",
                column: "TeacherId");

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
                name: "IX_StudentFamilies_StudentId",
                table: "StudentFamilies",
                column: "StudentId");

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
                name: "IX_UserPermissions_PermissionId",
                table: "UserPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermissions_UserId",
                table: "UserPermissions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StaffId",
                table: "Users",
                column: "StaffId",
                unique: true,
                filter: "[StaffId] IS NOT NULL");

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
                name: "PermissionGradeAccesses");

            migrationBuilder.DropTable(
                name: "PermissionMenuAccesses");

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
                name: "TeacherOffTimes");

            migrationBuilder.DropTable(
                name: "TeacherPreferedSubjects");

            migrationBuilder.DropTable(
                name: "TeacherQualificationSubjects");

            migrationBuilder.DropTable(
                name: "UserPermissions");

            migrationBuilder.DropTable(
                name: "ClassPromotions");

            migrationBuilder.DropTable(
                name: "OC_Meetings");

            migrationBuilder.DropTable(
                name: "PCR_StudentSubjects");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "ExtraActivityAcheivements");

            migrationBuilder.DropTable(
                name: "ExtraActivityPositions");

            migrationBuilder.DropTable(
                name: "TeacherQualifications");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "OnlineClasses");

            migrationBuilder.DropTable(
                name: "PCR_Students");

            migrationBuilder.DropTable(
                name: "ExtraActivities");

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
