IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' 
  AND name = 'pap_InsertAlbum')
  BEGIN
    DROP  Procedure  pap_InsertAlbum
  END
GO

CREATE Procedure dbo.pap_InsertAlbum
  (
      @AlbumID bigint OUTPUT,
      @UserName [nvarchar](256),
      @Name [varchar](50),
      @IsActive [char](1),
      @IsShared [char](1)
  )
AS

INSERT INTO pap_Albums (UserName, [Name], IsActive, IsShared, Modified, Created)
VALUES (@UserName, @Name, @IsActive, @IsShared, GETDATE(), GETDATE())

SELECT @AlbumID = @@IDENTITY
    
GO

GRANT EXEC ON pap_InsertAlbum TO PUBLIC
GO
