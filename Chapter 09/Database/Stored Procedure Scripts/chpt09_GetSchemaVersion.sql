IF EXISTS (
  SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt09_GetSchemaVersion')
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
    SELECT Version 
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
