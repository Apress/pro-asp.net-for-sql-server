IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'chpt08_Names')
	BEGIN
		DROP  Table chpt08_Names
	END
GO

CREATE TABLE [dbo].[chpt08_Names](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NOT NULL,
 CONSTRAINT [PK_chpt08_Names] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
