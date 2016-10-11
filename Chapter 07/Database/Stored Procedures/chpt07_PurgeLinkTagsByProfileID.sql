IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt07_PurgeLinkTagsByProfileID')
	BEGIN
		DROP  Procedure  chpt07_PurgeLinkTagsByProfileID
	END

GO

CREATE Procedure dbo.chpt07_PurgeLinkTagsByProfileID
(
	@ProfileID int
)
AS

IF EXISTS (
	SELECT * FROM chpt07_LinkTags AS lt
	JOIN chpt07_FavoriteLinks AS fl ON fl.FavoriteLinkID = lt.FavoriteLinkID
	WHERE fl.ProfileID = @ProfileID
)
BEGIN

	DECLARE @TagTokensToPurge TABLE
	(
		ID int IDENTITY,
		TagTokenID bigint,
		[Count] int
	)

	INSERT INTO @TagTokensToPurge (TagTokenID, [Count])
	SELECT tt.TagTokenID, COUNT(*) AS [Count]
	FROM chpt07_TagTokens AS tt
	JOIN chpt07_LinkTags AS lt ON lt.TagTokenID = tt.TagTokenID
	JOIN chpt07_FavoriteLinks AS fl ON fl.FavoriteLinkID = lt.FavoriteLinkID
	WHERE tt.TagTokenID in (
		SELECT DISTINCT tt2.TagTokenID 
		FROM chpt07_LinkTags AS lt2
		JOIN chpt07_TagTokens AS tt2 ON tt2.TagTokenID = lt2.TagTokenID
		JOIN chpt07_FavoriteLinks AS fl2 ON fl2.FavoriteLinkID = lt2.FavoriteLinkID
		WHERE fl2.ProfileID = @ProfileID
	)
	GROUP BY tt.TagTokenID
	HAVING COUNT(*) = 1
	
	DELETE FROM chpt07_LinkTags WHERE LinkTagID IN 
	(
		SELECT lt.LinkTagID FROM chpt07_LinkTags AS lt
		JOIN chpt07_FavoriteLinks AS fl ON fl.FavoriteLinkID = lt.FavoriteLinkID
		WHERE fl.ProfileID = @ProfileID
	)
	
	DELETE FROM chpt07_TagTokens WHERE TagTokenID IN 
	(SELECT TagTokenID FROM @TagTokensToPurge)
	
END

GO

GRANT EXEC ON chpt07_PurgeLinkTagsByProfileID TO PUBLIC
GO
