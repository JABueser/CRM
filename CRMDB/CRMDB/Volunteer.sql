﻿CREATE TABLE [dbo].[Volunteer]
(
	[VolunteerID]	INT		IDENTITY  (1,1) NOT NULL,
	[LastName] NVARCHAR (50) NULL,
	[FirstName] NVARCHAR (50) NULL,
	[Address] NVARCHAR (50) NULL,
	[City] NVARCHAR (50) NULL,
	[State] NVARCHAR (50) NULL,
	[Zipcode] NVARCHAR (50) NULL,
	[BirthDate] NVARCHAR (50) NULL,
	[Organization] NVARCHAR (50) NULL,
	[Occupation] NVARCHAR (50) NULL,
	[Church] NVARCHAR (50) NULL,
	[Pastor] NVARCHAR (50) NULL,
	[HowDidYouHear] NVARCHAR (MAX) NULL,
	[Felony] NVARCHAR (50) NULL,
	[NatureOfFelony] NVARCHAR (50) NULL,
	[EmergencyName] NVARCHAR (50) NULL,
	[EmergencyRelation] NVARCHAR (50) NULL,
	[EmergencyPhone] NVARCHAR (50) NULL,
	[Disabilities] NVARCHAR (MAX) NULL,
	[Skills] NVARCHAR (MAX) NULL,
	[Email] NVARCHAR (50) NULL,
	[Phone] NVARCHAR (50) NULL,
	[TotalHours] INT NULL,
	PRIMARY KEY CLUSTERED ([VolunteerID] ASC)
)
