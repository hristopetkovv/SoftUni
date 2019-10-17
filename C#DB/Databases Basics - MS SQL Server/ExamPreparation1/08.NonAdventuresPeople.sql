SELECT p.FirstName AS [First Name], p.LastName AS [Last Name], p.Age
FROM Passengers p
LEFT OUTER JOIN Tickets t
	ON t.PassengerId = p.Id
WHERE t.Id IS NULL
ORDER BY p.Age DESC, [First Name], [Last Name]