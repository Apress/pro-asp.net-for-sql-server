IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt07_GetRecentFavoriteLinksByProfileID')
	BEGIN
		DROP  Procedure  chpt07_GetRecentFavoriteLinksByProfileID
	END

GO

CREATE Procedure dbo.chpt07_GetRecentFavoriteLinksByProfileID
(
	@ProfileID int,
	@StartDaysBack int,
	@EndDaysBack int
)
AS

SET @StartDaysBack = -1 * @StartDaysBack
SET @EndDaysBack = -1 * @EndDaysBack

SELECT TOP 100 fl.FavoriteLinkID AS ID, lt.Title, lu.Url, fl.Keeper, fl.Rating, fl.Note, fl.Created, fl.Modified
FROM chpt07_FavoriteLinks AS fl
JOIN chpt07_LinkUrls AS lu ON lu.LinkUrlId = fl.LinkUrlID
JOIN chpt07_LinkTitles AS lt ON lt.LinkTitleID = fl.LinkTitleId
WHERE 
	fl.ProfileID = @ProfileID AND 
	fl.Created BETWEEN 
	DATEADD(DAY, @StartDaysBack, GETDATE()) AND 
	DATEADD(DAY, @EndDaysBack, GETDATE())
ORDER BY fl.Created DESC

GO

GRANT EXEC ON chpt07_GetRecentFavoriteLinksByProfileID TO PUBLIC
GO
