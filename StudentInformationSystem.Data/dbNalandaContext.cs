using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StudentInformationSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace StudentInformationSystem.Data
{
    public partial class dbSISContext : DbContext
    {
        public dbSISContext()
        {
        }

        public dbSISContext(DbContextOptions<dbSISContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClassStudent> ClassStudents { get; set; }
        public virtual DbSet<ClassStudentSubject> ClassStudentSubjects { get; set; }
        public virtual DbSet<ClassMonitor> ClassMonitors { get; set; }
        public virtual DbSet<ClassSubject> ClassSubjects { get; set; }
        public virtual DbSet<ClassTeacher> ClassTeachers { get; set; }
        //public virtual DbSet<ClubMember> ClubMembers { get; set; }
        //public virtual DbSet<Club> Clubs { get; set; }
        //public virtual DbSet<EventParticipation> EventParticipations { get; set; }
        public virtual DbSet<ExtraActivity> ExtraActivities { get; set; }
        public virtual DbSet<ExtraActivityAcheivement> ExtraActivityAcheivements { get; set; }
        public virtual DbSet<ExtraActivityPosition> ExtraActivityPositions { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<GradeClass> GradeClasses { get; set; }
        public virtual DbSet<GradeHead> GradeHeads { get; set; }
        public virtual DbSet<LeavingCertificate> LeavingCertificates { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        //public virtual DbSet<PeriodSetup> PeriodSetups { get; set; }
        //public virtual DbSet<Prefect> Prefects { get; set; }
        //public virtual DbSet<PromotionClass> PromotionClasses { get; set; }
        public virtual DbSet<RoleMenuAccess> RoleMenuAccesses { get; set; }
        //public virtual DbSet<RoleTile> RoleTiles { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<SectionHead> SectionHeads { get; set; }
        public virtual DbSet<StaffMember> StaffMembers { get; set; }
        public virtual DbSet<StudFamily> StudFamilies { get; set; }
        public virtual DbSet<StudSibling> StudSiblings { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentExtraActivityPosition> StudentExtraActivityPositions { get; set; }
        public virtual DbSet<StudentExtraActivityAcheivement> StudentExtraActivityAcheivements { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=dbSIS;Trusted_Connection=True;MultipleActiveResultSets=true");
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

                //entity.HasOne(d => d.ClassTeacher)
                //    .WithMany(p => p.ClassTeachers)
                //    .HasForeignKey(d => d.TeacherId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Teacher_Class");
            });

            modelBuilder.Entity<ClassMonitor>(entity =>
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

                //entity.HasOne(d => d.Class)
                //    .WithMany(p => p.ClassStudents)
                //    .HasForeignKey(d => d.ClassId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Class_ClassStudent");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ClassStudents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_ClassStudent");
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

                //entity.HasOne(d => d.Class)
                //    .WithMany(p => p.ClassSubjects)
                //    .HasForeignKey(d => d.ClassId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_Class_ClassSubjects");

                entity.HasOne(d => d.TeacherSubject)
                    .WithMany(p => p.ClassSubjects)
                    .HasForeignKey(d => d.TeacherSubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeacherSubject_ClassSubjects");
            });

            modelBuilder.Entity<ClassTeacher>(entity =>
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

            //modelBuilder.Entity<ClubMember>(entity =>
            //{
            //    entity.HasKey(e => e.Cmid);

            //    entity.HasIndex(e => e.Cid)
            //        .HasName("IX_FK_ClubClubMember");

            //    entity.HasIndex(e => e.StudentId)
            //        .HasName("IX_FK_StudentClubMember");

            //    entity.Property(e => e.Cmid).HasColumnName("CMID");

            //    entity.Property(e => e.Cid).HasColumnName("CID");

            //    entity.Property(e => e.CreatedBy).IsRequired();

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.MemberDate).HasColumnType("datetime");

            //    entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            //    entity.Property(e => e.RowVersion)
            //        .IsRequired()
            //        .IsRowVersion()
            //        .IsConcurrencyToken();

            //    entity.Property(e => e.StudentId).HasColumnName("StudentID");

            //    entity.HasOne(d => d.Club)
            //        .WithMany(p => p.ClubMembers)
            //        .HasForeignKey(d => d.Cid)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_ClubClubMember");

            //    entity.HasOne(d => d.Student)
            //        .WithMany(p => p.ClubMembers)
            //        .HasForeignKey(d => d.StudentId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_StudentClubMember");
            //});

            //modelBuilder.Entity<Club>(entity =>
            //{
            //    entity.HasKey(e => e.ClubId);

            //    entity.Property(e => e.ClubId).HasColumnName("CID");

            //    entity.Property(e => e.CreatedBy).IsRequired();

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            //    entity.Property(e => e.Name).IsRequired();

            //    entity.Property(e => e.RowVersion)
            //        .IsRequired()
            //        .IsRowVersion()
            //        .IsConcurrencyToken();
            //});

            //modelBuilder.Entity<EventParticipation>(entity =>
            //{
            //    entity.HasKey(e => e.Epid);

            //    entity.HasIndex(e => e.StudId)
            //        .HasName("IX_FK_StudentEventParticipation");

            //    entity.HasIndex(e => e.TeacherInCharge)
            //        .HasName("IX_FK_TeacherEventParticipation");

            //    entity.Property(e => e.Epid).HasColumnName("EPID");

            //    entity.Property(e => e.CreatedBy).IsRequired();

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.Date).HasColumnType("datetime");

            //    entity.Property(e => e.EventDesc).IsRequired();

            //    entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            //    entity.Property(e => e.RowVersion)
            //        .IsRequired()
            //        .IsRowVersion()
            //        .IsConcurrencyToken();

            //    entity.Property(e => e.StudId).HasColumnName("StudID");

            //    entity.HasOne(d => d.Student)
            //        .WithMany(p => p.EventParticipations)
            //        .HasForeignKey(d => d.StudId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_StudentEventParticipation");

            //    entity.HasOne(d => d.Teacher)
            //        .WithMany(p => p.EventParticipations)
            //        .HasForeignKey(d => d.TeacherInCharge)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_TeacherEventParticipation");
            //});

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

                entity.HasOne(d => d.StaffMember)
                    .WithMany(p => p.HeadingGrades)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StaffMember_HeadingGrades");
            });

            modelBuilder.Entity<LeavingCertificate>(entity =>
            {
                entity.HasKey(e => e.LeavCertId);

                entity.HasIndex(e => e.StudId)
                    .HasName("IX_FK_StudentLeavingCertificate");

                entity.Property(e => e.LeavCertId).HasColumnName("LeavCertID");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateLeaving).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.StudId).HasColumnName("StudID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.LeavingCertificates)
                    .HasForeignKey(d => d.StudId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentLeavingCertificate");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.MenuId);

                entity.HasIndex(e => e.ParentMenuId)
                    .HasName("IX_FK_MenuMenu");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.ParentMenuId).HasColumnName("ParentMenuID");

                entity.Property(e => e.Text).IsRequired();

                entity.Property(e => e.Type).IsRequired();

                entity.HasOne(d => d.ParentMenu)
                    .WithMany(p => p.InverseParentMenu)
                    .HasForeignKey(d => d.ParentMenuId)
                    .HasConstraintName("FK_MenuMenu");
            });

            //modelBuilder.Entity<PeriodSetup>(entity =>
            //{
            //    entity.HasKey(e => e.PeriodId);

            //    entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

            //    entity.Property(e => e.CreatedBy).IsRequired();

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            //    entity.Property(e => e.PeriodEndDate).HasColumnType("datetime");

            //    entity.Property(e => e.PeriodStartDate).HasColumnType("datetime");

            //    entity.Property(e => e.RowVersion)
            //        .IsRequired()
            //        .IsRowVersion()
            //        .IsConcurrencyToken();
            //});

            //modelBuilder.Entity<Prefect>(entity =>
            //{
            //    entity.HasKey(e => e.PreId);

            //    entity.HasIndex(e => e.PrefClassId)
            //        .HasName("IX_FK_PromotionClassPrefect");

            //    entity.HasIndex(e => e.StudId)
            //        .HasName("IX_FK_StudentPrefect");

            //    entity.Property(e => e.PreId).HasColumnName("PreID");

            //    entity.Property(e => e.CreatedBy).IsRequired();

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.EffectiveDate).HasColumnType("datetime");

            //    entity.Property(e => e.InactiveDate).HasColumnType("datetime");

            //    entity.Property(e => e.IsDhp).HasColumnName("IsDHP");

            //    entity.Property(e => e.IsHp).HasColumnName("IsHP");

            //    entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            //    entity.Property(e => e.PrefClassId).HasColumnName("PrefClassID");

            //    entity.Property(e => e.PromotedDate).HasColumnType("datetime");

            //    entity.Property(e => e.RowVersion)
            //        .IsRequired()
            //        .IsRowVersion()
            //        .IsConcurrencyToken();

            //    entity.Property(e => e.StudId).HasColumnName("StudID");

            //    entity.HasOne(d => d.PromotionClass)
            //        .WithMany(p => p.Prefects)
            //        .HasForeignKey(d => d.PrefClassId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_PromotionClassPrefect");

            //    entity.HasOne(d => d.Student)
            //        .WithMany(p => p.Prefects)
            //        .HasForeignKey(d => d.StudId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_StudentPrefect");
            //});

            //modelBuilder.Entity<PromotionClass>(entity =>
            //{
            //    entity.HasKey(e => e.PrClId);

            //    entity.HasIndex(e => e.ClassId)
            //        .HasName("IX_FK_ClassPromotionClass");

            //    entity.HasIndex(e => e.PeriodId)
            //        .HasName("IX_FK_PeriodSetupPromotionClass");

            //    entity.HasIndex(e => e.TeacherId)
            //        .HasName("IX_FK_TeacherPromotionClass");

            //    entity.Property(e => e.PrClId).HasColumnName("PrClID");

            //    entity.Property(e => e.ClassId).HasColumnName("ClassID");

            //    entity.Property(e => e.CreatedBy).IsRequired();

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            //    entity.Property(e => e.MonitorStud2Id).HasColumnName("MonitorStud2ID");

            //    entity.Property(e => e.MonitorStudId)
            //        .IsRequired()
            //        .HasColumnName("MonitorStudID");

            //    entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

            //    entity.Property(e => e.RowVersion)
            //        .IsRequired()
            //        .IsRowVersion()
            //        .IsConcurrencyToken();

            //    entity.Property(e => e.TeacherId).HasColumnName("TeacherID");
            //});

            modelBuilder.Entity<RoleMenuAccess>(entity =>
            {
                entity.HasKey(e => new { e.MenuId, e.RoleId });

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_FK_RoleMenuAccesses_Roles");

                entity.Property(e => e.MenuId).HasColumnName("MenuID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Menu)
                    .WithMany(p => p.RoleMenuAccesses)
                    .HasForeignKey(d => d.MenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleMenuAccesses_Menus");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleMenuAccesses)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleMenuAccesses_Roles");
            });

            //modelBuilder.Entity<RoleTile>(entity =>
            //{
            //    entity.HasKey(e => e.RoleTileId);

            //    entity.HasIndex(e => e.RoleId)
            //        .HasName("IX_FK_RoleRoleTiles");

            //    entity.Property(e => e.RoleTileId).HasColumnName("RoleTileID");

            //    entity.Property(e => e.CreatedBy).IsRequired();

            //    entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            //    entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

            //    entity.Property(e => e.RoleId).HasColumnName("RoleID");

            //    entity.Property(e => e.RowVersion)
            //        .IsRequired()
            //        .IsRowVersion()
            //        .IsConcurrencyToken();

            //    entity.Property(e => e.TileId).HasColumnName("TileID");

            //    entity.HasOne(d => d.Role)
            //        .WithMany(p => p.RoleTiles)
            //        .HasForeignKey(d => d.RoleId)
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_RoleRoleTiles");
            //});

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Code).IsRequired();

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
            });

            modelBuilder.Entity<StaffMember>(entity =>
            {
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

            modelBuilder.Entity<StudFamily>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.StudentId)
                    .HasName("IX_FK_StudentStudFamily");

                entity.Property(e => e.Id).HasColumnName("StudFID");

                entity.Property(e => e.ContactHome).IsRequired();

                entity.Property(e => e.ContactMob).IsRequired();

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Nicno)
                    .IsRequired()
                    .HasColumnName("NICNo");

                entity.Property(e => e.Occupation).IsRequired();

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.StudentId).HasColumnName("StudID");

                entity.Property(e => e.WorkingAdd).IsRequired();

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudFamilies)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentStudFamily");
            });

            modelBuilder.Entity<StudSibling>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.SiblingStudentId)
                    .HasName("IX_FK_StudentStudSibling1");

                entity.HasIndex(e => e.StudentId)
                    .HasName("IX_FK_StudentStudSibling");

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
                    .WithMany(p => p.StudSiblings)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Stud_StudSibling");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("StudID");

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("datetime");

                entity.Property(e => e.EmergencyConName).IsRequired();

                entity.Property(e => e.EmergencyContactTel).IsRequired();

                entity.Property(e => e.FullName).IsRequired();

                entity.Property(e => e.Initials).IsRequired();

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();
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

                entity.Property(e => e.Name).IsRequired();

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

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Nicno)
                    .IsRequired()
                    .HasColumnName("NICNo");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<TeacherSubject>(entity =>
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
                    .WithMany(p => p.TeacherSubjects)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Teacher_TeacherSubjects");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.TeacherSubjects)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grade_TeacherSubjects");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.TeacherSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject_TeacherSubjects");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.UserRoleId);

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_FK_RoleUserRole");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_FK_UserUserRole");

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleUserRole");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserUserRole");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("UserID");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.UserName).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);

            SeedData(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Grade>().HasData(
                new Grade { Id = 1, GradeId = Data.Grades.Grade1, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 2, GradeId = Data.Grades.Grade2, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 3, GradeId = Data.Grades.Grade3, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 4, GradeId = Data.Grades.Grade4, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 5, GradeId = Data.Grades.Grade5, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 6, GradeId = Data.Grades.Grade6, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 7, GradeId = Data.Grades.Grade7, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 8, GradeId = Data.Grades.Grade8, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 9, GradeId = Data.Grades.Grade9, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 10, GradeId = Data.Grades.Grade10, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 11, GradeId = Data.Grades.Grade11, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) });

            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, Code = "Admin", Name = "Administrator", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Role { RoleId = 2, Code = "AdminUser", Name = "Admin Department User", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) });

            modelBuilder.Entity<Menu>().HasData(
                new Menu { MenuId = 1, ParentMenuId = null, DisplaySeq = 10, Text = "Admin", Type = "M", Area = null, Controller = null, Action = null, IsHidden = false, Icon = "fas fa-user-tie" },
                new Menu { MenuId = 2, ParentMenuId = null, DisplaySeq = 20, Text = "Academic", Type = "M", Area = null, Controller = null, Action = null, IsHidden = false, Icon = "fas fa-book-reader" },
                new Menu { MenuId = 3, ParentMenuId = null, DisplaySeq = 30, Text = "Teacher", Type = "M", Area = null, Controller = null, Action = null, IsHidden = false, Icon = "fas fa-chalkboard-teacher" },
                new Menu { MenuId = 4, ParentMenuId = null, DisplaySeq = 40, Text = "Student", Type = "M", Area = null, Controller = null, Action = null, IsHidden = false, Icon = "fas fa-user-graduate" },
                new Menu { MenuId = 5, ParentMenuId = null, DisplaySeq = 50, Text = "Report", Type = "M", Area = null, Controller = null, Action = null, IsHidden = false, Icon = "fas fa-chart-bar" },
                new Menu { MenuId = 6, ParentMenuId = 1, DisplaySeq = 10, Text = "User Permissions", Type = "I", Area = "Admin", Controller = "UserRoles", Action = "Index" },
                new Menu { MenuId = 7, ParentMenuId = 1, DisplaySeq = 20, Text = "Users", Type = "I", Area = "Admin", Controller = "Users", Action = "Index" },
                new Menu { MenuId = 8, ParentMenuId = 1, DisplaySeq = 30, Text = "Staff Members", Type = "I", Area = "Admin", Controller = "StaffMember", Action = "Index" },
                new Menu { MenuId = 9, ParentMenuId = 1, DisplaySeq = 40, Text = "Sections", Type = "I", Area = "Admin", Controller = "Section", Action = "Index" },
                new Menu { MenuId = 10, ParentMenuId = 1, DisplaySeq = 50, Text = "Grades", Type = "I", Area = "Admin", Controller = "Grade", Action = "Index" },
                new Menu { MenuId = 11, ParentMenuId = 1, DisplaySeq = 60, Text = "Grade Classes", Type = "I", Area = "Admin", Controller = "GradeClass", Action = "Index" },
                new Menu { MenuId = 12, ParentMenuId = 2, DisplaySeq = 10, Text = "Section Heads", Type = "I", Area = "Academic", Controller = "SectionHead", Action = "Index" },
                new Menu { MenuId = 13, ParentMenuId = 2, DisplaySeq = 20, Text = "Grade Heads", Type = "I", Area = "Academic", Controller = "GradeHead", Action = "Index" },
                new Menu { MenuId = 14, ParentMenuId = 2, DisplaySeq = 30, Text = "Classes", Type = "I", Area = "Academic", Controller = "Class", Action = "Index" },
                new Menu { MenuId = 15, ParentMenuId = 3, DisplaySeq = 10, Text = "Teacher Maintenance", Type = "I", Area = "Teacher", Controller = "Teacher", Action = "Index" },
                new Menu { MenuId = 16, ParentMenuId = 4, DisplaySeq = 10, Text = "Student Maintenance", Type = "I", Area = "Student", Controller = "Student", Action = "Index" });

            modelBuilder.Entity<RoleMenuAccess>().HasData(
                new RoleMenuAccess { MenuId = 1, RoleId = 1 }
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

            modelBuilder.Entity<UserRole>().HasData(
               new UserRole { UserRoleId = 1, UserId = 1, RoleId = 1 });

            modelBuilder.Entity<Teacher>().HasData(
               new Teacher { Id = 1, Title = TitleTeacher.Mrs, Gender = Gender.Female, FullName = "Piumali Manorika Suraweera", Initials = "P M", Lname = "Suraweera", Address = "test", ContactNo = "0714479648", Nicno = "880272580V", ImmeContactNo = "0773411392", ImmeContactName = "Malith", Status = TeacherStatus.Active, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
               new Teacher { Id = 2, Title = TitleTeacher.Mrs, Gender = Gender.Male, FullName = "Udara Rathnayaka", Initials = "U", Lname = "Rathnayaka", Address = "test", ContactNo = "0716669648", Nicno = "900272580V", ImmeContactNo = "0773412392", ImmeContactName = "Umandya", Status = TeacherStatus.Active, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) });

            //modelBuilder.Entity<Subject>().HasData(
            //   new Subject { Id = 1, Name = "Sinhala", IsBasket = false, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
            //   new Subject { Id = 2, Name = "English", IsBasket = false, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
            //   new Subject { Id = 3, Name = "Dancing", IsBasket = false, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) });
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
