CREATE TABLE [dbo].[Auction]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Date] DATE NOT NULL, 
    [End_Date] DATE NOT NULL, 
    [Status] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(100) NULL, 
    [Price] MONEY NOT NULL 
)
