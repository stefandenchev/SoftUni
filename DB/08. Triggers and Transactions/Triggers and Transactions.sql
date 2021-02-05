--14. Create Table Logs
CREATE TABLE Logs
(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT,
	OldSum DECIMAL(10,2),
	NewSum DECIMAL(10,2)
)

CREATE TRIGGER tr_addLogOnTransaction
ON Accounts FOR UPDATE
AS
	DECLARE @newSum DECIMAL(15,2) = (SELECT Balance FROM inserted)
	DECLARE @oldSum DECIMAL(15,2) = (SELECT Balance FROM deleted)
	DECLARE @accountId INT = (SELECT Id FROM inserted)
	INSERT INTO Logs(AccountId, OldSum, NewSum) VALUES
	(@accountId, @oldSum, @newSum)

--15. Create Table Emails
CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT REFERENCES Accounts(Id),
	[Subject] VARCHAR(50),
	Body VARCHAR(MAX)
)

CREATE TRIGGER tr_LogEmail ON Logs FOR INSERT
AS
	DECLARE @accountId INT = (SELECT TOP(1) AccountId FROM inserted)
	DECLARE @oldSum DECIMAL(15,2) = (SELECT TOP(1) OldSum FROM inserted)
	DECLARE @newSum DECIMAL(15,2) = (SELECT TOP(1) NewSum FROM inserted)

INSERT INTO NotificationEmails (Recipient, [Subject], Body) VALUES
(
@accountId, 
'Balance change for account: ' + CAST(@accountId AS VARCHAR(20)),
'On ' + CONVERT(VARCHAR(30), GETDATE(), 103) + ' your balance was change from ' + CAST(@oldSum AS VARCHAR(20)) + ' to ' + CAST(@newSum AS VARCHAR(20))
)

--16. Deposit Money
CREATE PROC usp_DepositMoney @accountId INT, @moneyAmount DECIMAL(15,4)
AS
BEGIN TRANSACTION

DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @accountId)

IF (@account IS NULL)
BEGIN
	ROLLBACK
	RAISERROR('Invalid account id!', 16, 1)
	RETURN
END

IF (@moneyAmount < 0)
BEGIN
	ROLLBACK
	RAISERROR('Negative amount!', 16, 1)
	RETURN
END
	
UPDATE Accounts
SET Balance += @moneyAmount
WHERE Id = @accountId
COMMIT

--17. Withdraw Money Procedure
CREATE PROC usp_WithdrawMoney @accountId INT, @moneyAmount DECIMAL(15,4)
AS
BEGIN TRANSACTION

DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id = @accountId)
DECLARE @accountBalance DECIMAL(15,4) = (SELECT Balance FROM Accounts WHERE Id = @accountId)

IF (@account IS NULL)
BEGIN
	ROLLBACK
	RAISERROR('Invalid account id!', 16, 1)
	RETURN
END

IF (@moneyAmount < 0)
BEGIN
	ROLLBACK
	RAISERROR('Negative amount!', 16, 1)
	RETURN
END

IF (@accountBalance - @moneyAmount < 0)
BEGIN
	ROLLBACK
	RAISERROR('Insufficient funds!', 16, 1)
	RETURN
END
	
UPDATE Accounts
SET Balance -= @moneyAmount
WHERE Id = @accountId
COMMIT

--18. Money Transfer
CREATE PROC usp_TransferMoney @senderId INT, @receiverId INT, @amount DECIMAL(15,4)
AS
BEGIN TRANSACTION
EXEC usp_WithdrawMoney @senderId, @amount
EXEC usp_DepositMoney @receiverId, @amount
COMMIT

--19. Trigger
--1.
CREATE TRIGGER tr_restrictItems ON UserGameItems INSTEAD OF INSERT
AS
DECLARE @itemId INT = (SELECT ItemId FROM inserted)
DECLARE @userGameId INT = (SELECT UserGameId FROM inserted)

DECLARE @itemLevel INT = (SELECT MinLevel FROM Items WHERE Id = @itemId)
DECLARE @userGameLevel INT = (SELECT [Level] FROM UsersGames WHERE Id = @userGameId)

IF(@userGameLevel >= @itemLevel)
BEGIN
	INSERT INTO UserGameItems(ItemId, UserGameId) VALUES
	(@itemId, @userGameId)
END

--2.
SELECT * FROM 
USERS u
JOIN UsersGames ug ON ug.UserId = u.Id
JOIN Games g ON g.Id = ug.GameId
WHERE g.Name = 'Bali' AND u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')

UPDATE UsersGames
SET Cash += 50000
WHERE GameId = (SELECT Id FROM Games WHERE Name = 'Bali') AND
	  UserId IN (SELECT Id FROM Users WHERE Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos'))

--https://www.youtube.com/watch?v=dmnT7VwFtEs&feature=emb_title&ab_channel=SoftwareUniversity%28SoftUni%29

-- From 00:50 To 01:15h

--20. *Massive Shopping
