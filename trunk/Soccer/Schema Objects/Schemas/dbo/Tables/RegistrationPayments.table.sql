CREATE TABLE [dbo].[RegistrationPayments]
(
	ID INT IDENTITY(1, 1) NOT NULL, 
	TournamentID int NOT NULL,
	TeamID int NOT NULL,
	PaidDate Date NOT NULL  
)
