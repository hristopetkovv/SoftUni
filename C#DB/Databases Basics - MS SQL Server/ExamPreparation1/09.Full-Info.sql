SELECT CONCAT(p.FirstName, ' ', p.LastName) AS [Full Name],
			pl.[Name] AS [Plane Name],
			CONCAT(f.Origin, ' - ', f.Destination) AS [Trip],
			lt.Type AS [Luggage Type]
FROM Passengers p
INNER JOIN Tickets t
	ON t.PassengerId = p.Id
INNER JOIN Flights f
	ON t.FlightId = f.Id
INNER JOIN Planes pl
	ON f.PlaneId = pl.Id
INNER JOIN Luggages l
	ON t.LuggageId = l.Id
INNER JOIN LuggageTypes lt
	ON l.LuggageTypeId = lt.Id
ORDER BY [Full Name], [Plane Name], f.Origin, f.Destination, [Luggage Type]
