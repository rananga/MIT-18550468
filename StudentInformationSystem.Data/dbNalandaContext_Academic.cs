using Microsoft.EntityFrameworkCore;
using StudentInformationSystem.Data.Models;

namespace StudentInformationSystem.Data
{
    public partial class dbNalandaContext : DbContext
    {
        public virtual DbSet<PhysicalClassRoom> PhysicalClassRooms { get; set; }
        public virtual DbSet<PCR_Monitor> PCR_Monitors { get; set; }
        public virtual DbSet<PCR_Student> PCR_Students { get; set; }
        public virtual DbSet<PCR_StudentSubject> PCR_StudentSubjects { get; set; }
        public virtual DbSet<PCR_StudentSubjectMark> PCR_StudentSubjectMarks { get; set; }
        public virtual DbSet<PCR_Subject> PCR_Subjects { get; set; }
        public virtual DbSet<PCR_Teacher> PCR_Teachers { get; set; }
        public virtual DbSet<GradeClass> GradeClasses { get; set; }
        public virtual DbSet<GradeClassSubject> GradeClassSubjects { get; set; }
        public virtual DbSet<GradeSubject> GradeSubjects { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectCategory> SubjectCategories { get; set; }

        partial void OnModelCreatingPartial_Academic(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhysicalClassRoom>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

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

            modelBuilder.Entity<PCR_Monitor>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.PhysicalClassRoom)
                    .WithMany(p => p.ClassMonitors)
                    .HasForeignKey(d => d.CR_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Class_ClassMonitors");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ClassMonitors)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_ClassMonitors");
            });

            modelBuilder.Entity<PCR_Student>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.PhysicalClassRoom)
                    .WithMany(p => p.ClassStudents)
                    .HasForeignKey(d => d.CR_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Class_ClassStudents");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.ClassStudents)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Student_ClassStudents");
            });

            modelBuilder.Entity<PCR_StudentSubject>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.CR_Student)
                    .WithMany(p => p.StudentSubjects)
                    .HasForeignKey(d => d.CR_StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClassStudent_StudentSubjects");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.StudentSubjects)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject_StudentSubjects");
            });

            modelBuilder.Entity<PCR_StudentSubjectMark>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.CR_StudentSubject)
                    .WithMany(p => p.ClassStudentSubjectMarks)
                    .HasForeignKey(d => d.CR_StudentSubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClassStudentSubject_ClassStudentSubjectMarks");
            });

            modelBuilder.Entity<PCR_Subject>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.PhysicalClassRoom)
                    .WithMany(p => p.ClassSubjects)
                    .HasForeignKey(d => d.CR_Id)
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

                entity.Property(e => e.StaffId).IsRequired(false);
            });

            modelBuilder.Entity<PCR_Teacher>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FromDate).HasColumnType("date");

                entity.Property(e => e.ToDate).HasColumnType("date");

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.PhysicalClassRoom)
                    .WithMany(p => p.ClassTeachers)
                    .HasForeignKey(d => d.CR_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Class_ClassTeachers");

                entity.HasOne(d => d.StaffMember)
                    .WithMany(p => p.ClassTeachers)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StaffMember_ClassTeachers");
            });

            modelBuilder.Entity<GradeClass>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

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

            modelBuilder.Entity<GradeSubject>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

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

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

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

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();
            });
        }
    }
}
