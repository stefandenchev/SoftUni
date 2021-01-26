-- SoftUni DB
--01. Find Names of All Employees by First Name
SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'SA%'

--02. Find Names of All Employees by Last Name
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'

--03. Find First Names of All Employess
SELECT FirstName
FROM Employees
WHERE DepartmentID IN (3, 10) AND
YEAR(HireDate) BETWEEN 1995 AND 2005

--04. Find All Employees Except Engineers
SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

--05. Find Towns with Name Length
SELECT Name
FROM Towns
WHERE LEN(Name) IN (5,6)
ORDER BY Name

--06. Find Towns Starting With
SELECT *
FROM Towns
WHERE Name LIKE '[MKBE]%'
ORDER BY Name

--WHERE Name LIKE 'M%'
--   OR Name LIKE 'K%'
--   OR Name LIKE 'B%'
--   OR Name LIKE 'E%'

--07. Find Towns Not Starting With
SELECT *
FROM Towns
WHERE Name NOT LIKE '[RBD]%'
ORDER BY Name

--08. Create View Employees Hired After
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
FROM Employees
WHERE YEAR(HireDate) > 2000

--09. Length of Last Name
SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5

--10. Rank Employees by Salary
SELECT EmployeeID, FirstName, LastName, Salary,
DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC 

--11. Find All Employees with Rank 2 (not included in final score)
SELECT * FROM
(   SELECT EmployeeID, FirstName, LastName, Salary,
		DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000
) AS [T]
WHERE [Rank] = 2
ORDER BY Salary DESC

-- Geography DB
--12. Countries Holding 'A'
SELECT CountryName, IsoCode
FROM Countries
WHERE CountryName LIKE '%a%a%a%'
ORDER BY IsoCode

--13. Mix of Peak and River Names
/*SELECT p.PeakName,
	   r.RiverName,
	   LOWER(STUFF(p.PeakName, LEN(p.PeakName), LEN(r.RiverName), r.RiverName)) AS Mix
FROM Peaks p
JOIN Rivers r ON p.Id = p.Id
WHERE RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
ORDER BY Mix
*/
SELECT PeakName,
	   RiverName,
	   LOWER(LEFT(PeakName, LEN(PeakName) - 1) +RiverName) AS Mix
FROM Peaks, Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY Mix

-- Diablo DB
--14. Games From 2011 and 2012 Year
SELECT TOP(50) Name, FORMAT(Start, 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE YEAR(Start) IN (2011, 2012)
ORDER BY Start, Name

--15. User Email Providers
SELECT Username,
	   RIGHT(Email, LEN(Email) - CHARINDEX('@', Email)) AS [Email Provider]
FROM Users
ORDER BY [Email Provider], Username

--16. Get Users with IPAddress Like Pattern
SELECT Username, IpAddress
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

--17. Show All Games with Duration
SELECT
	Name,
	[Part of the Day] =
	CASE 
		WHEN DATEPART(hour, Start) BETWEEN 0 AND 11 THEN 'Morning'
		WHEN DATEPART(hour, Start) BETWEEN 12 AND 17 THEN 'Afternoon' 
		WHEN DATEPART(hour, Start) BETWEEN 18 AND 24 THEN 'Evening'  
	END,
	CASE 
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short' 
		WHEN Duration > 6 THEN 'Long' 
		ELSE 'Extra Long'
	END AS Duration
FROM Games
ORDER BY [Name], Duration

--Date Functions 
--18. Orders Table
CREATE TABLE Orders
(
	Id INT IDENTITY PRIMARY KEY,
	ProductName NVARCHAR(50) NOT NULL,
	OrderDate DATETIME2 NOT NULL
)

INSERT INTO Orders VALUES
('Butter', '2016-09-19'),
('Milk', '2016-09-30'),
('Cheese', '2016-09-04'),
('Bread', '2015-12-20'),
('Tomatoes', '2015-12-30')

SELECT ProductName, OrderDate,
	[Pay Date] = DATEADD(DAY, 3, OrderDate),
	[Deliver Due]  = DATEADD(MONTH, 1, OrderDate)
FROM Orders

--19. People Table
CREATE TABLE People2
(
	Id INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL,
	Birthdate DATETIME2 NOT NULL
)

INSERT INTO People2 VALUES
('Victor', '2000-12-07'),
('Steven', '1992-09-10'),
('Stephen', '1910-09-19'),
('John', '2010-01-06')

SELECT [Name],
	   [Age in Years] = DATEDIFF(YEAR, Birthdate, GETDATE()),
	   [Age in Months] = DATEDIFF(MONTH, Birthdate, GETDATE()),
	   [Age in Days] = DATEDIFF(DAY, Birthdate, GETDATE()),
	   [Age in Minutes] = DATEDIFF(MINUTE, Birthdate, GETDATE())
FROM People2
ORDER BY [Age in Months] DESC

--Experiment
DELETE FROM People2

INSERT INTO People2 VALUES
('Stefan', '1998-10-20'),
('Valeri', '1998-07-13'),
('Ivan', '1998-08-26'),
('Kevin', '1998-12-17'),
('Maria_B', '1999-09-30'),
('Maria_D', '1999-06-23'),
('Irena', '2001-08-25')