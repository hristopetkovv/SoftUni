SELECT FirstName
FROM Employees
WHERE DepartmentID = 3 or DepartmentID = 10
AND YEAR(HireDate) BETWEEN 1995 AND 2005