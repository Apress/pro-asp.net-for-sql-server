IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'chpt07_TagTokens')
	BEGIN
		DROP  Table chpt07_TagTokens
	END
GO

CREATE TABLE dbo.chpt07_TagTokens
(
	[TagTokenID] [bigint] IDENTITY(1,1) NOT NULL,
	[Token] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NOT NULL,
 CONSTRAINT [PK_chpt07_TagTokens] PRIMARY KEY CLUSTERED 
(
	[TagTokenID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE NONCLUSTERED INDEX [IX_chpt07_TagTokens] ON [dbo].[chpt07_TagTokens] 
(
	[Token] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]

GO
