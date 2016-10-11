 IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' 
  AND name = 'pap_MoveAlbum')
  BEGIN
    DROP  Procedure  pap_MoveAlbum
  END
GO

CREATE Procedure dbo.pap_MoveAlbum
  (
    @AlbumID bigint,
    @SourceUserName [nvarchar](256),
    @DestinationUserName [nvarchar](256)
  )
AS

UPDATE pap_Albums SET UserName = @DestinationUserName
WHERE UserName = @SourceUserName AND ID = @AlbumID

GO

GRANT EXEC ON pap_MoveAlbum TO PUBLIC
GO
