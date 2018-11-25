CREATE TABLE [dbo].[Category]
(
	[CategoryID] INT	IDENTITY (1,1) NOT NULL,
	[Category] NVARCHAR (50) NULL,
	[CategoryValue] INT NULL,
	PRIMARY KEY CLUSTERED ([CategoryID] ASC)
)
