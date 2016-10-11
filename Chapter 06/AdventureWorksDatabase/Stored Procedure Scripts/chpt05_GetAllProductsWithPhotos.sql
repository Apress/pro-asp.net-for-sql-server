IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt05_GetAllProductsWithPhotos')
	BEGIN
		DROP  Procedure  chpt05_GetAllProductsWithPhotos
	END

GO

CREATE Procedure dbo.chpt05_GetAllProductsWithPhotos

AS

SELECT
	p.ProductID, p.[Name], p.ProductNumber, p.Color, p.ListPrice, 
	p.SellStartDate, p.SellEndDate, p.DiscontinuedDate
FROM Production.Product AS p
JOIN Production.ProductProductPhoto AS ppp ON ppp.ProductID = p.ProductID
WHERE ppp.ProductPhotoID != 1

GO

GRANT EXEC ON chpt05_GetAllProductsWithPhotos TO PUBLIC

GO
