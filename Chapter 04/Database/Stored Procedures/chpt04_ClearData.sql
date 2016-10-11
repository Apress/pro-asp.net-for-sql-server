IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt04_ClearData')
	BEGIN
		DROP  Procedure  chpt04_ClearData
	END
GO

CREATE Procedure dbo.chpt04_ClearData
AS

PRINT 'Clearing data'

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[FK_chpt04_Person_chpt04_Location]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[chpt04_Person] DROP CONSTRAINT FK_chpt04_Person_chpt04_Location

TRUNCATE TABLE dbo.chpt04_Person
TRUNCATE TABLE dbo.chpt04_Location

ALTER TABLE [dbo].[chpt04_Person]  WITH CHECK ADD  CONSTRAINT [FK_chpt04_Person_chpt04_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[chpt04_Location] ([LocationId])

-- reSET the Location identity
DBCC CHECKIDENT (chpt04_Location, RESEED, 1)

PRINT 'Done.'

GO

GRANT EXEC ON chpt04_ClearData TO PUBLIC
GO
