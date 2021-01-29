--01. Records� Count
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
SELECT 
	CASE
	  WHEN w.Age BETWEEN 0 AND 10 THEN '[0-10]'
	  WHEN w.Age BETWEEN 11 AND 20 THEN '[11-20]'
	  WHEN w.Age BETWEEN 21 AND 30 THEN '[21-30]'
	  WHEN w.Age BETWEEN 31 AND 40 THEN '[31-40]'
	  WHEN w.Age BETWEEN 41 AND 50 THEN '[41-50]'
	  WHEN w.Age BETWEEN 51 AND 60 THEN '[51-60]'
	  WHEN w.Age >= 61 THEN '[61+]'
	END AS [AgeGroup],
COUNT(*) AS [WizardCount]
	FROM WizzardDeposits AS w
GROUP BY
	CASE
	  WHEN w.Age BETWEEN 0 AND 10 THEN '[0-10]'
	  WHEN w.Age BETWEEN 11 AND 20 THEN '[11-20]'
	  WHEN w.Age BETWEEN 21 AND 30 THEN '[21-30]'
	  WHEN w.Age BETWEEN 31 AND 40 THEN '[31-40]'
	  WHEN w.Age BETWEEN 41 AND 50 THEN '[41-50]'
	  WHEN w.Age BETWEEN 51 AND 60 THEN '[51-60]'
	  WHEN w.Age >= 61 THEN '[61+]'
	END

--10. First Letter
SELECT DISTINCT LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY FirstName

--11. Average Interest
SELECT *
FROM WizzardDeposits

SELECT DepositGroup, IsDepositExpired, AVG(DepositInterest)
FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

--*12. Rich Wizard, Poor Wizard
SELECT *
FROM WizzardDeposits

SELECT
	FirstName AS [Host Wizard],
	DepositAmount AS [Host Wizard Deposit],
	LEAD(FirstName, 1, 0)
	OVER(PARTITION BY FirstName ORDER BY FirstName) AS [Guest Wizard]
	--LEAD(DepositAmount) AS [Guest Wizard Deposit],
	--LEAD(DepositAmount) - DepositAmount AS [Difference]
FROM WizzardDeposits

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
SELECT DepartmentID, Salary
FROM Employees
ORDER BY DepartmentID, Salary DESC

SELECT DepartmentId, Salary
FROM(
SELECT DepartmentID, Salary
FROM Employees) as a
ORDER BY DepartmentID, Salary DESC

SELECT TOP(3) DepartmentId, Salary FROM
(SELECT DepartmentId, Salary 
FROM Employees 
GROUP BY DepartmentId, Salary
) AS K
ORDER BY Salary DESC

--*19. Salary Challenge
SELECT FirstName, LastName, DepartmentID
FROM Employees
WHERE Salary > AVG(Salary)