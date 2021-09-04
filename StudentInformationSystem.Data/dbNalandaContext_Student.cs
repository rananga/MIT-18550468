using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Data.Models;

namespace StudentInformationSystem.Data
{
    public partial class dbNalandaContext : DbContext
    {
        public virtual DbSet<ClassPromotion> ClassPromotions { get; set; }
        public virtual DbSet<ClassPromotionDetail> ClassPromotionDetails { get; set; }
        public virtual DbSet<LeavingCertificate> LeavingCertificates { get; set; }
        public virtual DbSet<StudentFamily> StudentFamilies { get; set; }
        public virtual DbSet<StudentSibling> StudentSiblings { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentBasketSubject> StudentBasketSubjects { get; set; }
        public virtual DbSet<StudentExtraActivityAcheivement> StudentExtraActivityAcheivements { get; set; }
        public virtual DbSet<StudentExtraActivityPosition> StudentExtraActivityPositions { get; set; }
        public virtual DbSet<StudentTransfer> StudentTransfers { get; set; }

        partial void OnModelCreatingPartial_Student(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassPromotion>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.ClassPromotions)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grade_ClassPromotions");
            });

            modelBuilder.Entity<ClassPromotionDetail>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.ClassPromotion)
                    .WithMany(p => p.ClassPromotionDetails)
                    .HasForeignKey(d => d.PromotionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClassPromotion_PromotionDetails");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ClassPromotionDetails)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_ClassPromotionDetails");

                entity.HasOne(d => d.FromClass)
                    .WithMany(p => p.FromClassPromotionDetails)
                    .HasForeignKey(d => d.FromClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FromClass_FromClassPromotionDetails");

                entity.HasOne(d => d.ToClass)
                    .WithMany(p => p.ToClassPromotionDetails)
                    .HasForeignKey(d => d.ToClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ToClass_ToClassPromotionDetails");
            });

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

                entity.HasOne(d => d.AdmittedGrade)
                    .WithMany(p => p.GradeAdmissions)
                    .HasForeignKey(d => d.AdmittedGradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AdmittedGrade_GradeAdmissions");

                entity.HasOne(d => d.LastClass)
                    .WithMany(p => p.LastClassStudents)
                    .HasForeignKey(d => d.LastClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LastClass_LastClassStudents");

                entity.Property(e => e.DOB).IsRequired(false);
                entity.Property(e => e.Address1).IsRequired(false);
                entity.Property(e => e.City).IsRequired(false);
                entity.Property(e => e.EmergContactName).IsRequired(false);
                entity.Property(e => e.EmergContactNo).IsRequired(false);
                entity.Property(e => e.EmergContactNo).IsRequired(false);
                entity.Property(e => e.AdmittedGradeId).IsRequired(false);
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

            modelBuilder.Entity<StudentTransfer>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentTransfers)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_StudentTransfers");

                entity.HasOne(d => d.FromClass)
                    .WithMany(p => p.FromTransfers)
                    .HasForeignKey(d => d.FromCR_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FromClass_FromTransfers");

                entity.HasOne(d => d.ToClass)
                    .WithMany(p => p.ToTransfers)
                    .HasForeignKey(d => d.ToCR_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ToClass_ToTransfers");
            });
        }
    }
}
