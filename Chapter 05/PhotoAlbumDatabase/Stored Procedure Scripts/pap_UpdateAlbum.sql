IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' 
  AND name = 'pap_UpdateAlbum')
  BEGIN
    DROP  Procedure  pap_UpdateAlbum
  END
GO

CREATE Procedure dbo.pap_UpdateAlbum
  (
      @AlbumID bigint,
      @Name [varchar](50),
      @IsActive [char](1),
      @IsShared [char](1)
  )
AS

UPDATE pap_Albums SET
  [Name] = @Name,
  IsActive = @IsActive,
  IsShared = @IsShared,
  Modified = GETDATE()
WHERE ID = @AlbumID

GO

GRANT EXEC ON pap_UpdateAlbum TO PUBLIC
GO
