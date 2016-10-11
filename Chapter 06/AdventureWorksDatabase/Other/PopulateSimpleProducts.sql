--
-- Get data from AdventureWorks
--

-- Clear the existing data 
DELETE FROM dbo.SimpleProduct

-- Manual Step:
-- turn off primary key and identity for SimpleProduct

INSERT INTO dbo.SimpleProduct (
	ProductID,[Name],ProductNumber, Color, ListPrice,
	SellStartDate, SellEndDate, DiscontinuedDate
)
SELECT TOP 5
	ProductID, [Name], ProductNumber, Color, ListPrice, 
	SellStartDate, SellEndDate, DiscontinuedDate
FROM AdventureWorks.Production.Product

-- Manual Step:
-- turn on primary key and identity for SimpleProduct
