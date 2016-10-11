IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt07_SaveTagToken')
	BEGIN
		DROP  Procedure  chpt07_SaveTagToken
	END

GO

CREATE Procedure dbo.chpt07_SaveTagToken
(
	@Token nvarchar(30),
	@TagTokenID bigint OUTPUT
)
AS

IF EXISTS (SELECT * FROM chpt07_TagTokens WHERE Token = @Token)
	BEGIN
			SET @TagTokenID = (SELECT TagTokenID FROM chpt07_TagTokens WHERE Token = @Token)
	END
ELSE
	BEGIN
			INSERT INTO chpt07_TagTokens (Token, Created, Modified)
			VALUES (@Token, GETDATE(), GETDATE())
			SELECT @TagTokenID = @@IDENTITY
	END

GO

GRANT EXEC ON chpt07_SaveTagToken TO PUBLIC
GO
