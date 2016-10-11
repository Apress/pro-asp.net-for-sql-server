IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt07_GetFavoriteLinksByProfileID')
	BEGIN
		DROP  Procedure  chpt07_GetFavoriteLinksByProfileID
	END

GO

CREATE Procedure dbo.chpt07_GetFavoriteLinksByProfileID
(
	@ProfileID int
)
AS

SELECT 
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
WHERE fl.ProfileID = @ProfileID
ORDER BY fl.Created DESC

GO

GRANT EXEC ON chpt07_GetFavoriteLinksByProfileID TO PUBLIC
GO

