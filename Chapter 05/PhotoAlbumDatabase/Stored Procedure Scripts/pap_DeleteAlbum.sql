IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' 
  AND name = 'pap_DeleteAlbum')
  BEGIN
    DROP  Procedure  pap_DeleteAlbum
  END
GO

CREATE Procedure dbo.pap_DeleteAlbum
  (
      @AlbumID bigint
  )
AS

/* Assume child dependencies are deleted by provider */
DELETE FROM pap_Albums WHERE ID = @AlbumID

GO

GRANT EXEC ON pap_DeleteAlbum TO PUBLIC
GO
