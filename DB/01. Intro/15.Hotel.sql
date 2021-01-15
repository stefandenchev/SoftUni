--CREATE DATABASE Hotel
--USE Hotel

CREATE TABLE Employees
(
	Id INT PRIMARY KEY,
	FirstName VARCHAR(90) NOT NULL,
	LastName VARCHAR(90) NOT NULL,
	Title VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Employees
(Id, FirstName, LastName, Title, Notes) VALUES
(1, 'Gosho', 'Goshev', 'CEO', NULL),
(2, 'Petyr', 'Petrov', 'CFO', 'notes n stuff'),
(3, 'Tosho', 'Toshev', 'CTO', NULL)

CREATE TABLE Customers
(
	AccountNumber INT PRIMARY KEY,
	FirstName VARCHAR(90) NOT NULL,
	LastName VARCHAR(90) NOT NULL,
	PhoneNumber CHAR(10) NOT NULL,
	EmergencyName VARCHAR(90) NOT NULL,
	EmergencyNumber CHAR(90) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Customers
VALUES
(120, 'I', 'T', '123456789', 'T', '987654321', NULL),
(121, 'S', 'D', '123456789', 'Q', '232332311', NULL),
(122, 'V', 'B', '123456789', 'T', '987654321', NULL)

CREATE TABLE RoomStatus
(
	RoomStatus VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO RoomStatus VALUES
('Cleaning', NULL),
('Free', NULL),
('Not free', NULL)

CREATE TABLE RoomTypes
(
	RoomType VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO RoomTypes VALUES
('Apartment', NULL),
('One Bedroom', NULL),
('Two Bedroom', NULL)

CREATE TABLE BedTypes
(
	BedType VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO BedTypes VALUES
('Single', NULL),
('Double', NULL),
('Child', NULL)

CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY,
	RoomType VARCHAR(20) NOT NULL,
	BedType VARCHAR(20) NOT NULL,
	Rate INT,
	RoomStatus VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Rooms VALUES
(120, 'Apartment', 'Single', 10, 'Free', NULL),
(121, 'One Bedroom', 'Double', 23, 'Not free', NULL),
(122, 'Two Bedroom', 'Child', 11, 'Free', NULL)

CREATE TABLE Payments
(
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	PaymentDate DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATETIME NOT NULL,
	LastDateOccupied DATETIME NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharged DECIMAL(15,2),
	TaxRate DECIMAL(15,2),
	TaxAmount INT,
	PaymentTotal DECIMAL(15,2),
	Notes VARCHAR(MAX)
)

INSERT INTO Payments VALUES
(1, 1, GETDATE(), 120, 5/5/2012, 5/8/2012, 3, 450.23, 20.20, NULL, 450.23, NULL),
(2, 1, GETDATE(), 120, 1/5/2012, 5/10/2012, 3, 45.93, 23.23, NULL, 450.23, NULL),
(3, 1, GETDATE(), 120, 5/8/2012, 5/11/2012, 3, 458.13, 10, NULL, 457.23, NULL)


CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	DateOccupied DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied INT,
	PhoneCharge DECIMAL(15,2),
	Notes VARCHAR(MAX)
)

INSERT INTO Occupancies VALUES
(1, 120, GETDATE(), 120, 120, 0, 0, NULL),
(2, 121, GETDATE(), 121, 123, 0, 0, NULL),
(3, 122, GETDATE(), 125, 129, 0, 0, NULL)

EXEC sp_changedbowner 'sa'

-----p.23-----
UPDATE Payments
SET TaxRate *= 0.97

SELECT TaxRate FROM Payments

-----p.24-----
DELETE FROM Occupancies



