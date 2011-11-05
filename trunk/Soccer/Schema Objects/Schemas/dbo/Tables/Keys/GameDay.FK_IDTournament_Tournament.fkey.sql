ALTER TABLE [dbo].[GameDay]
	ADD CONSTRAINT [FK_IDTournament_Tournament] 
	FOREIGN KEY (TournamentID)
	REFERENCES Tournament (ID)	

