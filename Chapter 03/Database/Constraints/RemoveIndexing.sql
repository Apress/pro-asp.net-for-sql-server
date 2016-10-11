
BEGIN TRANSACTION
GO

IF EXISTS
	(SELECT * FROM sysindexes AS i
	JOIN sysobjects AS o on i.id = o.id
	WHERE o.name = 'chpt03_Location' and i.name = 'IX_chpt03_Location_City')
	BEGIN
		PRINT 'Dropping index IX_chpt03_Location_City'
		DROP INDEX IX_chpt03_Location_City ON dbo.chpt03_Location
	END
GO

IF EXISTS
	(SELECT * FROM sysindexes AS i
	JOIN sysobjects AS o on i.id = o.id
	WHERE o.name = 'chpt03_Location' and i.name = 'IX_chpt03_Location_Country')
	BEGIN
		PRINT 'Dropping index IX_chpt03_Location_Country'
		DROP INDEX IX_chpt03_Location_Country ON dbo.chpt03_Location
	END
GO

IF EXISTS
	(SELECT * FROM sysindexes AS i
	JOIN sysobjects AS o on i.id = o.id
	WHERE o.name = 'chpt03_Person' and i.name = 'IX_chpt03_Person_BirthDate')
	BEGIN
		PRINT 'Dropping index IX_chpt03_Person_BirthDate'
		DROP INDEX IX_chpt03_Person_BirthDate ON dbo.chpt03_Person
	END
GO

COMMIT
