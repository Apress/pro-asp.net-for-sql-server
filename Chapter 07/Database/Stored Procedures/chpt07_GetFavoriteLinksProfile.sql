IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt07_GetFavoriteLinkProfile')
	BEGIN
		DROP  Procedure  chpt07_GetFavoriteLinkProfile
	END

GO

CREATE Procedure dbo.chpt07_GetFavoriteLinkProfile
	(
		@UserID uniqueidentifier,
		@ProfileID int OUTPUT
	)
AS

SET NOCOUNT ON

IF EXISTS (SELECT * FROM chpt07_Profile WHERE UserID = @UserID)
  BEGIN
		SELECT @ProfileID = ProfileID FROM chpt07_Profile
		WHERE UserID = @UserID
		PRINT 'ProfileID = ' + CONVERT(nvarchar(10), @ProfileID)
  END
ELSE
  BEGIN
		EXEC chpt07_SaveProfile @UserID, @ProfileID OUTPUT
  END

SET NOCOUNT OFF

GO

GRANT EXEC ON chpt07_GetFavoriteLinkProfile TO PUBLIC
GO
