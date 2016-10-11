IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'SimpleProduct')
	BEGIN
		DROP  Table SimpleProduct
	END
GO

CREATE TABLE dbo.SimpleProduct
(
	[ProductID] [int] NOT NULL,
	[Name] [nvarchar](50) COLLATE Latin1_General_CS_AS NOT NULL,
	[ProductNumber] [nvarchar](25) COLLATE Latin1_General_CS_AS NOT NULL,
	[Color] [nvarchar](15) COLLATE Latin1_General_CS_AS NULL,
	[ListPrice] [money] NOT NULL,
	[SellStartDate] [datetime] NOT NULL,
	[SellEndDate] [datetime] NULL,
	[DiscontinuedDate] [datetime] NULL
) ON [PRIMARY]
GO

GRANT SELECT ON SimpleProduct TO PUBLIC
GO
