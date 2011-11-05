ALTER TABLE [dbo].[Team]
	ADD CONSTRAINT [FK_CategoryID_Category] 
	FOREIGN KEY (CategoryID)
	REFERENCES Category (ID)	

