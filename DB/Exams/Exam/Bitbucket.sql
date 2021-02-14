--01. DDL
CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	Password VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors
(
	RepositoryId INT REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT REFERENCES Users(Id) NOT NULL
	PRIMARY KEY(RepositoryId, ContributorId)
)

CREATE TABLE Issues
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(255) NOT NULL,
	IssueStatus CHAR(6) NOT NULL,
	RepositoryId INT REFERENCES Repositories(Id) NOT NULL,
	AssigneeId INT REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Commits
(
	Id INT PRIMARY KEY IDENTITY,
	Message VARCHAR(255) NOT NULL,
	IssueId INT REFERENCES Issues(Id),
	RepositoryId INT REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(100) NOT NULL,
	Size DECIMAL(18,2) NOT NULL,
	ParentId INT REFERENCES Files(Id),
	CommitId INT REFERENCES Commits(Id) NOT NULL
)

--02. Insert
INSERT INTO Files VALUES
('Trade.idk', 2598.0, 1 , 1),
('menu.net', 9238.31, 2 , 2),
('Administrate.soshy', 1246.93, 3 , 3),
('Controller.php', 7353.15, 4 , 4),
('Find.java', 9957.86, 5 , 5),
('Controller.json', 14034.87, 3 , 6),
('Operate.xix', 7662.92, 7 , 7)

INSERT INTO Issues VALUES
('Critical Problem with HomeController.cs file', 'open', 1 , 4),
('Typo fix in Judge.html', 'open', 4 , 3),
('Implement documentation for UsersService.cs', 'closed', 8 , 2),
('Unreachable code in Index.cs', 'open', 9 , 8)

--03. Update
UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6

--04. Delete
DELETE FROM RepositoriesContributors
WHERE RepositoryId = 3

DELETE FROM Files
WHERE Id = 36

DELETE FROM Commits
WHERE RepositoryId = 3

DELETE FROM Issues
WHERE RepositoryId = 3

DELETE FROM Repositories
WHERE Name = 'Softuni-Teamwork'

--05. Commits
SELECT Id, Message, RepositoryId, ContributorId
FROM Commits
ORDER BY Id, Message, RepositoryId, ContributorId

--06. Front-end
SELECT Id, Name, Size
FROM Files
WHERE Size > 1000 AND Name LIKE '%html%'
ORDER BY Size DESC, Id, Name

--07. Issue Assignment
SELECT
	i.Id,
	U.Username + ' : ' + i.Title AS IssueAssignee
FROM Issues i
JOIN Users u ON i.AssigneeId = u.Id
ORDER BY i.Id DESC, i.AssigneeId

--08. Single Files
--Select all of the files, which are NOT a parent to any other file.

SELECT
	f2.Id,
	f2.Name,
	CONVERT(VARCHAR, f2.Size) + 'KB' AS Size
FROM Files f
RIGHT JOIN Files f2 ON f2.Id = f.ParentId
WHERE f.ParentId IS NULL
ORDER BY f.Id, f.Name, f.Size

--09. Commits in Repositories
SELECT TOP(5)
	r.Id,
	r.Name,
	COUNT(rc.ContributorId) AS Commits
FROM Commits c
	JOIN Repositories r ON r.Id = c.RepositoryId
	JOIN RepositoriesContributors rc ON rc.RepositoryId = r.Id
	GROUP BY r.Id, r.Name
	ORDER BY Commits DESC, r.Id, r.Name

--10. Average Size
SELECT
	Username,
	AVG(Size) AS Size
FROM Users u
	JOIN Commits c ON u.Id = c.ContributorId
	JOIN Files f ON f.CommitId = c.Id
GROUP BY Username
ORDER BY Size DESC

--11. All User Commits
CREATE OR ALTER FUNCTION udf_AllUserCommits(@username VARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @result INT = (SELECT
							COUNT(c.Id) AS Commits
						   FROM Users u
						   	JOIN Commits c ON c.ContributorId = u.Id
						   WHERE u.Username = @username
						   GROUP BY u.Username)
	IF(@result IS NULL)
	RETURN 0

	RETURN @result
END

SELECT dbo.udf_AllUserCommits('Tosho')

--12. Search for Files
CREATE PROC usp_SearchForFiles(@fileExtension VARCHAR(50))
AS
	SELECT
		Id,
		Name,
		CONVERT(VARCHAR, Size) + 'KB' AS Size
	FROM Files
	WHERE RIGHT(Name, LEN(Name) - CHARINDEX('.', Name)) = @fileExtension
	--WHERE Name LIKE '%.txt'

	EXEC usp_SearchForFiles 'txt'

