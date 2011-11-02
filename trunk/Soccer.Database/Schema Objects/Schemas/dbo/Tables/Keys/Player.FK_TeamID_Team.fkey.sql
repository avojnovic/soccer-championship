ALTER TABLE [dbo].[Player]
	ADD CONSTRAINT [FK_TeamID_Team] 
	FOREIGN KEY (TeamID)
	REFERENCES Team (ID)	

