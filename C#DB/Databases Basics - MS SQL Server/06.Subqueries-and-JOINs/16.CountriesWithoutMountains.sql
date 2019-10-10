SELECT COUNT(*) - COUNT(mc.MountainId) AS [CountryCode]
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode