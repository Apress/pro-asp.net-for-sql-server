IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' 
  AND name = 'pap_GetAlbumsByUsername')
  BEGIN
    DROP  Procedure  pap_GetAlbumsByUsername
  END

GO

CREATE Procedure dbo.pap_GetAlbumsByUserName
  (
    @UserName [nvarchar](256)
  )
AS

SELECT * FROM pap_Albums
WHERE UserName = @UserName
ORDER BY Created DESC

GO

GRANT EXEC ON pap_GetAlbumsByUsername TO PUBLIC
GO
