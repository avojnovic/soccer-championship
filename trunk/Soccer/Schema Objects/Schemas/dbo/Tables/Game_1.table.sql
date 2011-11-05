CREATE TABLE [dbo].[Game]
(
	ID INT IDENTITY(1, 1) NOT NULL,
	GameDayID INT NOT NULL,
	StartTime DateTime NOT NULL,	
	Team1ID int NOT NULL,
	Team2ID int NOT NULL
)
