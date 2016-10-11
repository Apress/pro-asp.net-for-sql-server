IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt02_ClearData')
	BEGIN
		DROP  Procedure  chpt02_ClearData
	END
GO

CREATE Procedure dbo.chpt02_ClearData
AS

PRINT 'Clearing data'

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[FK_chpt02_Person_chpt02_Location]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[chpt02_Person] DROP CONSTRAINT FK_chpt02_Person_chpt02_Location

TRUNCATE TABLE dbo.chpt02_Person
TRUNCATE TABLE dbo.chpt02_Location

ALTER TABLE [dbo].[chpt02_Person]  WITH CHECK ADD  CONSTRAINT [FK_chpt02_Person_chpt02_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[chpt02_Location] ([LocationId])

-- reSET the Location identity
DBCC CHECKIDENT (chpt02_Location, RESEED, 1)

PRINT 'Done.'

GO

GRANT EXEC ON chpt02_ClearData TO PUBLIC
GO
