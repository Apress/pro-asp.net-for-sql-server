IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt07_GetLinkTagsWithCountByProfileID')
	BEGIN
		DROP  Procedure  chpt07_GetLinkTagsWithCountByProfileID
	END

GO

CREATE Procedure dbo.chpt07_GetLinkTagsWithCountByProfileID
(
	@ProfileID bigint
)
AS

SELECT tt.TagTokenID, tt.Token as Token, COUNT(DISTINCT lt.LinkTagID) AS [Count]
FROM chpt07_FavoriteLinks as fl
JOIN chpt07_LinkTags AS lt ON lt.FavoriteLinkID = fl.FavoriteLinkID
JOIN chpt07_TagTokens AS tt ON tt.TagTokenID = lt.TagTokenID
WHERE fl.ProfileID = @ProfileID
GROUP BY tt.TagTokenID, tt.Token
ORDER BY tt.Token

GO

GRANT EXEC ON chpt07_GetLinkTagsWithCountByProfileID TO PUBLIC
GO
