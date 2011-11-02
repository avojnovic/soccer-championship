ALTER TABLE [dbo].[PlayerStatics]
	ADD CONSTRAINT [FK_GameDayID_GameDay] 
	FOREIGN KEY (GameDayID)
	REFERENCES GameDay (ID)	

