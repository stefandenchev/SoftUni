--01. DDL
CREATE DATABASE Bakery
--DROP DATABASE Bakery

CREATE TABLE Countries
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(50) UNIQUE
)

CREATE TABLE Customers
(
	Id INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Gender CHAR(1) CHECK (Gender in ('M','F')),
	Age INT,
	PhoneNumber CHAR(10) CHECK (LEN(PhoneNumber) = 10),
	CountryId INT REFERENCES Countries(Id)
)

CREATE TABLE Products
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(25) UNIQUE,
	[Description] NVARCHAR(250),
	Recipe NVARCHAR(MAX),
	Price DECIMAL(10,2) CHECK (Price > 0)
)

CREATE TABLE Feedbacks
(
	Id INT IDENTITY PRIMARY KEY,
	[Description] NVARCHAR(250),
	Rate DECIMAL(4,2) CHECK (Rate >= 0 AND Rate <= 10),
	ProductId INT REFERENCES Products(Id),
	CustomerId INT REFERENCES Customers(Id)
)

CREATE TABLE Distributors
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(25) UNIQUE,
	AddressText NVARCHAR(30),
	Summary NVARCHAR(200),
	CountryId INT REFERENCES Countries(Id)
)

CREATE TABLE Ingredients
(
	Id INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(30),
	[Description] NVARCHAR(200),
	OriginCountryId INT REFERENCES Countries(Id),
	DistributorId INT REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients
(
	ProductId INT REFERENCES Products(Id),
	IngredientId INT REFERENCES Ingredients(Id),
	PRIMARY KEY(ProductId, IngredientId)
)

--02. Insert
INSERT INTO Distributors ([Name], CountryId, AddressText, Summary) VALUES
('Deloitte & Touche', 2, '6 Arch St #9757', 'Customizable neutral traveling'),
('Congress Title', 13, '58 Hancock St', 'Customer loyalty'),
('Kitchen People', 1, '3 E 31st St #77', 'Triple-buffered stable delivery'),
('General Color Co Inc', 21, '6185 Bohn St #72', 'Focus group'),
('Beck Corporation', 23, '21 E 64th Ave', 'Quality-focused 4th generation hardware')

INSERT INTO Customers (FirstName, LastName, Age, Gender, PhoneNumber, CountryId) VALUES
('Francoise', 'Rautenstrauch', 15, 'M', '0195698399', 5),
('Kendra', 'Loud', 22, 'F', '0063631526', 11),
('Lourdes', 'Bauswell', 50, 'M', '0195698399', 8),
('Hannah', 'Edmison', 18, 'F', '0195698399', 1),
('Tom', 'Loeza', 31, 'M', '0195698399', 23),
('Queenie', 'Kramarczyk', 30, 'F', '0195698399', 29),
('Hiu', 'Portaro', 25, 'M', '0195698399', 16),
('Josefa', 'Opitz', 43, 'F', '0195698399', 17)

--03. Update
UPDATE Ingredients
SET DistributorId = 35
WHERE [Name] IN ('Bay Leaf', 'Paprika', 'Poppy')

UPDATE Ingredients
SET OriginCountryId = 14
WHERE OriginCountryId = 8

--04. Delete
DELETE
FROM Feedbacks
WHERE CustomerId = 14 OR ProductId = 5

--05. Products By Price
SELECT [Name], Price, [Description]
FROM Products
ORDER BY Price DESC, Name

--06. Negative Feedback
SELECT f.ProductId, f.Rate, f.[Description], f.CustomerId, c.Age, c.Gender
FROM Feedbacks f
JOIN Customers c ON c.Id = f.CustomerId
WHERE Rate < 5
ORDER BY f.ProductId DESC, Rate

--07. Customers without Feedback 3/6???
SELECT c.FirstName + ' ' + c.LastName AS CustomerName,
	   c.PhoneNumber,
	   c.Gender
FROM Customers c
LEFT JOIN Feedbacks f ON c.Id = f.CustomerId
WHERE f.Id IS NULL
ORDER BY c.Id

--08. Customers by Criteria
SELECT FirstName, Age, PhoneNumber
FROM Customers cu
JOIN Countries c ON cu.CountryId = c.Id
WHERE (FirstName LIKE '%an%' AND Age >= 21) OR (RIGHT(PhoneNumber, 2) = 38 AND c.Name !='Greece')
ORDER BY FirstName, Age DESC

--09. Middle Range Distributors 3/7??
SELECT
	d.[Name],
	i.[Name],
	p.[Name],
	AVG(f.Rate) AS AverageRate
FROM Distributors d
LEFT JOIN Ingredients i ON i.DistributorId = d.Id
LEFT JOIN ProductsIngredients pri ON pri.IngredientId = i.Id
LEFT JOIN Products p ON p.Id = pri.ProductId
LEFT JOIN Feedbacks f ON f.ProductId = p.Id
WHERE f.Rate BETWEEN 5 AND 8
GROUP BY d.[Name], i.[Name], p.[Name]
ORDER BY d.[Name], i.[Name], p.[Name]

--10. Country Representative
SELECT s.CountryName, s.DistributorName
FROM (SELECT c.Name AS CountryName, d.Name AS DistributorName, 
	DENSE_RANK() OVER(PARTITION BY c.Name ORDER BY COUNT(i.Id) DESC) AS Ranked
FROM Countries c
LEFT JOIN Distributors d ON c.Id = d.CountryId
LEFT JOIN Ingredients i ON i.DistributorId = d.Id
GROUP BY c.Name, d.Name) AS s
WHERE s.Ranked = 1



SELECT c.Name, d.Name, 
	DENSE_RANK() OVER(PARTITION BY c.Name ORDER BY COUNT(i.Id)) AS Help
FROM Countries c
LEFT JOIN Distributors d ON c.Id = d.CountryId
LEFT JOIN Ingredients i ON i.DistributorId = d.Id
GROUP BY c.Name, d.Name
ORDER BY c.[Name], d.[Name]