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
                new Menu { MenuId = 10, ParentMenuId = 1, DisplaySeq = 40, Text = "Visitors", Type = "I", Area = "Admin", Controller = "Visitor", Action = "Index" },
                new Menu { MenuId = 11, ParentMenuId = 1, DisplaySeq = 50, Text = "Sections", Type = "I", Area = "Admin", Controller = "Section", Action = "Index" },
                new Menu { MenuId = 12, ParentMenuId = 1, DisplaySeq = 60, Text = "Section Heads", Type = "I", Area = "Admin", Controller = "SectionHead", Action = "Index" },
                new Menu { MenuId = 13, ParentMenuId = 1, DisplaySeq = 70, Text = "Grades", Type = "I", Area = "Admin", Controller = "Grade", Action = "Index" },
                new Menu { MenuId = 14, ParentMenuId = 1, DisplaySeq = 80, Text = "Grade Heads", Type = "I", Area = "Admin", Controller = "GradeHead", Action = "Index" },
                new Menu { MenuId = 15, ParentMenuId = 1, DisplaySeq = 90, Text = "Extra Activities", Type = "I", Area = "Admin", Controller = "ExtraActivity", Action = "Index" },
                new Menu { MenuId = 16, ParentMenuId = 2, DisplaySeq = 10, Text = "Subject Categories", Type = "I", Area = "Academic", Controller = "SubjectCategory", Action = "Index" },
                new Menu { MenuId = 17, ParentMenuId = 2, DisplaySeq = 20, Text = "Subjects", Type = "I", Area = "Academic", Controller = "Subject", Action = "Index" },
                new Menu { MenuId = 18, ParentMenuId = 2, DisplaySeq = 30, Text = "Grade Subjects", Type = "I", Area = "Academic", Controller = "GradeSubject", Action = "Index" },
                new Menu { MenuId = 19, ParentMenuId = 2, DisplaySeq = 40, Text = "Grade Classes", Type = "I", Area = "Academic", Controller = "GradeClass", Action = "Index" },
                new Menu { MenuId = 20, ParentMenuId = 2, DisplaySeq = 50, Text = "Physical Classrooms", Type = "I", Area = "Academic", Controller = "ClassRoom", Action = "Index" },
                new Menu { MenuId = 21, ParentMenuId = 3, DisplaySeq = 10, Text = "Teacher Information", Type = "I", Area = "Teacher", Controller = "Teacher", Action = "Index" },
                new Menu { MenuId = 22, ParentMenuId = 3, DisplaySeq = 20, Text = "Teacher Availability", Type = "I", Area = "Teacher", Controller = "TeacherAvailability", Action = "Index" },
                new Menu { MenuId = 23, ParentMenuId = 4, DisplaySeq = 10, Text = "Student Maintenance", Type = "I", Area = "Student", Controller = "Student", Action = "Index" },
                new Menu { MenuId = 24, ParentMenuId = 4, DisplaySeq = 20, Text = "Student Basket Subjects", Type = "I", Area = "Student", Controller = "BasketSubject", Action = "Index" },
                new Menu { MenuId = 25, ParentMenuId = 4, DisplaySeq = 30, Text = "Admit Student", Type = "I", Area = "Student", Controller = "StudentAdmit", Action = "Index" },
                new Menu { MenuId = 26, ParentMenuId = 4, DisplaySeq = 40, Text = "Student Marks", Type = "I", Area = "Student", Controller = "StudentMark", Action = "Index" },
                new Menu { MenuId = 27, ParentMenuId = 4, DisplaySeq = 50, Text = "Transfer Student", Type = "I", Area = "Student", Controller = "TransferStudent", Action = "Index" },
                new Menu { MenuId = 28, ParentMenuId = 4, DisplaySeq = 50, Text = "Class Promotion", Type = "I", Area = "Student", Controller = "ClassPromotion", Action = "Index" },
                new Menu { MenuId = 29, ParentMenuId = 4, DisplaySeq = 60, Text = "Student Extra Activities", Type = "I", Area = "Student", Controller = "StudentExtraActivities", Action = "Index" },
                new Menu { MenuId = 30, ParentMenuId = 5, DisplaySeq = 10, Text = "Online Classrooms", Type = "I", Area = "Online", Controller = "OnlineClassRoom", Action = "Index" },
                new Menu { MenuId = 31, ParentMenuId = 5, DisplaySeq = 20, Text = "Online Time Table", Type = "I", Area = "Online", Controller = "OnlineTimeTable", Action = "Index" },
                new Menu { MenuId = 32, ParentMenuId = 6, DisplaySeq = 10, Text = "Student Character", Type = "I", Area = "Report", Controller = "StudentCharacter", Action = "Process" },
                new Menu { MenuId = 33, ParentMenuId = 6, DisplaySeq = 20, Text = "Student Attendance", Type = "I", Area = "Report", Controller = "StudentAttendance", Action = "Process" },
                new Menu { MenuId = 34, ParentMenuId = 6, DisplaySeq = 30, Text = "Term Wise Student Marks", Type = "I", Area = "Report", Controller = "StudentMarks", Action = "Process" },
                new Menu { MenuId = 35, ParentMenuId = 6, DisplaySeq = 40, Text = "Online Sessions Summary", Type = "I", Area = "Report", Controller = "OnlineSessionsSummary", Action = "Process" },
                new Menu { MenuId = 36, ParentMenuId = 6, DisplaySeq = 50, Text = "Weekly Summary", Type = "I", Area = "Report", Controller = "WeeklySummary", Action = "Process" });

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

            modelBuilder.Entity<Student>().HasData(
               new Student { Id = 1, IndexNo = 29013, FullName = "A J M T A Jayasundara", Initials = "A J M T A", LastName = "Jayasundara", SchoolEmail = "29013@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-17"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 2, IndexNo = 28953, FullName = "A U N De Silva", Initials = "A U N De", LastName = "Silva", SchoolEmail = "28953@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 3, IndexNo = 28948, FullName = "B L R Abedeera", Initials = "B L R", LastName = "Abedeera", SchoolEmail = "28948@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-15"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 4, IndexNo = 29043, FullName = "B M T Silva", Initials = "B M T", LastName = "Silva", SchoolEmail = "29043@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 5, IndexNo = 29028, FullName = "B W K M Peeris", Initials = "B W K M", LastName = "Peeris", SchoolEmail = "29028@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 6, IndexNo = 29049, FullName = "Chenuk Manthila P S", Initials = "Chenuk", LastName = "Manthila P S", SchoolEmail = "29049@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-10"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 7, IndexNo = 29023, FullName = "D C A Dias", Initials = "D C A", LastName = "Dias", SchoolEmail = "29023@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 8, IndexNo = 28988, FullName = "D J M K N Serasingha", Initials = "D J M K N", LastName = "Serasingha", SchoolEmail = "28988@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 9, IndexNo = 28941, FullName = "D M K S Liyanage", Initials = "D M K S", LastName = "Liyanage", SchoolEmail = "28941@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 10, IndexNo = 28926, FullName = "D M L Dasanayake", Initials = "D M L", LastName = "Dasanayake", SchoolEmail = "28926@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-05-11"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 11, IndexNo = 28963, FullName = "D N Gunasena", Initials = "D N", LastName = "Gunasena", SchoolEmail = "28963@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-16"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 12, IndexNo = 28983, FullName = "D W O D De Silva", Initials = "D W O D De", LastName = "Silva", SchoolEmail = "28983@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-14"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 13, IndexNo = 28921, FullName = "E H H Nethsara", Initials = "E H H", LastName = "Nethsara", SchoolEmail = "28921@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-05-29"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 14, IndexNo = 28896, FullName = "H A S Asmitha", Initials = "H A S", LastName = "Asmitha", SchoolEmail = "28896@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-11"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 15, IndexNo = 28911, FullName = "H L S Dulsara", Initials = "H L S", LastName = "Dulsara", SchoolEmail = "28911@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-05-16"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 16, IndexNo = 29018, FullName = "I U Roopasingha", Initials = "I U", LastName = "Roopasingha", SchoolEmail = "29018@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 17, IndexNo = 28998, FullName = "K A D Sanketh", Initials = "K A D", LastName = "Sanketh", SchoolEmail = "28998@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-17"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 18, IndexNo = 28916, FullName = "K A M Menath", Initials = "K A M", LastName = "Menath", SchoolEmail = "28916@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 19, IndexNo = 28891, FullName = "L G T S Samarasingha", Initials = "L G T S", LastName = "Samarasingha", SchoolEmail = "28891@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-14"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 20, IndexNo = 29033, FullName = "M K G Darmasiri", Initials = "M K G", LastName = "Darmasiri", SchoolEmail = "29033@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-07"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 21, IndexNo = 29038, FullName = "N H E De Silava", Initials = "N H E De", LastName = "Silava", SchoolEmail = "29038@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 22, IndexNo = 28901, FullName = "R V D R R Perera", Initials = "R V D R R", LastName = "Perera", SchoolEmail = "28901@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-05-19"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 23, IndexNo = 29008, FullName = "S A J Pathirana", Initials = "S A J", LastName = "Pathirana", SchoolEmail = "29008@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-16"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 24, IndexNo = 29003, FullName = "S H V Sanith", Initials = "S H V", LastName = "Sanith", SchoolEmail = "29003@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-20"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 25, IndexNo = 28973, FullName = "S I Kiriwandeniya", Initials = "S I", LastName = "Kiriwandeniya", SchoolEmail = "28973@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-15"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 26, IndexNo = 28931, FullName = "S L D Karunathilaka", Initials = "S L D", LastName = "Karunathilaka", SchoolEmail = "28931@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-12"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 27, IndexNo = 28958, FullName = "S O Leelarathna", Initials = "S O", LastName = "Leelarathna", SchoolEmail = "28958@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-05-31"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 28, IndexNo = 28968, FullName = "S T Ranwala", Initials = "S T", LastName = "Ranwala", SchoolEmail = "28968@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 29, IndexNo = 28978, FullName = "T D A Gunawardana", Initials = "T D A", LastName = "Gunawardana", SchoolEmail = "28978@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 30, IndexNo = 28993, FullName = "V A D Dilsara", Initials = "V A D", LastName = "Dilsara", SchoolEmail = "28993@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-05-07"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 31, IndexNo = 28906, FullName = "V K Almeda", Initials = "V K", LastName = "Almeda", SchoolEmail = "28906@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-11"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new Student { Id = 32, IndexNo = 28936, FullName = "W G T M Gamage", Initials = "W G T M", LastName = "Gamage", SchoolEmail = "28936@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) });

            modelBuilder.Entity<GradeClass>().HasData(
               new GradeClass { Id = 1, GradeId = 1, Name = Classes.A, Code = "1.A", CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) });

            modelBuilder.Entity<ClassRoom>().HasData(
               new ClassRoom { Id = 1, Year = 2021, GradeClassId = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) });

            modelBuilder.Entity<CR_Student>().HasData(
               new CR_Student { Id = 1, CR_Id = 1, StudentId = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 2, CR_Id = 1, StudentId = 2, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 3, CR_Id = 1, StudentId = 3, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 4, CR_Id = 1, StudentId = 4, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 5, CR_Id = 1, StudentId = 5, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 6, CR_Id = 1, StudentId = 6, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 7, CR_Id = 1, StudentId = 7, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 8, CR_Id = 1, StudentId = 8, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 9, CR_Id = 1, StudentId = 9, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 10, CR_Id = 1, StudentId = 10, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 11, CR_Id = 1, StudentId = 11, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 12, CR_Id = 1, StudentId = 12, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 13, CR_Id = 1, StudentId = 13, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 14, CR_Id = 1, StudentId = 14, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 15, CR_Id = 1, StudentId = 15, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 16, CR_Id = 1, StudentId = 16, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 17, CR_Id = 1, StudentId = 17, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 18, CR_Id = 1, StudentId = 18, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 19, CR_Id = 1, StudentId = 19, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 20, CR_Id = 1, StudentId = 20, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 21, CR_Id = 1, StudentId = 21, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 22, CR_Id = 1, StudentId = 22, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 23, CR_Id = 1, StudentId = 23, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 24, CR_Id = 1, StudentId = 24, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 25, CR_Id = 1, StudentId = 25, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 26, CR_Id = 1, StudentId = 26, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 27, CR_Id = 1, StudentId = 27, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 28, CR_Id = 1, StudentId = 28, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 29, CR_Id = 1, StudentId = 29, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 30, CR_Id = 1, StudentId = 30, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 31, CR_Id = 1, StudentId = 31, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new CR_Student { Id = 32, CR_Id = 1, StudentId = 32, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) });

            modelBuilder.Entity<OnlineClassRoom>().HasData(
               new OnlineClassRoom { Id = 1, Year = 2021, GradeId = 1, SubjectId = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) });

            modelBuilder.Entity<OCR_ClassRoom>().HasData(
               new OCR_ClassRoom { Id = 1, OCR_Id = 1, CR_Id = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) });

            modelBuilder.Entity<OCR_Teacher>().HasData(
               new OCR_Teacher { Id = 1, OCR_Id = 1, StaffId = 1, IsOwner = true, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) });

            modelBuilder.Entity<OnlineClass>().HasData(
               new OnlineClass { Id = 1, OCR_Id = 1, Date = new DateTime(2021, 6, 1), FromTime = new TimeSpan(17, 00, 0), ToTime = new TimeSpan(18, 30, 0), OCR_TeacherId = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new OnlineClass { Id = 2, OCR_Id = 1, Date = new DateTime(2021, 6, 3), FromTime = new TimeSpan(17, 00, 0), ToTime = new TimeSpan(18, 30, 0), OCR_TeacherId = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new OnlineClass { Id = 3, OCR_Id = 1, Date = new DateTime(2021, 6, 4), FromTime = new TimeSpan(17, 00, 0), ToTime = new TimeSpan(18, 30, 0), OCR_TeacherId = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new OnlineClass { Id = 4, OCR_Id = 1, Date = new DateTime(2021, 6, 7), FromTime = new TimeSpan(17, 00, 0), ToTime = new TimeSpan(18, 30, 0), OCR_TeacherId = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new OnlineClass { Id = 5, OCR_Id = 1, Date = new DateTime(2021, 6, 8), FromTime = new TimeSpan(17, 00, 0), ToTime = new TimeSpan(18, 30, 0), OCR_TeacherId = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new OnlineClass { Id = 6, OCR_Id = 1, Date = new DateTime(2021, 6, 10), FromTime = new TimeSpan(17, 00, 0), ToTime = new TimeSpan(18, 30, 0), OCR_TeacherId = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new OnlineClass { Id = 7, OCR_Id = 1, Date = new DateTime(2021, 6, 11), FromTime = new TimeSpan(17, 00, 0), ToTime = new TimeSpan(18, 30, 0), OCR_TeacherId = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new OnlineClass { Id = 8, OCR_Id = 1, Date = new DateTime(2021, 6, 14), FromTime = new TimeSpan(17, 00, 0), ToTime = new TimeSpan(18, 30, 0), OCR_TeacherId = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new OnlineClass { Id = 9, OCR_Id = 1, Date = new DateTime(2021, 6, 15), FromTime = new TimeSpan(17, 00, 0), ToTime = new TimeSpan(18, 30, 0), OCR_TeacherId = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new OnlineClass { Id = 10, OCR_Id = 1, Date = new DateTime(2021, 6, 17), FromTime = new TimeSpan(17, 00, 0), ToTime = new TimeSpan(18, 30, 0), OCR_TeacherId = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new OnlineClass { Id = 11, OCR_Id = 1, Date = new DateTime(2021, 6, 18), FromTime = new TimeSpan(17, 00, 0), ToTime = new TimeSpan(18, 30, 0), OCR_TeacherId = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) });

            modelBuilder.Entity<OC_Meeting>().HasData(
               new OC_Meeting { Id = 1, OC_Id = 1, MeetingCode = "MYEWAPPSOO", CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new OC_Meeting { Id = 2, OC_Id = 2, MeetingCode = "ASQWCRTUFF", CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new OC_Meeting { Id = 3, OC_Id = 3, MeetingCode = "IGIPEICFEK", CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) });

            modelBuilder.Entity<OC_MeetingAttendee>().HasData(
               new OC_MeetingAttendee { Id = 1, OC_MeetingId = 1, StudentId = 1, Duration = 5110, TimesVisited = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new OC_MeetingAttendee { Id = 2, OC_MeetingId = 2, StudentId = 11, Duration = 4879, TimesVisited = 2, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new OC_MeetingAttendee { Id = 3, OC_MeetingId = 3, StudentId = 21, Duration = 4805, TimesVisited = 4, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) });
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
