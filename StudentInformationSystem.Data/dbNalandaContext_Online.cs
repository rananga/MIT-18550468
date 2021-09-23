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
        public virtual DbSet<AuditTemp> AuditTemp { get; set; }
        public virtual DbSet<OC_Meeting> OC_Meetings { get; set; }
        public virtual DbSet<OC_MeetingAttendee> OC_MeetingAttendees { get; set; }
        public virtual DbSet<OCR_ClassRoom> OCR_ClassRooms { get; set; }
        public virtual DbSet<OCR_Teacher> OCR_Teachers { get; set; }
        public virtual DbSet<OnlineClassRoom> OnlineClassRooms { get; set; }
        public virtual DbSet<OnlineClass> OnlineClasses { get; set; }

        partial void OnModelCreatingPartial_Online(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditTemp>(entity =>
            {
                entity.HasKey(e => new { e.MeetingDate, e.CustomerId, e.ParticipantEmail, e.UniqueQualifier });

                entity.Property(e => e.MeetingDate).HasColumnType("datetime");

                entity.Property(e => e.ParticipantEmail).HasMaxLength(30);

                entity.Property(e => e.CalendarEventId).HasMaxLength(50);

                entity.Property(e => e.ConferenceId)
                    .HasColumnName("ConferenceID")
                    .HasMaxLength(50);

                entity.Property(e => e.MeetingCode).HasMaxLength(30);

                entity.Property(e => e.OrganizerEmail).HasMaxLength(30);
            });

            modelBuilder.Entity<OC_Meeting>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.OnlineClass)
                    .WithMany(p => p.OC_Meetings)
                    .HasForeignKey(d => d.OC_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OnlineClass_OC_Meetings");
            });

            modelBuilder.Entity<OC_MeetingAttendee>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.OC_Meeting)
                    .WithMany(p => p.OC_MeetingAttendees)
                    .HasForeignKey(d => d.OC_MeetingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OC_Meeting_OC_MeetingAttendees");
            });

            modelBuilder.Entity<OCR_ClassRoom>((Action<Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<OCR_ClassRoom>>)(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.OnlineClassRoom)
                    .WithMany((System.Linq.Expressions.Expression<Func<OnlineClassRoom, IEnumerable<OCR_ClassRoom>>>)(p => (IEnumerable<OCR_ClassRoom>)p.PhysicalClassRooms))
                    .HasForeignKey(d => d.OCR_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OnlineClassRoom_OCR_ClassRooms");

                entity.HasOne(d => d.ClassRoom)
                    .WithMany(p => p.OCR_ClassRooms)
                    .HasForeignKey(d => d.CR_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClassRoom_OCR_ClassRooms");
            }));

            modelBuilder.Entity<OCR_Teacher>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.OnlineClassRoom)
                    .WithMany(p => p.ClassTeachers)
                    .HasForeignKey(d => d.OCR_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OnlineClassRoom_ClassTeachers");

                entity.HasOne(d => d.StaffMember)
                    .WithMany(p => p.OCR_Teachers)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClassTeacher_OCR_Teachers");
            });

            modelBuilder.Entity<OnlineClassRoom>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.OnlineClassRooms)
                    .HasForeignKey(d => d.GradeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grade_OnlineClassRooms");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.OnlineClassRooms)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject_OnlineClassRooms");
            });

            modelBuilder.Entity<OnlineClass>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.OnlineClassRoom)
                    .WithMany(p => p.OnlineClasses)
                    .HasForeignKey(d => d.OCR_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OnlineClassRoom_OnlineClasses");

                entity.HasOne(d => d.OCR_Teacher)
                    .WithMany(p => p.OnlineClasses)
                    .HasForeignKey(d => d.OCR_TeacherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OCR_Teacher_OnlineClasses");
            });
        }
    }
}
