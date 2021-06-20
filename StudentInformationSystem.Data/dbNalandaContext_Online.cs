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
        public virtual DbSet<OnlineClassRoom> OnlineClassRooms { get; set; }
        public virtual DbSet<OCR_ClassRoom> OCR_ClassRooms { get; set; }
        public virtual DbSet<OCR_Teacher> OCR_Teachers { get; set; }

        partial void OnModelCreatingPartial_Online(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<OCR_ClassRoom>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.ClassRoom)
                    .WithMany(p => p.OCR_ClassRooms)
                    .HasForeignKey(d => d.CR_Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ClassRoom_OCR_ClassRooms");
            });

            modelBuilder.Entity<OCR_Teacher>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.CreatedBy).IsRequired();

                entity.Property(e => e.RowVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.StaffMember)
                    .WithMany(p => p.OCR_Teachers)
                    .HasForeignKey(d => d.StaffId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StaffMember_OCR_Teachers");
            });
        }
    }
}
