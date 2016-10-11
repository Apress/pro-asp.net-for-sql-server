IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt07_GetLatestFavoriteLinkDate')
	BEGIN
		DROP  Procedure  chpt07_GetLatestFavoriteLinkDate
	END

GO

CREATE Procedure dbo.chpt07_GetLatestFavoriteLinkDate
(
	@ProfileID int,
	@LatestDate datetime OUTPUT
)
AS

IF EXISTS (SELECT * FROM chpt07_FavoriteLinks WHERE ProfileID = @ProfileID)
BEGIN
	SET @LatestDate = (SELECT MAX(Modified) AS LatestDate FROM chpt07_FavoriteLinks WHERE ProfileID = @ProfileID)
END
ELSE
BEGIN
	SET @LatestDate = CONVERT(datetime, '1900/1/1')
END
GO

GRANT EXEC ON chpt07_GetLatestFavoriteLinkDate TO PUBLIC
GO
