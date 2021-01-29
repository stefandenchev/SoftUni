--01. Records’ Count
SELECT COUNT(*) AS Count
FROM WizzardDeposits

--02. Longest Magic Wand
SELECT MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits

--03. Longest Magic Wand per Deposit Groups
SELECT DepositGroup, MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup

--*04. Smallest Deposit Group per Magic Wand Size
SELECT TOP(2) DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

--05. Deposits Sum
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
GROUP BY DepositGroup

--06. Deposits Sum for Ollivander Family
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

--07. Deposits Filter
SELECT DepositGroup, SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

--08. Deposit Charge
SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

--09. Age Groups
SELECT Result.AgeGroup, COUNT(Result.AgeGroup)
FROM (
SELECT 
	CASE
	  WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
	  WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
	  WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
	  WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
	  WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
	  WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
	  WHEN Age >= 61 THEN '[61+]'
	END AS AgeGroup
	FROM WizzardDeposits) AS Result
GROUP BY Result.AgeGroup

--10. First Letter
SELECT DISTINCT LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY FirstName

--11. Average Interest
SELECT *
FROM WizzardDeposits

SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

--*12. Rich Wizard, Poor Wizard
SELECT *
FROM WizzardDeposits

SELECT
	SUM(Host.DepositAmount - Guest.DepositAmount) AS [Difference]
FROM WizzardDeposits AS Host
JOIN WizzardDeposits AS Guest ON Host.Id = Guest.Id - 1

--same with LEAD
SELECT SUM(k.[Difference]) AS [Difference]
	FROM (SELECT DepositAmount - LEAD(DepositAmount, 1) OVER (ORDER BY Id) AS [Difference]
FROM WizzardDeposits) AS k

--13. Departments Total Salaries
SELECT
	DepartmentID, SUM(Salary) AS TotalSalary
	FROM Employees
	GROUP BY DepartmentID
	ORDER BY DepartmentID

--same but with name
SELECT
	d.Name, SUM(Salary) AS TotalSalary
	FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	GROUP BY d.Name
	ORDER BY TotalSalary DESC

--14. Employees Minimum Salaries
SELECT DepartmentID, MIN(Salary) AS MinimumSalary
FROM Employees
WHERE DepartmentID IN (2, 5, 7) AND HireDate > '2000-01-01'
GROUP BY DepartmentID

--15. Employees Average Salaries
SELECT *
INTO EmplAbove30k
FROM Employees
WHERE Salary > 30000

DELETE
FROM EmplAbove30k
WHERE ManagerID = 42

UPDATE EmplAbove30k
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary
FROM EmplAbove30k
GROUP BY DepartmentID

--16. Employees Maximum Salaries
SELECT DepartmentID, MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--17. Employees Count Salaries
SELECT COUNT(*) AS [Count]
FROM Employees
WHERE ManagerID IS NULL

--18*. 3rd Highest Salary
SELECT DISTINCT k.DepartmentID, k.Salary AS ThirdHighestSalary
FROM (SELECT DepartmentID, Salary, DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY SALARY DESC) AS [Ranked]
FROM Employees) AS k
WHERE k.Ranked = 3

--*19. Salary Challenge
SELECT TOP(10) FirstName, LastName, DepartmentID
FROM Employees AS emp
WHERE Salary > (SELECT AVG(Salary)
			   FROM Employees
			   WHERE DepartmentID = emp.DepartmentID)

