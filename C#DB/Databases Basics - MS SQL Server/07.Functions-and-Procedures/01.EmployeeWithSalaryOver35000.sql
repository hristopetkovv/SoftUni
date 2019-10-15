CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
SELECT e.FirstName,
		e.LastName
FROM Employees e
WHERE Salary > 35000