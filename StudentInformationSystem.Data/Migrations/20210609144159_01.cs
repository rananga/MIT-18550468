using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentInformationSystem.Data.Migrations
{
    public partial class _01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Action = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    IsHidden = table.Column<bool>(nullable: false)
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
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.Id);
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
                    StaffNumber = table.Column<string>(nullable: false),
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
                    TeacherId = table.Column<int>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    JoinedDate = table.Column<DateTime>(type: "date", nullable: true),
                    RetiredDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    IndexNo = table.Column<int>(nullable: false),
                    Title = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    Initials = table.Column<string>(nullable: false),
                    LName = table.Column<string>(nullable: false),
                    SchoolEmail = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: false),
                    EmergencyConName = table.Column<string>(nullable: false),
                    EmergencyContactTel = table.Column<string>(nullable: false),
                    Medium = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastGrade = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    InactiveReason = table.Column<string>(nullable: true),
                    IsLeavingIssued = table.Column<bool>(nullable: false),
                    AdmissionDate = table.Column<DateTime>(nullable: false),
                    AdmittedClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudID);
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
                    Title = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    Initials = table.Column<string>(nullable: false),
                    LName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    ContactNo = table.Column<string>(nullable: false),
                    SchoolEmail = table.Column<string>(nullable: true),
                    NICNo = table.Column<string>(nullable: false),
                    TelHome = table.Column<string>(nullable: true),
                    ImmeContactNo = table.Column<string>(nullable: false),
                    ImmeContactName = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    InactiveReason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
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
                    Name = table.Column<string>(nullable: false)
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
                    Name = table.Column<string>(nullable: false),
                    IsBasket = table.Column<bool>(nullable: false)
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
                    ToDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SectionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeHeads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradeHeads_Sections_SectionId",
                        column: x => x.SectionId,
                        principalTable: "Sections",
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
                    ToDate = table.Column<DateTime>(type: "date", nullable: false),
                    StaffMemberId = table.Column<int>(nullable: true)
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
                        name: "FK_SectionHeads_StaffMembers_StaffMemberId",
                        column: x => x.StaffMemberId,
                        principalTable: "StaffMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_StaffMembers_StaffId",
                        column: x => x.StaffId,
                        principalTable: "StaffMembers",
                        principalColumn: "Id",
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
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    StudID = table.Column<int>(nullable: false),
                    Title = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Relationship = table.Column<int>(nullable: false),
                    Occupation = table.Column<string>(nullable: false),
                    WorkingAdd = table.Column<string>(nullable: false),
                    OfficeTel = table.Column<string>(nullable: true),
                    ContactMob = table.Column<string>(nullable: false),
                    ContactHome = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    NICNo = table.Column<string>(nullable: false)
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
                    table.PrimaryKey("PK_StudSiblings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stud_StudSibling",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudID",
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
                    GradeId = table.Column<int>(nullable: false),
                    SectionId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    TeacherId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grades_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
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
                        principalColumn: "StudID",
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
                        principalColumn: "StudID",
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
                    Description = table.Column<string>(nullable: true)
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
                name: "TeacherSubjects",
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
                    GradeId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    Medium = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Grade_TeacherSubjects",
                        column: x => x.GradeId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subject_TeacherSubjects",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Teacher_TeacherSubjects",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
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
                    table.PrimaryKey("PK_Classes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradeClass_Classes",
                        column: x => x.GradeClassId,
                        principalTable: "GradeClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Classes_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassMonitors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    ClassId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassMonitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_ClassMonitors",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_ClassMonitors",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassStudents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    ClassId = table.Column<int>(nullable: false),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassStudents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassStudents_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Student_ClassStudent",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    ClassId = table.Column<int>(nullable: false),
                    TeacherSubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassSubjects_Classes_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherSubject_ClassSubjects",
                        column: x => x.TeacherSubjectId,
                        principalTable: "TeacherSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClassTeachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    ClassId = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassTeachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_ClassTeachers",
                        column: x => x.ClassId,
                        principalTable: "Classes",
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
                name: "ClassStudentSubjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    ClassStudentId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassStudentSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassStudent_StudentSubjects",
                        column: x => x.ClassStudentId,
                        principalTable: "ClassStudents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subject_StudentSubjects",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "GradeId", "ModifiedBy", "ModifiedDate", "SectionId", "TeacherId" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, null, 0, null },
                    { 10, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, null, null, 0, null },
                    { 9, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, null, null, 0, null },
                    { 8, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, null, null, 0, null },
                    { 7, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, null, null, 0, null },
                    { 11, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, null, null, 0, null },
                    { 5, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, null, null, 0, null },
                    { 4, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, null, 0, null },
                    { 3, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, null, 0, null },
                    { 2, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, null, 0, null },
                    { 6, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, null, null, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuID", "Action", "Area", "Controller", "DisplaySeq", "Icon", "IsHidden", "ParentMenuID", "Text", "Type" },
                values: new object[,]
                {
                    { 1, null, null, null, 10, "fas fa-user-tie", false, null, "Admin", "M" },
                    { 2, null, null, null, 20, "fas fa-book-reader", false, null, "Academic", "M" },
                    { 3, null, null, null, 30, "fas fa-chalkboard-teacher", false, null, "Teacher", "M" },
                    { 4, null, null, null, 40, "fas fa-user-graduate", false, null, "Student", "M" },
                    { 5, null, null, null, 50, "fas fa-chart-bar", false, null, "Report", "M" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "Code", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1, "Admin", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Administrator" },
                    { 2, "AdminUser", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "Admin Department User" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Address", "ContactNo", "CreatedBy", "CreatedDate", "FullName", "Gender", "ImmeContactName", "ImmeContactNo", "InactiveReason", "Initials", "LName", "ModifiedBy", "ModifiedDate", "NICNo", "SchoolEmail", "Status", "TelHome", "Title" },
                values: new object[,]
                {
                    { 2, "test", "0716669648", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Udara Rathnayaka", 0, "Umandya", "0773412392", null, "U", "Rathnayaka", null, null, "900272580V", null, 0, null, 5 },
                    { 1, "test", "0714479648", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Piumali Manorika Suraweera", 1, "Malith", "0773411392", null, "P M", "Suraweera", null, null, "880272580V", null, 0, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Password", "StaffId", "Status", "UserName" },
                values: new object[] { 1, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, 1, "rananga" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuID", "Action", "Area", "Controller", "DisplaySeq", "Icon", "IsHidden", "ParentMenuID", "Text", "Type" },
                values: new object[,]
                {
                    { 6, "Index", "Admin", "UserRoles", 10, null, false, 1, "User Permissions", "I" },
                    { 7, "Index", "Admin", "Users", 20, null, false, 1, "Users", "I" },
                    { 8, "Index", "Admin", "StaffMember", 30, null, false, 1, "Staff Members", "I" },
                    { 9, "Index", "Admin", "Section", 40, null, false, 1, "Sections", "I" },
                    { 10, "Index", "Admin", "Grade", 50, null, false, 1, "Grades", "I" },
                    { 11, "Index", "Admin", "GradeClass", 60, null, false, 1, "Grade Classes", "I" },
                    { 12, "Index", "Academic", "SectionHead", 10, null, false, 2, "Section Heads", "I" },
                    { 13, "Index", "Academic", "GradeHead", 20, null, false, 2, "Grade Heads", "I" },
                    { 14, "Index", "Academic", "Class", 30, null, false, 2, "Classes", "I" },
                    { 15, "Index", "Teacher", "Teacher", 10, null, false, 3, "Teacher Maintenance", "I" },
                    { 16, "Index", "Student", "Student", 10, null, false, 4, "Student Maintenance", "I" }
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
                name: "IX_Classes_GradeClassId",
                table: "Classes",
                column: "GradeClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_TeacherId",
                table: "Classes",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassMonitors_ClassId",
                table: "ClassMonitors",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassMonitors_StudentId",
                table: "ClassMonitors",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudents_ClassId",
                table: "ClassStudents",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudents_StudentId",
                table: "ClassStudents",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudentSubjects_ClassStudentId",
                table: "ClassStudentSubjects",
                column: "ClassStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassStudentSubjects_SubjectId",
                table: "ClassStudentSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjects_ClassId",
                table: "ClassSubjects",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjects_TeacherSubjectId",
                table: "ClassSubjects",
                column: "TeacherSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeachers_ClassId",
                table: "ClassTeachers",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassTeachers_StaffId",
                table: "ClassTeachers",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraActivityAcheivements_ActivityId",
                table: "ExtraActivityAcheivements",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraActivityPositions_ActivityId",
                table: "ExtraActivityPositions",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeClasses_GradeId",
                table: "GradeClasses",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeHeads_SectionId",
                table: "GradeHeads",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_GradeHeads_StaffId",
                table: "GradeHeads",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Grades_TeacherId",
                table: "Grades",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_StudentLeavingCertificate",
                table: "LeavingCertificates",
                column: "StudID");

            migrationBuilder.CreateIndex(
                name: "IX_FK_MenuMenu",
                table: "Menus",
                column: "ParentMenuID");

            migrationBuilder.CreateIndex(
                name: "IX_FK_RoleMenuAccesses_Roles",
                table: "RoleMenuAccesses",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_SectionHeads_SectionId",
                table: "SectionHeads",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_SectionHeads_StaffMemberId",
                table: "SectionHeads",
                column: "StaffMemberId");

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
                name: "IX_FK_StudentStudFamily",
                table: "StudFamilies",
                column: "StudID");

            migrationBuilder.CreateIndex(
                name: "IX_FK_StudentStudSibling1",
                table: "StudSiblings",
                column: "SiblingStudentId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_StudentStudSibling",
                table: "StudSiblings",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SectionId",
                table: "Subjects",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_GradeId",
                table: "TeacherSubjects",
                column: "GradeId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_SubjectId",
                table: "TeacherSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherSubjects_TeacherId",
                table: "TeacherSubjects",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_FK_RoleUserRole",
                table: "UserRoles",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_FK_UserUserRole",
                table: "UserRoles",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_StaffId",
                table: "Users",
                column: "StaffId",
                unique: true,
                filter: "[StaffId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassMonitors");

            migrationBuilder.DropTable(
                name: "ClassStudentSubjects");

            migrationBuilder.DropTable(
                name: "ClassSubjects");

            migrationBuilder.DropTable(
                name: "ClassTeachers");

            migrationBuilder.DropTable(
                name: "GradeHeads");

            migrationBuilder.DropTable(
                name: "LeavingCertificates");

            migrationBuilder.DropTable(
                name: "RoleMenuAccesses");

            migrationBuilder.DropTable(
                name: "SectionHeads");

            migrationBuilder.DropTable(
                name: "StudentExtraActivityAcheivements");

            migrationBuilder.DropTable(
                name: "StudentExtraActivityPositions");

            migrationBuilder.DropTable(
                name: "StudFamilies");

            migrationBuilder.DropTable(
                name: "StudSiblings");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "ClassStudents");

            migrationBuilder.DropTable(
                name: "TeacherSubjects");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "ExtraActivityAcheivements");

            migrationBuilder.DropTable(
                name: "ExtraActivityPositions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "ExtraActivities");

            migrationBuilder.DropTable(
                name: "StaffMembers");

            migrationBuilder.DropTable(
                name: "GradeClasses");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
