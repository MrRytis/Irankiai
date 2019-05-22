CREATE TABLE [dbo].[Advert]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [valid_from] DATE NULL, 
    [valid_to] DATE NULL, 
    [title] NVARCHAR(50) NULL, 
    [price] MONEY NULL, 
    [status] NVARCHAR(50) NULL, 
    [description] NVARCHAR(100) NULL
)
