IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND 
  name = 'sm_InsertSiteMapNode')
  BEGIN
    DROP  Procedure  sm_InsertSiteMapNode
  END

GO

CREATE Procedure dbo.sm_InsertSiteMapNode
(
  @ParentID bigint,
  @Url nvarchar(150),
  @Title nvarchar(50),
  @Depth int,
  @ID bigint OUTPUT
)
AS

IF NOT EXISTS (SELECT * FROM sm_SiteMapNodes WHERE Url = @Url)
BEGIN
  INSERT INTO sm_SiteMapNodes (ParentID, Url, Title, Depth, Creation, Modified)
  VALUES (
    @ParentID,
    @Url,
    @Title,
    @Depth,
    GETDATE(),
    GETDATE()
  )
  SET @ID = @@IDENTITY
END
ELSE
BEGIN
  SET @ID = ( SELECT ID FROM sm_SiteMapNodes WHERE Url = @Url )
END

GO

GRANT EXEC ON sm_InsertSiteMapNode TO PUBLIC
GO
