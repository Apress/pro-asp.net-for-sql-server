IF EXISTS (SELECT * FROM sysobjects WHERE type = 'TR' AND name = 'Product_AspNet_SqlCacheNotification_Trigger')
	BEGIN
		DROP  Trigger Production.Product_AspNet_SqlCacheNotification_Trigger
	END
GO

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
CREATE TRIGGER Production.[Product_AspNet_SqlCacheNotification_Trigger] 
	ON Production.[Product]
	FOR INSERT, UPDATE, DELETE AS BEGIN
	SET NOCOUNT ON
	EXEC dbo.AspNet_SqlCacheUpdateChangeIdStoredProcedure N'Product'
END

GO

