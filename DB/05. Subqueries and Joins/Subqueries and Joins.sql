--SoftUni DB
--01. Employee Address
SELECT TOP(5)
	EmployeeID, JobTitle, e.AddressID, a.AddressText
FROM Employees e
JOIN Addresses a ON e.AddressID = a.AddressID
ORDER BY AddressID

--02. Addresses with Towns
SELECT TOP(50)
	   e.FirstName AS [First Name],
	   e.LastName AS [Last Name],
	   t.Name as Town,
	   a.AddressText
	FROM Employees e
	LEFT JOIN Addresses a ON e.AddressID = a.AddressID
	LEFT JOIN Towns t ON a.TownID = t.TownID
	ORDER BY [First Name], [Last Name]

--03. Sales Employees
SELECT e.EmployeeID,
	   e.FirstName,
	   e.LastName,
	   d.[Name]
	FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE d.Name = 'Sales'
	ORDER BY EmployeeID

--04. Employee Departments
SELECT TOP(5)
	EmployeeID, FirstName, Salary, d.Name AS [DepartmentName]
FROM Employees e
JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE Salary > 15000
ORDER BY e.DepartmentID

--05. Employees Without Projects
SELECT TOP(3)
	e.EmployeeID, e.FirstName
FROM Employees e
LEFT JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
LEFT JOIN Projects p ON ep.ProjectID = p.ProjectID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID

--06. Employees Hired After
SELECT e.FirstName,
	   e.LastName,
	   e.HireDate,
	   d.[Name] AS [DeptName]
	FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE e.HireDate > '1999-01-01' AND
	d.Name IN ('Sales', 'Finance')
	--(d.Name = 'Sales' OR d.Name = 'Finance')
	ORDER BY HireDate

--07. Employees With Project
SELECT TOP(5)
	e.EmployeeID, e.FirstName, p.Name AS [ProjectName]
FROM Employees e
LEFT JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
LEFT JOIN Projects p ON ep.ProjectID = p.ProjectID
WHERE P.StartDate > '2002-08-13'
ORDER BY e.EmployeeID

--08. Employee 24
SELECT
	e.EmployeeID,
	e.FirstName,
	p.Name AS [ProjectName]
FROM Employees e
LEFT JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
LEFT JOIN Projects p ON ep.ProjectID = p.ProjectID AND p.StartDate < '2005'
WHERE e.EmployeeID = 24

--09. Employee Manager
SELECT
	e.EmployeeID,
	e.FirstName,
	e.ManagerID,
	m.FirstName
FROM Employees e
LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN (3, 7)
ORDER BY EmployeeID

--10. Employees Summary
SELECT TOP(50) 
	e.EmployeeID,
	e.FirstName + ' ' + e.LastName AS EmployeeName,
	m.FirstName + ' ' + m.LastName AS ManagerName,
	d.Name AS DepartmentName
FROM Employees e
	LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID
	LEFT JOIN Departments D ON e.DepartmentID = D.DepartmentID
ORDER BY e.EmployeeID

--11. Min Average Salary
SELECT TOP(1)
	(SELECT AVG(Salary) 
		FROM Employees
		WHERE DepartmentID = d.DepartmentID) AS MinAverageSalary
FROM Departments d
ORDER BY MinAverageSalary

--SAME AS:
SELECT TOP(1)
	AVG(Salary) AS [Avg] FROM Employees
	GROUP BY DepartmentID
	ORDER BY [Avg]

--Geography DB
--12. Highest Peaks in Bulgaria
SELECT 
	c.CountryCode,
	m.MountainRange,
	p.PeakName,
	p.Elevation
FROM Countries c
JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
JOIN Mountains m ON mc.MountainId = m.Id
JOIN Peaks p ON m.Id = p.MountainId
WHERE c.CountryName = 'Bulgaria' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--13. Count Mountain Ranges
SELECT
	c.CountryCode,
	COUNT(c.CountryCode) AS [MountainRanges]
FROM Countries c
JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
WHERE c.CountryName IN ('United States', 'Russia', 'Bulgaria')
GROUP BY c.CountryCode

--14. Countries With or Without Rivers
SELECT TOP(5)
	c.CountryName,
	r.RiverName
FROM Countries c
LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers r ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

--15. Continents and Currencies
SELECT ContinentCode, CurrencyCode, Total
FROM (
SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS Total,
	DENSE_RANK() OVER(PARTITION BY ContinentCode ORDER BY COUNT(CurrencyCode) DESC) AS Ranked
FROM Countries c
GROUP BY ContinentCode, CurrencyCode) AS K
	WHERE Ranked = 1 AND Total > 1
ORDER BY ContinentCode

--16.Countries Without Any Mountains
SELECT COUNT(*) AS [Count]
	FROM Countries c
	LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
	WHERE mc.MountainId IS NULL

--17. Highest Peak and Longest River by Country
SELECT TOP(5)
	c.CountryName,
	MAX(p.Elevation) AS [HighestPeakElevation],
	MAX(r.Length) AS [LongestRiverLength]
FROM Countries c
LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains m ON mc.MountainId = m.Id
LEFT JOIN Peaks p ON m.Id = p.MountainId
LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers r ON cr.RiverId = r.Id
	GROUP BY c.CountryName
	ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, c.CountryName

--18. Highest Peak Name and Elevation by Country
SELECT TOP(5) k.Country, k.[Highest Peak Name], k.[Highest Peak Elevation], k.Mountain
FROM (SELECT
	c.CountryName AS [Country],
	ISNULL(p.PeakName, '(no highest peak)') AS [Highest Peak Name],
	ISNULL(MAX(p.Elevation), 0) AS [Highest Peak Elevation],
	ISNULL(m.MountainRange, '(no mountain)') AS [Mountain],
	DENSE_RANK() OVER(PARTITION BY CountryName ORDER BY MAX(p.Elevation) DESC) AS Ranked
FROM Countries c
LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains m ON mc.MountainId = m.Id
LEFT JOIN Peaks p ON m.Id = p.MountainId
	GROUP BY c.CountryName, p.PeakName, m.MountainRange) AS k
WHERE Ranked = 1
ORDER BY Country, [Highest Peak Name]