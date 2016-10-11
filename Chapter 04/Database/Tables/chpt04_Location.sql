IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'chpt04_Location')
	BEGIN
		DROP  Table chpt04_Location
	END
GO

CREATE TABLE [dbo].[chpt04_Location](
	[LocationId] [bigint] IDENTITY(1,1) NOT NULL,
	[City] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Country] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
 CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GRANT SELECT ON chpt04_Location TO PUBLIC
GO
