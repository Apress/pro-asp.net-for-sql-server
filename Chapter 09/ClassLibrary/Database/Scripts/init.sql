-- init db (creates SchemaVersions table and related stored procedures)

CREATE TABLE [dbo].[chpt09_SchemaVersions](
	[Name] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Version] [smallint] NOT NULL,
 CONSTRAINT [PK_chpt09_SchemaVersions] PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt09_SetSchemaVersion')
	BEGIN
		DROP  Procedure  chpt09_SetSchemaVersion
	END

GO

CREATE Procedure dbo.chpt09_SetSchemaVersion
(
	@Name nvarchar(20),
	@Version smallint
)
AS

IF NOT EXISTS (
SELECT * FROM chpt09_SchemaVersions
WHERE Name = @Name
)
BEGIN
  INSERT into chpt09_SchemaVersions
  ([Name],Version)
  values (@Name, @Version)  
END
ELSE
BEGIN
	UPDATE chpt09_SchemaVersions
	SET Version = @Version
	WHERE [Name] = @Name
END

GO

GRANT EXEC ON chpt09_SetSchemaVersion TO PUBLIC
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt09_GetSchemaVersion')
	BEGIN
		DROP  Procedure  chpt09_GetSchemaVersion
	END

GO

CREATE Procedure dbo.chpt09_GetSchemaVersion
(
	@Name nvarchar(20),
	@Version smallint OUTPUT
)
AS
IF EXISTS (
	SELECT * FROM chpt09_SchemaVersions
	WHERE Name = @Name
)
BEGIN
	SET @Version = (
		SELECT TOP 1 Version 
		FROM chpt09_SchemaVersions 
		WHERE Name = @Name)
END
ELSE
BEGIN
	SET @Version = 0
END

GO

GRANT EXEC ON chpt09_GetSchemaVersion TO PUBLIC
GO
