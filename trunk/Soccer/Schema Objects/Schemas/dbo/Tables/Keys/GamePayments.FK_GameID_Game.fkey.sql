ALTER TABLE [dbo].[GamePayments]
	ADD CONSTRAINT [FK_GameID_Game] 
	FOREIGN KEY (GameID)
	REFERENCES Game (ID)	

