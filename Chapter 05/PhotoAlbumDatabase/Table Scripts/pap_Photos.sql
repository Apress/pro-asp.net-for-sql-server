IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'pap_Photos')
  BEGIN
    PRINT 'Dropping Table pap_Photos'
    DROP  Table pap_Photos
  END
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[pap_Photos](
  [ID] [bigint] IDENTITY(1,1) NOT NULL,
  [AlbumID] [bigint] NOT NULL,
  [Name] [nvarchar](60) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [PhotoDate] [datetime] NULL,
  [RegularUrl] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [RegularWidth] [int] NOT NULL,
  [RegularHeight] [int] NOT NULL,
  [ThumbnailUrl] [nvarchar](200) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [ThumbnailWidth] [int] NOT NULL,
  [ThumbnailHeight] [int] NOT NULL,
  [IsActive] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [IsShared] [char](1) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Modified] [datetime] NOT NULL,
  [Created] [datetime] NOT NULL,
CONSTRAINT [PK_pap_Photos] PRIMARY KEY CLUSTERED 
(
  [ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
