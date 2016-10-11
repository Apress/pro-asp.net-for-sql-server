IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt05_GetProductByID')
	BEGIN
		DROP  Procedure  chpt05_GetProductByID
	END

GO

CREATE Procedure dbo.chpt05_GetProductByID
(
	@ProductID int
)
AS

SELECT 
	ProductID, [Name], ProductNumber, Color, ListPrice,
	SellStartDate, SellEndDate, DiscontinuedDate
FROM Production.Product
WHERE ProductID = @ProductID

--SELECT 
--	p.ProductID, p.[Name], p.ProductNumber, p.Color, p.ListPrice, 
--	p.SellStartDate, p.SellEndDate, p.DiscontinuedDate,
--	CASE pi.Quantity 
--		WHEN 0 THEN 'Out Of Stock' 
--		ELSE 'In Stock'
--	END AS [Availability]
--FROM Production.Product AS p
--JOIN (
--	SELECT ProductID, sum(Quantity) AS [Quantity]
--	FROM Production.ProductInventory
--	WHERE ProductID = @ProductID 
--	GROUP BY ProductID
--) AS pi ON pi.ProductID = p.ProductID
--WHERE p.ProductID = @ProductID

GO

GRANT EXEC ON chpt05_GetProductByID TO PUBLIC
GO
