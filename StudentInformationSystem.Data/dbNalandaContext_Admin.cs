using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Data.Models;

namespace StudentInformationSystem.Data
{
    public partial class dbNalandaContext : DbContext
    {
        public virtual DbSet<ExtraActivity> ExtraActivities { get; set; }
        public virtual DbSet<ExtraActivityAcheivement> ExtraActivityAcheivements { get; set; }
        public virtual DbSet<ExtraActivityIncharge> ExtraActivityIncharges { get; set; }
        public virtual DbSet<ExtraActivityPosition> ExtraActivityPositions { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<GradeHead> GradeHeads { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<PermissionGradeAccess> PermissionGradeAccesses { get; set; }
        public virtual DbSet<PermissionMenuAccess> PermissionMenuAccesses { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<SectionHead> SectionHeads { get; set; }
        public virtual DbSet<StaffMember> StaffMembers { get; set; }
        public virtual DbSet<UserPermission> UserPermissions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Visitor> Visitors { get; set; }

        partial void OnModelCreatingPartial_Admin(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExtraActivity>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<ExtraActivityAcheivement>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

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

            modelBuilder.Entity<ExtraActivityIncharge>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Activity)
                    .WithMany(p => p.Incharges)
                    .HasForeignKey(d => d.ActivityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_Incharges");

                entity.HasOne(d => d.StaffMember)
                    .WithMany(p => p.ExtraActivityIncharges)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StaffMember_ExtraActivityIncharges");
            });

            modelBuilder.Entity<ExtraActivityPosition>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

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

            modelBuilder.Entity<GradeHead>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.ToDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy).IsRequired();

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

            modelBuilder.Entity<PermissionGradeAccess>(entity =>
            {
                entity.HasKey(e => new { e.GradeId, e.PermissionId });

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.PermissionGradeAccesses)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grade_PermissionGradeAccesses");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.PermissionGradeAccesses)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Permission_PermissionGradeAccesses");
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

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(b => b.User).WithOne(p => p.StaffMember).HasForeignKey<User>(b => b.StaffId);
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

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(b => b.User).WithOne(p => p.Visitor).HasForeignKey<User>(b => b.VisitorId);
            });
        }
    }
}
