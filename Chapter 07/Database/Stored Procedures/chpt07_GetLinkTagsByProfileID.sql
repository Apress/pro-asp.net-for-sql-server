IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt07_GetLinkTagsByProfileID')
	BEGIN
		DROP  Procedure  chpt07_GetLinkTagsByProfileID
	END

GO

CREATE Procedure dbo.chpt07_GetLinkTagsByProfileID
(
	@ProfileID bigint
)
AS

SELECT lt.LinkTagID, tt.Token as Token
FROM chpt07_FavoriteLinks as fl
JOIN chpt07_LinkTags AS lt ON lt.FavoriteLinkID = fl.FavoriteLinkID
JOIN chpt07_TagTokens AS tt ON tt.TagTokenID = lt.TagTokenID
WHERE fl.ProfileID = @ProfileID

GO

GRANT EXEC ON chpt07_GetLinkTagsByProfileID TO PUBLIC
GO
