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
        public static string ConnectionString { get; set; }

        public dbNalandaContext()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["dbSIS"].ConnectionString;
            //ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=dbSIS;Integrated Security=True;MultipleActiveResultSets=True;App=EntityFramework";
            //ConnectionString = "Data Source=nalanda-sis.database.windows.net;Initial Catalog=nalanda-sis;Persist Security Info=False;User ID=sisadmin;Password=qaTest1986;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;;MultipleActiveResultSets=True;App=EntityFramework";
            //ConnectionString = "Data Source=nalanda-sis.database.windows.net;Initial Catalog=dev-nalanda-sis;Persist Security Info=False;User ID=sisadmin;Password=qaTest1986;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;;MultipleActiveResultSets=True;App=EntityFramework";
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
            modelBuilder.Entity<SystemParameter>().HasData(new SystemParameter { Key = ParameterConstants.SchoolLocationLatitude, Value = "6.923965293049291" },
                new SystemParameter { Key = ParameterConstants.SchoolLocationLongitude, Value = "79.87495688972923" });

            modelBuilder.Entity<Section>().HasData(
                new Section { Id = 1, Code = "Primary", Description = "Primary Section", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Section { Id = 2, Code = "Junior", Description = "Junior Section", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Section { Id = 3, Code = "Senior", Description = "Senior Section", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Section { Id = 4, Code = "AL-Science", Description = "AL Science Section", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Section { Id = 5, Code = "AL-Art & Commerce", Description = "AL Art & Commerce Section", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Section { Id = 6, Code = "AL-Technology", Description = "AL Technology Section", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) });

            modelBuilder.Entity<Grade>().HasData(
                new Grade { Id = 1, SectionId = 1, GradeNo = Data.Grades.Grade1, Description = "Primary Section Grade 1", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 2, SectionId = 1, GradeNo = Data.Grades.Grade2, Description = "Primary Section Grade 2", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 3, SectionId = 1, GradeNo = Data.Grades.Grade3, Description = "Primary Section Grade 3", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 4, SectionId = 1, GradeNo = Data.Grades.Grade4, Description = "Primary Section Grade 4", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 5, SectionId = 1, GradeNo = Data.Grades.Grade5, Description = "Primary Section Grade 5", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 6, SectionId = 2, GradeNo = Data.Grades.Grade6, Description = "Junior Section Grade 6", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 7, SectionId = 2, GradeNo = Data.Grades.Grade7, Description = "Junior Section Grade 7", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 8, SectionId = 2, GradeNo = Data.Grades.Grade8, Description = "Junior Section Grade 8", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 9, SectionId = 3, GradeNo = Data.Grades.Grade9, Description = "Senior Section Grade 9", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 10, SectionId = 3, GradeNo = Data.Grades.Grade10, Description = "Senior Section Grade 10", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Grade { Id = 11, SectionId = 3, GradeNo = Data.Grades.Grade11, Description = "Senior Section Grade 11", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) });

            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, Code = "Admin", Name = "Administrator", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Role { RoleId = 2, Code = "AdminUser", Name = "Admin Department User", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Role { RoleId = 3, Code = "Parent", Name = "Parent", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) });

            modelBuilder.Entity<Menu>().HasData(
                new Menu { MenuId = 1, ParentMenuId = null, DisplaySeq = 10, Text = "Admin", Type = "M", Area = null, Controller = null, Action = null, IsHidden = false, Icon = "fas fa-user-tie" },
                new Menu { MenuId = 2, ParentMenuId = null, DisplaySeq = 20, Text = "Academic", Type = "M", Area = null, Controller = null, Action = null, IsHidden = false, Icon = "fas fa-book-reader" },
                new Menu { MenuId = 3, ParentMenuId = null, DisplaySeq = 30, Text = "Teacher", Type = "M", Area = null, Controller = null, Action = null, IsHidden = false, Icon = "fas fa-chalkboard-teacher" },
                new Menu { MenuId = 4, ParentMenuId = null, DisplaySeq = 40, Text = "Student", Type = "M", Area = null, Controller = null, Action = null, IsHidden = false, Icon = "fas fa-user-graduate" },
                new Menu { MenuId = 5, ParentMenuId = null, DisplaySeq = 50, Text = "Online", Type = "M", Area = null, Controller = null, Action = null, IsHidden = false, Icon = "fas fa-laptop-code" },
                new Menu { MenuId = 6, ParentMenuId = null, DisplaySeq = 60, Text = "Report", Type = "M", Area = null, Controller = null, Action = null, IsHidden = false, Icon = "fas fa-chart-bar" },
                new Menu { MenuId = 7, ParentMenuId = 1, DisplaySeq = 10, Text = "Sections", Type = "I", Area = "Admin", Controller = "Section", Action = "Index" },
                new Menu { MenuId = 8, ParentMenuId = 1, DisplaySeq = 20, Text = "Grades", Type = "I", Area = "Admin", Controller = "Grade", Action = "Index" },
                new Menu { MenuId = 9, ParentMenuId = 1, DisplaySeq = 30, Text = "Staff Members", Type = "I", Area = "Admin", Controller = "StaffMember", Action = "Index" },
                new Menu { MenuId = 10, ParentMenuId = 1, DisplaySeq = 40, Text = "Parents", Type = "I", Area = "Admin", Controller = "Parent", Action = "Index" },
                new Menu { MenuId = 11, ParentMenuId = 1, DisplaySeq = 50, Text = "Visitors", Type = "I", Area = "Admin", Controller = "Visitor", Action = "Index" },
                new Menu { MenuId = 12, ParentMenuId = 1, DisplaySeq = 60, Text = "Roles", Type = "I", Area = "Admin", Controller = "Role", Action = "Index" },
                new Menu { MenuId = 13, ParentMenuId = 1, DisplaySeq = 70, Text = "Users", Type = "I", Area = "Admin", Controller = "Users", Action = "Index" },
                new Menu { MenuId = 14, ParentMenuId = 1, DisplaySeq = 80, Text = "Section Heads", Type = "I", Area = "Admin", Controller = "SectionHead", Action = "Index" },
                new Menu { MenuId = 15, ParentMenuId = 1, DisplaySeq = 90, Text = "Grade Heads", Type = "I", Area = "Admin", Controller = "GradeHead", Action = "Index" },
                new Menu { MenuId = 16, ParentMenuId = 1, DisplaySeq = 100, Text = "Extra Activities", Type = "I", Area = "Admin", Controller = "ExtraActivity", Action = "Index" },
                new Menu { MenuId = 17, ParentMenuId = 2, DisplaySeq = 10, Text = "Subject Categories", Type = "I", Area = "Academic", Controller = "SubjectCategory", Action = "Index" },
                new Menu { MenuId = 18, ParentMenuId = 2, DisplaySeq = 20, Text = "Subjects", Type = "I", Area = "Academic", Controller = "Subject", Action = "Index" },
                new Menu { MenuId = 19, ParentMenuId = 2, DisplaySeq = 30, Text = "Grade Subjects", Type = "I", Area = "Academic", Controller = "GradeSubject", Action = "Index" },
                new Menu { MenuId = 20, ParentMenuId = 2, DisplaySeq = 40, Text = "Grade Classes", Type = "I", Area = "Academic", Controller = "GradeClass", Action = "Index" },
                new Menu { MenuId = 21, ParentMenuId = 2, DisplaySeq = 50, Text = "Physical Classrooms", Type = "I", Area = "Academic", Controller = "ClassRoom", Action = "Index" },
                new Menu { MenuId = 22, ParentMenuId = 3, DisplaySeq = 10, Text = "Teacher Subjects", Type = "I", Area = "Teacher", Controller = "Teacher", Action = "Index" },
                new Menu { MenuId = 23, ParentMenuId = 3, DisplaySeq = 20, Text = "Teacher Qualifications", Type = "I", Area = "Teacher", Controller = "TeacherQualification", Action = "Index" },
                new Menu { MenuId = 24, ParentMenuId = 3, DisplaySeq = 30, Text = "Teacher Off Times", Type = "I", Area = "Teacher", Controller = "TeacherOffTime", Action = "Index" },
                new Menu { MenuId = 25, ParentMenuId = 4, DisplaySeq = 10, Text = "Student Maintenance", Type = "I", Area = "Student", Controller = "Student", Action = "Index" },
                new Menu { MenuId = 26, ParentMenuId = 4, DisplaySeq = 20, Text = "Student Basket Subjects", Type = "I", Area = "Student", Controller = "BasketSubject", Action = "Index" },
                new Menu { MenuId = 27, ParentMenuId = 4, DisplaySeq = 30, Text = "Admit Student", Type = "I", Area = "Student", Controller = "StudentAdmit", Action = "Index" },
                new Menu { MenuId = 28, ParentMenuId = 4, DisplaySeq = 40, Text = "Student Marks", Type = "I", Area = "Student", Controller = "StudentMark", Action = "Index" },
                new Menu { MenuId = 29, ParentMenuId = 4, DisplaySeq = 50, Text = "Transfer Student", Type = "I", Area = "Student", Controller = "TransferStudent", Action = "Index" },
                new Menu { MenuId = 30, ParentMenuId = 4, DisplaySeq = 50, Text = "Class Promotion", Type = "I", Area = "Student", Controller = "ClassPromotion", Action = "Index" },
                new Menu { MenuId = 31, ParentMenuId = 4, DisplaySeq = 60, Text = "Student Extra Activities", Type = "I", Area = "Student", Controller = "StudentExtraActivities", Action = "Index" },
                new Menu { MenuId = 32, ParentMenuId = 5, DisplaySeq = 10, Text = "Online Classrooms", Type = "I", Area = "Online", Controller = "OnlineClassRoom", Action = "Index" },
                new Menu { MenuId = 33, ParentMenuId = 5, DisplaySeq = 20, Text = "Online Time Table", Type = "I", Area = "Online", Controller = "OnlineTimeTable", Action = "Index" },
                new Menu { MenuId = 34, ParentMenuId = 6, DisplaySeq = 10, Text = "Student Character", Type = "I", Area = "Report", Controller = "StudentCharacter", Action = "Process" },
                new Menu { MenuId = 35, ParentMenuId = 6, DisplaySeq = 20, Text = "Student Attendance", Type = "I", Area = "Report", Controller = "StudentAttendance", Action = "Process" },
                new Menu { MenuId = 36, ParentMenuId = 6, DisplaySeq = 30, Text = "Term Wise Student Marks", Type = "I", Area = "Report", Controller = "StudentMarks", Action = "Process" },
                new Menu { MenuId = 37, ParentMenuId = 6, DisplaySeq = 40, Text = "Online Sessions Summary", Type = "I", Area = "Report", Controller = "OnlineSessionsSummary", Action = "Process" },
                new Menu { MenuId = 38, ParentMenuId = 6, DisplaySeq = 50, Text = "Weekly Summary", Type = "I", Area = "Report", Controller = "WeeklySummary", Action = "Process" },
                new Menu { MenuId = 39, ParentMenuId = 1, DisplaySeq = 110, Text = "Admission Map", Type = "I", Area = "Admin", Controller = "AdmissionMap", Action = "Index" });

            modelBuilder.Entity<MenuAction>().HasData(
                new MenuAction { MenuId = 1, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 2, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 3, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 4, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 5, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 6, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 7, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 8, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 9, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 10, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 11, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 12, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 13, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 14, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 15, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 16, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 17, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 18, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 19, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 20, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 21, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 22, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 23, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 24, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 25, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 26, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 27, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 28, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 29, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 30, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 31, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 32, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 33, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 34, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 35, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 36, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 37, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 38, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 39, ActionId = 0, Text = "All" },
                new MenuAction { MenuId = 7, ActionId = 1, Text = "View" },
                new MenuAction { MenuId = 7, ActionId = 2, Text = "Create" },
                new MenuAction { MenuId = 7, ActionId = 3, Text = "Edit" },
                new MenuAction { MenuId = 7, ActionId = 4, Text = "Delete" },
                new MenuAction { MenuId = 8, ActionId = 1, Text = "View" },
                new MenuAction { MenuId = 8, ActionId = 2, Text = "Create" },
                new MenuAction { MenuId = 8, ActionId = 3, Text = "Edit" },
                new MenuAction { MenuId = 8, ActionId = 4, Text = "Delete" });

            modelBuilder.Entity<Visitor>().HasData(
                new Visitor { Id = 1, Title = TitleStaff.Mr, Gender = Gender.Male, FullName = "Rananga Lakshitha Suraweera", Initials = "R L", LastName = "Suraweera", SchoolEmail_Google = "rananga@nalandacollege.info", MobileNo = "0713522384", NicNo = "860272580V", CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) });

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, UserName = "rananga", Password = "1", Status = ActiveState.Active, VisitorId = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) });

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { UserRoleId = 1, UserId = 1, RoleId = 1 });

            modelBuilder.Entity<StaffMember>().HasData(
                new StaffMember { Id = 1, StaffNumber = 101, Title = TitleStaff.Mrs, Gender = Gender.Female, FullName = "Diana Sladen", Initials = "Diana", LastName = "Sladen", Address1 = "TestEntry", Address2 = "TestEntry", City = "Colombo", MobileNo = "0712345678", NicNo = "888888001V", SchoolEmail_Google = "dainas@nalandacollege.info", ImmeContactNo = "0712345678", ImmeContactName = "TestEntry", Status = ActiveStatus.Active, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new StaffMember { Id = 2, StaffNumber = 102, Title = TitleStaff.Mrs, Gender = Gender.Female, FullName = "Ayomi Dilhani", Initials = "Ayomi", LastName = "Dilhani", Address1 = "TestEntry", Address2 = "TestEntry", City = "Colombo", MobileNo = "0712345678", NicNo = "888888002V", SchoolEmail_Google = "ayomik@nalandacollege.info", ImmeContactNo = "0712345678", ImmeContactName = "TestEntry", Status = ActiveStatus.Active, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new StaffMember { Id = 3, StaffNumber = 103, Title = TitleStaff.Mrs, Gender = Gender.Female, FullName = "Apsara Vithan", Initials = "Apsara", LastName = "Vithan", Address1 = "TestEntry", Address2 = "TestEntry", City = "Colombo", MobileNo = "0712345678", NicNo = "888888003V", SchoolEmail_Google = "apsarae@nalandacollege.info", ImmeContactNo = "0712345678", ImmeContactName = "TestEntry", Status = ActiveStatus.Active, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new StaffMember { Id = 4, StaffNumber = 104, Title = TitleStaff.Mrs, Gender = Gender.Female, FullName = "Malsha Mallawaarachchi", Initials = "Malsha", LastName = "Mallawaarachchi", Address1 = "TestEntry", Address2 = "TestEntry", City = "Colombo", MobileNo = "0712345678", NicNo = "888888004V", SchoolEmail_Google = "malsham@nalandacollege.info", ImmeContactNo = "0712345678", ImmeContactName = "TestEntry", Status = ActiveStatus.Active, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new StaffMember { Id = 5, StaffNumber = 105, Title = TitleStaff.Mr, Gender = Gender.Male, FullName = "Gammanpila Dayananda", Initials = "Gammanpila", LastName = "Dayananda", Address1 = "TestEntry", Address2 = "TestEntry", City = "Colombo", MobileNo = "0712345678", NicNo = "888888005V", SchoolEmail_Google = "dayanandag@nalandacollege.info", ImmeContactNo = "0712345678", ImmeContactName = "TestEntry", Status = ActiveStatus.Active, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new StaffMember { Id = 6, StaffNumber = 106, Title = TitleStaff.Mrs, Gender = Gender.Female, FullName = "D.S.Chethana", Initials = "D.S.", LastName = "Chethana", Address1 = "TestEntry", Address2 = "TestEntry", City = "Colombo", MobileNo = "0712345678", NicNo = "888888006V", SchoolEmail_Google = "chethanac@nalandacollege.info", ImmeContactNo = "0712345678", ImmeContactName = "TestEntry", Status = ActiveStatus.Active, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new StaffMember { Id = 7, StaffNumber = 107, Title = TitleStaff.Mrs, Gender = Gender.Female, FullName = "Himali Nanayakkara", Initials = "Himali", LastName = "Nanayakkara", Address1 = "TestEntry", Address2 = "TestEntry", City = "Colombo", MobileNo = "0712345678", NicNo = "888888007V", SchoolEmail_Google = "himalin@nalandacollege.info", ImmeContactNo = "0712345678", ImmeContactName = "TestEntry", Status = ActiveStatus.Active, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new StaffMember { Id = 8, StaffNumber = 108, Title = TitleStaff.Mrs, Gender = Gender.Female, FullName = "Thilini Cooray", Initials = "Thilini", LastName = "Cooray", Address1 = "TestEntry", Address2 = "TestEntry", City = "Colombo", MobileNo = "0712345678", NicNo = "888888008V", SchoolEmail_Google = "thilinic@nalandacollege.info", ImmeContactNo = "0712345678", ImmeContactName = "TestEntry", Status = ActiveStatus.Active, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new StaffMember { Id = 9, StaffNumber = 109, Title = TitleStaff.Mrs, Gender = Gender.Female, FullName = "Prabha Hiroshine", Initials = "Prabha", LastName = "Hiroshine", Address1 = "TestEntry", Address2 = "TestEntry", City = "Colombo", MobileNo = "0712345678", NicNo = "888888009V", SchoolEmail_Google = "prabhah@nalandacollege.info", ImmeContactNo = "0712345678", ImmeContactName = "TestEntry", Status = ActiveStatus.Active, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new StaffMember { Id = 10, StaffNumber = 110, Title = TitleStaff.Mrs, Gender = Gender.Female, FullName = "Vijini Herath", Initials = "Vijini", LastName = "Herath", Address1 = "TestEntry", Address2 = "TestEntry", City = "Colombo", MobileNo = "0712345678", NicNo = "888888010V", SchoolEmail_Google = "vijinih@nalandacollege.info", ImmeContactNo = "0712345678", ImmeContactName = "TestEntry", Status = ActiveStatus.Active, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new StaffMember { Id = 11, StaffNumber = 111, Title = TitleStaff.Ven, Gender = Gender.Male, FullName = "බැද්දේවෙල ධම්මකිත්ති හිමි", Initials = "බැද්දේවෙල", LastName = "ධම්මකිත්ති හිමි", Address1 = "TestEntry", Address2 = "TestEntry", City = "Colombo", MobileNo = "0712345678", NicNo = "888888011V", SchoolEmail_Google = "bdhammakiththi@nalandacollege.info", ImmeContactNo = "0712345678", ImmeContactName = "TestEntry", Status = ActiveStatus.Active, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new StaffMember { Id = 12, StaffNumber = 112, Title = TitleStaff.Mr, Gender = Gender.Male, FullName = "Kalpa Udayappriya", Initials = "Kalpa", LastName = "Udayappriya", Address1 = "TestEntry", Address2 = "TestEntry", City = "Colombo", MobileNo = "0712345678", NicNo = "888888012V", SchoolEmail_Google = "kalpau@nalandacollege.info", ImmeContactNo = "0712345678", ImmeContactName = "TestEntry", Status = ActiveStatus.Active, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new StaffMember { Id = 13, StaffNumber = 113, Title = TitleStaff.Mrs, Gender = Gender.Female, FullName = "Dilani Nilanga", Initials = "Dilani", LastName = "Nilanga", Address1 = "TestEntry", Address2 = "TestEntry", City = "Colombo", MobileNo = "0712345678", NicNo = "888888013V", SchoolEmail_Google = "dilinin@nalandacollege.info", ImmeContactNo = "0712345678", ImmeContactName = "TestEntry", Status = ActiveStatus.Active, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new StaffMember { Id = 14, StaffNumber = 114, Title = TitleStaff.Ms, Gender = Gender.Female, FullName = "Dinithi Fernando", Initials = "Dinithi", LastName = "Fernando", Address1 = "TestEntry", Address2 = "TestEntry", City = "Colombo", MobileNo = "0712345678", NicNo = "888888014V", SchoolEmail_Google = "dinithif@nalandacollege.info", ImmeContactNo = "0712345678", ImmeContactName = "TestEntry", Status = ActiveStatus.Active, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) });

            modelBuilder.Entity<SubjectCategory>().HasData(
                new SubjectCategory { Id = 1, Code = "Main", IsBasket = false, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new SubjectCategory { Id = 2, Code = "Basket 1", IsBasket = true, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new SubjectCategory { Id = 3, Code = "Basket 2", IsBasket = true, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new SubjectCategory { Id = 4, Code = "Basket 3", IsBasket = true, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) });

            modelBuilder.Entity<Subject>().HasData(
                new Subject { Id = 1, Code = "බුද්ධධර්මය", SectionId = 3, SubjectCategoryId = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Subject { Id = 2, Code = "සිංහල", SectionId = 3, SubjectCategoryId = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Subject { Id = 3, Code = "English", SectionId = 3, SubjectCategoryId = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Subject { Id = 4, Code = "Mathematics", SectionId = 3, SubjectCategoryId = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Subject { Id = 5, Code = "Science", SectionId = 3, SubjectCategoryId = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Subject { Id = 6, Code = "History", SectionId = 3, SubjectCategoryId = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Subject { Id = 7, Code = "Tamil", SectionId = 3, SubjectCategoryId = 2, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Subject { Id = 8, Code = "Geography", SectionId = 3, SubjectCategoryId = 2, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Subject { Id = 9, Code = "Civic Education", SectionId = 3, SubjectCategoryId = 2, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Subject { Id = 10, Code = "Eastern Music", SectionId = 3, SubjectCategoryId = 3, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Subject { Id = 11, Code = "Drama", SectionId = 3, SubjectCategoryId = 3, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Subject { Id = 12, Code = "Western Music", SectionId = 3, SubjectCategoryId = 3, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Subject { Id = 13, Code = "PTS", SectionId = 3, SubjectCategoryId = 4, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Subject { Id = 14, Code = "Health", SectionId = 3, SubjectCategoryId = 4, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) },
                new Subject { Id = 15, Code = "ICT", SectionId = 3, SubjectCategoryId = 4, CreatedBy = "System", CreatedDate = new DateTime(2021, 1, 1) });

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, AdmissionNo = 25130, FullName = "Anuk Gunasekara", Initials = "Anuk", LastName = "Gunasekara", SchoolEmail_Google = "25130@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-17"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 2, AdmissionNo = 24695, FullName = "B.A.Inuka A. Abeysekara", Initials = "B.A.Inuka A.", LastName = "Abeysekara", SchoolEmail_Google = "24695@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 3, AdmissionNo = 24747, FullName = "B.A.Thavidu T. Wimalasena", Initials = "B.A.Thavidu T.", LastName = "Wimalasena", SchoolEmail_Google = "24747@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-15"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 4, AdmissionNo = 25445, FullName = "Bihandu A.Bethmage", Initials = "Bihandu A.", LastName = "Bethmage", SchoolEmail_Google = "25445@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 5, AdmissionNo = 24735, FullName = "Chanuka S.Wijerathna", Initials = "Chanuka S.", LastName = "Wijerathna", SchoolEmail_Google = "24735@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 6, AdmissionNo = 24701, FullName = "D.T.K.Nethun Sanketh", Initials = "D.T.K.Nethun", LastName = "Sanketh", SchoolEmail_Google = "24701@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-10"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 7, AdmissionNo = 27403, FullName = "D.W.Iran V.S.Wickramanayake", Initials = "D.W.Iran V.S.", LastName = "Wickramanayake", SchoolEmail_Google = "27403@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 8, AdmissionNo = 24750, FullName = "Dimath B Kahatapitiya", Initials = "Dimath B", LastName = "Kahatapitiya", SchoolEmail_Google = "24750@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 9, AdmissionNo = 24706, FullName = "Dulain S. Jayawardhana", Initials = "Dulain S.", LastName = "Jayawardhana", SchoolEmail_Google = "24706@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 10, AdmissionNo = 25145, FullName = "Dulina S.Gunathilake", Initials = "Dulina S.", LastName = "Gunathilake", SchoolEmail_Google = "25145@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-05-11"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 11, AdmissionNo = 24785, FullName = "G.Nuran C. Perera", Initials = "G.Nuran C.", LastName = "Perera", SchoolEmail_Google = "24785@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-16"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 12, AdmissionNo = 24685, FullName = "G.A.D.Daham C. Siriwardane", Initials = "G.A.D.Daham C.", LastName = "Siriwardane", SchoolEmail_Google = "24685@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-14"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 13, AdmissionNo = 27390, FullName = "G.P.Dimath Senhiru", Initials = "G.P.Dimath", LastName = "Senhiru", SchoolEmail_Google = "27390@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-05-29"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 14, AdmissionNo = 24786, FullName = "G.V.Himasha R Peiris", Initials = "G.V.Himasha R", LastName = "Peiris", SchoolEmail_Google = "24786@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-11"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 15, AdmissionNo = 24712, FullName = "H.A.Hirun S. Samaranayake", Initials = "H.A.Hirun S.", LastName = "Samaranayake", SchoolEmail_Google = "24712@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-05-16"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 16, AdmissionNo = 24758, FullName = "H.A.Ositha J. Wijayarathna", Initials = "H.A.Ositha J.", LastName = "Wijayarathna", SchoolEmail_Google = "24758@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 17, AdmissionNo = 27326, FullName = "H.M.Dinuka D.B.Rajaguru", Initials = "H.M.Dinuka D.B.", LastName = "Rajaguru", SchoolEmail_Google = "27326@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-17"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 18, AdmissionNo = 24972, FullName = "H.M.Thimath S. Herath", Initials = "H.M.Thimath S.", LastName = "Herath", SchoolEmail_Google = "24972@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 19, AdmissionNo = 24687, FullName = "I.A.Daniru Vinijith", Initials = "I.A.Daniru", LastName = "Vinijith", SchoolEmail_Google = "24687@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-14"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 20, AdmissionNo = 24717, FullName = "J.K.Tharul M. Perera", Initials = "J.K.Tharul M.", LastName = "Perera", SchoolEmail_Google = "24717@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-07"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 21, AdmissionNo = 24749, FullName = "J.M.M.Raadawa Jayasundara", Initials = "J.M.M.Raadawa", LastName = "Jayasundara", SchoolEmail_Google = "24749@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 22, AdmissionNo = 28051, FullName = "K.Dasindu Dulwan", Initials = "K.Dasindu", LastName = "Dulwan", SchoolEmail_Google = "28051@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-05-19"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 23, AdmissionNo = 25425, FullName = "K.Mithuru M. Perera", Initials = "K.Mithuru M.", LastName = "Perera", SchoolEmail_Google = "25425@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-16"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 24, AdmissionNo = 24755, FullName = "K.S.Vikum M. Kariyawasam", Initials = "K.S.Vikum M.", LastName = "Kariyawasam", SchoolEmail_Google = "24755@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-20"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 25, AdmissionNo = 24781, FullName = "Kuvidu H.Amarasinghe", Initials = "Kuvidu H.", LastName = "Amarasinghe", SchoolEmail_Google = "24781@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-15"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 26, AdmissionNo = 29091, FullName = "L.K.A.Y.Dissanayake", Initials = "L.K.A.Y.", LastName = "Dissanayake", SchoolEmail_Google = "29091@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-12"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 27, AdmissionNo = 24680, FullName = "Luvya V.Seelanatha", Initials = "Luvya V.", LastName = "Seelanatha", SchoolEmail_Google = "24680@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-05-31"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 28, AdmissionNo = 24746, FullName = "M.A.Chathura P. Karunasekara", Initials = "M.A.Chathura P.", LastName = "Karunasekara", SchoolEmail_Google = "24746@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 29, AdmissionNo = 27289, FullName = "M.D.Savith P. Binuditha", Initials = "M.D.Savith P.", LastName = "Binuditha", SchoolEmail_Google = "27289@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 30, AdmissionNo = 27287, FullName = "M.G.Shashen R. Bandara", Initials = "M.G.Shashen R.", LastName = "Bandara", SchoolEmail_Google = "27287@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-05-07"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 31, AdmissionNo = 28647, FullName = "Mihisara Kaveesha Hettiarachchi", Initials = "Mihisara Kaveesha", LastName = "Hettiarachchi", SchoolEmail_Google = "28647@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 32, AdmissionNo = 25039, FullName = "Minul Demith Peladagama", Initials = "Minul Demith", LastName = "Peladagama", SchoolEmail_Google = "25039@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 33, AdmissionNo = 24779, FullName = "P.M.G.Onitha O. Gunathilake", Initials = "P.M.G.Onitha O.", LastName = "Gunathilake", SchoolEmail_Google = "24779@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 34, AdmissionNo = 28052, FullName = "R.M.Thisath Dewwin Bandara", Initials = "R.M.Thisath Dewwin", LastName = "Bandara", SchoolEmail_Google = "28052@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 35, AdmissionNo = 24812, FullName = "R.G.Ravishka Sathsindu", Initials = "R.G.Ravishka", LastName = "Sathsindu", SchoolEmail_Google = "24812@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 36, AdmissionNo = 25640, FullName = "R.M.Sashmitha N. B.Kotu", Initials = "R.M.Sashmitha N. B.", LastName = "Kotu", SchoolEmail_Google = "25640@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 37, AdmissionNo = 27364, FullName = "S.M.Pavanindu N. Egodagedara", Initials = "S.M.Pavanindu N.", LastName = "Egodagedara", SchoolEmail_Google = "27364@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 38, AdmissionNo = 25032, FullName = "Sanuka N.Wanniarachchi", Initials = "Sanuka N.", LastName = "Wanniarachchi", SchoolEmail_Google = "25032@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 39, AdmissionNo = 27385, FullName = "Sanuth I.E.Liyanage", Initials = "Sanuth I.", LastName = "E.Liyanage", SchoolEmail_Google = "27385@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 40, AdmissionNo = 25656, FullName = "Seniru M.Weerasinghe", Initials = "Seniru", LastName = "M.Weerasinghe", SchoolEmail_Google = "25656@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 41, AdmissionNo = 24775, FullName = "Senuja M.Gunasekara", Initials = "Senuja M.", LastName = "Gunasekara", SchoolEmail_Google = "24775@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 42, AdmissionNo = 27327, FullName = "Sithum K.S.Rajapaksha", Initials = "Sithum K.S.", LastName = "Rajapaksha", SchoolEmail_Google = "27327@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 43, AdmissionNo = 24757, FullName = "T.Thulnith I. Vithana", Initials = "T.Thulnith I.", LastName = "Vithana", SchoolEmail_Google = "24757@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 44, AdmissionNo = 27396, FullName = "T.N.Hansaka Walpola", Initials = "T.N.Hansaka", LastName = "Walpola", SchoolEmail_Google = "27396@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 45, AdmissionNo = 24718, FullName = "Tharul B. Dharmasena", Initials = "Tharul B.", LastName = "Dharmasena", SchoolEmail_Google = "24718@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 46, AdmissionNo = 24710, FullName = "Tharusha V.Kalubowila", Initials = "Tharusha V.", LastName = "Kalubowila", SchoolEmail_Google = "24710@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 47, AdmissionNo = 24770, FullName = "The min S. Wijayawardana", Initials = "The min S.", LastName = "Wijayawardana", SchoolEmail_Google = "24770@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 48, AdmissionNo = 27347, FullName = "W.Sachintha Akalanka", Initials = "W.Sachintha", LastName = "Akalanka", SchoolEmail_Google = "27347@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 49, AdmissionNo = 24790, FullName = "W.A.Dinushka R Perera", Initials = "W.A.Dinushka R", LastName = "Perera", SchoolEmail_Google = "24790@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 50, AdmissionNo = 24754, FullName = "W.A.H.Nethru Weerasooriya", Initials = "W.A.H.Nethru", LastName = "Weerasooriya", SchoolEmail_Google = "24754@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 51, AdmissionNo = 27483, FullName = "W.A.Nushan Wijeweera", Initials = "W.A.Nushan", LastName = "Wijeweera", SchoolEmail_Google = "27483@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 52, AdmissionNo = 27482, FullName = "W.F.Tenura T. Perera", Initials = "W.F.Tenura T.", LastName = "Perera", SchoolEmail_Google = "27482@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 53, AdmissionNo = 25430, FullName = "W.M.A.Rivinaka Eragoda", Initials = "W.M.A.Rivinaka", LastName = "Eragoda", SchoolEmail_Google = "25430@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 54, AdmissionNo = 28054, FullName = "Yonal B. Galagedara", Initials = "Yonal B.", LastName = "Galagedara", SchoolEmail_Google = "28054@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
                new Student { Id = 55, AdmissionNo = 24714, FullName = "Yumeth M.Dewapura", Initials = "Yumeth M.", LastName = "Dewapura", SchoolEmail_Google = "24714@nalandacollege.info", AdmissionDate = DateTime.Parse("2021-06-18"), CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English });

            modelBuilder.Entity<GradeClass>().HasData(
               new GradeClass { Id = 1, GradeId = 1, Name = Classes.A, Code = "1.A", CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new GradeClass { Id = 2, GradeId = 1, Name = Classes.B, Code = "1.B", CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new GradeClass { Id = 3, GradeId = 1, Name = Classes.C, Code = "1.C", CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new GradeClass { Id = 4, GradeId = 1, Name = Classes.D, Code = "1.D", CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new GradeClass { Id = 5, GradeId = 9, Name = Classes.A, Code = "9.A", CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
               new GradeClass { Id = 6, GradeId = 9, Name = Classes.B, Code = "9.B", CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1), Medium = Medium.English },
               new GradeClass { Id = 7, GradeId = 9, Name = Classes.C, Code = "9.C", CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new GradeClass { Id = 8, GradeId = 9, Name = Classes.D, Code = "9.D", CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new GradeClass { Id = 9, GradeId = 9, Name = Classes.E, Code = "9.E", CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new GradeClass { Id = 10, GradeId = 9, Name = Classes.F, Code = "9.F", CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new GradeClass { Id = 11, GradeId = 9, Name = Classes.G, Code = "9.G", CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new GradeClass { Id = 12, GradeId = 9, Name = Classes.H, Code = "9.H", CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new GradeClass { Id = 13, GradeId = 9, Name = Classes.I, Code = "9.I", CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) });

            modelBuilder.Entity<PhysicalClassRoom>().HasData(
               new PhysicalClassRoom { Id = 1, Year = 2021, GradeClassId = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PhysicalClassRoom { Id = 2, Year = 2021, GradeClassId = 2, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PhysicalClassRoom { Id = 3, Year = 2021, GradeClassId = 3, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PhysicalClassRoom { Id = 4, Year = 2021, GradeClassId = 4, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PhysicalClassRoom { Id = 5, Year = 2021, GradeClassId = 5, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PhysicalClassRoom { Id = 6, Year = 2021, GradeClassId = 6, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PhysicalClassRoom { Id = 7, Year = 2021, GradeClassId = 7, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PhysicalClassRoom { Id = 8, Year = 2021, GradeClassId = 8, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PhysicalClassRoom { Id = 9, Year = 2021, GradeClassId = 9, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PhysicalClassRoom { Id = 10, Year = 2021, GradeClassId = 10, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PhysicalClassRoom { Id = 11, Year = 2021, GradeClassId = 11, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PhysicalClassRoom { Id = 12, Year = 2021, GradeClassId = 12, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PhysicalClassRoom { Id = 13, Year = 2021, GradeClassId = 13, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) });

            modelBuilder.Entity<PCR_Student>().HasData(
               new PCR_Student { Id = 1, CR_Id = 5, StudentId = 1, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 2, CR_Id = 5, StudentId = 2, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 3, CR_Id = 5, StudentId = 3, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 4, CR_Id = 5, StudentId = 4, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 5, CR_Id = 5, StudentId = 5, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 6, CR_Id = 5, StudentId = 6, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 7, CR_Id = 5, StudentId = 7, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 8, CR_Id = 5, StudentId = 8, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 9, CR_Id = 5, StudentId = 9, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 10, CR_Id = 5, StudentId = 10, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 11, CR_Id = 5, StudentId = 11, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 12, CR_Id = 5, StudentId = 12, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 13, CR_Id = 5, StudentId = 13, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 14, CR_Id = 5, StudentId = 14, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 15, CR_Id = 5, StudentId = 15, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 16, CR_Id = 5, StudentId = 16, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 17, CR_Id = 5, StudentId = 17, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 18, CR_Id = 5, StudentId = 18, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 19, CR_Id = 5, StudentId = 19, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 20, CR_Id = 5, StudentId = 20, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 21, CR_Id = 5, StudentId = 21, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 22, CR_Id = 5, StudentId = 22, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 23, CR_Id = 5, StudentId = 23, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 24, CR_Id = 5, StudentId = 24, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 25, CR_Id = 5, StudentId = 25, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 26, CR_Id = 5, StudentId = 26, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 27, CR_Id = 5, StudentId = 27, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 28, CR_Id = 5, StudentId = 28, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 29, CR_Id = 5, StudentId = 29, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 30, CR_Id = 5, StudentId = 30, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 31, CR_Id = 5, StudentId = 31, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 32, CR_Id = 5, StudentId = 32, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 33, CR_Id = 5, StudentId = 33, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 34, CR_Id = 5, StudentId = 34, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 35, CR_Id = 5, StudentId = 35, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 36, CR_Id = 5, StudentId = 36, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 37, CR_Id = 5, StudentId = 37, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 38, CR_Id = 5, StudentId = 38, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 39, CR_Id = 5, StudentId = 39, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 40, CR_Id = 5, StudentId = 40, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 41, CR_Id = 5, StudentId = 41, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 42, CR_Id = 5, StudentId = 42, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 43, CR_Id = 5, StudentId = 43, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 44, CR_Id = 5, StudentId = 44, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 45, CR_Id = 5, StudentId = 45, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 46, CR_Id = 5, StudentId = 46, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 47, CR_Id = 5, StudentId = 47, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 48, CR_Id = 5, StudentId = 48, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 49, CR_Id = 5, StudentId = 49, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 50, CR_Id = 5, StudentId = 50, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 51, CR_Id = 5, StudentId = 51, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 52, CR_Id = 5, StudentId = 52, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 53, CR_Id = 5, StudentId = 53, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 54, CR_Id = 5, StudentId = 54, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) },
               new PCR_Student { Id = 55, CR_Id = 5, StudentId = 55, CreatedBy = "System", CreatedDate = new DateTime(2021, 7, 1) });

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

            modelBuilder.Entity<GradeEmail>().HasData(
               new GradeEmail { Year = 2021, Grade = 1, EmailAddress = "grade1-2021@nalandacollege.info" },
               new GradeEmail { Year = 2021, Grade = 2, EmailAddress = "grade2-2021@nalandacollege.info" },
               new GradeEmail { Year = 2021, Grade = 3, EmailAddress = "grade3-2021@nalandacollege.info" },
               new GradeEmail { Year = 2021, Grade = 4, EmailAddress = "grade4-2021@nalandacollege.info" },
               new GradeEmail { Year = 2021, Grade = 5, EmailAddress = "grade5-2021@nalandacollege.info" },
               new GradeEmail { Year = 2021, Grade = 6, EmailAddress = "grade6-2021@nalandacollege.info" },
               new GradeEmail { Year = 2021, Grade = 7, EmailAddress = "grade7-2021@nalandacollege.info" },
               new GradeEmail { Year = 2021, Grade = 8, EmailAddress = "grade8-2021@nalandacollege.info" },
               new GradeEmail { Year = 2021, Grade = 9, EmailAddress = "grade9-2021@nalandacollege.info" },
               new GradeEmail { Year = 2021, Grade = 10, EmailAddress = "grade10-2021@nalandacollege.info" },
               new GradeEmail { Year = 2021, Grade = 11, EmailAddress = "grade11-2021@nalandacollege.info" });

            modelBuilder.Entity<NearbySchool>().HasData(
                new NearbySchool { Id = 1, SchoolName = "St.John's Maha Vidyalaya", DisplayName = "St.John's Maha Vidyalaya", Latitude = 6.970070197201281M, Longitude = 79.8745095110652M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 2, SchoolName = "St Mari's Vidyalaya", DisplayName = "St Mari's Vidyalaya", Latitude = 6.970996110086345M, Longitude = 79.87772173138907M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 3, SchoolName = "Thotawatta Methodist Vidyalaya", DisplayName = "Thotawatta Methodist Vidyalaya", Latitude = 6.9729644090880205M, Longitude = 79.8783044922579M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 4, SchoolName = "Thelagapata Sri Rathnapala Maha Vidyalaya", DisplayName = "Thelagapata Sri Rathnapala Maha Vidyalaya", Latitude = 6.975418335900986M, Longitude = 79.89036243888029M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 5, SchoolName = "D B Jayathilaka Vidyalaya", DisplayName = "D B Jayathilaka Vidyalaya", Latitude = 6.935708669009438M, Longitude = 79.86783863533545M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 6, SchoolName = "Sri Sudharshana Dharma Vidyalaya", DisplayName = "Sri Sudharshana Dharma Vidyalaya", Latitude = 6.965945142596526M, Longitude = 79.90746794925046M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 7, SchoolName = "Wedamulla Vidyalaya", DisplayName = "Wedamulla Vidyalaya", Latitude = 6.966213118422979M, Longitude = 79.90200527155879M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 8, SchoolName = "Sri Dharmaloka College", DisplayName = "Sri Dharmaloka College", Latitude = 6.961453483489864M, Longitude = 79.90132225634902M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 9, SchoolName = "Dutugemunu Maha Vidyalaya", DisplayName = "Dutugemunu Maha Vidyalaya", Latitude = 6.96654055161512M, Longitude = 79.88697528702862M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 10, SchoolName = "St.John's Maha Vidyalaya", DisplayName = "St.John's Maha Vidyalaya", Latitude = 6.968101018852353M, Longitude = 79.87069172524153M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 11, SchoolName = "Modara Ananda Madya Maha Vidyalaya", DisplayName = "Modara Ananda Madya Maha Vidyalaya", Latitude = 6.965768502859825M, Longitude = 79.87207975955133M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 12, SchoolName = "St.Anthony's Vidyalaya", DisplayName = "St.Anthony's Vidyalaya", Latitude = 6.960883129224072M, Longitude = 79.87207749254094M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 13, SchoolName = "Sri Sandhabodhi Maha Vidyalaya", DisplayName = "Sri Sandhabodhi Maha Vidyalaya", Latitude = 6.9592885187110864M, Longitude = 79.87506700070102M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 14, SchoolName = "Sri Medhananda Vidyalaya", DisplayName = "Sri Medhananda Vidyalaya", Latitude = 6.963862296389635M, Longitude = 79.86610385918239M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 15, SchoolName = "Hindu College", DisplayName = "Hindu College", Latitude = 6.963997327415411M, Longitude = 79.86520583306206M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 16, SchoolName = "Hamza Muslin Maha Vidyalaya", DisplayName = "Hamza Muslin Maha Vidyalaya", Latitude = 6.962832219379015M, Longitude = 79.86417421848853M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 17, SchoolName = "De La Salle College", DisplayName = "De La Salle College", Latitude = 6.9624076530508M, Longitude = 79.86235178327715M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 18, SchoolName = "St.Andrew's Vidyalaya", DisplayName = "St.Andrew's Vidyalaya", Latitude = 6.958567947391003M, Longitude = 79.86098766096825M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 19, SchoolName = "Kumara Vidyalaya", DisplayName = "Kumara Vidyalaya", Latitude = 6.951823721689836M, Longitude = 79.8621572137206M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 20, SchoolName = "Sri Gunananda Vidyalaya", DisplayName = "Sri Gunananda Vidyalaya", Latitude = 6.9506159058721515M, Longitude = 79.86276274082178M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 21, SchoolName = "Agamethi Vidyalaya", DisplayName = "Agamethi Vidyalaya", Latitude = 6.957873696041287M, Longitude = 79.86829845364839M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 22, SchoolName = "H K Dharmadasa Vidyalaya", DisplayName = "H K Dharmadasa Vidyalaya", Latitude = 6.95764088028663M, Longitude = 79.8872196819606M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 23, SchoolName = "Gurukula Vidyalaya", DisplayName = "Gurukula Vidyalaya", Latitude = 6.958624135826215M, Longitude = 79.89425358054602M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 24, SchoolName = "Gamini Vidyalaya", DisplayName = "Gamini Vidyalaya", Latitude = 6.95332315925607M, Longitude = 79.89071932510947M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 25, SchoolName = "Roman Catholic Primary School", DisplayName = "Roman Catholic Primary School", Latitude = 6.95723231827066M, Longitude = 79.89715079759593M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 26, SchoolName = "Sri Dharmaloka Collage (Primary)", DisplayName = "Sri Dharmaloka Collage (Primary)", Latitude = 6.959448253089006M, Longitude = 79.90195320295699M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 27, SchoolName = "Sri Sambodhi Kanishta Vidyalaya", DisplayName = "Sri Sambodhi Kanishta Vidyalaya", Latitude = 6.95335967738376M, Longitude = 79.90194838627318M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 28, SchoolName = "President College", DisplayName = "President College", Latitude = 6.951652448136115M, Longitude = 79.90983446258785M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 29, SchoolName = "Kelani Maha Vidyalaya", DisplayName = "Kelani Maha Vidyalaya", Latitude = 6.949722906949908M, Longitude = 79.91891244566027M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 30, SchoolName = "Tibet S.Mahinda Vidyalaya", DisplayName = "Tibet S.Mahinda Vidyalaya", Latitude = 6.947154953888367M, Longitude = 79.90661069938744M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 31, SchoolName = "Siddhartha Central College (Primary)", DisplayName = "Siddhartha Central College (Primary)", Latitude = 6.945534444370153M, Longitude = 79.8982696683254M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 32, SchoolName = "Siddhartha Central College", DisplayName = "Siddhartha Central College", Latitude = 6.943219718262826M, Longitude = 79.89876277738948M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 33, SchoolName = "Weragoda Kanishta Vidyalaya", DisplayName = "Weragoda Kanishta Vidyalaya", Latitude = 6.948573679465975M, Longitude = 79.88542125304508M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 34, SchoolName = "St.Joseph's College", DisplayName = "St.Joseph's College", Latitude = 6.947776156965983M, Longitude = 79.8749058986322M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 35, SchoolName = "Al-Naser Maha Vidyalaya", DisplayName = "Al-Naser Maha Vidyalaya", Latitude = 6.948151208413165M, Longitude = 79.871952384379M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 36, SchoolName = "Wijayaba Maha Vidyalaya", DisplayName = "Wijayaba Maha Vidyalaya", Latitude = 6.946377523115497M, Longitude = 79.8722112665752M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 37, SchoolName = "Jayanthi Vidyalaya", DisplayName = "Jayanthi Vidyalaya", Latitude = 6.944375233274231M, Longitude = 79.8727762981936M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 38, SchoolName = "Bloenedhal Tamil Vidyalaya", DisplayName = "Bloenedhal Tamil Vidyalaya", Latitude = 6.947589226546415M, Longitude = 79.87065164885018M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 39, SchoolName = "St.Lucia's College", DisplayName = "St.Lucia's College", Latitude = 6.948662827454927M, Longitude = 79.86517228067437M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 40, SchoolName = "St.Benedict's College", DisplayName = "St.Benedict's College", Latitude = 6.948743114659192M, Longitude = 79.86419775479663M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 41, SchoolName = "Cathedral Boys College", DisplayName = "Cathedral Boys College", Latitude = 6.949658821327737M, Longitude = 79.86281811356818M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 42, SchoolName = "Kotahena Muslim Vidyalaya", DisplayName = "Kotahena Muslim Vidyalaya", Latitude = 6.944239982000094M, Longitude = 79.86209404888034M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 43, SchoolName = "Kotahena Central College", DisplayName = "Kotahena Central College", Latitude = 6.94323786828517M, Longitude = 79.86222182205587M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 44, SchoolName = "Vivekananda Vidyalaya", DisplayName = "Vivekananda Vidyalaya", Latitude = 6.943060658410507M, Longitude = 79.86004652449823M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 45, SchoolName = "St.Anthony's Boys Maha Vidyalaya", DisplayName = "St.Anthony's Boys Maha Vidyalaya", Latitude = 6.944504766562148M, Longitude = 79.85738187524329M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 46, SchoolName = "A.E.Gunasingha Vidyalaya", DisplayName = "A.E.Gunasingha Vidyalaya", Latitude = 6.9375480052614265M, Longitude = 79.85759645463634M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 47, SchoolName = "Al-Hikma College", DisplayName = "Al-Hikma College", Latitude = 6.936108466321763M, Longitude = 79.85794583295763M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 48, SchoolName = "Mihindu Mawatha Maha Vidyalaya", DisplayName = "Mihindu Mawatha Maha Vidyalaya", Latitude = 6.93385104871877M, Longitude = 79.8581615197802M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 49, SchoolName = "Hameed Al Husein College", DisplayName = "Hameed Al Husein College", Latitude = 6.94129888071402M, Longitude = 79.86007165126638M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 50, SchoolName = "Kotahena Sinhala Junior School", DisplayName = "Kotahena Sinhala Junior School", Latitude = 6.943052631481036M, Longitude = 79.86370019470739M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 51, SchoolName = "Al Hakeem Vidyalaya", DisplayName = "Al Hakeem Vidyalaya", Latitude = 6.936699706703718M, Longitude = 79.86170277240286M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 52, SchoolName = "St.Sebastian Muslim Maha Vidyalaya", DisplayName = "St.Sebastian Muslim Maha Vidyalaya", Latitude = 6.936101106105699M, Longitude = 79.8625641830186M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 53, SchoolName = "Al Hidhaya Muslim Vidyalaya ", DisplayName = "Al Hidhaya Muslim Vidyalaya ", Latitude = 6.932774164994967M, Longitude = 79.86379092517672M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 54, SchoolName = "Sri Baron Jayathilaka Vidyalaya", DisplayName = "Sri Baron Jayathilaka Vidyalaya", Latitude = 6.935803868179595M, Longitude = 79.86785467477044M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 55, SchoolName = "Dharussalaam Maha Vidyalaya", DisplayName = "Dharussalaam Maha Vidyalaya", Latitude = 6.937613004027705M, Longitude = 79.87151008940867M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 56, SchoolName = "Rajasinghe Maha Vidyalaya", DisplayName = "Rajasinghe Maha Vidyalaya", Latitude = 6.941437735425139M, Longitude = 79.87778279088295M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 57, SchoolName = "Meethotamulla Sri Rahula Vidyalaya", DisplayName = "Meethotamulla Sri Rahula Vidyalaya", Latitude = 6.9378556312174045M, Longitude = 79.88858969270504M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 58, SchoolName = "Vidyawardana Maha Vidyalaya", DisplayName = "Vidyawardana Maha Vidyalaya", Latitude = 6.935464783320471M, Longitude = 79.8949328872852M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 59, SchoolName = "Dharmapala Vidyalaya", DisplayName = "Dharmapala Vidyalaya", Latitude = 6.937751687582452M, Longitude = 79.91649601381296M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 60, SchoolName = "Sri Rajasinghe Maha Vidyalaya", DisplayName = "Sri Rajasinghe Maha Vidyalaya", Latitude = 6.936372432067953M, Longitude = 79.92023088905958M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 61, SchoolName = "Sri Rahula Maha Vidyalaya", DisplayName = "Sri Rahula Maha Vidyalaya", Latitude = 6.928867203737568M, Longitude = 79.92710280656395M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 62, SchoolName = "Gothatuwa Maha Vidyalaya", DisplayName = "Gothatuwa Maha Vidyalaya", Latitude = 6.927981013968253M, Longitude = 79.90772971766943M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 63, SchoolName = "Henry Olcott Maha Vidyalaya", DisplayName = "Henry Olcott Maha Vidyalaya", Latitude = 6.925508065791465M, Longitude = 79.89630849496197M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 64, SchoolName = "St.Joseph's College", DisplayName = "St.Joseph's College", Latitude = 6.93169325637771M, Longitude = 79.8921703018387M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 65, SchoolName = "Terrence N De Silva Maha Vidyalaya", DisplayName = "Terrence N De Silva Maha Vidyalaya", Latitude = 6.933373915322716M, Longitude = 79.8890256563571M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 66, SchoolName = "Vipulanantha Tamil Maha Vidyalaya", DisplayName = "Vipulanantha Tamil Maha Vidyalaya", Latitude = 6.929163693965849M, Longitude = 79.88104173449108M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 67, SchoolName = "Veluwana Vidyalaya", DisplayName = "Veluwana Vidyalaya", Latitude = 6.926375480059915M, Longitude = 79.8802618229489M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 68, SchoolName = "Mathew Maha Vidyalaya", DisplayName = "Mathew Maha Vidyalaya", Latitude = 6.929977310592843M, Longitude = 79.87775320474M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 69, SchoolName = "St.John's College", DisplayName = "St.John's College", Latitude = 6.930851560420409M, Longitude = 79.87380180459533M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 70, SchoolName = "Al Hijra Muslim Vidyalaya", DisplayName = "Al Hijra Muslim Vidyalaya", Latitude = 6.929004422808176M, Longitude = 79.87501265134071M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 71, SchoolName = "Mahinda Vidyalaya", DisplayName = "Mahinda Vidyalaya", Latitude = 6.926571170259525M, Longitude = 79.87296571701955M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 72, SchoolName = "Zahira College", DisplayName = "Zahira College", Latitude = 6.927527581766879M, Longitude = 79.86471054736508M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 73, SchoolName = "Sri Sangaraja Central College", DisplayName = "Sri Sangaraja Central College", Latitude = 6.932898799009237M, Longitude = 79.86316772641766M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 74, SchoolName = "Thondar Vidyalaya", DisplayName = "Thondar Vidyalaya", Latitude = 6.930748366242011M, Longitude = 79.85744966954965M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 75, SchoolName = "Defence Services College", DisplayName = "Defence Services College", Latitude = 6.92647087644207M, Longitude = 79.85083021826722M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 76, SchoolName = "T.B.Jayah Zahira Vidyalaya", DisplayName = "T.B.Jayah Zahira Vidyalaya", Latitude = 6.92249149211648M, Longitude = 79.85246621557661M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 77, SchoolName = "Siri Sariputhra Maha Vidyalaya", DisplayName = "Siri Sariputhra Maha Vidyalaya", Latitude = 6.920948227333019M, Longitude = 79.85213896430824M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 78, SchoolName = "Al-Iqbal Maha Vidyalaya", DisplayName = "Al-Iqbal Maha Vidyalaya", Latitude = 6.921233920572449M, Longitude = 79.8527742646261M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 79, SchoolName = "Mahabodhi Vidyalaya", DisplayName = "Mahabodhi Vidyalaya", Latitude = 6.918856720099941M, Longitude = 79.86388508545895M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 80, SchoolName = "Asoka Vidyalaya", DisplayName = "Asoka Vidyalaya", Latitude = 6.922796712249498M, Longitude = 79.8673272027865M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 81, SchoolName = "Ananda College", DisplayName = "Ananda College", Latitude = 6.924882244794921M, Longitude = 79.87038626250474M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 82, SchoolName = "Nalanda College", DisplayName = "Nalanda College", Latitude = 6.923494037662476M, Longitude = 79.87512466605946M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = false },
                new NearbySchool { Id = 83, SchoolName = "C.W.W.Kannangara Vidyalaya", DisplayName = "C.W.W.Kannangara Vidyalaya", Latitude = 6.919002521998347M, Longitude = 79.87710186453214M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 84, SchoolName = "Wesley College", DisplayName = "Wesley College", Latitude = 6.922596455691681M, Longitude = 79.87716627128238M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = false },
                new NearbySchool { Id = 85, SchoolName = "Seevali Maha Vidyalaya", DisplayName = "Seevali Maha Vidyalaya", Latitude = 6.923296930011396M, Longitude = 79.88135284971304M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 86, SchoolName = "Sobhitha Vidyalaya", DisplayName = "Sobhitha Vidyalaya", Latitude = 6.920253360880668M, Longitude = 79.89445456471695M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 87, SchoolName = "Sri Panghadasa Damma School", DisplayName = "Sri Panghadasa Damma School", Latitude = 6.919882555044265M, Longitude = 79.90923215848815M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 88, SchoolName = "St.Anthony's International School", DisplayName = "St.Anthony's International School", Latitude = 6.920417538036354M, Longitude = 79.92660316754498M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 89, SchoolName = "M.D.H.Jayawardhana Primary Vidyalaya", DisplayName = "M.D.H.Jayawardhana Primary Vidyalaya", Latitude = 6.912963509167469M, Longitude = 79.92905204667927M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 90, SchoolName = "Sri Siddhartha Maha Vidyalaya", DisplayName = "Sri Siddhartha Maha Vidyalaya", Latitude = 6.915376081207031M, Longitude = 79.9171059908843M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 91, SchoolName = "Hewavitharana Maha Vidyalaya", DisplayName = "Hewavitharana Maha Vidyalaya", Latitude = 6.912136263159198M, Longitude = 79.89381105669428M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 92, SchoolName = "Roman Catholic Tamil Vidyalaya", DisplayName = "Roman Catholic Tamil Vidyalaya", Latitude = 6.910406302464903M, Longitude = 79.89457850889177M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 93, SchoolName = "Siri Perakumba Maha Vidyalaya", DisplayName = "Siri Perakumba Maha Vidyalaya", Latitude = 6.913791496685488M, Longitude = 79.890197802535M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 94, SchoolName = "S.W.R.D.Bandaranayake Vidyalaya", DisplayName = "S.W.R.D.Bandaranayake Vidyalaya", Latitude = 6.911740983732433M, Longitude = 79.887191486747M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 95, SchoolName = "Susamayawardhana Maha Vidyalaya", DisplayName = "Susamayawardhana Maha Vidyalaya", Latitude = 6.913306562451488M, Longitude = 79.87634434650809M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 96, SchoolName = "St.Michael's College", DisplayName = "St.Michael's College", Latitude = 6.913848780570867M, Longitude = 79.85313404503479M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 97, SchoolName = "Mahanama Maha Vidyalaya", DisplayName = "Mahanama Maha Vidyalaya", Latitude = 6.906203089999496M, Longitude = 79.85476720498549M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 98, SchoolName = "Thurstan College", DisplayName = "Thurstan College", Latitude = 6.903746767746111M, Longitude = 79.85958433794691M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 99, SchoolName = "Royal College", DisplayName = "Royal College", Latitude = 6.904866233396896M, Longitude = 79.86117055236195M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 100, SchoolName = "D.S.Senanayake Vidyalaya", DisplayName = "D.S.Senanayake Vidyalaya", Latitude = 6.908827154541392M, Longitude = 79.87516361025631M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 101, SchoolName = "President's College", DisplayName = "President's College", Latitude = 6.907579658886732M, Longitude = 79.89388744354783M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 102, SchoolName = "Lanka Sabha Junior School", DisplayName = "Lanka Sabha Junior School", Latitude = 6.9045405929125065M, Longitude = 79.92387782365833M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 103, SchoolName = "Sri Subuthi National School", DisplayName = "Sri Subuthi National School", Latitude = 6.903308436646462M, Longitude = 79.92382764572193M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 104, SchoolName = "Willsedeh International School", DisplayName = "Willsedeh International School", Latitude = 6.904876532115713M, Longitude = 79.92488745766865M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 105, SchoolName = "Sri Indrajothi Vidyalaya", DisplayName = "Sri Indrajothi Vidyalaya", Latitude = 6.900673518034033M, Longitude = 79.92087310065347M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 106, SchoolName = "Sri Jayawardhanapura Maha Vidyalaya", DisplayName = "Sri Jayawardhanapura Maha Vidyalaya", Latitude = 6.893071017213769M, Longitude = 79.90003397060896M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 107, SchoolName = "Sri Parakrama Maha Vidyalaya", DisplayName = "Sri Parakrama Maha Vidyalaya", Latitude = 6.895106524624598M, Longitude = 79.8773837704163M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 108, SchoolName = "St.Mary's Maha Vidyalaya", DisplayName = "St.Mary's Maha Vidyalaya", Latitude = 6.894647732486573M, Longitude = 79.85741726608045M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 109, SchoolName = "Wellawatta Maha Vidyalaya", DisplayName = "Wellawatta Maha Vidyalaya", Latitude = 6.880374519258141M, Longitude = 79.86801498855152M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 110, SchoolName = "Widyathilake Vidyalaya", DisplayName = "Widyathilake Vidyalaya", Latitude = 6.891477390475086M, Longitude = 79.86662266033268M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 111, SchoolName = "Lumbini Vidyalaya", DisplayName = "Lumbini Vidyalaya", Latitude = 6.884080067154313M, Longitude = 79.8664916653287M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 112, SchoolName = "Isipathana Vidyalaya", DisplayName = "Isipathana Vidyalaya", Latitude = 6.887722568049907M, Longitude = 79.8690490200904M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 113, SchoolName = "Dudley Senanayak Vidyalaya", DisplayName = "Dudley Senanayak Vidyalaya", Latitude = 6.8906780904646325M, Longitude = 79.87259317171045M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 114, SchoolName = "Mahamathya Vidyalaya", DisplayName = "Mahamathya Vidyalaya", Latitude = 6.885904095135547M, Longitude = 79.87665911423484M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 115, SchoolName = "Ananda Shastralaya", DisplayName = "Ananda Shastralaya", Latitude = 6.883183978934333M, Longitude = 79.9028730935093M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 116, SchoolName = "St.Thomas College", DisplayName = "St.Thomas College", Latitude = 6.881596226926195M, Longitude = 79.90155721818898M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 117, SchoolName = "Sri Saddharmodaya Maha Vidyalaya", DisplayName = "Sri Saddharmodaya Maha Vidyalaya", Latitude = 6.877242509721396M, Longitude = 79.88348932146513M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 118, SchoolName = "Kumarauthayam Tamil Vidyalaya", DisplayName = "Kumarauthayam Tamil Vidyalaya", Latitude = 6.87831555443556M, Longitude = 79.87727839257478M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 119, SchoolName = "Arethusa Vidyalaya", DisplayName = "Arethusa Vidyalaya", Latitude = 6.874382114641902M, Longitude = 79.86831708528M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 120, SchoolName = "Ramakrishna Vidylaya", DisplayName = "Ramakrishna Vidylaya", Latitude = 6.875833620210724M, Longitude = 79.86997893166355M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true });
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
