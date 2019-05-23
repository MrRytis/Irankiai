CREATE TABLE [dbo].[Rent]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[StartDate] DATE NULL, 
    [EndDate] DATE NULL, 
    [Status] VARCHAR(50) NULL, 
    [Comments] VARCHAR(50) NULL

);


INSERT INTO Rent(Id, StartDate, EndDate, Status, Comments)
VALUES (1, null, null, 'In progress', 'Perfect');