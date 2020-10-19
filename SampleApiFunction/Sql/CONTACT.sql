IF NOT EXISTS (SELECT * FROM sys.objects where name = 'CONTACT')
	CREATE TABLE [dbo].[CONTACT] (
		[ID]          INT           IDENTITY (1, 1) NOT NULL,
		[FamilyName]  VARCHAR (100) NULL,
		[GivenNames]  VARCHAR (100) NULL,
		[DateOfBirth] DATE          NULL,
		[Sex]         VARCHAR (1)   NULL
	);
GO

