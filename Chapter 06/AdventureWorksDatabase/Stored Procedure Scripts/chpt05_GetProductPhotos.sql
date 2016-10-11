IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt05_GetProductPhotos')
	BEGIN
		DROP  Procedure  chpt05_GetProductPhotos
	END

GO

CREATE Procedure dbo.chpt05_GetProductPhotos
(
	@ProductID int
)
AS

SELECT * 
FROM Production.ProductPhoto AS pp
JOIN Production.ProductProductPhoto AS ppp ON ppp.ProductPhotoID = pp.ProductPhotoID
WHERE ppp.ProductID = @ProductID

GO

GRANT EXEC ON chpt05_GetProductPhotos TO PUBLIC
GO

