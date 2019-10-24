SELECT TOP 10 s.FirstName, s.LastName, CAST(AVG(se.Grade) AS DECIMAL(3, 2)) AS [Grade]
FROM Students s
INNER JOIN StudentsExams se
	ON se.StudentId = s.Id
GROUP BY s.FirstName, s.LastName
ORDER BY [Grade] DESC, FirstName, LastName