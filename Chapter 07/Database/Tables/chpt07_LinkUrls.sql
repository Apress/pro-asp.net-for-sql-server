IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'chpt07_LinkUrls')
	BEGIN
		DROP  Table chpt07_LinkUrls
	END
GO

CREATE TABLE dbo.chpt07_LinkUrls
(
	[LinkUrlID] [bigint] IDENTITY(1,1) NOT NULL,
	[Url] [varchar](250) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NOT NULL,
 CONSTRAINT [PK_chpt07_LinkUrls] PRIMARY KEY CLUSTERED 
(
	[LinkUrlID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_chpt07_LinkUrls_Url] ON [dbo].[chpt07_LinkUrls] 
(
	[Url] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, 
	IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO
