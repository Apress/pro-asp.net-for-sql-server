IF EXISTS (
  SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt09_SetSchemaVersion')
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
