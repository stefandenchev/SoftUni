CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	LastLoginTime DATETIME,
	IsDeleted BIT
)

INSERT INTO Users
(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
VALUES 
('Stefak', 'stronku', NULL, '1/12/2021', 0),
('Val', 'stronku1', NULL, '2/12/2021', 0),
('Iv', 'stro23nku', NULL, '3/12/2021', 0),
('Kev', 'st1ronku', NULL, '4/12/2021', 0),
('Mar', 'strongu', NULL, '12/23/2021', 1)

ALTER TABLE Users
ADD CONSTRAINT PK_IDUsername PRIMARY KEY (Id, Username)

ALTER TABLE Users
ADD CONSTRAINT CH_Password5Symbols CHECK (LEN(Password) > 5)