CREATE TABLE [dbo].[CategoryAssoc]
(
	[CategoryID] INT NOT NULL,
	[VolunteerID] INT NOT NULL,
	PRIMARY KEY (CategoryID, VolunteerID),
	CONSTRAINT [FK_dbo.CategoryAssoc_dbo.Category_CategoryID] FOREIGN KEY ([CategoryID]) 
        REFERENCES [dbo].[Category] ([CategoryID]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.CategoryAssoc_dbo.Volunteer_VolunteerID] FOREIGN KEY ([VolunteerID]) 
        REFERENCES [dbo].[Volunteer] ([VolunteerID]) ON DELETE CASCADE
)
