IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'sm_GetSiteMapNodes')
  BEGIN
    DROP  Procedure  sm_GetSiteMapNodes
  END

GO

CREATE Procedure dbo.sm_GetSiteMapNodes
AS

SELECT c.ID, c.ParentID, c.Url, c.Title, c.Depth, p.Url AS ParentUrl
FROM sm_SiteMapNodes AS c
LEFT OUTER JOIN sm_SiteMapNodes AS p ON p.ID = c.ParentID
ORDER BY c.Depth, c.ParentID

GO
GRANT EXEC ON sm_GetSiteMapNodes TO PUBLIC
GO
