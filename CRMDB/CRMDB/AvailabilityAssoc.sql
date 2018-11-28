CREATE TABLE [dbo].[AvailabilityAssoc]
(
	[AvailabilityID] INT NOT NULL,
	[VolunteerID] INT NOT NULL,
	PRIMARY KEY (AvailabilityID, VolunteerID),
	CONSTRAINT [FK_dbo.AvailabilityAssoc_dbo.Availability_AvailabilityID] FOREIGN KEY ([AvailabilityID]) 
        REFERENCES [dbo].[Availability] ([AvailabilityID]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.AvailabilityAssoc_dbo.Volunteer_VolunteerID] FOREIGN KEY ([VolunteerID]) 
        REFERENCES [dbo].[Volunteer] ([VolunteerID]) ON DELETE CASCADE
)