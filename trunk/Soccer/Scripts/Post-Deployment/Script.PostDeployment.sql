SET IDENTITY_INSERT [Category] ON
INSERT [Category] ([Id], [Name]) VALUES (1, N'A')
INSERT [Category] ([Id], [Name]) VALUES (2, N'B')
INSERT [Category] ([Id], [Name]) VALUES (3, N'C')
SET IDENTITY_INSERT [Category] OFF
SET IDENTITY_INSERT [Team] ON
INSERT [Team] ([ID], [Name], [CategoryID]) VALUES (1, N'ManchesterDiferencial', 1)
INSERT [Team] ([ID], [Name], [CategoryID]) VALUES (2, N'MilanEsa', 2)
SET IDENTITY_INSERT [Team] OFF
SET IDENTITY_INSERT [Tournament] ON
INSERT [Tournament] (ID, CategoryID,Name,StartDate,RegistrationAmount) values (1,1,N'Cebollitas Tournament',GETDATE(),100)
INSERT [Tournament] (ID, CategoryID,Name,StartDate,RegistrationAmount) values (2,1,N'Papafritas Tournament',GETDATE(),100)
SET IDENTITY_INSERT [Tournament] OFF

SET IDENTITY_INSERT [Player] ON
INSERT [Player] ([ID], [Dni], [Mail], [Name], [Address], [Phone], [TeamID]) VALUES (1, 32145166, N'damionly@gmail.com', N'Damian Barletta', N'Zabala 2710', N'46248252', 2)
INSERT [Player] ([ID], [Dni], [Mail], [Name], [Address], [Phone], [TeamID]) VALUES (2, 32850680, N'alanv@gmail.com', N'Alan Vojnovic', N'Munilla 5568', N'16487498', 2)
INSERT [Player] ([ID], [Dni], [Mail], [Name], [Address], [Phone], [TeamID]) VALUES (3, 32403832, N'nue.g@gmail.com', N'Nuelio Gimenez', N'Libertad 222', N'49897796', 2)
INSERT [Player] ([ID], [Dni], [Mail], [Name], [Address], [Phone], [TeamID]) VALUES (6, 32555887, N'nicolas@aasdasd.com', N'Mario Perez', N'Jose K 123', N'12436897', 1)
SET IDENTITY_INSERT [Player] OFF