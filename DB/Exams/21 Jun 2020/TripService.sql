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
JOIN Accounts a ON a.CityId = c.Id
GROUP BY c.Id, c.Name, c.CountryCode
ORDER BY Accounts DESC

--09. Romantic Getaways
SELECT 
	a.Id,
	a.Email,
	c.Name,
	COUNT(*) AS Trips
FROM AccountsTrips ac
JOIN Accounts a ON ac.AccountId = a.Id
JOIN Cities c ON a.CityId = c.Id
JOIN Trips t ON t.Id = ac.TripId
JOIN Rooms r ON r.Id = t.RoomId
JOIN Hotels h ON r.HotelId = h.Id
WHERE c.Id = h.CityId
GROUP BY a.Id, a.Email, c.Name
ORDER BY Trips DESC, a.Id

--10. GDPR Violation
SELECT 
	t.Id,
	a.FirstName + ' ' + + ISNULL(a.MiddleName + ' ', '') + a.LastName AS [Full Name],
	c.Name AS [From],
	hc.Name AS [To],
	CASE
		WHEN t.CancelDate IS NULL THEN CONVERT(NVARCHAR, DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) + ' days'
		ELSE 'Canceled'
	END AS Duration
FROM AccountsTrips ac
JOIN Accounts a ON ac.AccountId = a.Id
JOIN Cities c ON a.CityId = c.Id
JOIN Trips t ON t.Id = ac.TripId
JOIN Rooms r ON r.Id = t.RoomId
JOIN Hotels h ON r.HotelId = h.Id
JOIN Cities hc ON hc.Id = h.CityId
ORDER BY [Full Name], t.Id

--11. Available Room
CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(MAX)
BEGIN
	DECLARE @RoomInfo VARCHAR(MAX) = (SELECT TOP(1) 'Room ' + CONVERT(VARCHAR, r.Id) + ': ' + r.Type + ' (' + CONVERT(VARCHAR, r.Beds) + ' beds) - $' + CONVERT(VARCHAR, (BaseRate + Price) * @People)
	FROM Rooms r
	JOIN Hotels h ON h.Id = r.HotelId
	WHERE Beds >= @People AND HotelId = @HotelId AND
		NOT EXISTS (SELECT * FROM Trips t WHERE t.RoomId = r.Id
											AND CancelDate IS NULL 
											AND @Date BETWEEN ArrivalDate AND ReturnDate)
	ORDER BY (BaseRate + Price) * @People DESC)

	IF (@RoomInfo IS NULL) RETURN 'No rooms available'
	RETURN @RoomInfo
END

SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)
SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)

--12. Switch Room
CREATE PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
	DECLARE @TripHotelId INT = (SELECT r.HotelId
	FROM Trips t
	JOIN Rooms r ON t.RoomId = r.Id
	WHERE t.Id = @TripId)

	DECLARE @TargetRoomHotelId INT = (SELECT HotelId FROM Rooms
													 WHERE Id = @TargetRoomId)

	IF (@TripHotelId != @TargetRoomHotelId)
		THROW 50001, 'Target room is in another hotel!', 1

	DECLARE @TripAccounts INT = (SELECT COUNT(*) FROM AccountsTrips WHERE TripId = @TripId);
	DECLARE @TargetRoomBeds INT = (SELECT Beds FROM Rooms WHERE Id = @TargetRoomId)
	
	IF (@TripAccounts > @TargetRoomBeds)
		THROW 50002, 'Not enough beds in target room!', 1

	UPDATE Trips
	SET RoomId = @TargetRoomId WHERE Id = @TripId
	

EXEC usp_SwitchRoom 10, 11
SELECT RoomId FROM Trips WHERE Id = 10
EXEC usp_SwitchRoom 10, 7
EXEC usp_SwitchRoom 10, 8
