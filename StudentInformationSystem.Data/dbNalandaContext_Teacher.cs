using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Data.Models;

namespace StudentInformationSystem.Data
{
    public partial class dbNalandaContext : DbContext
    {
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TeacherOffTime> TeacherOffTimes { get; set; }
        public virtual DbSet<TeacherQualification> TeacherQualifications { get; set; }
        public virtual DbSet<TeacherQualificationSubject> TeacherQualificationSubjects { get; set; }
        public virtual DbSet<TeacherPreferedSubject> TeacherPreferedSubjects { get; set; }

        partial void OnModelCreatingPartial_Teacher(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

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

            modelBuilder.Entity<TeacherOffTime>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeacherOffTimes)
                    .HasForeignKey(d => d.TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Teacher_OffTimes");
            });

            modelBuilder.Entity<TeacherQualification>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

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
        }
    }
}
