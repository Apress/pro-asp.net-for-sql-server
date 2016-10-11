IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt05_SetListPriceByID')
	BEGIN
		DROP  Procedure  chpt05_SetListPriceByID
	END

GO

CREATE Procedure dbo.chpt05_SetListPriceByID
(
	@ListPrice money,
	@ProductID int
)
AS

UPDATE Production.Product SET ListPrice = @ListPrice WHERE ProductID = @ProductID

--UPDATE dbo.SimpleProduct SET ListPrice = @ListPrice WHERE ProductID = @ProductID

GO

GRANT EXEC ON chpt05_SetListPriceByID TO PUBLIC
GO