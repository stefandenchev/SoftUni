CREATE DATABASE Airport

--01. DDL
CREATE TABLE Planes
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	Range INT NOT NULL
)

CREATE TABLE Flights
(
	Id INT PRIMARY KEY IDENTITY,
	DepartureTime DATETIME,
	ArrivalTime DATETIME,
	Origin VARCHAR(50) NOT NULL,
	Destination VARCHAR(50) NOT NULL,
	PlaneId INT NOT NULL REFERENCES Planes(Id)
)

CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	Address VARCHAR(30) NOT NULL,
	PassportId CHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes
(
	Id INT PRIMARY KEY IDENTITY,
	Type VARCHAR(30) NOT NULL
)

CREATE TABLE Luggages
(
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT REFERENCES LuggageTypes(Id) NOT NULL,
	PassengerId INT REFERENCES Passengers(Id) NOT NULL
)

CREATE TABLE Tickets
(
	Id INT PRIMARY KEY IDENTITY,
	PassengerId INT REFERENCES Passengers(Id) NOT NULL,
	FlightId INT REFERENCES Flights(Id) NOT NULL,
	LuggageId INT REFERENCES Luggages(Id) NOT NULL,
	Price DECIMAL(18,2) NOT NULL
)

--02. Insert
INSERT INTO Planes VALUES
('Airbus 336', 112, 5132),
('Airbus 330', 432, 5325),
('Boeing 369', 231, 2355),
('Stelt 297', 254, 2143),
('Boeing 338', 165, 5111),
('Airbus 558', 387, 1342),
('Boeing 128', 345, 5541)

INSERT INTO LuggageTypes VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')

--03. Update
UPDATE Tickets
SET Price *= 1.13
WHERE FlightId = 41

--04. Delete
DELETE FROM Tickets
WHERE FlightId = 30

DELETE FROM Flights
WHERE Destination = 'Ayn Halagim'

--05. The "Tr" Planes
SELECT *
FROM Planes
WHERE Name LIKE '%tr%'
ORDER BY Id, Name, Seats, Range

--06. Flight Profits
SELECT
	f.Id,
	SUM(Price) AS Price
FROM Flights f 
JOIN Tickets t ON t.FlightId = f.Id
GROUP BY f.Id
ORDER BY Price DESC, f.Id 

--07. Passenger Trips
SELECT 
	FirstName + ' ' + LastName AS [Full Name],
	Origin,
	Destination
FROM Passengers p
JOIN Tickets t ON t.PassengerId = p.Id
JOIN Flights f ON f.Id = t.FlightId
ORDER BY [Full Name], Origin, Destination

--08. Non Adventures People
SELECT 
	FirstName,
	LastName,
	Age
FROM Passengers p
LEFT JOIN Tickets t ON t.PassengerId = p.Id
WHERE t.PassengerId IS NULL
ORDER BY Age DESC, FirstName, LastName

--09. Full Info
SELECT 
	FirstName + ' ' + LastName AS [Full Name],
	pl.Name,
	(Origin + ' - ' + Destination) AS Trip,
	lt.Type
FROM Passengers p
JOIN Tickets t ON t.PassengerId = p.Id
JOIN Luggages l ON t.LuggageId = l.Id
JOIN LuggageTypes lt ON lt.Id = l.LuggageTypeId
JOIN Flights f ON f.Id = t.FlightId
JOIN Planes pl ON pl.Id = f.PlaneId
ORDER BY [Full Name], pl.Name, Origin, Destination, lt.Type

--10. PSP
SELECT
	pl.Name,
	Seats,
	COUNT(t.Id) AS [Passengers Count]
FROM Planes pl
LEFT JOIN Flights f ON pl.Id = f.PlaneId
LEFT JOIN Tickets t ON t.FlightId = f.Id
LEFT JOIN Passengers p ON t.PassengerId = p.Id
GROUP BY pl.Name, Seats
ORDER BY [Passengers Count] DESC, pl.Name, Seats

--11. Vacation
CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(MAX)
AS
BEGIN
	IF(@peopleCount <= 0)
	BEGIN
	RETURN 'Invalid people count!'
	END

	DECLARE @tripId INT = (SELECT Id FROM
		Flights f
		WHERE Origin = @origin
		AND Destination = @destination)

	IF(@tripId IS NULL)
	RETURN 'Invalid flight!'

	DECLARE @ticketPrice DECIMAL(18,2) = (SELECT
	SUM(Price) AS Price
	FROM Flights f
	JOIN Tickets t ON t.FlightId = f.Id
	WHERE Origin = @origin
	AND Destination = @destination
	GROUP BY f.Id) * @peopleCount

	DECLARE @Result VARCHAR(50) = 'Total price ' + CONVERT(VARCHAR, @ticketPrice)

	RETURN @Result
END

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)
SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', -1)
SELECT dbo.udf_CalculateTickets('Invalid','Rancabolang', 33)

--12. Wrong Data
CREATE PROCEDURE usp_CancelFlights
AS
	UPDATE Flights
	SET ArrivalTime = NULL, DepartureTime = NULL
	WHERE ArrivalTime > DepartureTime