IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt07_GetFavoriteLinkByUrl')
	BEGIN
		DROP  Procedure  chpt07_GetFavoriteLinkByUrl
	END

GO

CREATE Procedure dbo.chpt07_GetFavoriteLinkByUrl
(
	@ProfileID bigint,
	@Url nvarchar(250)
)
AS

SELECT TOP 1 
	fl.FavoriteLinkID AS ID, 
	lt.Title, 
	lu.Url, 
	fl.Keeper, 
	fl.Rating, 
	fl.Note, 
	fl.Created, 
	fl.Modified
FROM chpt07_FavoriteLinks AS fl
JOIN chpt07_LinkUrls AS lu ON lu.LinkUrlId = fl.LinkUrlID
JOIN chpt07_LinkTitles AS lt ON lt.LinkTitleID = fl.LinkTitleId
JOIN chpt07_LinkTags AS lt2 ON lt2.FavoriteLinkID = fl.FavoriteLinkID
JOIN chpt07_TagTokens AS tt ON tt.TagTokenID = lt2.TagTokenID
WHERE fl.ProfileID = @ProfileID AND lu.url = @Url
ORDER BY fl.Created DESC

GO

GRANT EXEC ON chpt07_GetFavoriteLinkByUrl TO PUBLIC
GO
