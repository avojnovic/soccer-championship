ALTER TABLE [dbo].[Tournament]
	ADD CONSTRAINT [FK_CategoryID_Category_2] 
	FOREIGN KEY (CategoryID)
	REFERENCES Category (ID)	

