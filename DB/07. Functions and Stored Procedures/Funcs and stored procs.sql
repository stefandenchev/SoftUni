--01. Employees with Salary Above 35000
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary > 35000

--EXEC usp_GetEmployeesSalaryAbove35000

--02. Employees with Salary Above Number
CREATE PROC usp_GetEmployeesSalaryAboveNumber (@NUM DECIMAL(18,4))
AS
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary >= @NUM

--03. Town Names Starting With
CREATE PROC usp_GetTownsStartingWith (@INPUT NVARCHAR(50))
AS
	SELECT [Name] AS Town
	FROM Towns
	WHERE [Name] LIKE @INPUT + '%'

--EXEC usp_GetTownsStartingWith b

--04. Employees from Town
CREATE PROC usp_GetEmployeesFromTown (@INPUT NVARCHAR(50))
AS
	SELECT FirstName, LastName
	FROM Employees e
	JOIN Addresses a ON e.AddressID = a.AddressID
	JOIN Towns t ON a.TownID = t.TownID
	WHERE t.[Name] = @INPUT

--exec usp_GetEmployeesFromTown Sofia
	
--05. Salary Level Function
CREATE FUNCTION ufn_GetSalaryLevel(@Salary MONEY)
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @result VARCHAR(20)

	IF @Salary < 30000
		SET @result = 'Low'
	ELSE IF @Salary <= 50000
		SET @result = 'Average'
	ELSE
		SET @result = 'High'
	RETURN @result
END

--06. Employees by Salary Level
CREATE PROC usp_EmployeesBySalaryLevel(@levelOfSalary VARCHAR(20))
AS
	SELECT FirstName,
		   LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @levelOfSalary

EXEC usp_EmployeesBySalaryLevel 'Average'

--07. Define Function
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50)) 
RETURNS BIT
BEGIN
DECLARE @count INT = 1

WHILE(@count <= LEN(@word))
BEGIN
	DECLARE @currentLetter CHAR(1) = SUBSTRING(@word, @count, 1)

		IF CHARINDEX(@currentLetter, @setOfLetters) = 0
		RETURN 0
	SET @count += 1
END
	RETURN 1
END

--08. Delete Employees and Departments
CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT NULL

	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

	UPDATE Employees
	SET ManagerID = NULL
	WHERE EmployeeID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT EmployeeID FROM Employees WHERE DepartmentID = @departmentId)

	UPDATE Departments
	SET ManagerID = NULL
	WHERE DepartmentID = @departmentId

	DELETE FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*) FROM Employees WHERE DepartmentID = @departmentId

--09. Find Full Name
CREATE PROC usp_GetHoldersFullName
AS
	SELECT FirstName + ' ' + LastName AS [Full Name]
	FROM AccountHolders

EXEC usp_GetHoldersFullName

--10. People with Balance Higher Than
CREATE PROC usp_GetHoldersWithBalanceHigherThan(@amount DECIMAL(15,2))
AS
	SELECT FirstName, LastName
	FROM AccountHolders ah
	JOIN Accounts a ON ah.Id = a.AccountHolderId
	GROUP BY FirstName, LastName
	HAVING SUM(Balance) > @amount
	ORDER BY FirstName, LastName

exec usp_GetHoldersWithBalanceHigherThan 2000

--11. Future Value Function
CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(15,2), @yearlyRate FLOAT, @years INT)
RETURNS DECIMAL(15,4)
BEGIN
	DECLARE @Result DECIMAL(15,4)
	SET @Result = (@sum * POWER((1 + @yearlyRate), @years))
	RETURN @Result
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5)

--12. Calculating Interest
CREATE PROCEDURE usp_CalculateFutureValueForAccount (@accountId INT, @interestRate FLOAT)
AS
SELECT a.Id,
	   ah.FirstName,
	   ah.LastName,
	   a.Balance,
	   dbo.ufn_CalculateFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
	FROM AccountHolders ah
	JOIN Accounts a ON a.AccountHolderId = ah.Id
	WHERE a.Id = @accountId

EXEC usp_CalculateFutureValueForAccount 1, 0.1

--13. *Cash in User Games Odd Rows
CREATE FUNCTION ufn_CashInUsersGames (@gameName VARCHAR(100))
RETURNS TABLE
AS
	RETURN (SELECT SUM(k.TotalCash) AS TotalCash
FROM (SELECT Cash AS TotalCash,
		ROW_NUMBER() OVER (ORDER BY Cash DESC) AS RowNumber
	FROM Games g
	JOIN UsersGames ug ON ug.GameId = g.Id
	WHERE Name = @gameName) AS k
WHERE k.RowNumber % 2 = 1)

SELECT * FROM ufn_CashInUsersGames('Love in a mist')

--21. Employees with Three Projects
CREATE PROC usp_AssignProject(@EmployeeId INT, @ProjectId INT)
AS
	DECLARE @EmployeesProjects INT =
		(SELECT COUNT (*) FROM EmployeesProjects
			WHERE EmployeeId = @EmployeeId)

	IF (@EmployeesProjects >= 3)
		THROW 50001, 'Employee has more than 3 projects', 1

	--DECLARE @EmployeesInThisProjectCount INT =
	--	(SELECT COUNT (*) FROM EmployeesProjects
	--		WHERE EmployeeId = @EmployeeId
	--			AND ProjectId = @ProjectId)

	--IF (@EmployeesInThisProjectCount > 1)
	--	THROW 50002, 'Employee already in this project', 1

	INSERT INTO EmployeesProjects (EmployeeID, ProjectID)
		VALUES (@EmployeeId, @ProjectID)



