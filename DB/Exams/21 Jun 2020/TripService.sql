CREATE DATABASE TripService
--01. DDL
CREATE TABLE Cities
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(20) NOT NULL,
	CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(30) NOT NULL,
	CityId INT REFERENCES Cities(Id) NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(18,2)
)

CREATE TABLE Rooms
(
	Id INT IDENTITY PRIMARY KEY,
	Price DECIMAL(15,2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT REFERENCES Hotels(Id) NOT NULL
)

CREATE TABLE Trips
(
	Id INT IDENTITY PRIMARY KEY,
	RoomId INT REFERENCES Rooms(Id),
	BookDate DATE NOT NULL,
	ArrivalDate DATE NOT NULL,
	ReturnDate DATE NOT NULL,
	CancelDate DATE,
	CHECK (BookDate < ArrivalDate),
	CHECK (ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts
(
	Id INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT REFERENCES Cities(Id) NOT NULL,
	BirthDate DATE NOT NULL,
	Email VARCHAR(100) UNIQUE NOT NULL
)

CREATE TABLE AccountsTrips
(
	AccountId INT NOT NULL REFERENCES Accounts(Id),
	TripId INT NOT NULL REFERENCES Trips(Id),
	Luggage INT  NOT NULL,
	PRIMARY KEY(AccountId, TripId),
	CHECK (Luggage >= 0)
)


--02. Insert
INSERT INTO Accounts VALUES
('John', 'Smith', 'Smith', 34,	'1975-07-21', 'j_smith@gmail.com'),
('Gosho', NULL, 'Petrov',	11,	'1978-05-16',	'g_petrov@gmail.com'),
('Ivan', 'Petrovich',	'Pavlov', 59, '1849-09-26',	'i_pavlov@softuni.bg'),
('Friedrich', '	Wilhelm', '	Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg')

INSERT INTO Trips (RoomId, BookDate, ArrivalDate, ReturnDate, CancelDate)
VALUES
(101, '2015-04-12',	'2015-04-14', '2015-04-20', '2015-02-02'),
(102, '2015-07-07',	'2015-07-15', '2015-07-22', '2015-04-29'),
(103, '2013-07-17',	'2013-07-23', '2013-07-24', NULL),
(104, '2012-03-17',	'2012-03-31', '2012-04-01', '2012-01-10'),
(109, '2017-08-07', '2017-08-28', '2017-08-29', NULL)

--03. Update
UPDATE
Rooms
SET Price *= 1.14
WHERE HotelId IN (5,7,9)

--04. Delete
DELETE FROM
AccountsTrips
WHERE AccountId = 47

--05. EEE-Mails
SELECT FirstName, LastName,
	   FORMAT(BirthDate, 'MM-dd-yyyy') AS BirthDate,
	   c.Name AS Hometown,
	   Email
FROM Accounts a
JOIN Cities c ON c.Id = a.CityId
WHERE Email LIKE 'e%'
ORDER BY Hometown

--06. City Statistics
SELECT c.Name, COUNT(*) AS Hotels
FROM Cities c
JOIN Hotels h ON c.Id = h.CityId
GROUP BY c.Name
ORDER BY Hotels DESC, c.Name

--07. Longest and Shortest Trips
SELECT a.Id,
	   a.FirstName + ' ' + a.LastName AS FullName,
	   MAX(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS LongestTrip,
	   MIN(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS ShortestTrip
FROM Trips t
JOIN AccountsTrips ac ON ac.TripId = t.Id
JOIN Accounts a ON a.Id = ac.AccountId
WHERE CancelDate IS NULL AND a.MiddleName IS NULL
GROUP BY a.Id, a.FirstName, a.LastName
ORDER BY LongestTrip DESC, ShortestTrip

--08. Metropolis
SELECT TOP(10)
	c.Id,
	c.Name,
	c.CountryCode,
	COUNT(*) AS Accounts
FROM Cities c
JOIN Accounts a ON a.CityId =  c.Id
GROUP BY c.Id, c.Name, c.CountryCode
ORDER BY Accounts DESC

--09. Romantic Getaways
SELECT *
FROM Accounts a
JOIN Cities c ON a.CityId = c.Id
JOIN Hotels h ON h.CityId = c.Id
JOIN AccountsTrips ac ON ac.AccountId = a.Id
JOIN Trips t ON t.Id = ac.TripId
WHERE c.Id = h.CityId
ORDER BY a.Id
