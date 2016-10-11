-- update 0 (creates Names table and related stored procedures)

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'chpt09_Names')
	BEGIN
		DROP  Table chpt09_Names
	END
GO

CREATE TABLE [dbo].[chpt09_Names](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NOT NULL,
 CONSTRAINT [PK_chpt09_Names] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt09_SaveName')
	BEGIN
		DROP  Procedure  chpt09_SaveName
	END

GO

CREATE Procedure dbo.chpt09_SaveName
(
	@Name nvarchar(50)
)
AS

IF EXISTS ( SELECT * FROM chpt09_Names WHERE Name = @Name )
	BEGIN
			UPDATE chpt09_Names SET Modified = GETDATE() WHERE Name = @Name
	END
ELSE
	BEGIN
			INSERT INTO chpt09_Names ([Name],Created,Modified)
			VALUES (@Name,GETDATE(),GETDATE())
	END

GO

GRANT EXEC ON chpt09_SaveName TO PUBLIC
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt09_GetNames')
	BEGIN
		DROP  Procedure  chpt09_GetNames
	END

GO

CREATE Procedure dbo.chpt09_GetNames
AS

SELECT * FROM chpt09_Names

GO

GRANT EXEC ON chpt09_GetNames TO PUBLIC
GO

-- be sure to update the names schema version
EXEC chpt09_SetSchemaVersion 'names', 1

GO
