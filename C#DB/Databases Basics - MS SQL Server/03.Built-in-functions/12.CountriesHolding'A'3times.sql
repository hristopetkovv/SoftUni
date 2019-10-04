SELECT CountryName as [Country Name],
		IsoCode as [ISO Code]
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode