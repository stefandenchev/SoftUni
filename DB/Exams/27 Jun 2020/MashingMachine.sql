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
	[Status] VARCHAR(11) DEFAULT 'Pending' CHECK ([Status] in ('Pending','In Progress', 'Finished')) NOT NULL,
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
	Quantity INT DEFAULT 1 CHECK (Quantity > 0) NOT NULL,
	PRIMARY KEY(OrderId, PartId)
)

CREATE TABLE PartsNeeded
(
	JobId INT REFERENCES Jobs(JobId) NOT NULL,
	PartId INT REFERENCES Parts(PartId) NOT NULL, 
	Quantity INT DEFAULT 1 CHECK (Quantity > 0) NOT NULL,
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
GROUP BY m.MechanicId, FirstName, LastName
ORDER BY m.MechanicId

--08. Available Mechanics??
SELECT CONCAT(FirstName,' ',LastName) AS Available
       FROM Mechanics m
  LEFT JOIN Jobs j ON j.MechanicId = m.MechanicId
     WHERE  j.JobId IS NULL 
            OR 'Finished' = ALL(SELECT j.[Status]
                                FROM Jobs j  
                                WHERE j.MechanicId = m.MechanicId)    
   GROUP BY FirstName,LastName,m.MechanicId
   ORDER BY m.MechanicId

--09. Past Expenses
SELECT j.JobId, ISNULL(SUM(p.Price * op.Quantity), 0) AS Total
FROM Jobs j
	LEFT JOIN Orders o ON o.JobId = j.JobId
	LEFT JOIN OrderParts op ON op.OrderId = o.OrderId
	LEFT JOIN Parts p ON p.PartId = op.PartId
WHERE j.Status = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC, j.JobId

--10. Missing Parts
SELECT
	p.PartId,
	p.Description,
	pn.Quantity AS Required,
	p.StockQty AS [In Stock],
	IIF(o.Delivered = 0, op.Quantity, 0) AS Ordered
FROM Parts p
	LEFT JOIN PartsNeeded pn ON pn.PartId = p.PartId
	LEFT JOIN Jobs j ON j.JobId = pn.JobId
	LEFT JOIN Orders o ON o.JobId = j.JobId
	LEFT JOIN OrderParts op ON op.PartId = p.PartId --op.OrderId = o.OrderId
WHERE j.Status != 'Finished' AND p.StockQty + IIF(o.Delivered = 0, op.Quantity, 0) < pn.Quantity
ORDER BY p.PartId

SELECT p.PartId,p.[Description],
          SUM(pn.Quantity) AS [Required],
          SUM(p.StockQty) AS [IN Stock], 0 AS Ordered
     FROM Jobs j
FULL JOIN Orders o ON j.JobId = o.JobId
     JOIN PartsNeeded pn ON pn.JobId = j.JobId
     JOIN Parts p ON p.PartId = pn.PartId
    WHERE j.STATUS <> 'Finished' AND o.Delivered IS NULL
 GROUP BY p.PartId,p.Description
   HAVING SUM(p.StockQty) < SUM(pn.Quantity) 

--11. Place Order???
CREATE PROCEDURE usp_PlaceOrder(@jobID INT, @partSN VARCHAR(50), @quantity INT)
AS
	DECLARE @status VARCHAR(10) = (SELECT Status FROM Jobs WHERE JobId = @jobID)
	DECLARE @partId INT = (SELECT PartId FROM Parts WHERE SerialNumber = @partSN)

	IF (@quantity <= 0)
		THROW 50012, 'Part quantity must be more than zero!', 1
	ELSE IF (@status IS NULL)
		THROW 50013, 'Job not found!', 1
	ELSE IF (@status = 'Finished')
		THROW 50011, 'This job is not active!', 1
	ELSE IF (@jobID IS NULL)
		THROW 50014, 'Part not found!', 1

	DECLARE @orderId INT = (SELECT OrderId
							FROM Orders
							WHERE JobId = @jobID AND IssueDate IS NULL)

IF (@orderId IS NULL)
BEGIN
	INSERT INTO Orders (JobId, IssueDate) VALUES (@jobID, NULL)
END

SET @orderId = (SELECT OrderId FROM Orders
				WHERE JobId = @jobID AND IssueDate IS NULL)
DECLARE @orderPartExists INT = (SELECT OrderId FROM OrderParts WHERE OrderId = @orderId AND PartId = @partId)

IF (@orderPartExists IS NULL)
BEGIN
	INSERT INTO OrderParts (OrderId, PartId, Quantity) VALUES
	(@orderId, @partId, @quantity)
END

ELSE
BEGIN
		UPDATE OrderParts
		SET Quantity += @quantity
		WHERE OrderId = @orderId AND PartId = @partId
END


--ANOTHER SOLUTION

CREATE PROC usp_PlaceOrder @JobId INT, @SerialNumber VARCHAR(50),@Quantity INT
 AS
--- Limitations -------  
IF NOT EXISTS (SELECT JobId FROM Jobs WHERE JobId = @JobId) 
    THROW 50013, 'Job not found!' , 1
ELSE
    DECLARE @JobStatus VARCHAR(11) = (SELECT [STATUS] FROM Jobs WHERE JobId = @JobId)
 
IF @JobStatus = 'Finished'
    THROW 50011, 'This job is not active!', 1
 
IF NOT EXISTS (SELECT PartId FROM Parts WHERE SerialNumber = @SerialNumber)
    THROW 50014, 'Part not found!' , 1
ELSE
     DECLARE @PartId INT = (SELECT PartId FROM Parts WHERE SerialNumber = @SerialNumber)
 
IF @Quantity <= 0 
    THROW 50012, 'Part quantity must be more than zero!', 1
 
DECLARE @OrderId INT
---- if order already exists ---------
IF EXISTS (SELECT OrderId FROM Orders WHERE JobId=@JobId AND IssueDate IS NULL)
    BEGIN
    SET @OrderId =(SELECT TOP(1) OrderId FROM Orders WHERE JobId=@JobId AND 
                            IssueDate IS NULL) 
    ----- if the part not in that existing order -------- 
    IF NOT EXISTS (SELECT PartId FROM OrderParts 
                    WHERE OrderId = @OrderId AND PartId = @PartId)
        BEGIN 
        INSERT INTO OrderParts (OrderId,PartId,Quantity)
            VALUES (@OrderId, @PartId, @Quantity)
        END
    ELSE
     ----- if the part already in the order --------------
        BEGIN
        UPDATE OrderParts
        SET Quantity +=@Quantity
        WHERE OrderId = @OrderId AND PartId = @PartId
        END
    END
----- order not exists ----------
ELSE
    BEGIN
        INSERT INTO Orders (JobId,IssueDate)
                VALUES (@JobId,NULL)
        SET @OrderId = (SELECT OrderId FROM Orders
                          WHERE JobId = @JobId AND IssueDate IS NULL)
        INSERT INTO OrderParts (OrderId,PartId,Quantity)
        VALUES (@OrderId, @PartId,@Quantity)
    END



--12. Cost of Order  ???Invalid object name 'PartsNeeded'.???
CREATE FUNCTION udf_GetCost(@jobID INT)
RETURNS DECIMAL(6,2)
AS
BEGIN
	DECLARE @Result DECIMAL(6,2)
	SET @Result = (SELECT SUM(Price * op.Quantity) AS Total
		FROM Jobs j
			LEFT JOIN Orders o ON o.JobId = j.JobId
			LEFT JOIN OrderParts op ON op.OrderId = o.OrderId
			LEFT JOIN Parts p ON p.PartId = op.PartId
		WHERE j.JobId = @jobID
	GROUP BY j.JobId)

	IF(@Result IS NULL)
	SET @Result = 0

	RETURN @Result
END

SELECT dbo.udf_GetCost(3)


