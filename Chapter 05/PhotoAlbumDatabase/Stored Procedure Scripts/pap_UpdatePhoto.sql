IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' 
  AND name = 'pap_UpdatePhoto')
  BEGIN
    DROP  Procedure  pap_UpdatePhoto
  END
GO

CREATE Procedure dbo.pap_UpdatePhoto
  (
    @PhotoID bigint,
    @Name [varchar](50),
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

UPDATE pap_Photos SET
  [Name] = @Name,
  PhotoDate = @PhotoDate,
  RegularUrl = @RegularUrl,
  RegularWidth = @RegularWidth,
  RegularHeight = @RegularHeight,
  ThumbnailUrl = @ThumbnailUrl,
  ThumbnailWidth = @ThumbnailWidth,
  ThumbnailHeight = @ThumbnailHeight,
  IsActive = @IsActive,
  IsShared = @IsShared,
  Modified = GETDATE()
WHERE ID = @PhotoID

GO

GRANT EXEC ON pap_UpdatePhoto TO PUBLIC
GO
