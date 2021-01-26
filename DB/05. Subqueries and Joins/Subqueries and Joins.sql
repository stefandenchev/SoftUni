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


	