/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
MERGE INTO Category AS Target
USING (VALUES
        (1, 'Doctor', 1),
        (2, 'Dentist', 1),
        (3, 'Nurse', 1),
        (4, 'Chapel Ministry', 1),
        (5, 'Bus Driver', 1),
        (6, 'Office/Clerical', 1),
        (7, 'Maintenance', 1),
        (8, 'Auto Shop', 1),
        (9, 'Food Service', 1),
        (10, 'Mens Division', 1),
        (11, 'Thrift Store', 1),
        (12, 'Special Events', 1),
        (13, 'Women, Children, and Families', 1),
        (14, 'Job Training/Life Skills Instructor', 1)
)
AS Source (CategoryID, Category, CategoryValue)
ON Target.CategoryID = Source.CategoryID
WHEN NOT MATCHED BY TARGET THEN
INSERT (Category, CategoryValue)
VALUES (Category, CategoryValue);

MERGE INTO Availability AS Target
USING (VALUES
        (1, 'Sunday'),
        (2, 'Monday'),
        (3, 'Tuesday'),
        (4, 'Wednesday'),
        (5, 'Thursday'),
        (6, 'Friday'),
        (7, 'Saturday')
)
AS SOURCE (AvailabilityID, Day)
ON Target.AvailabilityID = Source.AvailabilityID
WHEN NOT MATCHED BY TARGET THEN
INSERT (Day)
VALUES (DAY); 
