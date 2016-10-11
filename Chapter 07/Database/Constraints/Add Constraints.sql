
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

-- Add Foreign Keys

ALTER TABLE dbo.chpt07_FavoriteLinks ADD CONSTRAINT
	FK_chpt07_FavoriteLinks_chpt07_Profile FOREIGN KEY
	(
	ProfileID
	) REFERENCES dbo.chpt07_Profile
	(
	ProfileID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO

ALTER TABLE dbo.chpt07_FavoriteLinks ADD CONSTRAINT
	FK_chpt07_FavoriteLinks_chpt07_LinkTitles FOREIGN KEY
	(
	LinkTitleID
	) REFERENCES dbo.chpt07_LinkTitles
	(
	LinkTitleID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO

ALTER TABLE dbo.chpt07_FavoriteLinks ADD CONSTRAINT
	FK_chpt07_FavoriteLinks_chpt07_LinkUrls FOREIGN KEY
	(
	LinkUrlID
	) REFERENCES dbo.chpt07_LinkUrls
	(
	LinkUrlID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO

ALTER TABLE dbo.chpt07_LinkTags ADD CONSTRAINT
	FK_chpt07_LinkTags_chpt07_FavoriteLinks FOREIGN KEY
	(
	FavoriteLinkID
	) REFERENCES dbo.chpt07_FavoriteLinks
	(
	FavoriteLinkID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO

ALTER TABLE dbo.chpt07_LinkTags ADD CONSTRAINT
	FK_chpt07_LinkTags_chpt07_TagTokens FOREIGN KEY
	(
	TagTokenID
	) REFERENCES dbo.chpt07_TagTokens
	(
	TagTokenID
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
