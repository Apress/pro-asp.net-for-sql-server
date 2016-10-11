IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt07_SaveLinkTag')
	BEGIN
		DROP  Procedure  chpt07_SaveLinkTag
	END

GO

CREATE Procedure dbo.chpt07_SaveLinkTag
(
	@FavoriteLinkID bigint,
	@Token nvarchar(30),
	@LinkTagID bigint OUTPUT
)
AS

	DECLARE @TagTokenID bigint

	EXEC chpt07_SaveTagToken @Token, @TagTokenID OUTPUT
	PRINT '@TagTokenID = ' + CONVERT(nvarchar(10), @TagTokenID)
	
	IF NOT EXISTS 
		(SELECT * FROM chpt07_LinkTags
		WHERE FavoriteLinkID = @FavoriteLinkID AND TagTokenID = @TagTokenID)
	
	  BEGIN
		INSERT INTO chpt07_LinkTags (FavoriteLinkID, TagTokenID, Created, Modified)
		VALUES (@FavoriteLinkID, @TagTokenID, GETDATE(), GETDATE())
		
		SELECT @LinkTagID = @@IDENTITY
	  END
	ELSE
	  BEGIN
		SET @LinkTagID = (SELECT LinkTagID FROM chpt07_LinkTags
			WHERE FavoriteLinkID = @FavoriteLinkID AND TagTokenID = @TagTokenID)
	  END
GO

GRANT EXEC ON chpt07_SaveLinkTag TO PUBLIC
GO
