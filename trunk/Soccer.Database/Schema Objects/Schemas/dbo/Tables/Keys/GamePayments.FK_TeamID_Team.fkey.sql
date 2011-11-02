ALTER TABLE [dbo].[GamePayments]
	ADD CONSTRAINT [FK_TeamID_Team_3] 
	FOREIGN KEY (TeamID)
	REFERENCES Team (ID)	

