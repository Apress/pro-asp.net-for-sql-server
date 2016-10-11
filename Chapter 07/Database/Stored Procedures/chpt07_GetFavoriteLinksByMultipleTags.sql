IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt07_GetFavoriteLinksByMultipleTags')
	BEGIN
		DROP  Procedure  chpt07_GetFavoriteLinksByMultipleTags
	END

GO

CREATE Procedure dbo.chpt07_GetFavoriteLinksByMultipleTags
(
	@ProfileID bigint,
	@Token1 nvarchar(30),
	@Token2 nvarchar(30),
	@Token3 nvarchar(30)
)
AS

DECLARE @sql nvarchar(4000)

SET @sql = 'SELECT fl.FavoriteLinkID AS ID, lt.Title, lu.Url, fl.Keeper, fl.Rating, fl.Note, fl.Created, fl.Modified
FROM chpt07_FavoriteLinks AS fl
JOIN chpt07_LinkUrls AS lu ON lu.LinkUrlId = fl.LinkUrlID
JOIN chpt07_LinkTitles AS lt ON lt.LinkTitleID = fl.LinkTitleId
WHERE fl.FavoriteLinkID in (
	SELECT fl1.FavoriteLinkID
	FROM chpt07_FavoriteLinks AS fl1
	JOIN chpt07_LinkTags AS lt2 ON lt2.FavoriteLinkID = fl1.FavoriteLinkID
	JOIN chpt07_TagTokens AS tt ON tt.TagTokenID = lt2.TagTokenID
	WHERE fl1.ProfileID = ' + CONVERT(varchar(10), @ProfileID) + 
' AND tt.Token = ''' + @Token1 + '''
)'

IF (@Token2 IS NOT null)
BEGIN
	SET @sql = @sql + 'AND fl.FavoriteLinkID in (
	SELECT fl2.FavoriteLinkID
	FROM chpt07_FavoriteLinks AS fl2
	JOIN chpt07_LinkTags AS lt2 ON lt2.FavoriteLinkID = fl2.FavoriteLinkID
	JOIN chpt07_TagTokens AS tt ON tt.TagTokenID = lt2.TagTokenID
	WHERE fl2.ProfileID = ' + CONVERT(varchar(10), @ProfileID) + 
' AND tt.Token = ''' + @Token2 + '''
)'
END

IF (@Token3 IS NOT null)
BEGIN
	SET @sql = @sql + 'AND fl.FavoriteLinkID in (
	SELECT fl3.FavoriteLinkID
	FROM chpt07_FavoriteLinks AS fl3
	JOIN chpt07_LinkTags AS lt2 ON lt2.FavoriteLinkID = fl3.FavoriteLinkID
	JOIN chpt07_TagTokens AS tt ON tt.TagTokenID = lt2.TagTokenID
	WHERE fl3.ProfileID = ' + CONVERT(varchar(10), @ProfileID) + 
' AND tt.Token = ''' + @Token3 + '''
)'
END

	SET @sql = @sql + '
ORDER BY fl.Created DESC
'

--PRINT @sql

-- Execute the SQL query
EXEC sp_executesql @sql

GO


GRANT EXEC ON chpt07_GetFavoriteLinksByMultipleTags TO PUBLIC
GO
