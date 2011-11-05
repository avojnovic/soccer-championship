CREATE TABLE [dbo].[PlayerStatics]
(
	ID INT IDENTITY(1, 1) NOT NULL,
	PlayerID INT NOT NULL,
	GameDayID INT NOT NULL,
	RedCard INT NOT NULL,
	YellowCards INT NOT NULL,
	Goals INT NOT NULL
)
