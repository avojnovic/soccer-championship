ALTER TABLE [dbo].[RegistrationPayments]
	ADD CONSTRAINT [FK_TournamentID_Tournament] 
	FOREIGN KEY (TournamentID)
	REFERENCES Tournament (ID)	

