CREATE TABLE [dbo].[GameDay]
(
	ID INT IDENTITY(1, 1) NOT NULL,
	TournamentID INT NOT NULL,
	GameDate Date NOT NULL,	
	GameAmount money NOT NULL

)
