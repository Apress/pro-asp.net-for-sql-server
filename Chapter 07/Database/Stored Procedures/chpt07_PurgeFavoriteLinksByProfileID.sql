IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt07_PurgeFavoriteLinksByProfileID')
	BEGIN
		DROP  Procedure  chpt07_PurgeFavoriteLinksByProfileID
	END

GO

CREATE Procedure dbo.chpt07_PurgeFavoriteLinksByProfileID
(
	@ProfileID bigint
)
AS

SET NOCOUNT ON

IF EXISTS 
	(SELECT * FROM chpt07_FavoriteLinks WHERE ProfileID = @ProfileID)
BEGIN

	EXEC chpt07_PurgeLinkTagsByProfileID @ProfileID

	DECLARE @LinkUrlsToPurge TABLE
	(
		ID int IDENTITY,
		LinkUrlID bigint,
		[Count] int
	)

	INSERT INTO @LinkUrlsToPurge (LinkUrlID, [Count])
	SELECT lu.LinkUrlID, COUNT(*) AS [Count] 
	FROM chpt07_LinkUrls AS lu
	JOIN chpt07_FavoriteLinks AS fl ON fl.LinkUrlID = lu.LinkUrlID
	WHERE lu.LinkUrlID in (
		SELECT DISTINCT LinkUrlID FROM chpt07_FavoriteLinks WHERE ProfileID = @ProfileID
	)
	GROUP BY lu.LinkUrlID
	HAVING COUNT(*) = 1

	DECLARE @LinkTitlesToPurge TABLE
	(
		ID int IDENTITY,
		LinkTitleID bigint,
		[Count] int
	)

	INSERT INTO @LinkTitlesToPurge (LinkTitleID, [Count])
	SELECT lt.LinkTitleID, COUNT(*) AS [Count] 
	FROM chpt07_LinkTitles AS lt
	JOIN chpt07_FavoriteLinks AS fl ON fl.LinkTitleID = lt.LinkTitleID
	WHERE lt.LinkTitleID in (
		SELECT DISTINCT LinkTitleID FROM chpt07_FavoriteLinks WHERE ProfileID = @ProfileID
	)
	GROUP BY lt.LinkTitleID
	HAVING COUNT(*) = 1
	
	DELETE FROM chpt07_FavoriteLinks WHERE ProfileID = @ProfileID
	
	DELETE FROM chpt07_LinkUrls WHERE LinkUrlID IN 
	(SELECT LinkUrlID FROM @LinkUrlsToPurge)
	
	DELETE FROM chpt07_LinkTitles WHERE LinkTitleID IN 
	(SELECT LinkTitleID FROM @LinkTitlesToPurge)

END

GO

GRANT EXEC ON chpt07_PurgeFavoriteLinksByProfileID TO PUBLIC
GO
