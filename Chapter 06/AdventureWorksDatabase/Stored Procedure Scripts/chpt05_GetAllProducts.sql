IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt05_GetAllProducts')
	BEGIN
		DROP  Procedure  chpt05_GetAllProducts
	END

GO

CREATE Procedure dbo.chpt05_GetAllProducts

AS

SELECT 
	ProductID, [Name], ProductNumber, Color, ListPrice, 
	SellStartDate, SellEndDate, DiscontinuedDate
FROM Production.Product

GO

GRANT EXEC ON chpt05_GetAllProducts TO PUBLIC

GO
