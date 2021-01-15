--CREATE DATABASE SoftUni

CREATE TABLE Towns
(
	Id INT PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Addresses 
(
	Id INT PRIMARY KEY,
	AddressText NVARCHAR(50) NOT NULL,
	TownId INT NOT NULL
)

CREATE TABLE Departments 
(
	Id INT PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees  
(
	Id INT PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	JobTitle NVARCHAR(50) NOT NULL,
	DepartmentId INT NOT NULL,
	HireDate DATETIME2 NOT NULL,
	Salary DECIMAL(10,2) NOT NULL,
	AddressId INT
)

DROP TABLE Employees

INSERT INTO Towns VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna'),
(4, 'Burgas')

INSERT INTO Departments VALUES
(1, 'Engineering'),
(2, 'Sales'),
(3, 'Marketing'),
(4, 'Software Development'),
(5, 'Quality Assurance')

INSERT INTO Employees VALUES
(1, 'Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '02/01/2013', 3500.00, NULL),
(2, 'Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '03/02/2004', 4000.00, NULL),
(3, 'Maria', 'Petrova', 'Ivanova', 'Intern', 5, '08/28/2016', 525.25, NULL),
(4, 'Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '12/09/2007', 3000.00, 4),
(5, 'Peter', 'Pan', 'Pan', 'Intern', 3, '08/28/2016', 599.88, 5)

SELECT * FROM Towns
ORDER BY [Name] ASC

SELECT * FROM Departments
ORDER BY [Name] ASC

SELECT * FROM Employees
ORDER BY Salary DESC

----------------------

SELECT [Name] FROM Towns
ORDER BY [Name] ASC

SELECT [Name] FROM Departments
ORDER BY [Name] ASC

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC

----------------------

UPDATE Employees
SET Salary *= 1.1

SELECT Salary FROM Employees