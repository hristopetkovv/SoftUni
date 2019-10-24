SELECT CONCAT(s.FirstName, ' ', s.LastName) AS [Full Name]
FROM Students s
LEFT OUTER JOIN StudentsExams se
	ON se.StudentId = s.Id
WHERE se.ExamId IS NULL
ORDER BY [Full Name]