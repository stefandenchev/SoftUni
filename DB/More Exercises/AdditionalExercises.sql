--DIABLO DB
--1. Number of Users for Email Provider
SELECT 
	 RIGHT(Email, LEN(Email) - CHARINDEX('@', email)) AS Domain,
	 COUNT(*) AS [Number Of Users]
FROM Users
GROUP BY RIGHT(Email, LEN(Email) - CHARINDEX('@', email))
ORDER BY [Number Of Users] DESC, Domain

--02. All Users in Games
SELECT 
	g.Name,
	gt.Name,
	u.Username,
	ug.Level,
	ug.Cash,
	c.Name
FROM Users u
JOIN UsersGames ug ON ug.UserId = u.Id
JOIN Games g ON g.Id = ug.GameId
JOIN GameTypes gt ON gt.Id = g.GameTypeId
JOIN Characters c ON c.Id = ug.CharacterId
ORDER BY Level DESC, Username, g.Name

--03. Users in Games with Their Items
SELECT
	u.Username,
	g.Name AS Game,
	COUNT(i.Id) AS [Items Count],
	SUM(i.Price) AS [Items Price]
FROM Users u
JOIN UsersGames ug ON ug.UserId = u.Id
JOIN UserGameItems ugi ON ugi.UserGameId = ug.Id
JOIN Items i ON ugi.ItemId = i.Id
JOIN Games g ON g.Id = ug.GameId
GROUP BY u.Username, g.Name
HAVING COUNT(i.Id) >= 10
ORDER BY [Items Count] DESC, [Items Price] DESC, Username

--05. All Items with Greater than Average Statistics
--nope

--SELECT *
--FROM (SELECT
--	i.Name,
--	s.Strength AS Strength,
--	s.Defence AS Defence,
--	s.Speed AS Speed,
--	s.Luck AS Luck,
--	s.Mind AS Mind
--FROM Items i
--JOIN [Statistics] s ON s.Id = i.StatisticId) AS st
--HAVING Mind > AVG(st.Mind)

--06. Display All Items about Forbidden Game Type

