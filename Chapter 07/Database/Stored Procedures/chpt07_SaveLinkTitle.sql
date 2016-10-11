IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt07_SaveLinkTitle')
	BEGIN
		DROP  Procedure  chpt07_SaveLinkTitle
	END

GO

CREATE Procedure dbo.chpt07_SaveLinkTitle
	(
		@Title nvarchar(100),
		@LinkTitleID int OUTPUT
	)
AS

IF EXISTS (SELECT * FROM chpt07_LinkTitles WHERE Title = @Title)
	BEGIN
			SET @LinkTitleID = (SELECT LinkTitleID FROM chpt07_LinkTitles WHERE Title = @Title)			
	END
ELSE
	BEGIN
			INSERT INTO chpt07_LinkTitles (Title, Created, Modified)
			VALUES (@Title, GETDATE(), GETDATE())
			SELECT @LinkTitleID = @@IDENTITY
	END

PRINT 'LinkTitleID = ' + CONVERT(nvarchar(10), @LinkTitleID)

GO

GRANT EXEC ON chpt07_SaveLinkTitle TO PUBLIC
GO
