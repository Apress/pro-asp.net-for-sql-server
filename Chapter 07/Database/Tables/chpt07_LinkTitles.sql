IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'chpt07_LinkTitles')
	BEGIN
		DROP  Table chpt07_LinkTitles
	END
GO

CREATE TABLE dbo.chpt07_LinkTitles
(
	[LinkTitleID] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NOT NULL,
 CONSTRAINT [PK_chpt07_LinkTitles] PRIMARY KEY CLUSTERED 
(
	[LinkTitleID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
