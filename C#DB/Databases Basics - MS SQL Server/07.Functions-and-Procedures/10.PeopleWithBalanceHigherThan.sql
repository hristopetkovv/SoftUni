CREATE PROC usp_GetHoldersWithBalanceHigherThan (@Amount DECIMAL(28, 2))
AS
SELECT ah.FirstName,
		ah.LastName
FROM AccountHolders ah
INNER JOIN Accounts a
ON a.AccountHolderId = ah.Id
GROUP BY ah.FirstName,
		ah.LastName
HAVING SUM(a.Balance) > @Amount
ORDER BY ah.FirstName
