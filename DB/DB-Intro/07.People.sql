CREATE TABLE People
(
	Id INT PRIMARY KEY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture IMAGE,
	Height DECIMAL(4,2),
	[Weight] DECIMAL(4,2),
	Gender NCHAR NOT NULL,
	Birthdate DATETIME2 NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People VALUES
(1, 'Stefan', NULL, 1.78, 83.2, 'M', '10/20/1998', 'Mega dumb'),
(2, 'Valeri', NULL, 1.88, 76.7, 'M', '7/13/1998', NULL),
(3, 'Ivan', NULL, 1.78, 85.1, 'M', '8/26/1998', NULL),
(4, 'Kevin', NULL, 1.78, 77.3, 'M', '12/17/1998', NULL),
(5, 'Maria', NULL, 1.69, 53.1, 'F', '9/30/1998', NULL)

SELECT * FROM People
WHERE Gender = 'F'