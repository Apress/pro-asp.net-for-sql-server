IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' 
  AND name = 'pap_InsertPhoto')
  BEGIN
    DROP  Procedure  pap_InsertPhoto
  END
GO

CREATE Procedure dbo.pap_InsertPhoto
  (
    @PhotoID bigint OUTPUT,
    @AlbumID bigint,
    @Name [nvarchar](60),
    @PhotoDate [datetime],
    @RegularUrl [nvarchar](200),
    @RegularWidth [int],
    @RegularHeight [int],
    @ThumbnailUrl [nvarchar](200),
    @ThumbnailWidth [int],
    @ThumbnailHeight [int],
    @IsActive [char](1),
    @IsShared [char](1)
  )
AS

INSERT INTO pap_Photos (
  AlbumID, [Name], PhotoDate, 
  RegularUrl, RegularWidth, RegularHeight,
  ThumbnailUrl, ThumbnailWidth, ThumbnailHeight,
  IsActive, IsShared, Modified, Created
) VALUES (
  @AlbumID, @Name, @PhotoDate, 
  @RegularUrl, @RegularWidth, @RegularHeight, 
  @ThumbnailUrl, @ThumbnailWidth, @ThumbnailHeight, 
  @IsActive, @IsShared, GETDATE(), GETDATE()
)

SELECT @PhotoID = @@IDENTITY
GO

GRANT EXEC ON pap_InsertPhoto TO PUBLIC
GO
