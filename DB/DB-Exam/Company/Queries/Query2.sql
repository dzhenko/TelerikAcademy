USE Company
GO

SELECT Departments.Name AS [Department Name],
	   Count(*) AS [Employees Count]
FROM Departments
INNER JOIN Employees
	ON Departments.Id = Employees.DepartmentId
GROUP BY Departments.Name
ORDER BY [Employees Count] DESC