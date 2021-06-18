using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StudentInformationSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;

namespace StudentInformationSystem.Data
{
    public partial class dbNalandaContext : DbContext
    {
        public static string ConnectionString { get; set; }

        public dbNalandaContext()
        {
            ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=dbNalanda;Trusted_Connection=True;MultipleActiveResultSets=true";
            //ConnectionString = "Server=tcp:enalanda.database.windows.net,1433;Initial Catalog=dbNalanda;Persist Security Info=False;User ID=admindbenalanda;Password=Pass@123!;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        public dbNalandaContext(DbContextOptions<dbNalandaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassStudent> ClassStudents { get; set; }
        public virtual DbSet<ClassStudentSubject> ClassStudentSubjects { get; set; }
        public virtual DbSet<ClassStudentSubjectMark> ClassStudentSubjectMarks { get; set; }
        public virtual DbSet<ClassMonitor> ClassMonitors { get; set; }
        public virtual DbSet<ClassSubject> ClassSubjects { get; set; }
        public virtual DbSet<ClassTeacher> ClassTeachers { get; set; }
        public virtual DbSet<ExtraActivity> ExtraActivities { get; set; }
        public virtual DbSet<ExtraActivityAcheivement> ExtraActivityAcheivements { get; set; }
        public virtual DbSet<ExtraActivityPosition> ExtraActivityPositions { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<GradeClass> GradeClasses { get; set; }
        public virtual DbSet<GradeClassSubject> GradeClassSubjects { get; set; }
        public virtual DbSet<GradeSubject> GradeSubjects { get; set; }
        public virtual DbSet<GradeHead> GradeHeads { get; set; }
        public virtual DbSet<LeavingCertificate> LeavingCertificates { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<PermissionMenuAccess> PermissionMenuAccesses { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<SectionHead> SectionHeads { get; set; }
        public virtual DbSet<StaffMember> StaffMembers { get; set; }
        public virtual DbSet<StudentFamily> StudentFamilies { get; set; }
        public virtual DbSet<StudentSibling> StudentSiblings { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentBasketSubject> StudentBasketSubjects { get; set; }
        public virtual DbSet<StudentExtraActivityPosition> StudentExtraActivityPositions { get; set; }
        public virtual DbSet<StudentExtraActivityAcheivement> StudentExtraActivityAcheivements { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectCategory> SubjectCategories { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TeacherQualification> TeacherQualifications { get; set; }
        public virtual DbSet<TeacherQualificationSubject> TeacherQualificationSubjects { get; set; }
        public virtual DbSet<TeacherPreferedSubject> TeacherPreferedSubjects { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Visitor> Visitors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.GradeClass)
                    .WithMany(p => p.Classes)
                    .HasForeignKey(d => d.GradeClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GradeClass_Classes");
            });

            modelBuilder.Entity<ClassMonitor>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ClassMonitors)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Class_ClassMonitors");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ClassMonitors)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_ClassMonitors");
            });

            modelBuilder.Entity<ClassStudent>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ClassStudents)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Class_ClassStudents");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ClassStudents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_ClassStudents");
            });

            modelBuilder.Entity<ClassStudentSubject>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.ClassStudent)
                    .WithMany(p => p.StudentSubjects)
                    .HasForeignKey(d => d.ClassStudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClassStudent_StudentSubjects");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.StudentSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject_StudentSubjects");
            });

            modelBuilder.Entity<ClassStudentSubjectMark>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.ClassStudentSubject)
                    .WithMany(p => p.ClassStudentSubjectMarks)
                    .HasForeignKey(d => d.ClsStudSubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClassStudentSubject_ClassStudentSubjectMarks");
            });

            modelBuilder.Entity<ClassSubject>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ClassSubjects)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Class_ClassSubjects");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.ClassSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject_ClassSubjects");

                entity.HasOne(d => d.StaffMember)
                    .WithMany(p => p.ClassSubjects)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StaffMember_ClassSubjects");
            });

            modelBuilder.Entity<ClassTeacher>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ClassTeachers)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Class_ClassTeachers");

                entity.HasOne(d => d.StaffMember)
                    .WithMany(p => p.ClassTeachers)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StaffMember_ClassTeachers");
            });

            modelBuilder.Entity<ExtraActivity>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<ExtraActivityAcheivement>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Acheivements)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_Acheivements");
            });

            modelBuilder.Entity<ExtraActivityPosition>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_Positions");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Section_Grades");
            });

            modelBuilder.Entity<GradeClass>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.GradeClasses)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grade_GradeClasses");
            });

            modelBuilder.Entity<GradeClassSubject>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.GradeClass)
                    .WithMany(p => p.GradeClassSubjects)
                    .HasForeignKey(d => d.GradeClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GradeClass_GradeClassSubjects");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.GradeClassSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject_GradeClassSubjects");
            });

            modelBuilder.Entity<GradeHead>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.GradeHeads)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grade_GradeHeads");

                entity.HasOne(d => d.StaffMember)
                    .WithMany(p => p.HeadingGrades)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StaffMember_HeadingGrades");
            });

            modelBuilder.Entity<GradeSubject>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.GradeSubjects)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grade_GradeSubjects");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.GradeSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject_GradeSubjects");
            });

            modelBuilder.Entity<LeavingCertificate>(entity =>
            {
                entity.HasKey(e => e.LeavCertId);

                entity.HasIndex(e => e.StudId)
                    .HasName("IX_FK_StudentLeavingCertificate");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateLeaving).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.LeavingCertificates)
                    .HasForeignKey(d => d.StudId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentLeavingCertificate");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.Property(e => e.Text).IsRequired();

                entity.Property(e => e.Type).IsRequired();

                entity.HasOne(d => d.ParentMenu)
                    .WithMany(p => p.InverseParentMenu)
                    .HasForeignKey(d => d.ParentMenuId)
                    .HasConstraintName("FK_MenuMenu");
            });

            modelBuilder.Entity<PermissionMenuAccess>(entity =>
            {
                entity.HasKey(e => new { e.MenuId, e.PermissionId });

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.PermissionMenuAccesses)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Menu_PermissionMenuAccesses");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.PermissionMenuAccesses)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permission_PermissionMenuAccesses");
            });

            modelBuilder.Entity<Permission>(entity =>
            {
                entity.HasKey(e => e.PermissionId);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<SectionHead>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.SectionHeads)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Section_SectionHeads");

                entity.HasOne(d => d.StaffMember)
                    .WithMany(p => p.HeadingSections)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StaffMember_HeadingSections");
            });

            modelBuilder.Entity<StaffMember>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.JoinedDate).HasColumnType("date");

                entity.Property(e => e.RetiredDate).HasColumnType("date");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(b => b.User).WithOne(p => p.StaffMember).HasForeignKey<User>(b => b.StaffId);
            });

            modelBuilder.Entity<StudentFamily>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentFamilies)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentStudFamily");
            });

            modelBuilder.Entity<StudentSibling>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.SiblingStudentId);

                entity.Property(e => e.StudentId);

                entity.HasOne(d => d.SiblingStudent)
                    .WithMany(p => p.StudentSiblings)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stud_StudSibling");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DOB).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<StudentBasketSubject>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentBasketSubjects)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_StudentBasketSubjects");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.StudentBasketSubjects)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject_StudentBasketSubjects");
            });

            modelBuilder.Entity<StudentExtraActivityAcheivement>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Acheivement)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.AcheivementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Acheivement_Students");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ActivityAcheivements)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_ActivityAcheivements");
            });

            modelBuilder.Entity<StudentExtraActivityPosition>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Position_Students");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ActivityPositions)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_ActivityPositions");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.SubjectCategory)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.SubjectCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubjectCategory_Subjects");
            });

            modelBuilder.Entity<SubjectCategory>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.StaffMember).WithOne(p => p.Teacher).HasForeignKey<StaffMember>(d => d.TeacherId);

                entity.HasOne(d => d.Section)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.SectionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Section_Teachers");
            });

            modelBuilder.Entity<TeacherQualification>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherQualifications)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Teacher_TeacherQualifications");
            });

            modelBuilder.Entity<TeacherQualificationSubject>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.TeacherQualification)
                    .WithMany(p => p.TeacherQualificationSubjects)
                    .HasForeignKey(d => d.TeacherQualificationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeacherQualification_TeacherQualificationSubjects");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.TeacherQualificationSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject_TeacherQualificationSubjects");
            });

            modelBuilder.Entity<TeacherPreferedSubject>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherPreferedSubjects)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Teacher_TeacherPreferedSubjects");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.TeacherPreferedSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject_TeacherPreferedSubjects");
            });

            modelBuilder.Entity<UserPermission>(entity =>
            {
                entity.HasKey(e => e.UserPermissionId);

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.UserPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permission_UserPermissions");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPermissions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_UserPermissions");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Visitor>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(b => b.User).WithOne(p => p.Visitor).HasForeignKey<User>(b => b.VisitorId);
            });

            OnModelCreatingPartial(modelBuilder);

            SeedData(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Section>().HasData(
                new Section { Id = 1, Code = "Primary", Description = "", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Section { Id = 2, Code = "Junior", Description = "", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Section { Id = 3, Code = "Senior", Description = "", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Section { Id = 4, Code = "AL-Science", Description = "", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Section { Id = 5, Code = "AL-Art & Commerce", Description = "", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Section { Id = 6, Code = "AL-Technology", Description = "", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) });

            modelBuilder.Entity<Grade>().HasData(
                new Grade { Id = 1, SectionId = 1, GradeNo = Data.Grades.Grade1, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 2, SectionId = 1, GradeNo = Data.Grades.Grade2, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 3, SectionId = 1, GradeNo = Data.Grades.Grade3, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 4, SectionId = 1, GradeNo = Data.Grades.Grade4, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 5, SectionId = 1, GradeNo = Data.Grades.Grade5, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 6, SectionId = 2, GradeNo = Data.Grades.Grade6, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 7, SectionId = 2, GradeNo = Data.Grades.Grade7, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 8, SectionId = 2, GradeNo = Data.Grades.Grade8, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 9, SectionId = 3, GradeNo = Data.Grades.Grade9, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 10, SectionId = 3, GradeNo = Data.Grades.Grade10, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 11, SectionId = 3, GradeNo = Data.Grades.Grade11, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) });

            modelBuilder.Entity<Permission>().HasData(
                new Permission { PermissionId = 1, Code = "Admin", Name = "Administrator", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Permission { PermissionId = 2, Code = "AdminUser", Name = "Admin Department User", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) });

            modelBuilder.Entity<Menu>().HasData(
                new Menu { MenuId = 1, ParentMenuId = null, DisplaySeq = 10, Text = "Admin", Type = "M", Area = null, Controller = null, Action = null, IsHidden = false, Icon = "fas fa-user-tie" },
                new Menu { MenuId = 2, ParentMenuId = null, DisplaySeq = 20, Text = "Academic", Type = "M", Area = null, Controller = null, Action = null, IsHidden = false, Icon = "fas fa-book-reader" },
                new Menu { MenuId = 3, ParentMenuId = null, DisplaySeq = 30, Text = "Teacher", Type = "M", Area = null, Controller = null, Action = null, IsHidden = false, Icon = "fas fa-chalkboard-teacher" },
                new Menu { MenuId = 4, ParentMenuId = null, DisplaySeq = 40, Text = "Student", Type = "M", Area = null, Controller = null, Action = null, IsHidden = false, Icon = "fas fa-user-graduate" },
                new Menu { MenuId = 5, ParentMenuId = null, DisplaySeq = 50, Text = "Online", Type = "M", Area = null, Controller = null, Action = null, IsHidden = false, Icon = "fas fa-laptop-code" },
                new Menu { MenuId = 6, ParentMenuId = null, DisplaySeq = 60, Text = "Report", Type = "M", Area = null, Controller = null, Action = null, IsHidden = false, Icon = "fas fa-chart-bar" },
                new Menu { MenuId = 7, ParentMenuId = 1, DisplaySeq = 10, Text = "User Permissions", Type = "I", Area = "Admin", Controller = "UserPermission", Action = "Index" },
                new Menu { MenuId = 8, ParentMenuId = 1, DisplaySeq = 20, Text = "Users", Type = "I", Area = "Admin", Controller = "Users", Action = "Index" },
                new Menu { MenuId = 9, ParentMenuId = 1, DisplaySeq = 30, Text = "Staff Members", Type = "I", Area = "Admin", Controller = "StaffMember", Action = "Index" },
                new Menu { MenuId = 10, ParentMenuId = 1, DisplaySeq = 40, Text = "Sections", Type = "I", Area = "Admin", Controller = "Section", Action = "Index" },
                new Menu { MenuId = 11, ParentMenuId = 1, DisplaySeq = 50, Text = "Section Heads", Type = "I", Area = "Admin", Controller = "SectionHead", Action = "Index" },
                new Menu { MenuId = 12, ParentMenuId = 1, DisplaySeq = 60, Text = "Grades", Type = "I", Area = "Admin", Controller = "Grade", Action = "Index" },
                new Menu { MenuId = 13, ParentMenuId = 1, DisplaySeq = 70, Text = "Grade Heads", Type = "I", Area = "Admin", Controller = "GradeHead", Action = "Index" },
                new Menu { MenuId = 14, ParentMenuId = 2, DisplaySeq = 10, Text = "Subject Categories", Type = "I", Area = "Academic", Controller = "SubjectCategory", Action = "Index" },
                new Menu { MenuId = 15, ParentMenuId = 2, DisplaySeq = 20, Text = "Subjects", Type = "I", Area = "Academic", Controller = "Subject", Action = "Index" },
                new Menu { MenuId = 16, ParentMenuId = 2, DisplaySeq = 30, Text = "Grade Subjects", Type = "I", Area = "Academic", Controller = "GradeSubject", Action = "Index" },
                new Menu { MenuId = 17, ParentMenuId = 2, DisplaySeq = 40, Text = "Grade Classes", Type = "I", Area = "Academic", Controller = "GradeClass", Action = "Index" },
                new Menu { MenuId = 18, ParentMenuId = 2, DisplaySeq = 50, Text = "Class Rooms", Type = "I", Area = "Academic", Controller = "Class", Action = "Index" },
                new Menu { MenuId = 19, ParentMenuId = 3, DisplaySeq = 20, Text = "Teacher Information", Type = "I", Area = "Teacher", Controller = "Teacher", Action = "Index" },
                new Menu { MenuId = 20, ParentMenuId = 4, DisplaySeq = 10, Text = "Student Maintenance", Type = "I", Area = "Student", Controller = "Student", Action = "Index" },
                new Menu { MenuId = 21, ParentMenuId = 4, DisplaySeq = 20, Text = "Student Basket Subjects", Type = "I", Area = "Student", Controller = "BasketSubject", Action = "Index" },
                new Menu { MenuId = 22, ParentMenuId = 4, DisplaySeq = 30, Text = "Student Marks", Type = "I", Area = "Student", Controller = "StudentMark", Action = "Index" },
                new Menu { MenuId = 23, ParentMenuId = 5, DisplaySeq = 30, Text = "Online Class Rooms", Type = "I", Area = "Student", Controller = "StudentMark", Action = "Index" },
                new Menu { MenuId = 24, ParentMenuId = 5, DisplaySeq = 30, Text = "Online Time Table", Type = "I", Area = "Student", Controller = "StudentMark", Action = "Index" },
                new Menu { MenuId = 25, ParentMenuId = 6, DisplaySeq = 30, Text = "Student Attendance", Type = "I", Area = "Report", Controller = "StudentAttendance", Action = "Index" },
                new Menu { MenuId = 26, ParentMenuId = 6, DisplaySeq = 30, Text = "Attendance By Duration", Type = "I", Area = "Report", Controller = "AttendanceByDuration", Action = "Index" },
                new Menu { MenuId = 27, ParentMenuId = 6, DisplaySeq = 30, Text = "Term Wise Student Marks", Type = "I", Area = "Report", Controller = "StudentMarks", Action = "Process" },
                new Menu { MenuId = 28, ParentMenuId = 6, DisplaySeq = 30, Text = "Online Sessions Summary", Type = "I", Area = "Report", Controller = "OnlineSessionsSummary", Action = "Process" });

            modelBuilder.Entity<PermissionMenuAccess>().HasData(
                new PermissionMenuAccess { MenuId = 1, PermissionId = 1 }
                );

            modelBuilder.Entity<User>().HasData(
               new User
               {
                   Id = 1,
                   UserName = "rananga",
                   Password = "1",
                   Status = ActiveState.Active,
                   CreatedBy = "System",
                   CreatedDate = new DateTime(2021, 1, 1)
               });

            modelBuilder.Entity<UserPermission>().HasData(
               new UserPermission { UserPermissionId = 1, UserId = 1, PermissionId = 1 });

            modelBuilder.Entity<StaffMember>().HasData(
               new StaffMember { Id = 1, StaffNumber = 123, Title = TitleStaff.Mrs, Gender = Gender.Female, FullName = "Piumali Manorika Suraweera", Initials = "P M", LastName = "Suraweera", Address1 = "24/3, Udyana Avenue", Address2 = "Pepiliyana Road", City = "Nugegoda", MobileNo = "0714479648", Nicno = "880272580V", ImmeContactNo = "0773411392", ImmeContactName = "Malith", Status = ActiveStatus.Active, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
               new StaffMember { Id = 2, StaffNumber = 456, Title = TitleStaff.Mrs, Gender = Gender.Male, FullName = "Udara Rathnayaka", Initials = "U", LastName = "Rathnayaka", Address1 = "45C, School Avenue", Address2 = "Raththanapitiya", City = "Boralesgamuwa", MobileNo = "0716669648", Nicno = "900272580V", ImmeContactNo = "0773412392", ImmeContactName = "Umandya", Status = ActiveStatus.Active, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) });

            modelBuilder.Entity<SubjectCategory>().HasData(
               new SubjectCategory { Id = 1, Code = "Main", IsBasket = false, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
               new SubjectCategory { Id = 2, Code = "Basket 1", IsBasket = true, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
               new SubjectCategory { Id = 3, Code = "Basket 2", IsBasket = true, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
               new SubjectCategory { Id = 4, Code = "Basket 3", IsBasket = true, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) });

            modelBuilder.Entity<Subject>().HasData(
               new Subject { Id = 1, Code = "Sinhala", SectionId = 3, SubjectCategoryId = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
               new Subject { Id = 2, Code = "English", SectionId = 3, SubjectCategoryId = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
               new Subject { Id = 3, Code = "Geography", SectionId = 3, SubjectCategoryId = 2, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
               new Subject { Id = 4, Code = "Dancing", SectionId = 3, SubjectCategoryId = 3, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
               new Subject { Id = 5, Code = "ICT", SectionId = 3, SubjectCategoryId = 4, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) });
        }

        public override int SaveChanges()
        {
            var entities = from e in ChangeTracker.Entries()
                           where e.State == EntityState.Added
                               || e.State == EntityState.Modified
                           select e.Entity;

            var validationResults = new List<ValidationResult>();

            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext);
                Validator.TryValidateObject(entity, validationContext, validationResults, true);
            }

            if (validationResults.Count > 0)
            {
                var entityValidationResult = validationResults.Select(x => new DbEntityValidationResult(new DbEntityEntry(), x.MemberNames.Select(y => new DbValidationError(y, x.ErrorMessage))));

                var excp = new DbEntityValidationException("Validation failed for one or more entities.", entityValidationResult);
                throw excp;
            }

            return base.SaveChanges();
        }

        public void Detach(object entity)
        {
            Entry(entity).State = EntityState.Detached;
        }

        public void UndoChanges()
        {
            // Undo the changes of the all entries. 
            foreach (EntityEntry entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    // Under the covers, changing the state of an entity from  
                    // Modified to Unchanged first sets the values of all  
                    // properties to the original values that were read from  
                    // the database when it was queried, and then marks the  
                    // entity as Unchanged. This will also reject changes to  
                    // FK relationships since the original value of the FK  
                    // will be restored. 
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    // If the EntityState is the Deleted, reload the date from the database.   
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                    default: break;
                }
            }
        }
    }
}
