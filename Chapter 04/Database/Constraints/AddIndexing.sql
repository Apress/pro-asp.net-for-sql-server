
BEGIN TRANSACTION
GO

IF NOT EXISTS
	(SELECT * FROM sysindexes AS i
	JOIN sysobjects AS o on i.id = o.id
	WHERE o.name = 'chpt04_Location' and i.name = 'IX_chpt04_Location_City')
	BEGIN
		PRINT 'Adding index IX_chpt04_Location_City'
		CREATE NONCLUSTERED INDEX IX_chpt04_Location_City ON dbo.chpt04_Location
		(
		City
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, 
			ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	END
GO

IF NOT EXISTS
	(SELECT * FROM sysindexes AS i
	JOIN sysobjects AS o on i.id = o.id
	WHERE o.name = 'chpt04_Location' and i.name = 'IX_chpt04_Location_Country')
	BEGIN
		PRINT 'Adding index IX_chpt04_Location_Country'
		CREATE NONCLUSTERED INDEX IX_chpt04_Location_Country ON dbo.chpt04_Location
		(
		Country
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, 
			ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	END
GO

IF NOT EXISTS
	(SELECT * FROM sysindexes AS i
	JOIN sysobjects AS o on i.id = o.id
	WHERE o.name = 'chpt04_Person' and i.name = 'IX_chpt04_Person_BirthDate')
	BEGIN
		PRINT 'Adding index IX_chpt04_Person_BirthDate'		
		CREATE NONCLUSTERED INDEX IX_chpt04_Person_BirthDate ON dbo.chpt04_Person
		(
		BirthDate
		) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, 
			ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	END
GO

COMMIT
