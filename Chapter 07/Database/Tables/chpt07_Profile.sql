IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'chpt07_Profile')
	BEGIN
		DROP  Table chpt07_Profile
	END
GO

CREATE TABLE dbo.chpt07_Profile
(
	[ProfileID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [uniqueidentifier] NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NOT NULL,
 CONSTRAINT [PK_chpt07_Profile] PRIMARY KEY CLUSTERED 
(
	[ProfileID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

CREATE UNIQUE NONCLUSTERED INDEX [IX_chpt07_Profile_UserID] ON [dbo].[chpt07_Profile] 
(
	[UserID] ASC
)WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, 
	IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY]
GO
