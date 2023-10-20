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
                new NearbySchool { Id = 114001, SchoolName = "De La Salle College", DisplayName = "De La Salle College", Latitude = 6.9624076530508M, Longitude = 79.8623517832771M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 114004, SchoolName = "Kumara V.", DisplayName = "Kumara V.", Latitude = 6.95182372168983M, Longitude = 79.8621572137206M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 114005, SchoolName = "Mattakkuliya St.John's M.V", DisplayName = "Mattakkuliya St.John's M.V", Latitude = 6.97180453273626M, Longitude = 79.8747070955073M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 114006, SchoolName = "St.Lucia's College", DisplayName = "St.Lucia's College", Latitude = 6.94866282745492M, Longitude = 79.8651722806743M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 114007, SchoolName = "Cathedral Boys V.", DisplayName = "Cathedral Boys V.", Latitude = 6.94965882132773M, Longitude = 79.8628181135681M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 114008, SchoolName = "Kotahen President College", DisplayName = "Kotahen President College", Latitude = 6.9539568314876M, Longitude = 79.8628940764598M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 114010, SchoolName = "Modara Sri Medhananda V.", DisplayName = "Modara Sri Medhananda V.", Latitude = 6.96386229638963M, Longitude = 79.8661038591823M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 114011, SchoolName = "St. John's V.", DisplayName = "St. John's V.", Latitude = 6.96807460444064M, Longitude = 79.8707203229669M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 114012, SchoolName = "Ave Maria V.", DisplayName = "Ave Maria V.", Latitude = 6.97046526369563M, Longitude = 79.8777616239614M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 114013, SchoolName = "Sri Sandhabodhi M.V", DisplayName = "Sri Sandhabodhi M.V", Latitude = 6.95928851871108M, Longitude = 79.875067000701M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 114014, SchoolName = "Bloemendhal Sin V.", DisplayName = "Bloemendhal Sin V.", Latitude = 6.94758922654641M, Longitude = 79.8706516488501M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 114016, SchoolName = "Gunananda V.", DisplayName = "Gunananda V.", Latitude = 6.95061590587215M, Longitude = 79.8627627408217M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 114017, SchoolName = "Mahawatta St. Anthony's Sin V.", DisplayName = "Mahawatta St. Anthony's Sin V.", Latitude = 6.96088519266493M, Longitude = 79.8721699600927M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 114021, SchoolName = "Agamethi V.", DisplayName = "Agamethi V.", Latitude = 6.95787369604128M, Longitude = 79.8682984536483M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 114022, SchoolName = "Thotawatta Methodist V.", DisplayName = "Thotawatta Methodist V.", Latitude = 6.97296440908802M, Longitude = 79.8783044922579M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 114023, SchoolName = "Sri Razik Fareed Mus.B.V", DisplayName = "Sri Razik Fareed Mus.B.V", Latitude = 6.97181212638058M, Longitude = 79.876175699137M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 114024, SchoolName = "Hamza Mus.V", DisplayName = "Hamza Mus.V", Latitude = 6.96283221937901M, Longitude = 79.8641742184885M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 114025, SchoolName = "Kalaimagal T.V", DisplayName = "Kalaimagal T.V", Latitude = 6.94789012392999M, Longitude = 79.8708483425539M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 114026, SchoolName = "Mahawatta St. Anthony's T.M.V.", DisplayName = "Mahawatta St. Anthony's T.M.V.", Latitude = 6.96084765909503M, Longitude = 79.8720793877036M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 114028, SchoolName = "Mutwal Hindu College", DisplayName = "Mutwal Hindu College", Latitude = 6.96395928948056M, Longitude = 79.8652081486035M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 114029, SchoolName = "Kotahena Methodist T.V.", DisplayName = "Kotahena Methodist T.V.", Latitude = 6.94940427037171M, Longitude = 79.8617483147323M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 114030, SchoolName = "Ananda P.V", DisplayName = "Ananda P.V", Latitude = 6.96573942090777M, Longitude = 79.8720745765604M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 115002, SchoolName = "Sri Sangaraja M.M.V.", DisplayName = "Sri Sangaraja M.M.V.", Latitude = 6.93289879900923M, Longitude = 79.8631677264176M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 115003, SchoolName = "Mahabodhi V.", DisplayName = "Mahabodhi V.", Latitude = 6.91885672009994M, Longitude = 79.8638850854589M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 115004, SchoolName = "Rajasinghe M.V", DisplayName = "Rajasinghe M.V", Latitude = 6.94143773542513M, Longitude = 79.8777827908829M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 115005, SchoolName = "Mihindu Mawatha Sin.M.V.", DisplayName = "Mihindu Mawatha Sin.M.V.", Latitude = 6.93385104871877M, Longitude = 79.8581615197802M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 115006, SchoolName = "Siri Saripuththa M.V", DisplayName = "Siri Saripuththa M.V", Latitude = 6.92094822733301M, Longitude = 79.8521389643082M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 115007, SchoolName = "Vijayaba M.V.", DisplayName = "Vijayaba M.V.", Latitude = 6.94634510785179M, Longitude = 79.8722101810619M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 115009, SchoolName = "St.Joseph's Boy's V.", DisplayName = "St.Joseph's Boy's V.", Latitude = 6.94780458943722M, Longitude = 79.8749083843293M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 116014, SchoolName = "Mahanama College", DisplayName = "Mahanama College", Latitude = 6.90620308999949M, Longitude = 79.8547672049854M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 116023, SchoolName = "St. Michael's College", DisplayName = "St. Michael's College", Latitude = 6.91384878057086M, Longitude = 79.8531340450347M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 116025, SchoolName = "St. Mary's Sin Mix.V.", DisplayName = "St. Mary's Sin Mix.V.", Latitude = 6.89479125981432M, Longitude = 79.8573468392987M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 116029, SchoolName = "Kumarauthayam T.V.", DisplayName = "Kumarauthayam T.V.", Latitude = 6.87831555443556M, Longitude = 79.8772783925747M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 116030, SchoolName = "Ramakrishna V.", DisplayName = "Ramakrishna V.", Latitude = 6.87583362021072M, Longitude = 79.8699789316635M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 116032, SchoolName = "Hindu College", DisplayName = "Hindu College", Latitude = 6.88349697834477M, Longitude = 79.8619339966584M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 116033, SchoolName = "Al Ameen V.", DisplayName = "Al Ameen V.", Latitude = 6.92258269984139M, Longitude = 79.8482175387863M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 116034, SchoolName = "St Mary's T.M.V.", DisplayName = "St Mary's T.M.V.", Latitude = 6.89464775385252M, Longitude = 79.8574150456686M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 116035, SchoolName = "Kollupitiya Methodist G.T.V", DisplayName = "Kollupitiya Methodist G.T.V", Latitude = 6.91562439494181M, Longitude = 79.8523067866256M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 116037, SchoolName = "Defence Services College", DisplayName = "Defence Services College", Latitude = 6.92647087644207M, Longitude = 79.8508302182672M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 117001, SchoolName = "Royal College", DisplayName = "Royal College", Latitude = 6.90486623339689M, Longitude = 79.8611705523619M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 117002, SchoolName = "Ananda College", DisplayName = "Ananda College", Latitude = 6.92488224479492M, Longitude = 79.8703862625047M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 117004, SchoolName = "Thurstan College", DisplayName = "Thurstan College", Latitude = 6.90374676774611M, Longitude = 79.8595843379469M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 117005, SchoolName = "St. Mattews V.", DisplayName = "St. Mattews V.", Latitude = 6.92997975397401M, Longitude = 79.877753654739M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 117008, SchoolName = "St. John College", DisplayName = "St. John College", Latitude = 6.9308515604204M, Longitude = 79.8738018045953M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 117009, SchoolName = "Seevali M.M.V.", DisplayName = "Seevali M.M.V.", Latitude = 6.92329693001139M, Longitude = 79.881352849713M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 117010, SchoolName = "Susamayawardhana M.V.", DisplayName = "Susamayawardhana M.V.", Latitude = 6.91330656245148M, Longitude = 79.876344346508M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 117012, SchoolName = "Mahinda V.", DisplayName = "Mahinda V.", Latitude = 6.92657117025952M, Longitude = 79.8729657170195M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 117016, SchoolName = "D.S.Senanayake V.", DisplayName = "D.S.Senanayake V.", Latitude = 6.90882715454139M, Longitude = 79.8751636102563M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 117018, SchoolName = "Veluwana College", DisplayName = "Veluwana College", Latitude = 6.92637548005991M, Longitude = 79.8802618229489M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 117020, SchoolName = "Asoka V.", DisplayName = "Asoka V.", Latitude = 6.92279671224949M, Longitude = 79.8673272027865M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 117021, SchoolName = "C.W.W.Kannangara V.", DisplayName = "C.W.W.Kannangara V.", Latitude = 6.91900252199834M, Longitude = 79.8771018645321M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 117023, SchoolName = "Al Hijra Mus V.", DisplayName = "Al Hijra Mus V.", Latitude = 6.92900442280817M, Longitude = 79.8750126513407M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true },
                new NearbySchool { Id = 117024, SchoolName = "Thaninayagam T.V", DisplayName = "Thaninayagam T.V", Latitude = 6.91905894900137M, Longitude = 79.8852901977569M, CreatedBy = "System", CreatedDate = new DateTime(2023, 10, 1), IsActive = true });
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
