CREATE TABLE [dbo].[TimeLog]
(
	[TimeLogID] INT	IDENTITY(1,1) NOT NULL,
	[Date] NVARCHAR (50) NULL,
	[HoursWorked] INT NULL,
	[CategoryID] INT NOT NULL,
	[VolunteerID] INT NOT NULL,
	PRIMARY KEY CLUSTERED ([TimeLogID] ASC),
	CONSTRAINT [FK_dbo.TimeLog_dbo.Category_CategoryID] FOREIGN KEY ([CategoryID]) 
        REFERENCES [dbo].[Category] ([CategoryID]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.TimeLog_dbo.Volunteer_VolunteerID] FOREIGN KEY ([VolunteerID]) 
        REFERENCES [dbo].[Volunteer] ([VolunteerID]) ON DELETE CASCADE
)
