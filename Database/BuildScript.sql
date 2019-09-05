USE [master]
GO
/****** Object:  Database [CommunityShedDB]    Script Date: 9/5/2019 11:27:09 AM ******/
CREATE DATABASE [CommunityShedDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CommunityShedDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CommunityShedDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CommunityShedDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\CommunityShedDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CommunityShedDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CommunityShedDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CommunityShedDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CommunityShedDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CommunityShedDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CommunityShedDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CommunityShedDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CommunityShedDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CommunityShedDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CommunityShedDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CommunityShedDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CommunityShedDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CommunityShedDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CommunityShedDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CommunityShedDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CommunityShedDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CommunityShedDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CommunityShedDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CommunityShedDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CommunityShedDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CommunityShedDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CommunityShedDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CommunityShedDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CommunityShedDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CommunityShedDB] SET RECOVERY FULL 
GO
ALTER DATABASE [CommunityShedDB] SET  MULTI_USER 
GO
ALTER DATABASE [CommunityShedDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CommunityShedDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CommunityShedDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CommunityShedDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CommunityShedDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CommunityShedDB', N'ON'
GO
ALTER DATABASE [CommunityShedDB] SET QUERY_STORE = OFF
GO
USE [CommunityShedDB]
GO
/****** Object:  Table [dbo].[Community]    Script Date: 9/5/2019 11:27:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Community](
	[CommunityId] [int] IDENTITY(1,1) NOT NULL,
	[CommunityName] [nvarchar](50) NOT NULL,
	[CreatorPersonId] [nvarchar](50) NOT NULL,
	[IsOpen] [bit] NOT NULL,
 CONSTRAINT [PK_Community] PRIMARY KEY CLUSTERED 
(
	[CommunityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 9/5/2019 11:27:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonCommunity]    Script Date: 9/5/2019 11:27:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonCommunity](
	[PersonCommunityId] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[CommunityId] [int] NOT NULL,
	[PersonCommunityStatusId] [int] NOT NULL,
 CONSTRAINT [PK_PersonCommunity] PRIMARY KEY CLUSTERED 
(
	[PersonCommunityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonCommunityRole]    Script Date: 9/5/2019 11:27:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonCommunityRole](
	[PersonCommunityId] [int] NOT NULL,
	[RoleId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonCommunityStatus]    Script Date: 9/5/2019 11:27:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonCommunityStatus](
	[PersonCommunityStatusId] [int] IDENTITY(1,1) NOT NULL,
	[PersonCommunityStatusName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_PersonCommunityStatus] PRIMARY KEY CLUSTERED 
(
	[PersonCommunityStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 9/5/2019 11:27:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Community] ON 
GO
INSERT [dbo].[Community] ([CommunityId], [CommunityName], [CreatorPersonId], [IsOpen]) VALUES (1, N'Astoria', N'1', 1)
GO
INSERT [dbo].[Community] ([CommunityId], [CommunityName], [CreatorPersonId], [IsOpen]) VALUES (2, N'Jamaica', N'2', 1)
GO
INSERT [dbo].[Community] ([CommunityId], [CommunityName], [CreatorPersonId], [IsOpen]) VALUES (3, N'Brooklyn', N'1', 1)
GO
SET IDENTITY_INSERT [dbo].[Community] OFF
GO
SET IDENTITY_INSERT [dbo].[Person] ON 
GO
INSERT [dbo].[Person] ([PersonId], [Name], [Email], [Password]) VALUES (1, N'James Churchill', N'jc@123.com', N'password')
GO
INSERT [dbo].[Person] ([PersonId], [Name], [Email], [Password]) VALUES (2, N'Omer Latif', N'ol@321.com', N'password')
GO
INSERT [dbo].[Person] ([PersonId], [Name], [Email], [Password]) VALUES (3, N'Bill', N'James@321.com', N'password')
GO
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
SET IDENTITY_INSERT [dbo].[PersonCommunity] ON 
GO
INSERT [dbo].[PersonCommunity] ([PersonCommunityId], [PersonId], [CommunityId], [PersonCommunityStatusId]) VALUES (1, 1, 1, 2)
GO
INSERT [dbo].[PersonCommunity] ([PersonCommunityId], [PersonId], [CommunityId], [PersonCommunityStatusId]) VALUES (2, 2, 2, 2)
GO
INSERT [dbo].[PersonCommunity] ([PersonCommunityId], [PersonId], [CommunityId], [PersonCommunityStatusId]) VALUES (3, 1, 3, 2)
GO
INSERT [dbo].[PersonCommunity] ([PersonCommunityId], [PersonId], [CommunityId], [PersonCommunityStatusId]) VALUES (4, 3, 3, 2)
GO
SET IDENTITY_INSERT [dbo].[PersonCommunity] OFF
GO
INSERT [dbo].[PersonCommunityRole] ([PersonCommunityId], [RoleId]) VALUES (3, 3)
GO
INSERT [dbo].[PersonCommunityRole] ([PersonCommunityId], [RoleId]) VALUES (1, 3)
GO
INSERT [dbo].[PersonCommunityRole] ([PersonCommunityId], [RoleId]) VALUES (1, 4)
GO
INSERT [dbo].[PersonCommunityRole] ([PersonCommunityId], [RoleId]) VALUES (1, 5)
GO
INSERT [dbo].[PersonCommunityRole] ([PersonCommunityId], [RoleId]) VALUES (3, 4)
GO
INSERT [dbo].[PersonCommunityRole] ([PersonCommunityId], [RoleId]) VALUES (3, 5)
GO
INSERT [dbo].[PersonCommunityRole] ([PersonCommunityId], [RoleId]) VALUES (2, 3)
GO
INSERT [dbo].[PersonCommunityRole] ([PersonCommunityId], [RoleId]) VALUES (2, 4)
GO
INSERT [dbo].[PersonCommunityRole] ([PersonCommunityId], [RoleId]) VALUES (2, 5)
GO
INSERT [dbo].[PersonCommunityRole] ([PersonCommunityId], [RoleId]) VALUES (4, 2)
GO
SET IDENTITY_INSERT [dbo].[PersonCommunityStatus] ON 
GO
INSERT [dbo].[PersonCommunityStatus] ([PersonCommunityStatusId], [PersonCommunityStatusName]) VALUES (1, N'Pending')
GO
INSERT [dbo].[PersonCommunityStatus] ([PersonCommunityStatusId], [PersonCommunityStatusName]) VALUES (2, N'Approved')
GO
INSERT [dbo].[PersonCommunityStatus] ([PersonCommunityStatusId], [PersonCommunityStatusName]) VALUES (3, N'Denied')
GO
SET IDENTITY_INSERT [dbo].[PersonCommunityStatus] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (2, N'Member')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (3, N'Approver')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (4, N'Reviewer')
GO
INSERT [dbo].[Roles] ([RoleId], [RoleName]) VALUES (5, N'Enforcer')
GO
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
ALTER TABLE [dbo].[PersonCommunity]  WITH CHECK ADD  CONSTRAINT [FK_PersonCommunity_Community1] FOREIGN KEY([CommunityId])
REFERENCES [dbo].[Community] ([CommunityId])
GO
ALTER TABLE [dbo].[PersonCommunity] CHECK CONSTRAINT [FK_PersonCommunity_Community1]
GO
ALTER TABLE [dbo].[PersonCommunity]  WITH CHECK ADD  CONSTRAINT [FK_PersonCommunity_Person1] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([PersonId])
GO
ALTER TABLE [dbo].[PersonCommunity] CHECK CONSTRAINT [FK_PersonCommunity_Person1]
GO
ALTER TABLE [dbo].[PersonCommunity]  WITH CHECK ADD  CONSTRAINT [FK_PersonCommunity_PersonCommunityStatus] FOREIGN KEY([PersonCommunityStatusId])
REFERENCES [dbo].[PersonCommunityStatus] ([PersonCommunityStatusId])
GO
ALTER TABLE [dbo].[PersonCommunity] CHECK CONSTRAINT [FK_PersonCommunity_PersonCommunityStatus]
GO
ALTER TABLE [dbo].[PersonCommunityRole]  WITH CHECK ADD  CONSTRAINT [FK_PersonCommunityRole_PersonCommunity] FOREIGN KEY([PersonCommunityId])
REFERENCES [dbo].[PersonCommunity] ([PersonCommunityId])
GO
ALTER TABLE [dbo].[PersonCommunityRole] CHECK CONSTRAINT [FK_PersonCommunityRole_PersonCommunity]
GO
ALTER TABLE [dbo].[PersonCommunityRole]  WITH CHECK ADD  CONSTRAINT [FK_PersonCommunityRole_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([RoleId])
GO
ALTER TABLE [dbo].[PersonCommunityRole] CHECK CONSTRAINT [FK_PersonCommunityRole_Roles]
GO
USE [master]
GO
ALTER DATABASE [CommunityShedDB] SET  READ_WRITE 
GO
