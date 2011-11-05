ALTER TABLE [dbo].[PlayerStatics]
	ADD CONSTRAINT [FK_PlayerID_Player] 
	FOREIGN KEY (PlayerID)
	REFERENCES Player (ID)	

