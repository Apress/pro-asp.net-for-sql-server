IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'chpt02_Location')
	BEGIN
		DROP  Table chpt02_Location
	END
GO

CREATE TABLE [dbo].[chpt02_Location](
	[LocationId] [bigint] IDENTITY(1,1) NOT NULL,
	[City] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Country] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GRANT SELECT ON chpt02_Location TO PUBLIC
GO
