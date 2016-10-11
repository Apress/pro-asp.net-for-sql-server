IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt03_ClearData')
	BEGIN
		DROP  Procedure  chpt03_ClearData
	END
GO

CREATE Procedure dbo.chpt03_ClearData
AS

PRINT 'Clearing data'

IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[FK_chpt03_Person_chpt03_Location]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[chpt03_Person] DROP CONSTRAINT FK_chpt03_Person_chpt03_Location

TRUNCATE TABLE dbo.chpt03_Person
TRUNCATE TABLE dbo.chpt03_Location

ALTER TABLE [dbo].[chpt03_Person]  WITH CHECK ADD  CONSTRAINT [FK_chpt03_Person_chpt03_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[chpt03_Location] ([LocationId])

-- reSET the Location identity
DBCC CHECKIDENT (chpt03_Location, RESEED, 1)

PRINT 'Done.'

GO

GRANT EXEC ON chpt03_ClearData TO PUBLIC
GO
