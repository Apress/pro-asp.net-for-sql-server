IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'pap_Albums')
  BEGIN
    PRINT 'Dropping Table pap_Albums'
    DROP  Table pap_Albums
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[pap_Albums](
  [ID] [bigint] IDENTITY(1,1) NOT NULL,
  [UserName] [nvarchar](256) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Name] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [IsActive] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [IsShared] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Modified] [datetime] NOT NULL,
  [Created] [datetime] NOT NULL,
 CONSTRAINT [PK_pap_Albums] PRIMARY KEY CLUSTERED 
(
  [ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF