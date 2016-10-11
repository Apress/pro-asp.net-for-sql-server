IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' 
  AND name = 'pap_DeletePhoto')
  BEGIN
    DROP  Procedure  pap_DeletePhoto
  END

GO

CREATE Procedure dbo.pap_DeletePhoto
  (
      @PhotoID bigint
  )
AS

/* assume child dependencies have been deleted by provider */

DELETE FROM pap_Photos WHERE ID = @PhotoID

GO

GRANT EXEC ON pap_DeletePhoto TO PUBLIC
GO
