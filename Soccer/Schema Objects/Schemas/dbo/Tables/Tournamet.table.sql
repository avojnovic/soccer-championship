CREATE TABLE [dbo].[Tournament]
(
	ID INT IDENTITY(1, 1) NOT NULL, 
	CategoryID INT NOT NULL,
	Name varchar(100) NOT NULL,
	StartDate Date NOT NULL,
	RegistrationAmount money NOT NULL
)
