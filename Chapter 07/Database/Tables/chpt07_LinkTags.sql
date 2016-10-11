IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'chpt07_LinkTags')
	BEGIN
		DROP  Table chpt07_LinkTags
	END
GO

CREATE TABLE dbo.chpt07_LinkTags
(
	[LinkTagID] [bigint] IDENTITY(1,1) NOT NULL,
	[FavoriteLinkID] [bigint] NOT NULL,
	[TagTokenID] [bigint] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NOT NULL,
 CONSTRAINT [PK_chpt07_LinkTags] PRIMARY KEY CLUSTERED 
(
	[LinkTagID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
