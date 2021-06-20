using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StudentInformationSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            OnModelCreatingPartial_Academic(modelBuilder);
            OnModelCreatingPartial_Admin(modelBuilder);
            OnModelCreatingPartial_Online(modelBuilder);
            OnModelCreatingPartial_Student(modelBuilder);
            OnModelCreatingPartial_Teacher(modelBuilder);

            SeedData(modelBuilder);
        }

        partial void OnModelCreatingPartial_Academic(ModelBuilder modelBuilder);
        partial void OnModelCreatingPartial_Admin(ModelBuilder modelBuilder);
        partial void OnModelCreatingPartial_Online(ModelBuilder modelBuilder);
        partial void OnModelCreatingPartial_Student(ModelBuilder modelBuilder);
        partial void OnModelCreatingPartial_Teacher(ModelBuilder modelBuilder);

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
                new Menu { MenuId = 14, ParentMenuId = 1, DisplaySeq = 80, Text = "Extra Activities", Type = "I", Area = "Admin", Controller = "ExtraActivity", Action = "Index" },
                new Menu { MenuId = 15, ParentMenuId = 2, DisplaySeq = 10, Text = "Subject Categories", Type = "I", Area = "Academic", Controller = "SubjectCategory", Action = "Index" },
                new Menu { MenuId = 16, ParentMenuId = 2, DisplaySeq = 20, Text = "Subjects", Type = "I", Area = "Academic", Controller = "Subject", Action = "Index" },
                new Menu { MenuId = 17, ParentMenuId = 2, DisplaySeq = 30, Text = "Grade Subjects", Type = "I", Area = "Academic", Controller = "GradeSubject", Action = "Index" },
                new Menu { MenuId = 18, ParentMenuId = 2, DisplaySeq = 40, Text = "Grade Classes", Type = "I", Area = "Academic", Controller = "GradeClass", Action = "Index" },
                new Menu { MenuId = 19, ParentMenuId = 2, DisplaySeq = 50, Text = "Class Rooms", Type = "I", Area = "Academic", Controller = "ClassRoom", Action = "Index" },
                new Menu { MenuId = 20, ParentMenuId = 3, DisplaySeq = 20, Text = "Teacher Information", Type = "I", Area = "Teacher", Controller = "Teacher", Action = "Index" },
                new Menu { MenuId = 21, ParentMenuId = 4, DisplaySeq = 10, Text = "Student Maintenance", Type = "I", Area = "Student", Controller = "Student", Action = "Index" },
                new Menu { MenuId = 22, ParentMenuId = 4, DisplaySeq = 20, Text = "Student Basket Subjects", Type = "I", Area = "Student", Controller = "BasketSubject", Action = "Index" },
                new Menu { MenuId = 23, ParentMenuId = 4, DisplaySeq = 30, Text = "Student Marks", Type = "I", Area = "Student", Controller = "StudentMark", Action = "Index" },
                new Menu { MenuId = 24, ParentMenuId = 5, DisplaySeq = 30, Text = "Online Class Rooms", Type = "I", Area = "Student", Controller = "StudentMark", Action = "Index" },
                new Menu { MenuId = 25, ParentMenuId = 5, DisplaySeq = 30, Text = "Online Time Table", Type = "I", Area = "Student", Controller = "StudentMark", Action = "Index" },
                new Menu { MenuId = 26, ParentMenuId = 6, DisplaySeq = 30, Text = "Student Attendance", Type = "I", Area = "Report", Controller = "StudentAttendance", Action = "Index" },
                new Menu { MenuId = 27, ParentMenuId = 6, DisplaySeq = 30, Text = "Attendance By Duration", Type = "I", Area = "Report", Controller = "AttendanceByDuration", Action = "Index" },
                new Menu { MenuId = 28, ParentMenuId = 6, DisplaySeq = 30, Text = "Term Wise Student Marks", Type = "I", Area = "Report", Controller = "StudentMarks", Action = "Process" },
                new Menu { MenuId = 29, ParentMenuId = 6, DisplaySeq = 30, Text = "Online Sessions Summary", Type = "I", Area = "Report", Controller = "OnlineSessionsSummary", Action = "Process" });

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
