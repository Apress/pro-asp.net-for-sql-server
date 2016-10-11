IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND 
  name = 'sm_UpdateSiteMapNode')
  BEGIN
    DROP  Procedure  sm_UpdateSiteMapNode
  END

GO

CREATE Procedure dbo.sm_UpdateSiteMapNode
(
  @ID bigint,
  @ParentID bigint,
  @Url nvarchar(150),
  @Title nvarchar(50),
  @Depth int
)
AS

IF EXISTS (SELECT * FROM sm_SiteMapNodes WHERE ID = @ID)
BEGIN
  UPDATE sm_SiteMapNodes SET 
    ParentID = @ParentID,
    Url = @Url,
    Title = @Title,
    Depth = @Depth,
    Creation = GETDATE(),
    Modified = GETDATE()
END

GO

GRANT EXEC ON sm_UpdateSiteMapNode TO PUBLIC
GO
