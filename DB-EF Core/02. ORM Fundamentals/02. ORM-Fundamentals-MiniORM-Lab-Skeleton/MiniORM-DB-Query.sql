CREATE DATABASE MiniORM
GO

USE MiniORM
GO

CREATE TABLE Projects
(
	Id INT IDENTITY PRIMARY KEY,
	NAME VARCHAR(50) NOT NULL
)

CREATE TABLE Departments
(
	Id INT IDENTITY PRIMARY KEY,
	NAME VARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	Id INT IDENTITY PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50),
	LastName VARCHAR(50) NOT NULL,
	IsEmployed BIT NOT NULL,
	DepartmentId INT REFERENCES Departments(Id)
)

CREATE TABLE EmployeesProjects
(
	ProjectId INT NOT NULL REFERENCES Projects(Id),
	EmployeeId INT NOT NULL REFERENCES Employees(Id),
	PRIMARY KEY(ProjectId, EmployeeId)
)
GO

INSERT INTO MiniORM.dbo.Departments (Name) VALUES ('Research');

INSERT INTO MiniORM.dbo.Employees(FirstName, MiddleName, LastName, IsEmployed, DepartmentId) VALUES
('Stamat', NULL, 'Ivanov', 1, 1),
('Petar', 'Ivanov', 'Petrov', 0, 1),
('Ivan', 'Petrov', 'Georgiev', 1, 1),
('Gosho', NULL, 'Ivanov', 1, 1)

INSERT INTO MiniORM.dbo.Projects(Name)
VALUES ('C# Project'), ('Java Project');

INSERT INTO MiniORM.dbo.EmployeesProjects(ProjectId, EmployeeId) VALUES
(1, 1),
(1, 3),
(2, 2),
(2, 3)