USE Company
GO

SELECT FirstName + ' ' + LastName AS [Full Name],
	   YearSalary AS [Year Salary]
FROM Employees
WHERE YearSalary BETWEEN 100000 AND 150000
ORDER BY YearSalary