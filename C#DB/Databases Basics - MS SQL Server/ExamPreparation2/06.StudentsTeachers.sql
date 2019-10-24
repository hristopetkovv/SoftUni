SELECT s.FirstName, s.LastName, COUNT(st.TeacherId) AS [TeachersCount]
FROM Students s
LEFT OUTER JOIN StudentsTeachers st
	ON st.StudentId = s.Id
GROUP BY s.FirstName, s.LastName