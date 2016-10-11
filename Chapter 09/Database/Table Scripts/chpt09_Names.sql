IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'chpt09_Names')
	BEGIN
		DROP  Table chpt09_Names
	END
GO

CREATE TABLE [dbo].[chpt09_Names](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modified] [datetime] NOT NULL,
 CONSTRAINT [PK_chpt09_Names] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
