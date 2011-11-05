ALTER TABLE [dbo].[Game]
	ADD CONSTRAINT [FK_IDGameDay_GameDay] 
	FOREIGN KEY (GameDayID)
	REFERENCES GameDay (ID)	

