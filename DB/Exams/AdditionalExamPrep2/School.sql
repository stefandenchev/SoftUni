--01. DDL
CREATE TABLE Students
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(25),
	LastName NVARCHAR(30) NOT NULL,
	Age SMALLINT CHECK (Age >= 0),
	Address NVARCHAR(50),
	Phone NCHAR(10)
)

CREATE TABLE Subjects
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(20) NOT NULL,
	Lessons INT CHECK (Lessons > 0) NOT NULL
)

CREATE TABLE StudentsSubjects
(
	Id INT PRIMARY KEY IDENTITY,
	StudentId INT NOT NULL REFERENCES Students(Id),
	SubjectId INT NOT NULL REFERENCES Subjects(Id),
	Grade DECIMAL(18,2) CHECK (Grade BETWEEN 2 AND 6) NOT NULL
)

CREATE TABLE Exams
(
	Id INT PRIMARY KEY IDENTITY,
	Date DATETIME,
	SubjectId INT NOT NULL REFERENCES Subjects(Id)
)

CREATE TABLE StudentsExams
(
	StudentId INT NOT NULL REFERENCES Students(Id),
	ExamId INT NOT NULL REFERENCES Exams(Id),
	Grade DECIMAL(18,2) CHECK (Grade BETWEEN 2 AND 6) NOT NULL
	PRIMARY KEY(StudentId, ExamId)
)

CREATE TABLE Teachers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Address NVARCHAR(20) NOT NULL,
	Phone NCHAR(10),
	SubjectId INT NOT NULL REFERENCES Subjects(Id)
)

CREATE TABLE StudentsTeachers
(
	StudentId INT NOT NULL REFERENCES Students(Id),
	TeacherId INT NOT NULL REFERENCES Teachers(Id),
	PRIMARY KEY(StudentId, TeacherId)
)

--02. Insert
INSERT INTO Teachers VALUES
('Ruthanne', 'Bamb', '84948 Mesta Junction', '3105500146', 6),
('Gerrard', 'Lowin', '370 Talisman Plaza', '3324874824', 2),
('Merrile', 'Lambdin', '81 Dahle Plaza', '4373065154', 5),
('Bert', 'Ivie', '2 Gateway Circle', '4409584510', 4)

INSERT INTO Subjects VALUES
('Geometry', 12),
('Health', 10),
('Drama', 7),
('Sports', 9)

--03. Update
UPDATE StudentsSubjects
SET Grade = 6
WHERE SubjectId IN (1, 2) AND Grade >= 5.5

--04. Delete
DELETE st
FROM StudentsTeachers st
JOIN Teachers t
  ON t.Id = st.TeacherId
WHERE Phone LIKE '%72%'

DELETE FROM Teachers
WHERE Phone LIKE '%72%'

--05. Teen Students
SELECT 
	FirstName,
	LastName,
	Age
FROM Students
WHERE Age >= 12
ORDER BY FirstName, LastName

--06. Students Teachers
SELECT 
	s.FirstName,
	s.LastName,
	COUNT(t.Id) AS TeachersCount
FROM Students s
JOIN StudentsTeachers st ON s.Id = st.StudentId
JOIN Teachers t ON t.Id = st.TeacherId
GROUP BY s.FirstName, s.LastName

--07. Students to Go
SELECT 
	s.FirstName + ' ' + s.LastName AS [Full Name]
FROM Students s
LEFT JOIN StudentsExams se ON se.StudentId = s.Id
LEFT JOIN Exams e ON se.ExamId = e.Id
WHERE se.ExamId IS NULL
ORDER BY [Full Name]

--08. Top Students
SELECT TOP(10)
	s.FirstName,
	s.LastName,
	CAST(AVG(se.Grade) AS DECIMAL(6,2)) AS Grade
FROM Students s
LEFT JOIN StudentsExams se ON se.StudentId = s.Id
LEFT JOIN Exams e ON se.ExamId = e.Id
GROUP BY s.FirstName, s.LastName
ORDER BY Grade DESC, FirstName, LastName

--09. Not So In The Studying
SELECT REPLACE(CONCAT(FirstName + ' ', MiddleName + ' ', LastName + ' '),'  ',' ') AS [Full Name]
FROM Students s
LEFT JOIN StudentsSubjects ss ON ss.StudentId = s.Id
LEFT JOIN Subjects su ON ss.SubjectId = su.Id
WHERE ss.SubjectId IS NULL
ORDER BY FirstName

--10. Average Grade per Subject
SELECT res.Name, res.AverageGrade
FROM (SELECT
	su.Id,
	su.Name,
	AVG(Grade) AS AverageGrade
FROM Students s
JOIN StudentsSubjects ss ON ss.StudentId = s.Id
JOIN Subjects su ON ss.SubjectId = su.Id
GROUP BY su.Name, su.id) AS res
ORDER BY res.Id

--11. Exam Grades
CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT , @grade DECIMAL(4,2))
RETURNS VARCHAR(MAX)
AS
BEGIN

	DECLARE @studentToFind INT = (SELECT Id
						FROM Students
						WHERE Id = @studentId)

	IF(@studentToFind IS NULL)
	RETURN 'The student with provided id does not exist in the school!'

	DECLARE @studentName VARCHAR(20) = (SELECT FirstName
										FROM Students
										WHERE Id = @studentId)

	IF(@grade > 6)
	RETURN 'Grade cannot be above 6.00!'

	DECLARE @gradeCount INT = (SELECT COUNT(Grade)
						FROM Students s
						JOIN StudentsSubjects ss ON ss.StudentId = s.Id
						JOIN Subjects su ON ss.SubjectId = su.Id
						WHERE Grade > @grade AND Grade <= @grade + 0.5 AND StudentId = @studentId)

	DECLARE @Result VARCHAR(MAX) = 'You have to update ' + CAST(@gradeCount AS nvarchar(10)) + ' grades for the student ' + @studentName

	RETURN @Result
END


SELECT dbo.udf_ExamGradesToUpdate(12, 6.20)
SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)
SELECT dbo.udf_ExamGradesToUpdate(121, 5.50)

--12. Exclude From School
CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
	DECLARE @studentToFind INT = (SELECT Id
						FROM Students
						WHERE Id = @studentId)

	IF(@studentToFind IS NULL)
	BEGIN
	RAISERROR('This school has no student with the provided id!', 16, 1)
	RETURN
	END

	DELETE FROM StudentsExams
	WHERE StudentId = @StudentId

	DELETE FROM StudentsSubjects
	WHERE StudentId = @StudentId

	DELETE FROM StudentsTeachers
	WHERE StudentId = @StudentId

	DELETE FROM Students
	WHERE Id = @StudentId

	EXEC usp_ExcludeFromSchool 1

	SELECT COUNT(*) FROM Students








