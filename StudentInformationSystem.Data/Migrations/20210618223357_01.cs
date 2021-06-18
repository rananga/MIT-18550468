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
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
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
                    DOB = table.Column<DateTime>(type: "datetime", nullable: false),
                    FullName = table.Column<string>(nullable: false),
                    Initials = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    SchoolEmail = table.Column<string>(nullable: true),
                    Address1 = table.Column<string>(nullable: false),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: false),
                    EmergContactName = table.Column<string>(nullable: false),
                    EmergContactNo = table.Column<string>(nullable: false),
                    Medium = table.Column<int>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true),
                    AdmissionDate = table.Column<DateTime>(nullable: false),
                    LeavingDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    IsLeavingIssued = table.Column<bool>(nullable: false),
                    LastClassId = table.Column<int>(nullable: false),
                    AdmittedClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
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
                    Nicno = table.Column<string>(nullable: true)
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
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
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
                    Remarks = table.Column<int>(nullable: false)
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
                        column: x => x.StudentId,
                        principalTable: "Subjects",
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
                    FromDate = table.Column<DateTime>(type: "date", nullable: false),
                    ToDate = table.Column<DateTime>(type: "date", nullable: false)
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
                        principalColumn: "Id",
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
                        name: "FK_Class_ClassStudents",
                        column: x => x.ClassId,
                        principalTable: "Classes",
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
                    SubjectId = table.Column<int>(nullable: false),
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_ClassSubjects",
                        column: x => x.ClassId,
                        principalTable: "Classes",
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
                    FromDate = table.Column<DateTime>(type: "date", nullable: false),
                    ToDate = table.Column<DateTime>(type: "date", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "ClassStudentSubjectMarks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false),
                    ClsStudSubjectId = table.Column<int>(nullable: false),
                    Term = table.Column<int>(nullable: false),
                    Marks = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassStudentSubjectMarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassStudentSubject_ClassStudentSubjectMarks",
                        column: x => x.ClsStudSubjectId,
                        principalTable: "ClassStudentSubjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "Action", "Area", "Controller", "DisplaySeq", "Icon", "IsHidden", "ParentMenuId", "Text", "Type" },
                values: new object[,]
                {
                    { 1, null, null, null, 10, "fas fa-user-tie", false, null, "Admin", "M" },
                    { 2, null, null, null, 20, "fas fa-book-reader", false, null, "Academic", "M" },
                    { 3, null, null, null, 30, "fas fa-chalkboard-teacher", false, null, "Teacher", "M" },
                    { 4, null, null, null, 40, "fas fa-user-graduate", false, null, "Student", "M" },
                    { 5, null, null, null, 50, "fas fa-laptop-code", false, null, "Online", "M" },
                    { 6, null, null, null, 60, "fas fa-chart-bar", false, null, "Report", "M" }
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
                    { 6, "AL-Technology", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null },
                    { 5, "AL-Art & Commerce", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null },
                    { 4, "AL-Science", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null },
                    { 3, "Senior", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null },
                    { 2, "Junior", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null },
                    { 1, "Primary", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null }
                });

            migrationBuilder.InsertData(
                table: "StaffMembers",
                columns: new[] { "Id", "Address1", "Address2", "City", "CreatedBy", "CreatedDate", "FullName", "Gender", "ImagePath", "ImmeContactName", "ImmeContactNo", "Initials", "JoinedDate", "LastName", "MobileNo", "ModifiedBy", "ModifiedDate", "Nicno", "RetiredDate", "SchoolEmail", "StaffNumber", "Status", "TeacherId", "TelHome", "Title" },
                values: new object[,]
                {
                    { 1, "24/3, Udyana Avenue", "Pepiliyana Road", "Nugegoda", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Piumali Manorika Suraweera", 1, null, "Malith", "0773411392", "P M", null, "Suraweera", "0714479648", null, null, "880272580V", null, null, 123, 0, null, null, 5 },
                    { 2, "45C, School Avenue", "Raththanapitiya", "Boralesgamuwa", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Udara Rathnayaka", 0, null, "Umandya", "0773412392", "U", null, "Rathnayaka", "0716669648", null, null, "900272580V", null, null, 456, 0, null, null, 5 }
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
                table: "Users",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "Password", "StaffId", "Status", "UserName", "VisitorId" },
                values: new object[] { 1, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, "1", null, 1, "rananga", null });

            migrationBuilder.InsertData(
                table: "Grades",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "GradeNo", "ModifiedBy", "ModifiedDate", "SectionId", "TeacherId" },
                values: new object[,]
                {
                    { 11, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 11, null, null, 3, null },
                    { 10, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10, null, null, 3, null },
                    { 9, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 9, null, null, 3, null },
                    { 8, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8, null, null, 2, null },
                    { 7, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7, null, null, 2, null },
                    { 6, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 6, null, null, 2, null },
                    { 5, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5, null, null, 1, null },
                    { 4, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 4, null, null, 1, null },
                    { 3, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 3, null, null, 1, null },
                    { 2, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 2, null, null, 1, null },
                    { 1, "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, null, 1, null }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "Action", "Area", "Controller", "DisplaySeq", "Icon", "IsHidden", "ParentMenuId", "Text", "Type" },
                values: new object[,]
                {
                    { 7, "Index", "Admin", "UserPermission", 10, null, false, 1, "User Permissions", "I" },
                    { 28, "Process", "Report", "OnlineSessionsSummary", 30, null, false, 6, "Online Sessions Summary", "I" },
                    { 27, "Process", "Report", "StudentMarks", 30, null, false, 6, "Term Wise Student Marks", "I" },
                    { 25, "Index", "Report", "StudentAttendance", 30, null, false, 6, "Student Attendance", "I" },
                    { 24, "Index", "Student", "StudentMark", 30, null, false, 5, "Online Time Table", "I" },
                    { 26, "Index", "Report", "AttendanceByDuration", 30, null, false, 6, "Attendance By Duration", "I" },
                    { 22, "Index", "Student", "StudentMark", 30, null, false, 4, "Student Marks", "I" },
                    { 8, "Index", "Admin", "Users", 20, null, false, 1, "Users", "I" },
                    { 9, "Index", "Admin", "StaffMember", 30, null, false, 1, "Staff Members", "I" },
                    { 10, "Index", "Admin", "Section", 40, null, false, 1, "Sections", "I" },
                    { 11, "Index", "Admin", "SectionHead", 50, null, false, 1, "Section Heads", "I" },
                    { 12, "Index", "Admin", "Grade", 60, null, false, 1, "Grades", "I" },
                    { 23, "Index", "Student", "StudentMark", 30, null, false, 5, "Online Class Rooms", "I" },
                    { 14, "Index", "Academic", "SubjectCategory", 10, null, false, 2, "Subject Categories", "I" },
                    { 15, "Index", "Academic", "Subject", 20, null, false, 2, "Subjects", "I" },
                    { 13, "Index", "Admin", "GradeHead", 70, null, false, 1, "Grade Heads", "I" },
                    { 17, "Index", "Academic", "GradeClass", 40, null, false, 2, "Grade Classes", "I" },
                    { 18, "Index", "Academic", "Class", 50, null, false, 2, "Class Rooms", "I" },
                    { 19, "Index", "Teacher", "Teacher", 20, null, false, 3, "Teacher Information", "I" },
                    { 20, "Index", "Student", "Student", 10, null, false, 4, "Student Maintenance", "I" },
                    { 21, "Index", "Student", "BasketSubject", 20, null, false, 4, "Student Basket Subjects", "I" },
                    { 16, "Index", "Academic", "GradeSubject", 30, null, false, 2, "Grade Subjects", "I" }
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
                    { 5, "ICT", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 4 },
                    { 1, "Sinhala", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 1 },
                    { 2, "English", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 1 },
                    { 3, "Geography", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 2 },
                    { 4, "Dancing", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, null, null, null, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "UserPermissions",
                columns: new[] { "UserPermissionId", "PermissionId", "UserId" },
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
                name: "IX_ClassStudentSubjectMarks_ClsStudSubjectId",
                table: "ClassStudentSubjectMarks",
                column: "ClsStudSubjectId");

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
                name: "IX_ClassSubjects_StaffId",
                table: "ClassSubjects",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSubjects_SubjectId",
                table: "ClassSubjects",
                column: "SubjectId");

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
                name: "IX_PermissionMenuAccesses_PermissionId",
                table: "PermissionMenuAccesses",
                column: "PermissionId");

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
                name: "IX_StudentSiblings_StudentId",
                table: "StudentSiblings",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SectionId",
                table: "Subjects",
                column: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_SubjectCategoryId",
                table: "Subjects",
                column: "SubjectCategoryId");

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
                name: "ClassMonitors");

            migrationBuilder.DropTable(
                name: "ClassStudentSubjectMarks");

            migrationBuilder.DropTable(
                name: "ClassSubjects");

            migrationBuilder.DropTable(
                name: "ClassTeachers");

            migrationBuilder.DropTable(
                name: "GradeClassSubjects");

            migrationBuilder.DropTable(
                name: "GradeHeads");

            migrationBuilder.DropTable(
                name: "GradeSubjects");

            migrationBuilder.DropTable(
                name: "LeavingCertificates");

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
                name: "TeacherPreferedSubjects");

            migrationBuilder.DropTable(
                name: "TeacherQualificationSubjects");

            migrationBuilder.DropTable(
                name: "UserPermissions");

            migrationBuilder.DropTable(
                name: "ClassStudentSubjects");

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
                name: "ClassStudents");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "ExtraActivities");

            migrationBuilder.DropTable(
                name: "StaffMembers");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "SubjectCategories");

            migrationBuilder.DropTable(
                name: "GradeClasses");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Sections");
        }
    }
}
