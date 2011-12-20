SET IDENTITY_INSERT [Category] ON
INSERT [Category] ([Id], [Name]) VALUES (1, N'A')
INSERT [Category] ([Id], [Name]) VALUES (2, N'B')
INSERT [Category] ([Id], [Name]) VALUES (3, N'C')
SET IDENTITY_INSERT [Category] OFF
SET IDENTITY_INSERT [Team] ON
INSERT [Team] ([ID], [Name], [CategoryID]) VALUES (1, N'Equipo 1 A', 1)
INSERT [Team] ([ID], [Name], [CategoryID]) VALUES (2, N'Equipo 2 A', 1)
INSERT [Team] ([ID], [Name], [CategoryID]) VALUES (3, N'Equipo 1 B', 2)
INSERT [Team] ([ID], [Name], [CategoryID]) VALUES (4, N'Equipo 2 B', 2)
INSERT [Team] ([ID], [Name], [CategoryID]) VALUES (5, N'Equipo 1 C', 3)
INSERT [Team] ([ID], [Name], [CategoryID]) VALUES (6, N'Equipo 2 C', 3)
SET IDENTITY_INSERT [Team] OFF
SET IDENTITY_INSERT [Tournament] ON
INSERT [Tournament] (ID, CategoryID,Name,StartDate,RegistrationAmount) values (1,1,N'Torneo A',GETDATE(),100)
INSERT [Tournament] (ID, CategoryID,Name,StartDate,RegistrationAmount) values (2,2,N'Torneo B',GETDATE(),100)
INSERT [Tournament] (ID, CategoryID,Name,StartDate,RegistrationAmount) values (3,3,N'Torneo C',GETDATE(),100)
SET IDENTITY_INSERT [Tournament] OFF

SET IDENTITY_INSERT [Player] ON
INSERT [Player] ([ID], [Dni], [Mail], [Name], [Address], [Phone], [TeamID]) VALUES (1, 111111, N'jugador1@gmail.com', N'Jugador 1', N'Dirección 1', N'4444444', 1)
INSERT [Player] ([ID], [Dni], [Mail], [Name], [Address], [Phone], [TeamID]) VALUES (2, 222222, N'jugador2@gmail.com', N'Jugador 2', N'Dirección 2', N'4444444', 1)
INSERT [Player] ([ID], [Dni], [Mail], [Name], [Address], [Phone], [TeamID]) VALUES (3, 333333, N'jugador3@gmail.com', N'Jugador 3', N'Dirección 3', N'4444444', 2)
INSERT [Player] ([ID], [Dni], [Mail], [Name], [Address], [Phone], [TeamID]) VALUES (4, 444444, N'jugador4@gmail.com', N'Jugador 4', N'Dirección 4', N'4444444', 2)
INSERT [Player] ([ID], [Dni], [Mail], [Name], [Address], [Phone], [TeamID]) VALUES (5, 555555, N'jugador5@gmail.com', N'Jugador 5', N'Dirección 4', N'4444444', 3)
INSERT [Player] ([ID], [Dni], [Mail], [Name], [Address], [Phone], [TeamID]) VALUES (6, 666666, N'jugador6@gmail.com', N'Jugador 6', N'Dirección 4', N'4444444', 3)
INSERT [Player] ([ID], [Dni], [Mail], [Name], [Address], [Phone], [TeamID]) VALUES (7, 777777, N'jugador7@gmail.com', N'Jugador 7', N'Dirección 4', N'4444444', 4)
INSERT [Player] ([ID], [Dni], [Mail], [Name], [Address], [Phone], [TeamID]) VALUES (8, 888888, N'jugador8@gmail.com', N'Jugador 8', N'Dirección 4', N'4444444', 4)
INSERT [Player] ([ID], [Dni], [Mail], [Name], [Address], [Phone], [TeamID]) VALUES (9, 999999, N'jugador9@gmail.com', N'Jugador 9', N'Dirección 4', N'4444444', 5)
INSERT [Player] ([ID], [Dni], [Mail], [Name], [Address], [Phone], [TeamID]) VALUES (10, 101010, N'jugador10@gmail.com', N'Jugador 10', N'Dirección 4', N'4444444', 5)
INSERT [Player] ([ID], [Dni], [Mail], [Name], [Address], [Phone], [TeamID]) VALUES (11, 1111, N'jugador11@gmail.com', N'Jugador 11', N'Dirección 4', N'4444444', 6)
INSERT [Player] ([ID], [Dni], [Mail], [Name], [Address], [Phone], [TeamID]) VALUES (12, 121212, N'jugador12@gmail.com', N'Jugador 12', N'Dirección 4', N'4444444', 6)

SET IDENTITY_INSERT [Player] OFF