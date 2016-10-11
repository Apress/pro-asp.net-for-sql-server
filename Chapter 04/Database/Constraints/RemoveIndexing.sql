
BEGIN TRANSACTION
GO

IF EXISTS
	(SELECT * FROM sysindexes AS i
	JOIN sysobjects AS o on i.id = o.id
	WHERE o.name = 'chpt04_Location' and i.name = 'IX_chpt04_Location_City')
	BEGIN
		PRINT 'Dropping index IX_chpt04_Location_City'
		DROP INDEX IX_chpt04_Location_City ON dbo.chpt04_Location
	END
GO

IF EXISTS
	(SELECT * FROM sysindexes AS i
	JOIN sysobjects AS o on i.id = o.id
	WHERE o.name = 'chpt04_Location' and i.name = 'IX_chpt04_Location_Country')
	BEGIN
		PRINT 'Dropping index IX_chpt04_Location_Country'
		DROP INDEX IX_chpt04_Location_Country ON dbo.chpt04_Location
	END
GO

IF EXISTS
	(SELECT * FROM sysindexes AS i
	JOIN sysobjects AS o on i.id = o.id
	WHERE o.name = 'chpt04_Person' and i.name = 'IX_chpt04_Person_BirthDate')
	BEGIN
		PRINT 'Dropping index IX_chpt04_Person_BirthDate'
		DROP INDEX IX_chpt04_Person_BirthDate ON dbo.chpt04_Person
	END
GO

COMMIT
