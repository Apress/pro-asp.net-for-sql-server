IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' 
  AND name = 'pap_MovePhoto')
  BEGIN
    DROP  Procedure  pap_MovePhoto
  END
GO

CREATE Procedure dbo.pap_MovePhoto
  (
    @PhotoID bigint,
      @SourceAlbumID bigint,
      @DestinationAlbumID bigint
  )
AS

UPDATE pap_Photos SET AlbumID = @DestinationAlbumID
WHERE AlbumID = @SourceAlbumID AND ID = @PhotoID

GO

GRANT EXEC ON pap_MovePhoto TO PUBLIC
GO
