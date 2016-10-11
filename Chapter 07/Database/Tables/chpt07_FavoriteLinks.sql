IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'chpt07_FavoriteLinks')
	BEGIN
		DROP  Table chpt07_FavoriteLinks
	END
GO

CREATE TABLE dbo.chpt07_FavoriteLinks
(
	[FavoriteLinkID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProfileID] [bigint] NOT NULL,
	[LinkUrlID] [bigint] NOT NULL,
	[LinkTitleID] [bigint] NOT NULL,
	[Keeper] [bit] NOT NULL,
	[Rating] [smallint] NOT NULL,
	[Note] [varchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NOT NULL,
 CONSTRAINT [PK_chpt07_FavoriteLinks] PRIMARY KEY CLUSTERED 
(
	[FavoriteLinkID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
