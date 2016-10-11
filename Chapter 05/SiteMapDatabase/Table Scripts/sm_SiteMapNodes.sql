IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND 
  name = 'sm_SiteMapNodes')
  BEGIN
    DROP  Table sm_SiteMapNodes
  END
GO

CREATE TABLE [dbo].[sm_SiteMapNodes](
  [ID] [bigint] IDENTITY(1,1) NOT NULL,
  [ParentID] [bigint] NULL,
  [Url] [nvarchar](150) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Title] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
  [Depth] [int] NOT NULL CONSTRAINT [DF_sm_SiteMapNodes_Depth]  DEFAULT ((0)),
  [Creation] [datetime] NOT NULL,
  [Modified] [datetime] NOT NULL,
 CONSTRAINT [PK_sm_SiteMapNodes] PRIMARY KEY CLUSTERED 
(
  [ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO

GRANT SELECT ON sm_SiteMapNodes TO PUBLIC
GO
