CREATE DATABASE WMS

--01. DDL
CREATE TABLE Clients
(
	ClientId INT IDENTITY PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(12) CHECK (LEN(Phone) = 12) NOT NULL
)

CREATE TABLE Mechanics
(
	MechanicId INT IDENTITY PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(255) NOT NULL
)

CREATE TABLE Models
(
	ModelId INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Jobs
(
	JobId INT IDENTITY PRIMARY KEY,
	ModelId INT REFERENCES Models(ModelId) NOT NULL,
	[Status] VARCHAR(11) CHECK ([Status] in ('Pending','In Progress', 'Finished')) DEFAULT 'Pending' NOT NULL,
	ClientId INT REFERENCES Clients(ClientId) NOT NULL,
	MechanicId INT REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE
)

CREATE TABLE Orders
(
	OrderId INT IDENTITY PRIMARY KEY,
	JobId INT REFERENCES Jobs(JobId) NOT NULL,
	IssueDate DATE,
	Delivered BIT DEFAULT 0 NOT NULL
)

CREATE TABLE Vendors
(
	VendorId INT IDENTITY PRIMARY KEY,
	Name VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Parts
(
	PartId INT IDENTITY PRIMARY KEY,
	SerialNumber VARCHAR(50) UNIQUE NOT NULL,
	[Description] VARCHAR(255),
	Price DECIMAL(6,2) CHECK (Price > 0) NOT NULL,
	VendorId INT REFERENCES Vendors(VendorId) NOT NULL,
	StockQty INT CHECK (StockQty >= 0) DEFAULT 0
)

CREATE TABLE OrderParts
(
	OrderId INT REFERENCES Orders(OrderId),
	PartId INT REFERENCES Parts(PartId), 
	Quantity INT CHECK (Quantity > 0) DEFAULT 1 NOT NULL,
	PRIMARY KEY(OrderId, PartId)
)

CREATE TABLE PartsNeeded
(
	JobId INT REFERENCES Jobs(JobId),
	PartId INT REFERENCES Parts(PartId), 
	Quantity INT CHECK (Quantity > 0) DEFAULT 1 NOT NULL,
	PRIMARY KEY(JobId, PartId)
)

EXEC sp_changedbowner 'sa'

--02. Insert
INSERT INTO Clients VALUES
('Teri', 'Ennaco', '570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie', 'Mconnell', '908-802-3564'),
('Lemuel', 'Latzke', '631-748-6479'),
('Melodie', 'Knipp', '805-690-1682'),
('Candida', 'Corbley', '908-275-8357')

INSERT INTO Parts (SerialNumber, [Description], Price, VendorId)
VALUES
('WP8182119', 'Door Boot Seal', 117.86, 2),
('W10780048', 'Suspension Rod', 42.81, 1),
('W10841140', 'Silicone Adhesive ', 6.77, 4),
('WPY055980', 'High Temperature Adhesive', 13.94, 3)

--03. Update
UPDATE Jobs
SET MechanicId = 3, [Status] = 'In Progress'
WHERE [Status] = 'Pending'

--04. Delete
DELETE FROM OrderParts
WHERE OrderId = 19

DELETE FROM Orders
WHERE OrderId = 19

--05. Mechanic Assignments
SELECT FirstName + ' ' + LastName AS Mechanic,
	   j.[Status],
	   j.IssueDate
FROM Mechanics m
JOIN Jobs j ON m.MechanicId = j.MechanicId
ORDER BY m.MechanicId, IssueDate, j.JobId

--06. Current Clients
SELECT FirstName + ' ' + LastName AS Client,
	   DATEDIFF(DAY, IssueDate, '2017-04-24') AS [Days going],
	   [Status]
FROM Clients c
JOIN Jobs j ON c.ClientId = j.ClientId
WHERE j.[Status] != 'Finished'
ORDER BY [Days going] DESC, c.ClientId

--07. Mechanic Performance
SELECT FirstName + ' ' + LastName AS Mechanic,
	   AVG(DATEDIFF(DAY, IssueDate, FinishDate)) AS [Average Days]
FROM Mechanics m
JOIN Jobs j ON m.MechanicId = j.MechanicId
GROUP BY FirstName, LastName, m.MechanicId
ORDER BY m.MechanicId

--08. Available Mechanics??
SELECT FirstName + ' ' + LastName AS Available
FROM Mechanics m
LEFT JOIN Jobs j ON m.MechanicId = j.MechanicId
WHERE [Status] = 'Finished'
GROUP BY j.Status, FirstName, LastName, m.MechanicId
ORDER BY m.MechanicId

--09. Past Expenses??? ???Invalid object name 'PartsNeeded'.???
SELECT j.JobId, SUM(Price) AS Total
FROM Jobs j
	JOIN PartsNeeded pn ON j.JobId = pn.JobId
	JOIN Parts p ON pn.PartId = p.PartId
WHERE j.Status = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC, j.JobId

--10. Missing Parts?????
SELECT *
FROM Parts p
	LEFT JOIN PartsNeeded pn ON pn.PartId = p.PartId
	LEFT JOIN Jobs j ON j.JobId = pn.JobId
	LEFT JOIN Orders o ON o.JobId = j.JobId
	LEFT JOIN OrderParts op ON op.OrderId = o.OrderId
WHERE j.Status != 'Finished'
ORDER BY p.PartId

--11. Place Order???
CREATE PROCEDURE usp_PlaceOrder(@jobID INT, @partSN INT, @quantity INT)
AS

--12. Cost of Order  ???Invalid object name 'PartsNeeded'.???
CREATE FUNCTION udf_GetCost(@jobID INT)
RETURNS DECIMAL(6,2)
AS
BEGIN
	DECLARE @Result DECIMAL(6,2)
	SET @Result = (SELECT SUM(Price) AS Total
	FROM Jobs j
		JOIN PartsNeeded pn ON j.JobId = pn.JobId
		JOIN Parts p ON pn.PartId = p.PartId
		WHERE j.JobId = @jobID
	GROUP BY j.JobId)
	RETURN @Result
END

SELECT dbo.udf_GetCost(3)


