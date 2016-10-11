
SELECT * FROM Production.ProductCategory

SELECT * FROM Production.ProductSubcategory
WHERE ProductCategoryID = 2

SELECT * FROM Production.Product
WHERE ProductSubcategoryID = 4

-- categories with products with photos
SELECT DISTINCT pc.ProductCategoryID, pc.Name, count(p.ProductID) 
FROM Production.ProductCategory AS pc
JOIN Production.ProductSubcategory AS ps ON ps.ProductCategoryID = pc.ProductCategoryID
JOIN Production.Product AS p ON p.ProductSubcategoryID = ps.ProductSubcategoryID
JOIN Production.ProductProductPhoto AS ppp ON ppp.ProductID = p.ProductID
WHERE ppp.ProductPhotoID != 1
GROUP BY pc.ProductCategoryID, pc.Name
HAVING count(p.ProductID) > 0
ORDER BY pc.ProductCategoryID

-- subcategories with products with photos
SELECT DISTINCT ps.ProductSubcategoryID, ps.Name, count(p.ProductID) 
FROM Production.ProductSubcategory AS ps
JOIN Production.Product AS p ON p.ProductSubcategoryID = ps.ProductSubcategoryID
JOIN Production.ProductProductPhoto AS ppp ON ppp.ProductID = p.ProductID
WHERE ppp.ProductPhotoID != 1
GROUP BY ps.ProductSubcategoryID, ps.Name
HAVING count(p.ProductID) > 0
ORDER BY ps.ProductSubcategoryID

-- products in subcategory with photos
SELECT p.Name, p.ProductNumber, p.Color, p.ListPrice, 
	p.SellStartDate, p.SellEndDate, p.DiscontinuedDate, 
	pm.Name AS [ModelName], pm.Instructions
FROM Production.Product AS p
JOIN Production.ProductSubcategory AS ps ON ps.ProductSubcategoryID = p.ProductSubcategoryID
JOIN Production.ProductProductPhoto AS ppp ON ppp.ProductID = p.ProductID
JOIN Production.ProductModel AS pm ON pm.ProductModelID = p.ProductModelID
WHERE ppp.ProductPhotoID != 1
ORDER BY p.ProductNumber

SELECT count(*) FROM Production.ProductInventory
WHERE ProductID = 808

SELECT 
	p.ProductID, p.[Name], p.ProductNumber, p.Color, p.ListPrice, 
	p.SellStartDate, p.SellEndDate, p.DiscontinuedDate,
	CASE pi.Quantity 
		WHEN 0 THEN 'Out Of Stock' 
		ELSE 'In Stock'
	END AS [Availability]
FROM Production.Product AS p
JOIN (
	SELECT ProductID, sum(Quantity) AS [Quantity]
	FROM Production.ProductInventory
	WHERE ProductID = 808 
	GROUP BY ProductID
) AS pi ON pi.ProductID = p.ProductID
WHERE p.ProductID = 808

UPDATE Production.Product SET ProductNumber = 'HB-M243', ListPrice = 45.54
WHERE ProductID = 808

SELECT * FROM AspNet_SqlCacheTablesForChangeNotification

SELECT ProductNumber,ListPrice FROM Production.Product WHERE ProductID = 808
