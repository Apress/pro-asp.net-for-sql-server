IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' 
  AND name = 'pap_GetPhotosByAlbum')
  BEGIN
    DROP  Procedure  pap_GetPhotosByAlbum
  END
GO

CREATE Procedure dbo.pap_GetPhotosByAlbum
  (
      @AlbumID bigint
  )
AS

SELECT *
FROM pap_Photos
wHERE AlbumID = @AlbumID
ORDER BY Created DESC

GO

GRANT EXEC ON pap_GetPhotosByAlbum TO PUBLIC
GO
