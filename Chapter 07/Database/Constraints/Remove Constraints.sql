IF EXISTS (SELECT * FROM sysobjects WHERE type = 'F' AND name = 'FK_chpt07_FavoriteLinks_chpt07_Profile')
	BEGIN
		ALTER TABLE dbo.chpt07_FavoriteLinks
			DROP CONSTRAINT FK_chpt07_FavoriteLinks_chpt07_Profile
	END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'F' AND name = 'FK_chpt07_FavoriteLinks_chpt07_LinkTitles')
	BEGIN
		ALTER TABLE dbo.chpt07_FavoriteLinks
			DROP CONSTRAINT FK_chpt07_FavoriteLinks_chpt07_LinkTitles
	END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'F' AND name = 'FK_chpt07_FavoriteLinks_chpt07_LinkUrls')
	BEGIN
		ALTER TABLE dbo.chpt07_FavoriteLinks
			DROP CONSTRAINT FK_chpt07_FavoriteLinks_chpt07_LinkUrls
	END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'F' AND name = 'FK_chpt07_LinkTags_chpt07_FavoriteLinks')
	BEGIN
		ALTER TABLE dbo.chpt07_LinkTags
			DROP CONSTRAINT FK_chpt07_LinkTags_chpt07_FavoriteLinks
	END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'F' AND name = 'FK_chpt07_LinkTags_chpt07_TagTokens')
	BEGIN
		ALTER TABLE dbo.chpt07_LinkTags
			DROP CONSTRAINT FK_chpt07_LinkTags_chpt07_TagTokens
	END
GO