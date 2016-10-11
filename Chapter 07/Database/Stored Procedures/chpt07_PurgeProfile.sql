IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt07_PurgeProfile')
	BEGIN
		DROP  Procedure  chpt07_PurgeProfile
	END

GO

CREATE Procedure dbo.chpt07_PurgeProfile
(
	@ProfileID int
)
AS

IF EXISTS (SELECT * FROM chpt07_Profile WHERE ProfileID = @ProfileID) 
BEGIN

	SET NOCOUNT ON
	
	EXEC chpt07_PurgeFavoriteLinksByProfileID @ProfileID

	DELETE FROM chpt07_Profile WHERE ProfileID = @ProfileID

END

GO

GRANT EXEC ON chpt07_PurgeProfile TO PUBLIC
GO
