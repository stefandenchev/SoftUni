CREATE DATABASE Movies

CREATE TABLE Directors
(
	Id INT PRIMARY KEY,
	DirectorName NVARCHAR(90) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors VALUES
(1, 'Stefan', 'Mega dumb'),
(2, 'Valeri', NULL),
(3, 'Ivan', NULL),
(4, 'Maria', NULL),
(5, 'Kevin', NULL)

CREATE TABLE Genres
(
	Id INT PRIMARY KEY,
	GenreName NVARCHAR(90) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Genres VALUES
(1, 'Horror', 'Spoopy stuff'),
(2, 'Comedy', 'hehe xd'),
(3, 'Action', NULL),
(4, 'Adventure', NULL),
(5, 'Fantasy', NULL)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY,
	CategoryName NVARCHAR(90) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Categories VALUES
(1, 'Epic', 'amazing'),
(2, 'Stuff', 'next level creativity'),
(3, 'I got', NULL),
(4, 'No freakin', NULL),
(5, 'Idea', NULL)

CREATE TABLE Movies
(
	Id INT PRIMARY KEY,
	Title NVARCHAR(90) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear DATETIME2 NOT NULL,
	[Length] INT NOT NULL,
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating INT NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Movies VALUES
(1, 'The fellowship of the ring', 1, '2001', 180, 5, 5, 10, 'No need'),
(2, 'The two towers', 1, '2002', 181, 5, 5, 10, 'No need'),
(3, 'The return of the king', 1, '2003', 182, 5, 5, 10, 'No need'),
(4, 'Inception', 2, '2010', 160, 4, 3, 10, NULL),
(5, 'The dark knight', 3, '2008', 165, 3, 2, 10, 'Ledger <3')

