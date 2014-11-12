USE Company
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