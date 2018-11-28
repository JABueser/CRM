CREATE TABLE [dbo].[Availability]
(
	[AvailabilityID] INT	IDENTITY (1,1) NOT NULL,
	[Day] NVARCHAR (50) NULL,
	PRIMARY KEY CLUSTERED ([AvailabilityID] ASC)
)
