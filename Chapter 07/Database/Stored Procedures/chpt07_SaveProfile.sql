IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt07_SaveProfile')
	BEGIN
		DROP  Procedure  chpt07_SaveProfile
	END

GO

CREATE Procedure dbo.chpt07_SaveProfile
	(
		@UserID uniqueidentifier,
		@ProfileID bigint OUTPUT
	)
AS

SET NOCOUNT ON

IF EXISTS (SELECT * FROM chpt07_Profile WHERE UserID = @UserID)
	BEGIN
			UPDATE chpt07_Profile SET Modified = GETDATE() 
			WHERE UserID = @UserID
			SET @ProfileID = (select ProfileID FROM chpt07_Profile WHERE UserID = @UserID)
			PRINT 'ProfileID = ' + CONVERT(nvarchar(10), @ProfileID)
	END
ELSE
	BEGIN
			INSERT INTO chpt07_Profile (UserID, Created, Modified)
			VALUES (@UserID, GETDATE(), GETDATE())
			SELECT @ProfileID = @@IDENTITY
			PRINT 'ProfileID = ' + CONVERT(nvarchar(10), @ProfileID)
	END

SET NOCOUNT OFF

GO

GRANT EXEC ON chpt07_SaveProfile TO PUBLIC
GO
