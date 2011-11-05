CREATE TABLE [dbo].[Player]
(
	ID INT IDENTITY(1, 1) NOT NULL, 
	Dni int NOT NULL,
	Mail varchar(100) NOT NULL,
	Name varchar(100) NOT NULL,
	Address varchar(100) NOT NULL,
	Phone varchar(100),
	TeamID int NOT NULL

)
