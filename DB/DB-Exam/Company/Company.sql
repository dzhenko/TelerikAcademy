USE [master]
GO
/****** Object:  Database [Company]    Script Date: 08/09/2014 17:37:13 ******/
CREATE DATABASE [Company]
GO
ALTER DATABASE [Company] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Company].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Company] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Company] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Company] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Company] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Company] SET ARITHABORT OFF 
GO
ALTER DATABASE [Company] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Company] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Company] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Company] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Company] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Company] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Company] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Company] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Company] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Company] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Company] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Company] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Company] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Company] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Company] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Company] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Company] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Company] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Company] SET RECOVERY FULL 
GO
ALTER DATABASE [Company] SET  MULTI_USER 
GO
ALTER DATABASE [Company] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Company] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Company] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Company] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Company', N'ON'
GO
USE [Company]
GO
/****** Object:  StoredProcedure [dbo].[sp_createCacheTable]    Script Date: 08/09/2014 17:37:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_createCacheTable]
AS
BEGIN
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('CacheTable') 
AND type in (N'U'))
	DROP TABLE [dbo].[CacheTable]

DECLARE @SQLString NVARCHAR(MAX)
    Set @SQLString = 'CREATE TABLE [CacheTable]
    (
		[Employee Full Name] [nvarchar](41) NOT NULL,
		[Project Name] [nvarchar](50) NOT NULL,
		[Department Name] [nvarchar](50) NOT NULL,
		[Starting Date] [date] NOT NULL,
		[Ending Date] [date] NOT NULL,
		[Reports For Project] [int] NOT NULL
	) ON [PRIMARY]'

EXEC (@SQLString)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_updateCacheTable]    Script Date: 08/09/2014 17:37:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_updateCacheTable]
AS
BEGIN
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('CacheTable') 
AND type in (N'U'))
	EXEC dbo.sp_updateCacheTable --Creates the cache table if needed

DECLARE @SQLString NVARCHAR(MAX)
    Set @SQLString = 'INSERT INTO [CacheTable]
	   SELECT Employees.FirstName + '' '' + Employees.LastName AS [Employee Full Name],
	   Projects.Name AS [Project Name],
	   Departments.Name AS [Department Name],
	   EmployeesProjects.StartingDate AS [Starting Date],
	   EmployeesProjects.EndingDate AS [Ending Date],
	   COUNT (Reports.Id) AS [Reports For Project]
FROM Employees 
INNER JOIN EmployeesProjects
	ON Employees.Id = EmployeesProjects.EmployeeId
INNER JOIN Projects
	ON Projects.Id = EmployeesProjects.ProjectId
INNER JOIN Departments
    ON Departments.Id = Employees.DepartmentId
INNER JOIN Reports
	ON Reports.EmployeeId = Employees.Id
WHERE Reports.[Time] BETWEEN EmployeesProjects.StartingDate AND EmployeesProjects.EndingDate
GROUP BY  Employees.Id, Projects.Id, Employees.FirstName + '' '' + Employees.LastName,Projects.Name,Departments.Name,EmployeesProjects.StartingDate,EmployeesProjects.EndingDate
ORDER BY Employees.Id, Projects.Id'
	
EXEC (@SQLString)
END
GO
/****** Object:  Table [dbo].[CacheTable]    Script Date: 08/09/2014 17:37:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CacheTable](
	[Employee Full Name] [nvarchar](41) NOT NULL,
	[Project Name] [nvarchar](50) NOT NULL,
	[Department Name] [nvarchar](50) NOT NULL,
	[Starting Date] [date] NOT NULL,
	[Ending Date] [date] NOT NULL,
	[Reports For Project] [int] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Departments]    Script Date: 08/09/2014 17:37:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employees]    Script Date: 08/09/2014 17:37:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NOT NULL,
	[LastName] [nvarchar](20) NOT NULL,
	[YearSalary] [money] NOT NULL,
	[ManagerId] [int] NULL,
	[DepartmentId] [int] NOT NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeesProjects]    Script Date: 08/09/2014 17:37:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeesProjects](
	[EmployeeId] [int] NOT NULL,
	[ProjectId] [int] NOT NULL,
	[StartingDate] [date] NOT NULL,
	[EndingDate] [date] NOT NULL,
 CONSTRAINT [PK_EmployeesProjects] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC,
	[ProjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Projects]    Script Date: 08/09/2014 17:37:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reports]    Script Date: 08/09/2014 17:37:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reports](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[Time] [date] NOT NULL,
 CONSTRAINT [PK_Reports] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Departments_Name]    Script Date: 08/09/2014 17:37:13 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Departments_Name] ON [dbo].[Departments]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Departments] FOREIGN KEY([DepartmentId])
REFERENCES [dbo].[Departments] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Departments]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Employees] FOREIGN KEY([ManagerId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Employees]
GO
ALTER TABLE [dbo].[EmployeesProjects]  WITH CHECK ADD  CONSTRAINT [FK_EmployeesProjects_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[EmployeesProjects] CHECK CONSTRAINT [FK_EmployeesProjects_Employees]
GO
ALTER TABLE [dbo].[EmployeesProjects]  WITH CHECK ADD  CONSTRAINT [FK_EmployeesProjects_Projects] FOREIGN KEY([ProjectId])
REFERENCES [dbo].[Projects] ([Id])
GO
ALTER TABLE [dbo].[EmployeesProjects] CHECK CONSTRAINT [FK_EmployeesProjects_Projects]
GO
ALTER TABLE [dbo].[Reports]  WITH CHECK ADD  CONSTRAINT [FK_Reports_Employees] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employees] ([Id])
GO
ALTER TABLE [dbo].[Reports] CHECK CONSTRAINT [FK_Reports_Employees]
GO
ALTER TABLE [dbo].[Departments]  WITH CHECK ADD  CONSTRAINT [CK_DepartmentNameLength] CHECK  ((len([Name])>(9)))
GO
ALTER TABLE [dbo].[Departments] CHECK CONSTRAINT [CK_DepartmentNameLength]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [CK_EmployeeFirstNameLength] CHECK  ((len([FirstName])>(4)))
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [CK_EmployeeFirstNameLength]
GO
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [CK_EmployeeLastNameLength] CHECK  ((len([LastName])>(4)))
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [CK_EmployeeLastNameLength]
GO
ALTER TABLE [dbo].[Projects]  WITH CHECK ADD  CONSTRAINT [CK_ProjectNameLength] CHECK  ((len([Name])>(4)))
GO
ALTER TABLE [dbo].[Projects] CHECK CONSTRAINT [CK_ProjectNameLength]
GO
USE [master]
GO
ALTER DATABASE [Company] SET  READ_WRITE 
GO
