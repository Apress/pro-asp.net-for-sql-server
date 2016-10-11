IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt07_RemoveLinkTag')
	BEGIN
		DROP  Procedure  chpt07_RemoveLinkTag
	END

GO

CREATE Procedure dbo.chpt07_RemoveLinkTag
(
	@FavoriteLinkID bigint,
	@Token nvarchar(30)
)
AS

DECLARE @LinkTagID bigint

SET @LinkTagID = (
		SELECT TOP 1 lt.LinkTagID
		FROM chpt07_LinkTags AS lt
		JOIN chpt07_TagTokens AS tt ON tt.TagTokenID = lt.TagTokenID
		WHERE lt.FavoriteLinkID = @FavoriteLinkID AND tt.Token = @Token
	)

-- delete LinkTag for FavoriteLink/Token
DELETE FROM chpt07_LinkTags WHERE LinkTagID = @LinkTagID

DECLARE @TokenCount int
-- count tokens
SET @TokenCount = (
		SELECT COUNT(*) 
		FROM chpt07_LinkTags AS lt
		JOIN chpt07_TagTokens AS tt ON tt.TagTokenID = lt.TagTokenID
		WHERE tt.Token = @Token
	)

-- if count = 0, delete the token
IF (@TokenCount = 0)
BEGIN
	DELETE FROM chpt07_TagTokens WHERE Token = @Token
END

GO

GRANT EXEC ON chpt07_RemoveLinkTag TO PUBLIC
GO
