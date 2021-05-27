USE [dbSMS];
GO

SET IDENTITY_INSERT [dbo].[Roles] ON
INSERT INTO [dbo].[Roles] ([RoleID], [Code], [Name], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'Admin', N'Administrator', N'ERANDI_PC\erandi', N'2015-01-01 00:00:00', NULL, NULL)
INSERT INTO [dbo].[Roles] ([RoleID], [Code], [Name], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'AdminUser', N'Admin Department User', N'ERANDI_PC\erandi', N'2015-01-01 00:00:00', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Roles] OFF

SET IDENTITY_INSERT [dbo].[Menus] ON
INSERT INTO [dbo].[Menus] ([MenuID], [ParentMenuID], [DisplaySeq], [Text], [Type], [Area], [Controller], [Action]) VALUES (1, NULL, 10, N'Admin', N'M', NULL, NULL, NULL)
INSERT INTO [dbo].[Menus] ([MenuID], [ParentMenuID], [DisplaySeq], [Text], [Type], [Area], [Controller], [Action]) VALUES (2, 1, 10, N'User Information', N'I', N'Admin', N'Users', N'Index')

SET IDENTITY_INSERT [dbo].[Menus] OFF

INSERT INTO [dbo].[RoleMenuAccesses] SELECT 1, [MenuID] FROM [dbo].[Menus] WHERE [Type] = 'M'
INSERT INTO [dbo].[RoleMenuAccesses] ([RoleID], [MenuID]) VALUES (1, 2)

SET IDENTITY_INSERT [dbo].[Users] ON
INSERT INTO [dbo].[Users] ([UserID], [UserName], [Password], [EmployeeID], [Status], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'erandi', N'1', 3, 1, N'ERANDI_PC\erandi', N'2015-01-01 00:00:00', NULL, NULL)
INSERT INTO [dbo].[Users] ([UserID], [UserName], [Password], [EmployeeID], [Status], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (2, N'rananga', N'123', NULL, 1, N'ERANDI_PC\erandi', N'2015-01-01 00:00:00', NULL, NULL)
INSERT INTO [dbo].[Users] ([UserID], [UserName], [Password], [EmployeeID], [Status], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'gangani', N'1', 4, 1, N'NIBM\rananga', N'2015-12-29 13:40:10', NULL, NULL)
INSERT INTO [dbo].[Users] ([UserID], [UserName], [Password], [EmployeeID], [Status], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (4, N'kumari', N'1', 5, 1, N'NIBM\rananga', N'2015-12-29 15:28:55', NULL, NULL)
INSERT INTO [dbo].[Users] ([UserID], [UserName], [Password], [EmployeeID], [Status], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (5, N'dg', N'1', 1, 1, N'NIBM\rananga', N'2015-12-29 15:29:07', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF

SET IDENTITY_INSERT [dbo].[UserRoles] ON
INSERT INTO [dbo].[UserRoles] ([UserRoleID], [UserID], [RoleID]) VALUES (1, 1, 1)
INSERT INTO [dbo].[UserRoles] ([UserRoleID], [UserID], [RoleID]) VALUES (2, 2, 1)
INSERT INTO [dbo].[UserRoles] ([UserRoleID], [UserID], [RoleID]) VALUES (3, 2, 2)
SET IDENTITY_INSERT [dbo].[UserRoles] OFF