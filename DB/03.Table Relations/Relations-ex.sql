--01. One-To-One Relationship
CREATE TABLE Persons
(
	PersonID INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(30) NOT NULL,
	Salary DECIMAL(10,2) NOT NULL,
	PassportID INT NOT NULL
)

CREATE TABLE Passports
(
	PassportID INT PRIMARY KEY,
	PassportNumber CHAR(8) NOT NULL
)

INSERT INTO Persons VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)

INSERT INTO Passports VALUES
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')

ALTER TABLE Persons
ADD FOREIGN KEY (PassportID ) REFERENCES Passports(PassportID)

--02. One-To-Many Relationship
CREATE TABLE Models
(
	ModelID INT PRIMARY KEY,
	[Name] NVARCHAR(30) NOT NULL,
	ManufacturerID INT NOT NULL
)

CREATE TABLE Manufacturers
(
	ManufacturerID INT PRIMARY KEY,
	[Name] NVARCHAR(30) NOT NULL,
	EstablishedOn DATE NOT NULL
)

INSERT INTO Models VALUES
(101, 'X1', 1),
(102, 'i6', 1),
(103, 'Model S', 2),
(104, 'Model X', 2),
(105, 'Model 3', 2),
(106, 'Nova', 3)


INSERT INTO Manufacturers VALUES
(1, 'BMW', '07/03/1916'),
(2, 'Tesla', '01/01/2003'),
(3, 'Lada', '01/05/1966')

ALTER TABLE Models
ADD FOREIGN KEY (ManufacturerID) REFERENCES Manufacturers(ManufacturerID)

--03. Many-To-Many Relationship
CREATE TABLE Students
(
	StudentID INT PRIMARY KEY,
	[Name] VARCHAR(30)
)

CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY,
	[Name] VARCHAR(30)
)

CREATE TABLE StudentsExams (
  StudentID INT REFERENCES Students(StudentID),
  ExamID INT REFERENCES Exams(ExamID),
  PRIMARY KEY (StudentID, ExamID)
);

INSERT INTO Students VALUES
(1, 'Mila'),
(2, 'Toni'),
(3, 'Ron')

INSERT INTO Exams VALUES
(101, 'SpringMVC'),
(102, 'Neo4j'),
(103, 'Oracle 11g')

--04. Self-Referencing
CREATE TABLE Teachers
(
	TeacherID INT IDENTITY(101,1) PRIMARY KEY,
	[Name] NVARCHAR(30) NOT NULL,
	ManagerID INT
)

INSERT INTO Teachers VALUES
('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)

ALTER TABLE Teachers
ADD FOREIGN KEY (ManagerID) REFERENCES Teachers(TeacherID)

--05. Online Store Database
CREATE DATABASE OnlineStore

CREATE TABLE Orders
(
	OrderID INT PRIMARY KEY,
	CustomerID INT
)

CREATE TABLE Customers
(
	CustomerID INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	Birthday DATE,
	CityID INT
)

CREATE TABLE Cities
(
	CityID INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE OrderItems
(
	OrderID INT,
	ItemID INT,
	PRIMARY KEY(OrderID, ItemID)
)

CREATE TABLE Items
(
	ItemID INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	ItemTypeID INT,
)

CREATE TABLE ItemTypes
(
	ItemTypeID INT PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
)

ALTER TABLE Orders
ADD FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)

ALTER TABLE Customers
ADD FOREIGN KEY (CityID) REFERENCES Cities(CityID)

ALTER TABLE OrderItems
ADD FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)

ALTER TABLE OrderItems
ADD FOREIGN KEY (ItemID) REFERENCES Items(ItemID)

ALTER TABLE Items
ADD FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes(ItemTypeID)


--06. University Database
CREATE DATABASE University

CREATE TABLE Majors
(
	MajorID INT PRIMARY KEY,
	[Name] VARCHAR(50)
)

CREATE TABLE Students
(
	StudentID INT PRIMARY KEY,
	StudentNumber INT,
	StudentName VARCHAR(50),
	MajorID INT
)

CREATE TABLE Payments
(
	PaymentID INT PRIMARY KEY,
	PaymentDate DATE,
	PaymentAmount DECIMAL(10,2),
	StudentID INT
)

CREATE TABLE Subjects
(
	SubjectID INT PRIMARY KEY,
	SubjectName VARCHAR(50)
)

CREATE TABLE Agenda
(
	StudentID INT REFERENCES Students(StudentID),
	SubjectID INT REFERENCES Subjects(SubjectID),
	PRIMARY KEY(StudentID, SubjectID)
)

ALTER TABLE Students
ADD FOREIGN KEY (MajorID) REFERENCES Majors(MajorID)

ALTER TABLE Payments
ADD FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
