IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt07_SaveLinkUrl')
	BEGIN
		DROP  Procedure  chpt07_SaveLinkUrl
	END

GO

CREATE Procedure dbo.chpt07_SaveLinkUrl
	(
		@Url nvarchar(250),
		@LinkUrlID int OUTPUT
	)
AS

IF EXISTS (SELECT * FROM chpt07_LinkUrls WHERE Url = @Url)
	BEGIN
			SET @LinkUrlID = (SELECT LinkUrlID FROM chpt07_LinkUrls WHERE Url = @Url)			
	END
ELSE
	BEGIN
			INSERT INTO chpt07_LinkUrls (Url, Created, Modified)
			VALUES (@Url, GETDATE(), GETDATE())
			SELECT @LinkUrlID = @@IDENTITY
	END

PRINT 'LinkUrlID = ' + CONVERT(nvarchar(10), @LinkUrlID)

GO

GRANT EXEC ON chpt07_SaveLinkUrl TO PUBLIC
GO
