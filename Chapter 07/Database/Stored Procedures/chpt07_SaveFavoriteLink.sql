IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt07_SaveFavoriteLink')
	BEGIN
		DROP  Procedure  chpt07_SaveFavoriteLink
	END

GO

CREATE Procedure dbo.chpt07_SaveFavoriteLink
	(
		@ProfileID bigint,
		@Url nvarchar(250),
		@Title nvarchar(150),
		@Keeper bit,
		@Rating smallint,
		@Note nvarchar(500),
		@Created datetime,
		@Modified datetime,
		@OldFavoriteLinkID bigint,
		@FavoriteLinkID bigint OUTPUT
	)
AS

-- Save Url and get the LinkUrlID
-- Save Title and get the LinkTitleID
-- Save IDs, Rating and Note to chpt07_FavoriteLinks

DECLARE @LinkUrlID int
DECLARE @LinkTitleID int

EXEC chpt07_SaveLinkUrl @Url, @LinkUrlID OUTPUT
EXEC chpt07_SaveLinkTitle @Title, @LinkTitleID OUTPUT

IF (DATEPART(Yy, @Created) = 1754)
BEGIN
	SET @Created = GETDATE()
END

IF (DATEPART(Yy, @Modified) = 1754)
BEGIN
	SET @Modified = GETDATE()
END

-- check for an existing fl by url
IF (@OldFavoriteLinkID < 0 AND EXISTS (
	SELECT * FROM chpt07_FavoriteLinks WHERE LinkUrlID = @LinkUrlID AND ProfileID = @ProfileID
	)) 
	BEGIN
		SET @OldFavoriteLinkID = 
			(SELECT FavoriteLinkID FROM chpt07_FavoriteLinks 
			 WHERE LinkUrlID = @LinkUrlID AND ProfileID = @ProfileID)
	END

IF EXISTS (SELECT * FROM chpt07_FavoriteLinks 
			WHERE FavoriteLinkID = @OldFavoriteLinkID AND ProfileID = @ProfileID)
	BEGIN
		UPDATE chpt07_FavoriteLinks
		SET
			LinkUrlID = @LinkUrlID,
			LinkTitleID = @LinkTitleID,
			Keeper = @Keeper,
			Rating = @Rating,
			Note = @Note,
			Modified = GETDATE()
		WHERE 
			FavoriteLinkID = @OldFavoriteLinkID AND
			ProfileID = @ProfileID

		SET @FavoriteLinkID = @OldFavoriteLinkID
	END
ELSE
	BEGIN
		INSERT INTO chpt07_FavoriteLinks
		(ProfileID, LinkUrlID, LinkTitleID, Keeper, Rating, Note, Created, Modified)
		VALUES (
			@ProfileID,
			@LinkUrlID,
			@LinkTitleID,
			@Keeper,
			@Rating,
			@Note,
			@Created,
			@Modified
		)
		
		SELECT @FavoriteLinkID = @@IDENTITY
	END

GO

GRANT EXEC ON chpt07_SaveFavoriteLink TO PUBLIC
GO
