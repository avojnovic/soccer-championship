ALTER TABLE [dbo].[RegistrationPayments]
	ADD CONSTRAINT [FK_TeamID_Team_2] 
	FOREIGN KEY (TeamID)
	REFERENCES Team (ID)	

