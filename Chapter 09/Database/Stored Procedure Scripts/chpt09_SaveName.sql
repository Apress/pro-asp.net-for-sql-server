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
