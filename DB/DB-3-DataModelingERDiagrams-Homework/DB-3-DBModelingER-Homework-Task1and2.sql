USE [master]
GO
/****** Object:  Database [DBModelingTasksOneAndTwo]    Script Date: 21/08/2014 11:17:27 ******/
CREATE DATABASE [DBModelingTasksOneAndTwo]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DBModelingTasksOneAndTwo', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DBModelingTasksOneAndTwo.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'DBModelingTasksOneAndTwo_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\DBModelingTasksOneAndTwo_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DBModelingTasksOneAndTwo].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET ARITHABORT OFF 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET RECOVERY FULL 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET  MULTI_USER 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'DBModelingTasksOneAndTwo', N'ON'
GO
USE [DBModelingTasksOneAndTwo]
GO
/****** Object:  Table [dbo].[Addresses]    Script Date: 21/08/2014 11:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Addresses](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[AddressText] [nvarchar](200) NOT NULL,
	[TownId] [int] NOT NULL,
 CONSTRAINT [PK_Addresses] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continents]    Script Date: 21/08/2014 11:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Continents](
	[ContinentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[ContinentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Countries]    Script Date: 21/08/2014 11:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ContinentId] [int] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Persons]    Script Date: 21/08/2014 11:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persons](
	[PersonId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_Persons] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Towns]    Script Date: 21/08/2014 11:17:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Towns](
	[TownId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CountryId] [int] NOT NULL,
 CONSTRAINT [PK_Towns] PRIMARY KEY CLUSTERED 
(
	[TownId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Addresses] ON 

INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (3, N'Eiffel str. 12', 2)
INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (4, N'Mladost 3', 3)
INSERT [dbo].[Addresses] ([AddressId], [AddressText], [TownId]) VALUES (5, N'Main str. 124', 4)
SET IDENTITY_INSERT [dbo].[Addresses] OFF
SET IDENTITY_INSERT [dbo].[Continents] ON 

INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (1, N'Europe')
INSERT [dbo].[Continents] ([ContinentId], [Name]) VALUES (2, N'Australia')
SET IDENTITY_INSERT [dbo].[Continents] OFF
SET IDENTITY_INSERT [dbo].[Countries] ON 

INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId]) VALUES (1, N'France', 1)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId]) VALUES (2, N'Bulgaria', 1)
INSERT [dbo].[Countries] ([CountryId], [Name], [ContinentId]) VALUES (3, N'Australia', 2)
SET IDENTITY_INSERT [dbo].[Countries] OFF
SET IDENTITY_INSERT [dbo].[Persons] ON 

INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (3, N'Jan', N'LeBlanc', 3)
INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (4, N'Gosho ', N'Ivanov', 4)
INSERT [dbo].[Persons] ([PersonId], [FirstName], [LastName], [AddressId]) VALUES (5, N'Mr', N'Crocodile', 5)
SET IDENTITY_INSERT [dbo].[Persons] OFF
SET IDENTITY_INSERT [dbo].[Towns] ON 

INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (2, N'Paris', 1)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (3, N'Sofia', 2)
INSERT [dbo].[Towns] ([TownId], [Name], [CountryId]) VALUES (4, N'Sidney', 3)
SET IDENTITY_INSERT [dbo].[Towns] OFF
ALTER TABLE [dbo].[Addresses]  WITH CHECK ADD  CONSTRAINT [FK_Addresses_Towns] FOREIGN KEY([TownId])
REFERENCES [dbo].[Towns] ([TownId])
GO
ALTER TABLE [dbo].[Addresses] CHECK CONSTRAINT [FK_Addresses_Towns]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Continents] FOREIGN KEY([ContinentId])
REFERENCES [dbo].[Continents] ([ContinentId])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Countries_Continents]
GO
ALTER TABLE [dbo].[Persons]  WITH CHECK ADD  CONSTRAINT [FK_Persons_Addresses] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Addresses] ([AddressId])
GO
ALTER TABLE [dbo].[Persons] CHECK CONSTRAINT [FK_Persons_Addresses]
GO
ALTER TABLE [dbo].[Towns]  WITH CHECK ADD  CONSTRAINT [FK_Towns_Countries] FOREIGN KEY([CountryId])
REFERENCES [dbo].[Countries] ([CountryId])
GO
ALTER TABLE [dbo].[Towns] CHECK CONSTRAINT [FK_Towns_Countries]
GO
USE [master]
GO
ALTER DATABASE [DBModelingTasksOneAndTwo] SET  READ_WRITE 
GO
