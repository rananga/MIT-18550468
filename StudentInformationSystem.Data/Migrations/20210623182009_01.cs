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
                        column: x => x.SubjectId,
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
                name: "ClassRooms",
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
                    table.PrimaryKey("PK_ClassRooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GradeClass_Classes",
                        column: x => x.GradeClassId,
                        principalTable: "GradeClasses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClassRooms_Teachers_TeacherId",
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
                name: "CR_Monitors",
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
                    table.PrimaryKey("PK_CR_Monitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_ClassMonitors",
                        column: x => x.CR_Id,
                        principalTable: "ClassRooms",
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
                name: "CR_Students",
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
                    table.PrimaryKey("PK_CR_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_ClassStudents",
                        column: x => x.CR_Id,
                        principalTable: "ClassRooms",
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
                name: "CR_Subjects",
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
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CR_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_ClassSubjects",
                        column: x => x.CR_Id,
                        principalTable: "ClassRooms",
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
                name: "CR_Teachers",
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
                    table.PrimaryKey("PK_CR_Teachers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_ClassTeachers",
                        column: x => x.CR_Id,
                        principalTable: "ClassRooms",
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
                        principalTable: "ClassRooms",
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
                    CalendarEvent = table.Column<string>(nullable: true)
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
                name: "CR_StudentSubjects",
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
                    table.PrimaryKey("PK_CR_StudentSubjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassStudent_StudentSubjects",
                        column: x => x.CR_StudentId,
                        principalTable: "CR_Students",
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
                name: "CR_StudentSubjectMarks",
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
                    Marks = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CR_StudentSubjectMarks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassStudentSubject_ClassStudentSubjectMarks",
                        column: x => x.CR_StudentSubjectId,
                        principalTable: "CR_StudentSubjects",
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
                    { 1, "Primary", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null },
                    { 2, "Junior", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null },
                    { 3, "Senior", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null },
                    { 4, "AL-Science", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null },
                    { 5, "AL-Art & Commerce", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null },
                    { 6, "AL-Technology", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", null, null }
                });

            migrationBuilder.InsertData(
                table: "StaffMembers",
                columns: new[] { "Id", "Address1", "Address2", "City", "CreatedBy", "CreatedDate", "FullName", "Gender", "ImagePath", "ImmeContactName", "ImmeContactNo", "Initials", "JoinedDate", "LastName", "MobileNo", "ModifiedBy", "ModifiedDate", "Nicno", "RetiredDate", "SchoolEmail", "StaffNumber", "Status", "TeacherId", "TelHome", "Title" },
                values: new object[,]
                {
                    { 2, "45C, School Avenue", "Raththanapitiya", "Boralesgamuwa", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Udara Rathnayaka", 0, null, "Umandya", "0773412392", "U", null, "Rathnayaka", "0716669648", null, null, "900272580V", null, null, 456, 0, null, null, 5 },
                    { 1, "24/3, Udyana Avenue", "Pepiliyana Road", "Nugegoda", "System", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Piumali Manorika Suraweera", 1, null, "Malith", "0773411392", "P M", null, "Suraweera", "0714479648", null, null, "880272580V", null, null, 123, 0, null, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address1", "Address2", "AdmissionDate", "AdmittedClassId", "City", "CreatedBy", "CreatedDate", "DOB", "EmergContactName", "EmergContactNo", "FullName", "ImagePath", "IndexNo", "Initials", "IsLeavingIssued", "LastClassId", "LastName", "LeavingDate", "Medium", "ModifiedBy", "ModifiedDate", "SchoolEmail", "Status" },
                values: new object[,]
                {
                    { 18, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "K A M Menath", null, 28916, "K A M", false, 0, "Menath", null, 0, null, null, "28916@nalandacollege.info", 0 },
                    { 19, null, null, new DateTime(2021, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "L G T S Samarasingha", null, 28891, "L G T S", false, 0, "Samarasingha", null, 0, null, null, "28891@nalandacollege.info", 0 },
                    { 20, null, null, new DateTime(2021, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "M K G Darmasiri", null, 29033, "M K G", false, 0, "Darmasiri", null, 0, null, null, "29033@nalandacollege.info", 0 },
                    { 21, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "N H E De Silava", null, 29038, "N H E De", false, 0, "Silava", null, 0, null, null, "29038@nalandacollege.info", 0 },
                    { 22, null, null, new DateTime(2021, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "R V D R R Perera", null, 28901, "R V D R R", false, 0, "Perera", null, 0, null, null, "28901@nalandacollege.info", 0 },
                    { 23, null, null, new DateTime(2021, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "S A J Pathirana", null, 29008, "S A J", false, 0, "Pathirana", null, 0, null, null, "29008@nalandacollege.info", 0 },
                    { 24, null, null, new DateTime(2021, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "S H V Sanith", null, 29003, "S H V", false, 0, "Sanith", null, 0, null, null, "29003@nalandacollege.info", 0 },
                    { 25, null, null, new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "S I Kiriwandeniya", null, 28973, "S I", false, 0, "Kiriwandeniya", null, 0, null, null, "28973@nalandacollege.info", 0 },
                    { 27, null, null, new DateTime(2021, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "S O Leelarathna", null, 28958, "S O", false, 0, "Leelarathna", null, 0, null, null, "28958@nalandacollege.info", 0 },
                    { 28, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "S T Ranwala", null, 28968, "S T", false, 0, "Ranwala", null, 0, null, null, "28968@nalandacollege.info", 0 },
                    { 29, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "T D A Gunawardana", null, 28978, "T D A", false, 0, "Gunawardana", null, 0, null, null, "28978@nalandacollege.info", 0 },
                    { 30, null, null, new DateTime(2021, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "V A D Dilsara", null, 28993, "V A D", false, 0, "Dilsara", null, 0, null, null, "28993@nalandacollege.info", 0 },
                    { 31, null, null, new DateTime(2021, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "V K Almeda", null, 28906, "V K", false, 0, "Almeda", null, 0, null, null, "28906@nalandacollege.info", 0 },
                    { 32, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "W G T M Gamage", null, 28936, "W G T M", false, 0, "Gamage", null, 0, null, null, "28936@nalandacollege.info", 0 },
                    { 26, null, null, new DateTime(2021, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "S L D Karunathilaka", null, 28931, "S L D", false, 0, "Karunathilaka", null, 0, null, null, "28931@nalandacollege.info", 0 },
                    { 17, null, null, new DateTime(2021, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "K A D Sanketh", null, 28998, "K A D", false, 0, "Sanketh", null, 0, null, null, "28998@nalandacollege.info", 0 },
                    { 11, null, null, new DateTime(2021, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "D N Gunasena", null, 28963, "D N", false, 0, "Gunasena", null, 0, null, null, "28963@nalandacollege.info", 0 },
                    { 15, null, null, new DateTime(2021, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "H L S Dulsara", null, 28911, "H L S", false, 0, "Dulsara", null, 0, null, null, "28911@nalandacollege.info", 0 },
                    { 1, null, null, new DateTime(2021, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "A J M T A Jayasundara", null, 29013, "A J M T A", false, 0, "Jayasundara", null, 0, null, null, "29013@nalandacollege.info", 0 },
                    { 2, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "A U N De Silva", null, 28953, "A U N De", false, 0, "Silva", null, 0, null, null, "28953@nalandacollege.info", 0 },
                    { 3, null, null, new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "B L R Abedeera", null, 28948, "B L R", false, 0, "Abedeera", null, 0, null, null, "28948@nalandacollege.info", 0 },
                    { 4, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "B M T Silva", null, 29043, "B M T", false, 0, "Silva", null, 0, null, null, "29043@nalandacollege.info", 0 },
                    { 5, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "B W K M Peeris", null, 29028, "B W K M", false, 0, "Peeris", null, 0, null, null, "29028@nalandacollege.info", 0 },
                    { 16, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "I U Roopasingha", null, 29018, "I U", false, 0, "Roopasingha", null, 0, null, null, "29018@nalandacollege.info", 0 },
                    { 7, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "D C A Dias", null, 29023, "D C A", false, 0, "Dias", null, 0, null, null, "29023@nalandacollege.info", 0 },
                    { 6, null, null, new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Chenuk Manthila P S", null, 29049, "Chenuk", false, 0, "Manthila P S", null, 0, null, null, "29049@nalandacollege.info", 0 },
                    { 9, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "D M K S Liyanage", null, 28941, "D M K S", false, 0, "Liyanage", null, 0, null, null, "28941@nalandacollege.info", 0 },
                    { 10, null, null, new DateTime(2021, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "D M L Dasanayake", null, 28926, "D M L", false, 0, "Dasanayake", null, 0, null, null, "28926@nalandacollege.info", 0 },
                    { 12, null, null, new DateTime(2021, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "D W O D De Silva", null, 28983, "D W O D De", false, 0, "Silva", null, 0, null, null, "28983@nalandacollege.info", 0 },
                    { 13, null, null, new DateTime(2021, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "E H H Nethsara", null, 28921, "E H H", false, 0, "Nethsara", null, 0, null, null, "28921@nalandacollege.info", 0 },
                    { 14, null, null, new DateTime(2021, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "H A S Asmitha", null, 28896, "H A S", false, 0, "Asmitha", null, 0, null, null, "28896@nalandacollege.info", 0 },
                    { 8, null, null, new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "D J M K N Serasingha", null, 28988, "D J M K N", false, 0, "Serasingha", null, 0, null, null, "28988@nalandacollege.info", 0 }
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
                    { 25, "Index", "Online", "OnlineTimeTable", 30, null, false, 5, "Online Time Table", "I" },
                    { 24, "Index", "Online", "OnlineClassRoom", 30, null, false, 5, "Online Class Rooms", "I" },
                    { 26, "Process", "Report", "StudentAttendance", 30, null, false, 6, "Student Attendance", "I" },
                    { 22, "Index", "Student", "BasketSubject", 20, null, false, 4, "Student Basket Subjects", "I" },
                    { 8, "Index", "Admin", "Users", 20, null, false, 1, "Users", "I" },
                    { 9, "Index", "Admin", "StaffMember", 30, null, false, 1, "Staff Members", "I" },
                    { 10, "Index", "Admin", "Section", 40, null, false, 1, "Sections", "I" },
                    { 11, "Index", "Admin", "SectionHead", 50, null, false, 1, "Section Heads", "I" },
                    { 12, "Index", "Admin", "Grade", 60, null, false, 1, "Grades", "I" },
                    { 23, "Index", "Student", "StudentMark", 30, null, false, 4, "Student Marks", "I" },
                    { 14, "Index", "Admin", "ExtraActivity", 80, null, false, 1, "Extra Activities", "I" },
                    { 15, "Index", "Academic", "SubjectCategory", 10, null, false, 2, "Subject Categories", "I" },
                    { 13, "Index", "Admin", "GradeHead", 70, null, false, 1, "Grade Heads", "I" },
                    { 17, "Index", "Academic", "GradeSubject", 30, null, false, 2, "Grade Subjects", "I" },
                    { 18, "Index", "Academic", "GradeClass", 40, null, false, 2, "Grade Classes", "I" },
                    { 19, "Index", "Academic", "ClassRoom", 50, null, false, 2, "Physical Class Rooms", "I" },
                    { 20, "Index", "Teacher", "Teacher", 20, null, false, 3, "Teacher Information", "I" },
                    { 21, "Index", "Student", "Student", 10, null, false, 4, "Student Maintenance", "I" },
                    { 16, "Index", "Academic", "Subject", 20, null, false, 2, "Subjects", "I" }
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

            migrationBuilder.InsertData(
                table: "GradeClasses",
                columns: new[] { "Id", "Code", "CreatedBy", "CreatedDate", "GradeId", "MaxStudentCount", "Medium", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[] { 1, "1.A", "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 0, null, null, 1 });

            migrationBuilder.InsertData(
                table: "OnlineClassRooms",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "GoogleClassRoomId", "GoogleClassrommLink", "GradeId", "Medium", "ModifiedBy", "ModifiedDate", "SubjectId", "Year" },
                values: new object[] { 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1, 0, null, null, 1, 2021 });

            migrationBuilder.InsertData(
                table: "ClassRooms",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "GradeClassId", "Medium", "ModifiedBy", "ModifiedDate", "TeacherId", "Year" },
                values: new object[] { 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 0, null, null, null, 2021 });

            migrationBuilder.InsertData(
                table: "OCR_Teachers",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsOwner", "ModifiedBy", "ModifiedDate", "OCR_Id", "StaffId" },
                values: new object[] { 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, 1, 1 });

            migrationBuilder.InsertData(
                table: "CR_Students",
                columns: new[] { "Id", "CR_Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1 },
                    { 32, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 32 },
                    { 31, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 31 },
                    { 30, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 30 },
                    { 29, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 29 },
                    { 28, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 28 },
                    { 27, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 27 },
                    { 26, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 26 },
                    { 25, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 25 },
                    { 24, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 24 },
                    { 23, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 23 },
                    { 21, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 21 },
                    { 20, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 20 },
                    { 19, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 19 },
                    { 18, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 18 },
                    { 17, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 17 },
                    { 22, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 22 },
                    { 15, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 15 },
                    { 2, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 2 },
                    { 16, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 16 },
                    { 4, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 4 },
                    { 5, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 5 },
                    { 6, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 6 },
                    { 7, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 7 },
                    { 8, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 8 },
                    { 3, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 3 },
                    { 10, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 10 },
                    { 11, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 11 },
                    { 12, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 12 },
                    { 13, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 13 },
                    { 14, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 14 },
                    { 9, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 9 }
                });

            migrationBuilder.InsertData(
                table: "OCR_ClassRooms",
                columns: new[] { "Id", "CR_Id", "CreatedBy", "CreatedDate", "ModifiedBy", "ModifiedDate", "OCR_Id" },
                values: new object[] { 1, 1, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, 1 });

            migrationBuilder.InsertData(
                table: "OnlineClasses",
                columns: new[] { "Id", "CalendarEvent", "CreatedBy", "CreatedDate", "Date", "FromTime", "Lesson", "ModifiedBy", "ModifiedDate", "OCR_Id", "OCR_TeacherId", "Subject", "ToTime" },
                values: new object[,]
                {
                    { 9, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), null, null, null, 1, 1, null, new TimeSpan(0, 18, 30, 0, 0) },
                    { 8, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), null, null, null, 1, 1, null, new TimeSpan(0, 18, 30, 0, 0) },
                    { 7, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), null, null, null, 1, 1, null, new TimeSpan(0, 18, 30, 0, 0) },
                    { 6, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), null, null, null, 1, 1, null, new TimeSpan(0, 18, 30, 0, 0) },
                    { 2, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), null, null, null, 1, 1, null, new TimeSpan(0, 18, 30, 0, 0) },
                    { 4, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), null, null, null, 1, 1, null, new TimeSpan(0, 18, 30, 0, 0) },
                    { 3, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), null, null, null, 1, 1, null, new TimeSpan(0, 18, 30, 0, 0) },
                    { 1, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), null, null, null, 1, 1, null, new TimeSpan(0, 18, 30, 0, 0) },
                    { 10, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), null, null, null, 1, 1, null, new TimeSpan(0, 18, 30, 0, 0) },
                    { 5, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), null, null, null, 1, 1, null, new TimeSpan(0, 18, 30, 0, 0) },
                    { 11, null, "System", new DateTime(2021, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 17, 0, 0, 0), null, null, null, 1, 1, null, new TimeSpan(0, 18, 30, 0, 0) }
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
                name: "IX_ClassRooms_GradeClassId",
                table: "ClassRooms",
                column: "GradeClassId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassRooms_TeacherId",
                table: "ClassRooms",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_CR_Monitors_CR_Id",
                table: "CR_Monitors",
                column: "CR_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CR_Monitors_StudentId",
                table: "CR_Monitors",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CR_Students_CR_Id",
                table: "CR_Students",
                column: "CR_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CR_Students_StudentId",
                table: "CR_Students",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CR_StudentSubjectMarks_CR_StudentSubjectId",
                table: "CR_StudentSubjectMarks",
                column: "CR_StudentSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CR_StudentSubjects_CR_StudentId",
                table: "CR_StudentSubjects",
                column: "CR_StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_CR_StudentSubjects_SubjectId",
                table: "CR_StudentSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CR_Subjects_CR_Id",
                table: "CR_Subjects",
                column: "CR_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CR_Subjects_StaffId",
                table: "CR_Subjects",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_CR_Subjects_SubjectId",
                table: "CR_Subjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CR_Teachers_CR_Id",
                table: "CR_Teachers",
                column: "CR_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CR_Teachers_StaffId",
                table: "CR_Teachers",
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
                name: "IX_PermissionGradeAccesses_PermissionId",
                table: "PermissionGradeAccesses",
                column: "PermissionId");

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
                name: "CR_Monitors");

            migrationBuilder.DropTable(
                name: "CR_StudentSubjectMarks");

            migrationBuilder.DropTable(
                name: "CR_Subjects");

            migrationBuilder.DropTable(
                name: "CR_Teachers");

            migrationBuilder.DropTable(
                name: "GradeClassSubjects");

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
                name: "TeacherPreferedSubjects");

            migrationBuilder.DropTable(
                name: "TeacherQualificationSubjects");

            migrationBuilder.DropTable(
                name: "UserPermissions");

            migrationBuilder.DropTable(
                name: "CR_StudentSubjects");

            migrationBuilder.DropTable(
                name: "OC_Meetings");

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
                name: "CR_Students");

            migrationBuilder.DropTable(
                name: "OnlineClasses");

            migrationBuilder.DropTable(
                name: "ExtraActivities");

            migrationBuilder.DropTable(
                name: "Visitors");

            migrationBuilder.DropTable(
                name: "ClassRooms");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "OCR_Teachers");

            migrationBuilder.DropTable(
                name: "GradeClasses");

            migrationBuilder.DropTable(
                name: "OnlineClassRooms");

            migrationBuilder.DropTable(
                name: "StaffMembers");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "SubjectCategories");

            migrationBuilder.DropTable(
                name: "Sections");
        }
    }
}
