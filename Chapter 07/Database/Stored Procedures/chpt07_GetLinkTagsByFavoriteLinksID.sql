IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt07_GetLinkTagsByFavoriteLinkID')
	BEGIN
		DROP  Procedure  chpt07_GetLinkTagsByFavoriteLinkID
	END

GO

CREATE Procedure dbo.chpt07_GetLinkTagsByFavoriteLinkID
(
	@FavoriteLinkID bigint
)
AS

SELECT lt.LinkTagID, tt.Token as Token
FROM chpt07_LinkTags AS lt
JOIN chpt07_TagTokens AS tt ON tt.TagTokenID = lt.TagTokenID
WHERE lt.FavoriteLinkID = @FavoriteLinkID

GO

GRANT EXEC ON chpt07_GetLinkTagsByFavoriteLinkID TO PUBLIC
GO
