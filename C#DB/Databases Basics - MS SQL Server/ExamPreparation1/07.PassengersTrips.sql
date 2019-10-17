SELECT CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name],
		f.Origin,
		f.Destination
FROM Passengers p
INNER JOIN Tickets t
ON t.PassengerId = p.Id
INNER JOIN Flights f
ON t.FlightId = f.Id
ORDER BY [Full Name], f.Origin, f.Destination