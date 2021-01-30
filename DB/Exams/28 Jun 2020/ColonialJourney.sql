CREATE DATABASE ColonialJourney
DROP DATABASE ColonialJourney

--01. DDL
CREATE TABLE Planets
(
	Id INT IDENTITY PRIMARY KEY,
	Name VARCHAR(30) NOT NULL
)

CREATE TABLE Spaceports
(
	Id INT IDENTITY PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	PlanetId INT NOT NULL REFERENCES Planets(Id)
)

CREATE TABLE Spaceships
(
	Id INT IDENTITY PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	LightSpeedRate INT DEFAULT 0
)

CREATE TABLE Colonists
(
	Id INT IDENTITY PRIMARY KEY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Ucn VARCHAR(10) UNIQUE NOT NULL,
	BirthDate DATE NOT NULL
)

CREATE TABLE Journeys
(
	Id INT IDENTITY PRIMARY KEY,
	JourneyStart DATETIME NOT NULL,
	JourneyEnd DATETIME NOT NULL,
	Purpose VARCHAR(11) NOT NULL,
	DestinationSpaceportId INT NOT NULL REFERENCES Spaceports(Id),
	SpaceshipId INT NOT NULL REFERENCES Spaceships(Id)
)

CREATE TABLE TravelCards
(
	Id INT IDENTITY PRIMARY KEY,
	CardNumber CHAR(10) NOT NULL,
	JobDuringJourney VARCHAR(8),
	ColonistId INT NOT NULL REFERENCES Colonists(Id),
	JourneyId INT NOT NULL REFERENCES Journeys(Id)
)

--02. Insert
INSERT INTO Planets VALUES
('Mars'),
('Earth'),
('Jupiter'),
('Saturn')

INSERT INTO Spaceships VALUES
('Golf', 'VW', 3),
('WakaWaka', 'Wakanda', 4),
('Falcon9', 'SpaceX', 1),
('Bed', 'Vidolov', 6)

--03. Update
UPDATE Spaceships
SET LightSpeedRate += 1
WHERE Id BETWEEN 8 AND 12

--04. Delete?????
DELETE FROM TravelCards
WHERE JourneyId BETWEEN 1 AND 3

DELETE TOP(3) FROM Journeys

--05. Select All Military Journeys
SELECT Id, FORMAT(JourneyStart, 'dd/MM/yyyy'), FORMAT(JourneyEnd, 'dd/MM/yyyy')
FROM Journeys
WHERE Purpose = 'Military'
ORDER BY JourneyStart

--6. Select all pilots
SELECT c.Id, FirstName + ' ' + LastName AS [full_name]
FROM Colonists c
JOIN TravelCards t ON c.Id = t.ColonistId
WHERE t.JobDuringJourney = 'Pilot'
ORDER BY c.Id

SELECT * FROM COLONISTS

--07. Count Colonists
SELECT COUNT(*) AS [Count]
FROM Colonists c
JOIN TravelCards t ON c.Id = t.ColonistId
JOIN Journeys j ON t.JourneyId = j.Id
WHERE j.Purpose = 'Technical'

--08. Select Spaceships With Pilots
SELECT s.[Name], s.Manufacturer
FROM Colonists c
JOIN TravelCards t ON c.Id = t.ColonistId
JOIN Journeys j ON t.JourneyId = j.Id
JOIN Spaceships s ON j.SpaceshipId = s.Id
WHERE (c.BirthDate) > '1989-01-01' AND JobDuringJourney = 'Pilot'
ORDER BY s.[Name]

--09. Planets And Journeys
SELECT p.[Name], COUNT(*) AS JourneysCount 
FROM Planets p
RIGHT JOIN Spaceports s ON s.PlanetId = p.Id
RIGHT JOIN Journeys j ON j.DestinationSpaceportId = s.Id
GROUP BY p.[Name]
ORDER BY JourneysCount DESC, p.[Name]

--10. Select Special Colonists
