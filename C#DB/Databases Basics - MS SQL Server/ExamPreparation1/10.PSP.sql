SELECT p.[Name], p.Seats, COUNT(t.Id) AS [Passengers Count]
FROM Planes p
LEFT OUTER JOIN Flights f
	ON f.PlaneId = p.Id
LEFT OUTER JOIN Tickets t
	ON t.FlightId = f.Id
GROUP BY p.[Name], p.Seats
ORDER BY [Passengers Count] DESC, p.Name, p.Seats
