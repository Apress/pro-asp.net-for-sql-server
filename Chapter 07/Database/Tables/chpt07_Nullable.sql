IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'chpt07_Nullable')
	BEGIN
		DROP  Table chpt07_Nullable
	END
GO

CREATE TABLE [dbo].[chpt07_Nullable](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Color] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[BirthDate] [datetime] NULL,
 CONSTRAINT [PK_chpt07_Nullable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
