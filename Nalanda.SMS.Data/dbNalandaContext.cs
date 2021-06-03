using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Nalanda.SMS.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Nalanda.SMS.Data
{
    public partial class dbNalandaContext : DbContext
    {
        public dbNalandaContext()
        {
        }

        public dbNalandaContext(DbContextOptions<dbNalandaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClassStudent> ClassStudents { get; set; }
        public virtual DbSet<ClassTeacher> ClassTeachers { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClubMember> ClubMembers { get; set; }
        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<EventParticipation> EventParticipations { get; set; }
        public virtual DbSet<LeavingCertificate> LeavingCertificates { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<PeriodSetup> PeriodSetups { get; set; }
        public virtual DbSet<Prefect> Prefects { get; set; }
        public virtual DbSet<PromotionClass> PromotionClasses { get; set; }
        public virtual DbSet<RoleMenuAccess> RoleMenuAccesses { get; set; }
        public virtual DbSet<RoleTile> RoleTiles { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<StudFamily> StudFamilies { get; set; }
        public virtual DbSet<StudSibling> StudSiblings { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=dbNalanda;Trusted_Connection=True;MultipleActiveResultSets=true");
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassStudent>(entity =>
            {
                entity.HasKey(e => e.ClStudId);

                entity.HasIndex(e => e.PrClId)
                    .HasName("IX_FK_PromotionClassClassStudent");

                entity.HasIndex(e => e.StudId)
                    .HasName("IX_FK_StudentClassStudent");

                entity.Property(e => e.ClStudId).HasColumnName("ClStudID");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PeriodEndDate).HasColumnType("datetime");

                entity.Property(e => e.PeriodStartDate).HasColumnType("datetime");

                entity.Property(e => e.PrClId).HasColumnName("PrClID");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.StudId).HasColumnName("StudID");

                entity.HasOne(d => d.PromotionClass)
                    .WithMany(p => p.ClassStudents)
                    .HasForeignKey(d => d.PrClId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PromotionClassClassStudent");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ClassStudents)
                    .HasForeignKey(d => d.StudId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentClassStudent");
            });

            modelBuilder.Entity<ClassTeacher>(entity =>
            {
                entity.HasKey(e => e.ClTeachId);

                entity.HasIndex(e => e.ClassId)
                    .HasName("IX_FK_ClassClassTeacher");

                entity.HasIndex(e => e.PeriodId)
                    .HasName("IX_FK_PeriodSetupClassTeacher");

                entity.HasIndex(e => e.TeacherId)
                    .HasName("IX_FK_TeacherClassTeacher");

                entity.Property(e => e.ClTeachId).HasColumnName("ClTeachID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PeriodEndDate).HasColumnType("datetime");

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

                entity.Property(e => e.PeriodStartDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.ClassTeachers)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClassClassTeacher");

                entity.HasOne(d => d.Period)
                    .WithMany(p => p.ClassTeachers)
                    .HasForeignKey(d => d.PeriodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PeriodSetupClassTeacher");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.ClassTeachers)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeacherClassTeacher");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(e => e.ClassId);

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.ClassDesc).IsRequired();

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<ClubMember>(entity =>
            {
                entity.HasKey(e => e.Cmid);

                entity.HasIndex(e => e.Cid)
                    .HasName("IX_FK_ClubClubMember");

                entity.HasIndex(e => e.StudentId)
                    .HasName("IX_FK_StudentClubMember");

                entity.Property(e => e.Cmid).HasColumnName("CMID");

                entity.Property(e => e.Cid).HasColumnName("CID");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.MemberDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.ClubMembers)
                    .HasForeignKey(d => d.Cid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClubClubMember");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ClubMembers)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentClubMember");
            });

            modelBuilder.Entity<Club>(entity =>
            {
                entity.HasKey(e => e.Cid);

                entity.Property(e => e.Cid).HasColumnName("CID");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<EventParticipation>(entity =>
            {
                entity.HasKey(e => e.Epid);

                entity.HasIndex(e => e.StudId)
                    .HasName("IX_FK_StudentEventParticipation");

                entity.HasIndex(e => e.TeacherInCharge)
                    .HasName("IX_FK_TeacherEventParticipation");

                entity.Property(e => e.Epid).HasColumnName("EPID");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.EventDesc).IsRequired();

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.StudId).HasColumnName("StudID");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.EventParticipations)
                    .HasForeignKey(d => d.StudId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentEventParticipation");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.EventParticipations)
                    .HasForeignKey(d => d.TeacherInCharge)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeacherEventParticipation");
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

            modelBuilder.Entity<PeriodSetup>(entity =>
            {
                entity.HasKey(e => e.PeriodId);

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PeriodEndDate).HasColumnType("datetime");

                entity.Property(e => e.PeriodStartDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<Prefect>(entity =>
            {
                entity.HasKey(e => e.PreId);

                entity.HasIndex(e => e.PrefClassId)
                    .HasName("IX_FK_PromotionClassPrefect");

                entity.HasIndex(e => e.StudId)
                    .HasName("IX_FK_StudentPrefect");

                entity.Property(e => e.PreId).HasColumnName("PreID");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EffectiveDate).HasColumnType("datetime");

                entity.Property(e => e.InactiveDate).HasColumnType("datetime");

                entity.Property(e => e.IsDhp).HasColumnName("IsDHP");

                entity.Property(e => e.IsHp).HasColumnName("IsHP");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.PrefClassId).HasColumnName("PrefClassID");

                entity.Property(e => e.PromotedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.StudId).HasColumnName("StudID");

                entity.HasOne(d => d.PromotionClass)
                    .WithMany(p => p.Prefects)
                    .HasForeignKey(d => d.PrefClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PromotionClassPrefect");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Prefects)
                    .HasForeignKey(d => d.StudId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentPrefect");
            });

            modelBuilder.Entity<PromotionClass>(entity =>
            {
                entity.HasKey(e => e.PrClId);

                entity.HasIndex(e => e.ClassId)
                    .HasName("IX_FK_ClassPromotionClass");

                entity.HasIndex(e => e.PeriodId)
                    .HasName("IX_FK_PeriodSetupPromotionClass");

                entity.HasIndex(e => e.TeacherId)
                    .HasName("IX_FK_TeacherPromotionClass");

                entity.Property(e => e.PrClId).HasColumnName("PrClID");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.MonitorStud2Id).HasColumnName("MonitorStud2ID");

                entity.Property(e => e.MonitorStudId)
                    .IsRequired()
                    .HasColumnName("MonitorStudID");

                entity.Property(e => e.PeriodId).HasColumnName("PeriodID");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.PromotionClasses)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClassPromotionClass");

                entity.HasOne(d => d.PeriodSetup)
                    .WithMany(p => p.PromotionClasses)
                    .HasForeignKey(d => d.PeriodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PeriodSetupPromotionClass");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.PromotionClasses)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeacherPromotionClass");
            });

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

            modelBuilder.Entity<RoleTile>(entity =>
            {
                entity.HasKey(e => e.RoleTileId);

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_FK_RoleRoleTiles");

                entity.Property(e => e.RoleTileId).HasColumnName("RoleTileID");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.TileId).HasColumnName("TileID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleTiles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RoleRoleTiles");
            });

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

            modelBuilder.Entity<StudFamily>(entity =>
            {
                entity.HasKey(e => e.StudFid);

                entity.HasIndex(e => e.StudId)
                    .HasName("IX_FK_StudentStudFamily");

                entity.Property(e => e.StudFid).HasColumnName("StudFID");

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

                entity.Property(e => e.StudId).HasColumnName("StudID");

                entity.Property(e => e.WorkingAdd).IsRequired();

                entity.HasOne(d => d.Stud)
                    .WithMany(p => p.StudFamilies)
                    .HasForeignKey(d => d.StudId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentStudFamily");
            });

            modelBuilder.Entity<StudSibling>(entity =>
            {
                entity.HasKey(e => e.SubId);

                entity.HasIndex(e => e.SiblingStudId)
                    .HasName("IX_FK_StudentStudSibling1");

                entity.HasIndex(e => e.SudId)
                    .HasName("IX_FK_StudentStudSibling");

                entity.Property(e => e.SubId).HasColumnName("SubID");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.SiblingStudId).HasColumnName("SiblingStudID");

                entity.Property(e => e.SudId).HasColumnName("SudID");

                entity.HasOne(d => d.StudentRelation)
                    .WithMany(p => p.StudSiblings)
                    .HasForeignKey(d => d.SudId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentStudSibling");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.StudId);

                entity.Property(e => e.StudId).HasColumnName("StudID");

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

                entity.Property(e => e.LdhammaSchoolAdd).HasColumnName("LDhammaSchoolAdd");

                entity.Property(e => e.Lname)
                    .IsRequired()
                    .HasColumnName("LName");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.Property(e => e.School).IsRequired();
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.TeachId);

                entity.Property(e => e.TeachId).HasColumnName("TeachID");

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.ContactNo).IsRequired();

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FullName).IsRequired();

                entity.Property(e => e.Initials).IsRequired();

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
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

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
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, Code = "Admin", Name = "Administrator", CreatedBy = "System", CreatedDate = new DateTime(2015, 1, 1) },
                new Role { RoleId = 2, Code = "AdminUser", Name = "Admin Department User", CreatedBy = "System", CreatedDate = new DateTime(2015, 1, 1) });

            modelBuilder.Entity<Menu>().HasData(
                new Menu { MenuId = 1, ParentMenuId = null, DisplaySeq = 10, Text = "Admin", Type = "M", Area = null, Controller = null, Action = null },
                new Menu { MenuId = 2, ParentMenuId = 1, DisplaySeq = 10, Text = "User Role Maintenance", Type = "I", Area = "Admin", Controller = "Users", Action = "Index" },
                new Menu { MenuId = 3, ParentMenuId = 1, DisplaySeq = 20, Text = "User Maintenance", Type = "I", Area = "Admin", Controller = "UserRoles", Action = "Index" },
                new Menu { MenuId = 4, ParentMenuId = 1, DisplaySeq = 30, Text = "Teacher Maintenance", Type = "I", Area = "Admin", Controller = "Teacher", Action = "Index" },
                new Menu { MenuId = 5, ParentMenuId = 1, DisplaySeq = 40, Text = "-", Type = "D", Area = null, Controller = null, Action = null },
                new Menu { MenuId = 6, ParentMenuId = 1, DisplaySeq = 50, Text = "Class Definition", Type = "I", Area = "Admin", Controller = "Class", Action = "Index" },
                new Menu { MenuId = 7, ParentMenuId = 1, DisplaySeq = 60, Text = "Club Definition", Type = "I", Area = "Admin", Controller = "Club", Action = "Index" });

            modelBuilder.Entity<RoleMenuAccess>().HasData(
                new RoleMenuAccess { MenuId = 1, RoleId = 1 }
                );

            modelBuilder.Entity<User>().HasData(
               new User
               {
                   UserId = 1,
                   UserName = "rananga",
                   Password = "1",
                   Status = ActiveState.Active,
                   CreatedBy = "System",
                   CreatedDate = new DateTime(2015, 1, 1)
               });

            modelBuilder.Entity<UserRole>().HasData(
               new UserRole { UserRoleId = 1, UserId = 1, RoleId = 1 });
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
