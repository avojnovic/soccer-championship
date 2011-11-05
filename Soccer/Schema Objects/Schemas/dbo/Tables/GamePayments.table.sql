CREATE TABLE [dbo].[GamePayments]
(
	ID INT IDENTITY(1, 1)  NOT NULL,
	GameID int NOT NULL,
	TeamID int NOT NULL,
	PaidDate Date NOT NULL
)
