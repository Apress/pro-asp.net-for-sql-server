IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'chpt04_Person')
	BEGIN
		DROP  Table chpt04_Person
	END
GO

CREATE TABLE [dbo].[chpt04_Person](
	[PersonId] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[LastName] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[BirthDate] [datetime] NOT NULL,
	[LocationId] [bigint] NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[PersonId] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

GRANT SELECT ON chpt04_Person TO PUBLIC
GO
