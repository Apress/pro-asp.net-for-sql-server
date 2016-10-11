IF EXISTS (
  SELECT * FROM sysobjects WHERE type = 'U' AND name = 'chpt09_SchemaVersions')
  BEGIN
    DROP  Table chpt09_SchemaVersions
  END
GO

CREATE TABLE [dbo].[chpt09_SchemaVersions](
  [Name] [nvarchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Version] [smallint] NOT NULL,
 CONSTRAINT [PK_chpt09_SchemaVersions] PRIMARY KEY CLUSTERED 
(
  [Name] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
