SELECT wd.DepositGroup, SUM(wd.DepositAmount) AS [TotalAmount]
FROM WizzardDeposits AS wd
WHERE	wd.MagicWandCreator = 'Ollivander family'
GROUP BY wd.DepositGroup