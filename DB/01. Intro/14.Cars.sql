CREATE DATABASE CarRental

CREATE TABLE Categories
(
	Id INT PRIMARY KEY,
	CategoryName NVARCHAR(25) NOT NULL,
	DailyRate DECIMAL(10,2) NOT NULL,
	WeeklyRate DECIMAL(10,2) NOT NULL,
	MonthlyRate DECIMAL(10,2) NOT NULL,
	WeekendRate DECIMAL(10,2) NOT NULL
)

INSERT INTO Categories VALUES
(1, 'Sports', 30, 180, 650, 100),
(2, 'Muscle', 40, 160, 700, 120),
(3, 'Karuca', 100, 700, 3000, 250)

CREATE TABLE Cars 
(
	Id INT PRIMARY KEY,
	PlateNumber NVARCHAR(25) NOT NULL,
	Manufacturer NVARCHAR(25) NOT NULL,
	Model NVARCHAR(25) NOT NULL,
	CarYear DATETIME2 NOT NULL,
	CategoryId INT NOT NULL,
	Doors INT NOT NULL,
	Picture IMAGE,
	Condition NVARCHAR(25) NOT NULL,
	Available BIT NOT NULL
)

INSERT INTO Cars VALUES
(1, 'OB2323AM', 'Lada', 'Niva', '1970', 2, 4, NULL, 'As new', 0),
(2, 'Cyberpunk', 'Byrzobeg', '9000', '2077', 1, 2, NULL, 'Fix the damn game', 1),
(3, 'OB2f4sd65fM', 'Konq', 'Vihyr', '2012', 3, 1, NULL, 'The new modification', 0)

CREATE TABLE Employees 
(
	Id INT PRIMARY KEY,
	FirstName NVARCHAR(25) NOT NULL,
	LastName NVARCHAR(25) NOT NULL,
	Title NVARCHAR(25) NOT NULL,
	Notes NVARCHAR(MAX)	
)

INSERT INTO Employees VALUES
(1, 'Stefan', 'Denchev', 'Idiot', 'Hopeless'),
(2, 'Bojidar', 'Trendafilov', 'CEO', NULL),
(3, 'Chaika', 'Belejkova', 'Professor', NULL)

CREATE TABLE Customers  
(
	Id INT PRIMARY KEY,
	DriverLicenceNumber NVARCHAR(25) NOT NULL,
	FullName NVARCHAR(50) NOT NULL,
	[Address] NVARCHAR(100) NOT NULL,
	City NVARCHAR(50) NOT NULL,	
	ZIPCode NVARCHAR(10) NOT NULL,
	Notes NVARCHAR(MAX)	
)

INSERT INTO Customers VALUES
(1, '123asd321', 'Stefan Denchev', 'Osymska', 'Lovech', '5500', 'Idiot'),
(2, '12jgh3asd321', 'KK', 'Pod mosta', 'Lovech', '5501', NULL),
(3, '123asd32jhg1', 'DV', 'V mosta', 'Lovech', '5502', NULL)

CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	CustomerId INT NOT NULL,
	CarId INT NOT NULL,
	TankLevel INT NOT NULL,	
	KilometrageStart INT NOT NULL,
	KilometrageEnd INT NOT NULL,
	TotalKilometrage INT NOT NULL,
	StartDate DATETIME2 NOT NULL,
	EndDate DATETIME2 NOT NULL,
	TotalDays INT NOT NULL,
	RateApplied DECIMAL(10,2) NOT NULL,
	TaxRate DECIMAL(10,2) NOT NULL,
	OrderStatus NVARCHAR(20) NOT NULL,
	Notes NVARCHAR(MAX)	
)

INSERT INTO RentalOrders VALUES
(1, 1, 1, 1, 90, 5000, 5100, 100, '10/20/2100', '10/21/2100', 1, 200, 20, 'Active', NULL),
(2, 23, 23, 23, 91, 5001, 5102, 101, '10/21/2100', '10/26/2100', 5, 201, 23, 'Nah', NULL),
(3, 35, 35, 36, 90, 5000, 5100, 100, '10/20/2100', '10/21/2100', 1, 200, 20, 'asdfopjh', NULL)
