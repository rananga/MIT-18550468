
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/25/2021 00:15:03
-- Generated from EDMX file: D:\Projects\Student Management - NalandaCollege\SchoolManagementSystem\Common\DB\dbSMS.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [dbSMS];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MenuMenu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Menus] DROP CONSTRAINT [FK_MenuMenu];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleRoleTiles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleTiles] DROP CONSTRAINT [FK_RoleRoleTiles];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleUserRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [FK_RoleUserRole];
GO
IF OBJECT_ID(N'[dbo].[FK_UserUserRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[UserRoles] DROP CONSTRAINT [FK_UserUserRole];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleMenuAccesses_Menus]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleMenuAccesses] DROP CONSTRAINT [FK_RoleMenuAccesses_Menus];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleMenuAccesses_Roles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RoleMenuAccesses] DROP CONSTRAINT [FK_RoleMenuAccesses_Roles];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentStudSubling]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudSublings] DROP CONSTRAINT [FK_StudentStudSubling];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentStudSubling1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudSublings] DROP CONSTRAINT [FK_StudentStudSubling1];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentStudFamily]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[StudFamilies] DROP CONSTRAINT [FK_StudentStudFamily];
GO
IF OBJECT_ID(N'[dbo].[FK_ClassClassTeacher]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClassTeachers] DROP CONSTRAINT [FK_ClassClassTeacher];
GO
IF OBJECT_ID(N'[dbo].[FK_PeriodSetupClassTeacher]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClassTeachers] DROP CONSTRAINT [FK_PeriodSetupClassTeacher];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentClassStudent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClassStudents] DROP CONSTRAINT [FK_StudentClassStudent];
GO
IF OBJECT_ID(N'[dbo].[FK_TeacherClassTeacher]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClassTeachers] DROP CONSTRAINT [FK_TeacherClassTeacher];
GO
IF OBJECT_ID(N'[dbo].[FK_ClubClubMember]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClubMembers] DROP CONSTRAINT [FK_ClubClubMember];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentClubMember]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClubMembers] DROP CONSTRAINT [FK_StudentClubMember];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentEventParticipation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventParticipations] DROP CONSTRAINT [FK_StudentEventParticipation];
GO
IF OBJECT_ID(N'[dbo].[FK_TeacherEventParticipation]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventParticipations] DROP CONSTRAINT [FK_TeacherEventParticipation];
GO
IF OBJECT_ID(N'[dbo].[FK_ClassPromotionClass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PromotionClasses] DROP CONSTRAINT [FK_ClassPromotionClass];
GO
IF OBJECT_ID(N'[dbo].[FK_PeriodSetupPromotionClass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PromotionClasses] DROP CONSTRAINT [FK_PeriodSetupPromotionClass];
GO
IF OBJECT_ID(N'[dbo].[FK_PromotionClassClassStudent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ClassStudents] DROP CONSTRAINT [FK_PromotionClassClassStudent];
GO
IF OBJECT_ID(N'[dbo].[FK_TeacherPromotionClass]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PromotionClasses] DROP CONSTRAINT [FK_TeacherPromotionClass];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentPrefect]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Prefects] DROP CONSTRAINT [FK_StudentPrefect];
GO
IF OBJECT_ID(N'[dbo].[FK_PromotionClassPrefect]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Prefects] DROP CONSTRAINT [FK_PromotionClassPrefect];
GO
IF OBJECT_ID(N'[dbo].[FK_StudentLeavingCertificate]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LeavingCertificates] DROP CONSTRAINT [FK_StudentLeavingCertificate];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Menus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Menus];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[RoleTiles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleTiles];
GO
IF OBJECT_ID(N'[dbo].[UserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserRoles];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Students]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Students];
GO
IF OBJECT_ID(N'[dbo].[StudSublings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudSublings];
GO
IF OBJECT_ID(N'[dbo].[StudFamilies]', 'U') IS NOT NULL
    DROP TABLE [dbo].[StudFamilies];
GO
IF OBJECT_ID(N'[dbo].[Classes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Classes];
GO
IF OBJECT_ID(N'[dbo].[ClassTeachers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClassTeachers];
GO
IF OBJECT_ID(N'[dbo].[ClassStudents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClassStudents];
GO
IF OBJECT_ID(N'[dbo].[PeriodSetups]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PeriodSetups];
GO
IF OBJECT_ID(N'[dbo].[Teachers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Teachers];
GO
IF OBJECT_ID(N'[dbo].[ClubMembers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClubMembers];
GO
IF OBJECT_ID(N'[dbo].[Clubs]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clubs];
GO
IF OBJECT_ID(N'[dbo].[EventParticipations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventParticipations];
GO
IF OBJECT_ID(N'[dbo].[PromotionClasses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PromotionClasses];
GO
IF OBJECT_ID(N'[dbo].[Prefects]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Prefects];
GO
IF OBJECT_ID(N'[dbo].[LeavingCertificates]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LeavingCertificates];
GO
IF OBJECT_ID(N'[dbo].[RoleMenuAccesses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleMenuAccesses];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Menus'
CREATE TABLE [dbo].[Menus] (
    [MenuID] int IDENTITY(1,1) NOT NULL,
    [ParentMenuID] int  NULL,
    [DisplaySeq] int  NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Area] nvarchar(max)  NULL,
    [Controller] nvarchar(max)  NULL,
    [Action] nvarchar(max)  NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [RoleID] int IDENTITY(1,1) NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedBy] nvarchar(max)  NULL,
    [ModifiedDate] datetime  NULL,
    [RowVersion] binary(8)  NOT NULL
);
GO

-- Creating table 'RoleTiles'
CREATE TABLE [dbo].[RoleTiles] (
    [RoleTileID] int IDENTITY(1,1) NOT NULL,
    [TileID] int  NOT NULL,
    [RoleID] int  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedBy] nvarchar(max)  NULL,
    [ModifiedDate] datetime  NULL,
    [RowVersion] binary(8)  NOT NULL
);
GO

-- Creating table 'UserRoles'
CREATE TABLE [dbo].[UserRoles] (
    [UserRoleID] int IDENTITY(1,1) NOT NULL,
    [UserID] int  NOT NULL,
    [RoleID] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [UserID] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL,
    [EmployeeID] int  NULL,
    [NavUserName] nvarchar(max)  NULL,
    [CallCenterUserName] nvarchar(max)  NULL,
    [Status] int  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedBy] nvarchar(max)  NULL,
    [ModifiedDate] datetime  NULL,
    [RowVersion] binary(8)  NOT NULL
);
GO

-- Creating table 'Students'
CREATE TABLE [dbo].[Students] (
    [StudID] int IDENTITY(1,1) NOT NULL,
    [IndexNo] int  NOT NULL,
    [Title] int  NOT NULL,
    [Gender] int  NOT NULL,
    [FullName] nvarchar(max)  NOT NULL,
    [Initials] nvarchar(max)  NOT NULL,
    [LName] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [School] nvarchar(max)  NOT NULL,
    [SchoolAddress] nvarchar(max)  NULL,
    [LastDhammaSchool] nvarchar(max)  NULL,
    [LDhammaSchoolAdd] nvarchar(max)  NULL,
    [EngSpeaking] int  NOT NULL,
    [EngWriting] int  NOT NULL,
    [EngReading] int  NOT NULL,
    [EmergencyConName] nvarchar(max)  NOT NULL,
    [EmergencyContactTel] nvarchar(max)  NOT NULL,
    [SpecialAttention] nvarchar(max)  NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedBy] nvarchar(max)  NULL,
    [ModifiedDate] datetime  NULL,
    [RowVersion] binary(8)  NOT NULL,
    [ImagePath] nvarchar(max)  NULL,
    [DOB] datetime  NULL,
    [LastDhammaGrade] nvarchar(max)  NULL,
    [Status] int  NOT NULL,
    [InactiveReason] nvarchar(max)  NULL,
    [IsLeavingIssued] bit  NOT NULL
);
GO

-- Creating table 'StudSublings'
CREATE TABLE [dbo].[StudSublings] (
    [SubID] int IDENTITY(1,1) NOT NULL,
    [SudID] int  NOT NULL,
    [SublingStudID] int  NOT NULL,
    [Relationship] int  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedBy] nvarchar(max)  NULL,
    [ModifiedDate] datetime  NULL,
    [RowVersion] binary(8)  NOT NULL
);
GO

-- Creating table 'StudFamilies'
CREATE TABLE [dbo].[StudFamilies] (
    [StudFID] int IDENTITY(1,1) NOT NULL,
    [StudID] int  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Relationship] int  NOT NULL,
    [Occupation] nvarchar(max)  NOT NULL,
    [WorkingAdd] nvarchar(max)  NOT NULL,
    [OfficeTel] nvarchar(max)  NULL,
    [ContactMob] nvarchar(max)  NOT NULL,
    [ContactHome] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NULL,
    [NICNo] nvarchar(max)  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedBy] nvarchar(max)  NULL,
    [ModifiedDate] datetime  NULL,
    [RowVersion] binary(8)  NOT NULL,
    [Title] int  NOT NULL
);
GO

-- Creating table 'Classes'
CREATE TABLE [dbo].[Classes] (
    [ClassID] int IDENTITY(1,1) NOT NULL,
    [Grade] int  NOT NULL,
    [ClassDesc] nvarchar(max)  NOT NULL,
    [Status] int  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedBy] nvarchar(max)  NULL,
    [ModifiedDate] datetime  NULL,
    [RowVersion] binary(8)  NOT NULL
);
GO

-- Creating table 'ClassTeachers'
CREATE TABLE [dbo].[ClassTeachers] (
    [ClTeachID] int IDENTITY(1,1) NOT NULL,
    [ClassID] int  NOT NULL,
    [TeacherID] int  NOT NULL,
    [PeriodID] int  NOT NULL,
    [PeriodStartDate] datetime  NULL,
    [PeriodEndDate] datetime  NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedBy] nvarchar(max)  NULL,
    [ModifiedDate] datetime  NULL,
    [RowVersion] binary(8)  NOT NULL
);
GO

-- Creating table 'ClassStudents'
CREATE TABLE [dbo].[ClassStudents] (
    [ClStudID] int IDENTITY(1,1) NOT NULL,
    [PrClID] int  NOT NULL,
    [StudID] int  NOT NULL,
    [PeriodStartDate] datetime  NULL,
    [PeriodEndDate] datetime  NULL,
    [IsMonitor] bit  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedBy] nvarchar(max)  NULL,
    [ModifiedDate] datetime  NULL,
    [RowVersion] binary(8)  NOT NULL,
    [Status] int  NOT NULL,
    [IsCurrentMonitor] bit  NOT NULL
);
GO

-- Creating table 'PeriodSetups'
CREATE TABLE [dbo].[PeriodSetups] (
    [PeriodID] int IDENTITY(1,1) NOT NULL,
    [PeriodStartDate] datetime  NOT NULL,
    [PeriodEndDate] datetime  NOT NULL,
    [IsPeriodComplete] bit  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedBy] nvarchar(max)  NULL,
    [ModifiedDate] datetime  NULL,
    [RowVersion] binary(8)  NOT NULL
);
GO

-- Creating table 'Teachers'
CREATE TABLE [dbo].[Teachers] (
    [TeachID] int IDENTITY(1,1) NOT NULL,
    [Title] int  NOT NULL,
    [Gender] int  NOT NULL,
    [FullName] nvarchar(max)  NOT NULL,
    [Initials] nvarchar(max)  NOT NULL,
    [LName] nvarchar(max)  NOT NULL,
    [Address] nvarchar(max)  NOT NULL,
    [ContactNo] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NULL,
    [NICNo] nvarchar(max)  NOT NULL,
    [TelHome] nvarchar(max)  NULL,
    [ImmeContactNo] nvarchar(max)  NULL,
    [ImmeContactName] nvarchar(max)  NULL,
    [Status] int  NOT NULL,
    [InactiveReason] nvarchar(max)  NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedBy] nvarchar(max)  NULL,
    [ModifiedDate] datetime  NULL,
    [RowVersion] binary(8)  NOT NULL
);
GO

-- Creating table 'ClubMembers'
CREATE TABLE [dbo].[ClubMembers] (
    [CMID] int IDENTITY(1,1) NOT NULL,
    [CID] int  NOT NULL,
    [StudentID] int  NOT NULL,
    [MemberDate] datetime  NOT NULL,
    [MembershipType] int  NOT NULL,
    [CommiteeMemberType] int  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedBy] nvarchar(max)  NULL,
    [ModifiedDate] datetime  NULL,
    [RowVersion] binary(8)  NOT NULL,
    [Status] int  NOT NULL
);
GO

-- Creating table 'Clubs'
CREATE TABLE [dbo].[Clubs] (
    [CID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NULL,
    [Status] int  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedBy] nvarchar(max)  NULL,
    [ModifiedDate] datetime  NULL,
    [RowVersion] binary(8)  NOT NULL
);
GO

-- Creating table 'EventParticipations'
CREATE TABLE [dbo].[EventParticipations] (
    [EPID] int IDENTITY(1,1) NOT NULL,
    [StudID] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [EventDesc] nvarchar(max)  NOT NULL,
    [IsWinner] bit  NOT NULL,
    [WinningDetails] nvarchar(max)  NULL,
    [TeacherInCharge] int  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedBy] nvarchar(max)  NULL,
    [ModifiedDate] datetime  NULL,
    [RowVersion] binary(8)  NOT NULL
);
GO

-- Creating table 'PromotionClasses'
CREATE TABLE [dbo].[PromotionClasses] (
    [PrClID] int IDENTITY(1,1) NOT NULL,
    [ClassID] int  NOT NULL,
    [PeriodID] int  NOT NULL,
    [MonitorStudID] nvarchar(max)  NOT NULL,
    [MonitorStud2ID] nvarchar(max)  NULL,
    [TeacherID] int  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedBy] nvarchar(max)  NULL,
    [ModifiedDate] datetime  NULL,
    [RowVersion] binary(8)  NOT NULL
);
GO

-- Creating table 'Prefects'
CREATE TABLE [dbo].[Prefects] (
    [PreID] int IDENTITY(1,1) NOT NULL,
    [StudID] int  NOT NULL,
    [PrefClassID] int  NOT NULL,
    [Type] int  NOT NULL,
    [EffectiveDate] datetime  NOT NULL,
    [IsHP] bit  NOT NULL,
    [IsDHP] bit  NOT NULL,
    [Responsibilty] nvarchar(max)  NULL,
    [IsPromoted] bit  NOT NULL,
    [PromotedDate] datetime  NULL,
    [Status] int  NOT NULL,
    [InactiveDate] datetime  NULL,
    [InactiveReason] nvarchar(max)  NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedBy] nvarchar(max)  NULL,
    [ModifiedDate] datetime  NULL,
    [RowVersion] binary(8)  NOT NULL
);
GO

-- Creating table 'LeavingCertificates'
CREATE TABLE [dbo].[LeavingCertificates] (
    [LeavCertID] int IDENTITY(1,1) NOT NULL,
    [StudID] int  NOT NULL,
    [DateLeaving] datetime  NOT NULL,
    [Reason] nvarchar(max)  NULL,
    [Conduct] int  NOT NULL,
    [CreatedBy] nvarchar(max)  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [ModifiedBy] nvarchar(max)  NULL,
    [ModifiedDate] datetime  NULL,
    [RowVersion] binary(8)  NOT NULL
);
GO

-- Creating table 'RoleMenuAccesses'
CREATE TABLE [dbo].[RoleMenuAccesses] (
    [Menus_MenuID] int  NOT NULL,
    [Roles_RoleID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [MenuID] in table 'Menus'
ALTER TABLE [dbo].[Menus]
ADD CONSTRAINT [PK_Menus]
    PRIMARY KEY CLUSTERED ([MenuID] ASC);
GO

-- Creating primary key on [RoleID] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([RoleID] ASC);
GO

-- Creating primary key on [RoleTileID] in table 'RoleTiles'
ALTER TABLE [dbo].[RoleTiles]
ADD CONSTRAINT [PK_RoleTiles]
    PRIMARY KEY CLUSTERED ([RoleTileID] ASC);
GO

-- Creating primary key on [UserRoleID] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [PK_UserRoles]
    PRIMARY KEY CLUSTERED ([UserRoleID] ASC);
GO

-- Creating primary key on [UserID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([UserID] ASC);
GO

-- Creating primary key on [StudID] in table 'Students'
ALTER TABLE [dbo].[Students]
ADD CONSTRAINT [PK_Students]
    PRIMARY KEY CLUSTERED ([StudID] ASC);
GO

-- Creating primary key on [SubID] in table 'StudSublings'
ALTER TABLE [dbo].[StudSublings]
ADD CONSTRAINT [PK_StudSublings]
    PRIMARY KEY CLUSTERED ([SubID] ASC);
GO

-- Creating primary key on [StudFID] in table 'StudFamilies'
ALTER TABLE [dbo].[StudFamilies]
ADD CONSTRAINT [PK_StudFamilies]
    PRIMARY KEY CLUSTERED ([StudFID] ASC);
GO

-- Creating primary key on [ClassID] in table 'Classes'
ALTER TABLE [dbo].[Classes]
ADD CONSTRAINT [PK_Classes]
    PRIMARY KEY CLUSTERED ([ClassID] ASC);
GO

-- Creating primary key on [ClTeachID] in table 'ClassTeachers'
ALTER TABLE [dbo].[ClassTeachers]
ADD CONSTRAINT [PK_ClassTeachers]
    PRIMARY KEY CLUSTERED ([ClTeachID] ASC);
GO

-- Creating primary key on [ClStudID] in table 'ClassStudents'
ALTER TABLE [dbo].[ClassStudents]
ADD CONSTRAINT [PK_ClassStudents]
    PRIMARY KEY CLUSTERED ([ClStudID] ASC);
GO

-- Creating primary key on [PeriodID] in table 'PeriodSetups'
ALTER TABLE [dbo].[PeriodSetups]
ADD CONSTRAINT [PK_PeriodSetups]
    PRIMARY KEY CLUSTERED ([PeriodID] ASC);
GO

-- Creating primary key on [TeachID] in table 'Teachers'
ALTER TABLE [dbo].[Teachers]
ADD CONSTRAINT [PK_Teachers]
    PRIMARY KEY CLUSTERED ([TeachID] ASC);
GO

-- Creating primary key on [CMID] in table 'ClubMembers'
ALTER TABLE [dbo].[ClubMembers]
ADD CONSTRAINT [PK_ClubMembers]
    PRIMARY KEY CLUSTERED ([CMID] ASC);
GO

-- Creating primary key on [CID] in table 'Clubs'
ALTER TABLE [dbo].[Clubs]
ADD CONSTRAINT [PK_Clubs]
    PRIMARY KEY CLUSTERED ([CID] ASC);
GO

-- Creating primary key on [EPID] in table 'EventParticipations'
ALTER TABLE [dbo].[EventParticipations]
ADD CONSTRAINT [PK_EventParticipations]
    PRIMARY KEY CLUSTERED ([EPID] ASC);
GO

-- Creating primary key on [PrClID] in table 'PromotionClasses'
ALTER TABLE [dbo].[PromotionClasses]
ADD CONSTRAINT [PK_PromotionClasses]
    PRIMARY KEY CLUSTERED ([PrClID] ASC);
GO

-- Creating primary key on [PreID] in table 'Prefects'
ALTER TABLE [dbo].[Prefects]
ADD CONSTRAINT [PK_Prefects]
    PRIMARY KEY CLUSTERED ([PreID] ASC);
GO

-- Creating primary key on [LeavCertID] in table 'LeavingCertificates'
ALTER TABLE [dbo].[LeavingCertificates]
ADD CONSTRAINT [PK_LeavingCertificates]
    PRIMARY KEY CLUSTERED ([LeavCertID] ASC);
GO

-- Creating primary key on [Menus_MenuID], [Roles_RoleID] in table 'RoleMenuAccesses'
ALTER TABLE [dbo].[RoleMenuAccesses]
ADD CONSTRAINT [PK_RoleMenuAccesses]
    PRIMARY KEY CLUSTERED ([Menus_MenuID], [Roles_RoleID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ParentMenuID] in table 'Menus'
ALTER TABLE [dbo].[Menus]
ADD CONSTRAINT [FK_MenuMenu]
    FOREIGN KEY ([ParentMenuID])
    REFERENCES [dbo].[Menus]
        ([MenuID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MenuMenu'
CREATE INDEX [IX_FK_MenuMenu]
ON [dbo].[Menus]
    ([ParentMenuID]);
GO

-- Creating foreign key on [RoleID] in table 'RoleTiles'
ALTER TABLE [dbo].[RoleTiles]
ADD CONSTRAINT [FK_RoleRoleTiles]
    FOREIGN KEY ([RoleID])
    REFERENCES [dbo].[Roles]
        ([RoleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleRoleTiles'
CREATE INDEX [IX_FK_RoleRoleTiles]
ON [dbo].[RoleTiles]
    ([RoleID]);
GO

-- Creating foreign key on [RoleID] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [FK_RoleUserRole]
    FOREIGN KEY ([RoleID])
    REFERENCES [dbo].[Roles]
        ([RoleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleUserRole'
CREATE INDEX [IX_FK_RoleUserRole]
ON [dbo].[UserRoles]
    ([RoleID]);
GO

-- Creating foreign key on [UserID] in table 'UserRoles'
ALTER TABLE [dbo].[UserRoles]
ADD CONSTRAINT [FK_UserUserRole]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([UserID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserUserRole'
CREATE INDEX [IX_FK_UserUserRole]
ON [dbo].[UserRoles]
    ([UserID]);
GO

-- Creating foreign key on [Menus_MenuID] in table 'RoleMenuAccesses'
ALTER TABLE [dbo].[RoleMenuAccesses]
ADD CONSTRAINT [FK_RoleMenuAccesses_Menus]
    FOREIGN KEY ([Menus_MenuID])
    REFERENCES [dbo].[Menus]
        ([MenuID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Roles_RoleID] in table 'RoleMenuAccesses'
ALTER TABLE [dbo].[RoleMenuAccesses]
ADD CONSTRAINT [FK_RoleMenuAccesses_Roles]
    FOREIGN KEY ([Roles_RoleID])
    REFERENCES [dbo].[Roles]
        ([RoleID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleMenuAccesses_Roles'
CREATE INDEX [IX_FK_RoleMenuAccesses_Roles]
ON [dbo].[RoleMenuAccesses]
    ([Roles_RoleID]);
GO

-- Creating foreign key on [SudID] in table 'StudSublings'
ALTER TABLE [dbo].[StudSublings]
ADD CONSTRAINT [FK_StudentStudSubling]
    FOREIGN KEY ([SudID])
    REFERENCES [dbo].[Students]
        ([StudID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentStudSubling'
CREATE INDEX [IX_FK_StudentStudSubling]
ON [dbo].[StudSublings]
    ([SudID]);
GO

-- Creating foreign key on [SublingStudID] in table 'StudSublings'
ALTER TABLE [dbo].[StudSublings]
ADD CONSTRAINT [FK_StudentStudSubling1]
    FOREIGN KEY ([SublingStudID])
    REFERENCES [dbo].[Students]
        ([StudID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentStudSubling1'
CREATE INDEX [IX_FK_StudentStudSubling1]
ON [dbo].[StudSublings]
    ([SublingStudID]);
GO

-- Creating foreign key on [StudID] in table 'StudFamilies'
ALTER TABLE [dbo].[StudFamilies]
ADD CONSTRAINT [FK_StudentStudFamily]
    FOREIGN KEY ([StudID])
    REFERENCES [dbo].[Students]
        ([StudID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentStudFamily'
CREATE INDEX [IX_FK_StudentStudFamily]
ON [dbo].[StudFamilies]
    ([StudID]);
GO

-- Creating foreign key on [ClassID] in table 'ClassTeachers'
ALTER TABLE [dbo].[ClassTeachers]
ADD CONSTRAINT [FK_ClassClassTeacher]
    FOREIGN KEY ([ClassID])
    REFERENCES [dbo].[Classes]
        ([ClassID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClassClassTeacher'
CREATE INDEX [IX_FK_ClassClassTeacher]
ON [dbo].[ClassTeachers]
    ([ClassID]);
GO

-- Creating foreign key on [PeriodID] in table 'ClassTeachers'
ALTER TABLE [dbo].[ClassTeachers]
ADD CONSTRAINT [FK_PeriodSetupClassTeacher]
    FOREIGN KEY ([PeriodID])
    REFERENCES [dbo].[PeriodSetups]
        ([PeriodID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PeriodSetupClassTeacher'
CREATE INDEX [IX_FK_PeriodSetupClassTeacher]
ON [dbo].[ClassTeachers]
    ([PeriodID]);
GO

-- Creating foreign key on [StudID] in table 'ClassStudents'
ALTER TABLE [dbo].[ClassStudents]
ADD CONSTRAINT [FK_StudentClassStudent]
    FOREIGN KEY ([StudID])
    REFERENCES [dbo].[Students]
        ([StudID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentClassStudent'
CREATE INDEX [IX_FK_StudentClassStudent]
ON [dbo].[ClassStudents]
    ([StudID]);
GO

-- Creating foreign key on [TeacherID] in table 'ClassTeachers'
ALTER TABLE [dbo].[ClassTeachers]
ADD CONSTRAINT [FK_TeacherClassTeacher]
    FOREIGN KEY ([TeacherID])
    REFERENCES [dbo].[Teachers]
        ([TeachID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeacherClassTeacher'
CREATE INDEX [IX_FK_TeacherClassTeacher]
ON [dbo].[ClassTeachers]
    ([TeacherID]);
GO

-- Creating foreign key on [CID] in table 'ClubMembers'
ALTER TABLE [dbo].[ClubMembers]
ADD CONSTRAINT [FK_ClubClubMember]
    FOREIGN KEY ([CID])
    REFERENCES [dbo].[Clubs]
        ([CID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClubClubMember'
CREATE INDEX [IX_FK_ClubClubMember]
ON [dbo].[ClubMembers]
    ([CID]);
GO

-- Creating foreign key on [StudentID] in table 'ClubMembers'
ALTER TABLE [dbo].[ClubMembers]
ADD CONSTRAINT [FK_StudentClubMember]
    FOREIGN KEY ([StudentID])
    REFERENCES [dbo].[Students]
        ([StudID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentClubMember'
CREATE INDEX [IX_FK_StudentClubMember]
ON [dbo].[ClubMembers]
    ([StudentID]);
GO

-- Creating foreign key on [StudID] in table 'EventParticipations'
ALTER TABLE [dbo].[EventParticipations]
ADD CONSTRAINT [FK_StudentEventParticipation]
    FOREIGN KEY ([StudID])
    REFERENCES [dbo].[Students]
        ([StudID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentEventParticipation'
CREATE INDEX [IX_FK_StudentEventParticipation]
ON [dbo].[EventParticipations]
    ([StudID]);
GO

-- Creating foreign key on [TeacherInCharge] in table 'EventParticipations'
ALTER TABLE [dbo].[EventParticipations]
ADD CONSTRAINT [FK_TeacherEventParticipation]
    FOREIGN KEY ([TeacherInCharge])
    REFERENCES [dbo].[Teachers]
        ([TeachID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeacherEventParticipation'
CREATE INDEX [IX_FK_TeacherEventParticipation]
ON [dbo].[EventParticipations]
    ([TeacherInCharge]);
GO

-- Creating foreign key on [ClassID] in table 'PromotionClasses'
ALTER TABLE [dbo].[PromotionClasses]
ADD CONSTRAINT [FK_ClassPromotionClass]
    FOREIGN KEY ([ClassID])
    REFERENCES [dbo].[Classes]
        ([ClassID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClassPromotionClass'
CREATE INDEX [IX_FK_ClassPromotionClass]
ON [dbo].[PromotionClasses]
    ([ClassID]);
GO

-- Creating foreign key on [PeriodID] in table 'PromotionClasses'
ALTER TABLE [dbo].[PromotionClasses]
ADD CONSTRAINT [FK_PeriodSetupPromotionClass]
    FOREIGN KEY ([PeriodID])
    REFERENCES [dbo].[PeriodSetups]
        ([PeriodID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PeriodSetupPromotionClass'
CREATE INDEX [IX_FK_PeriodSetupPromotionClass]
ON [dbo].[PromotionClasses]
    ([PeriodID]);
GO

-- Creating foreign key on [PrClID] in table 'ClassStudents'
ALTER TABLE [dbo].[ClassStudents]
ADD CONSTRAINT [FK_PromotionClassClassStudent]
    FOREIGN KEY ([PrClID])
    REFERENCES [dbo].[PromotionClasses]
        ([PrClID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PromotionClassClassStudent'
CREATE INDEX [IX_FK_PromotionClassClassStudent]
ON [dbo].[ClassStudents]
    ([PrClID]);
GO

-- Creating foreign key on [TeacherID] in table 'PromotionClasses'
ALTER TABLE [dbo].[PromotionClasses]
ADD CONSTRAINT [FK_TeacherPromotionClass]
    FOREIGN KEY ([TeacherID])
    REFERENCES [dbo].[Teachers]
        ([TeachID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeacherPromotionClass'
CREATE INDEX [IX_FK_TeacherPromotionClass]
ON [dbo].[PromotionClasses]
    ([TeacherID]);
GO

-- Creating foreign key on [StudID] in table 'Prefects'
ALTER TABLE [dbo].[Prefects]
ADD CONSTRAINT [FK_StudentPrefect]
    FOREIGN KEY ([StudID])
    REFERENCES [dbo].[Students]
        ([StudID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentPrefect'
CREATE INDEX [IX_FK_StudentPrefect]
ON [dbo].[Prefects]
    ([StudID]);
GO

-- Creating foreign key on [PrefClassID] in table 'Prefects'
ALTER TABLE [dbo].[Prefects]
ADD CONSTRAINT [FK_PromotionClassPrefect]
    FOREIGN KEY ([PrefClassID])
    REFERENCES [dbo].[PromotionClasses]
        ([PrClID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PromotionClassPrefect'
CREATE INDEX [IX_FK_PromotionClassPrefect]
ON [dbo].[Prefects]
    ([PrefClassID]);
GO

-- Creating foreign key on [StudID] in table 'LeavingCertificates'
ALTER TABLE [dbo].[LeavingCertificates]
ADD CONSTRAINT [FK_StudentLeavingCertificate]
    FOREIGN KEY ([StudID])
    REFERENCES [dbo].[Students]
        ([StudID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_StudentLeavingCertificate'
CREATE INDEX [IX_FK_StudentLeavingCertificate]
ON [dbo].[LeavingCertificates]
    ([StudID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------