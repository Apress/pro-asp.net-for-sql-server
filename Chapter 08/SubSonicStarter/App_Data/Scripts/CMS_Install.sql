/****** Object:  User [NT AUTHORITY\NETWORK SERVICE]    Script Date: 05/09/2007 16:44:34 ******/
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'NT AUTHORITY\NETWORK SERVICE')
CREATE USER [NT AUTHORITY\NETWORK SERVICE] FOR LOGIN [NT AUTHORITY\NETWORK SERVICE] WITH DEFAULT_SCHEMA=[dbo]
/****** Object:  Table [dbo].[CMS_Page]    Script Date: 05/09/2007 16:44:34 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Page]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CMS_Page](
	[PageID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Body] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Locale] [char](5) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_CMS_Page_Locale]  DEFAULT ('en-US'),
	[ParentID] [int] NULL,
	[PageGuid] [uniqueidentifier] NOT NULL,
	[MenuTitle] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Roles] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_CMS_Page_ListOrder]  DEFAULT (N'*'),
	[Summary] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[PageUrl] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Keywords] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[CreatedOn] [datetime] NOT NULL CONSTRAINT [DF_Page_createdOn]  DEFAULT (getdate()),
	[CreatedBy] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ModifiedOn] [datetime] NOT NULL CONSTRAINT [DF_Page_modifiedOn]  DEFAULT (getdate()),
	[ModifiedBy] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Deleted] [bit] NOT NULL CONSTRAINT [DF_CMS_Page_Deleted]  DEFAULT ((0)),
 CONSTRAINT [PK_CMS_Page] PRIMARY KEY CLUSTERED 
(
	[PageID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
/****** Object:  Table [dbo].[CMS_Content]    Script Date: 05/09/2007 16:44:34 ******/
SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CMS_Content]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CMS_Content](
	[ContentID] [int] IDENTITY(1,1) NOT NULL,
	[ContentGUID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_Content_ContentGUID]  DEFAULT (newid()),
	[Title] [nvarchar](500) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ContentName] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Body] [nvarchar](max) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Locale] [nvarchar](7) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL CONSTRAINT [DF_Content_Locale]  DEFAULT (N'en-US'),
	[CreatedOn] [datetime] NULL CONSTRAINT [DF_Content_CreatedOn]  DEFAULT (getdate()),
	[CreatedBy] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[ModifiedOn] [datetime] NULL CONSTRAINT [DF_Content_ModifiedOn]  DEFAULT (getdate()),
	[ModifiedBy] [nvarchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
 CONSTRAINT [PK_Content] PRIMARY KEY CLUSTERED 
(
	[ContentID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END



