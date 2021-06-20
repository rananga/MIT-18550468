using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Data.Models;

namespace StudentInformationSystem.Data
{
    public partial class dbNalandaContext : DbContext
    {
        public virtual DbSet<LeavingCertificate> LeavingCertificates { get; set; }
        public virtual DbSet<StudentFamily> StudentFamilies { get; set; }
        public virtual DbSet<StudentSibling> StudentSiblings { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentBasketSubject> StudentBasketSubjects { get; set; }
        public virtual DbSet<StudentExtraActivityAcheivement> StudentExtraActivityAcheivements { get; set; }
        public virtual DbSet<StudentExtraActivityPosition> StudentExtraActivityPositions { get; set; }

        partial void OnModelCreatingPartial_Student(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LeavingCertificate>(entity =>
            {
                entity.HasKey(e => e.LeavCertId);

                entity.HasIndex(e => e.StudId)
                    .HasName("IX_FK_StudentLeavingCertificate");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.DateLeaving).HasColumnType("datetime");

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

            modelBuilder.Entity<StudentFamily>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

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

                entity.Property(e => e.DOB).HasColumnType("datetime");

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });

            modelBuilder.Entity<StudentBasketSubject>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

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
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject_StudentBasketSubjects");
            });

            modelBuilder.Entity<StudentExtraActivityAcheivement>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

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
        }
    }
}
