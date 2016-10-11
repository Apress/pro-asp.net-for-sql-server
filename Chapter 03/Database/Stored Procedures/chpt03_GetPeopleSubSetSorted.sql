-- sources:
-- http://weblogs.asp.net/scottgu/archive/2006/01/01/434314.aspx
-- http://aspnet.4guysFROMrolla.com/articles/032206-1.aspx

IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND 
  name = 'chpt03_GetPeopleSubSetSorted')
  BEGIN
    DROP  Procedure  chpt03_GetPeopleSubSetSorted
  END

GO

CREATE Procedure dbo.chpt03_GetPeopleSubSetSorted
(
  @sortExpression  nvarchar(50),
  @startRowIndex  int,
  @maximumRows  int
)
AS

IF LEN(@sortExpression) = 0
  SET @sortExpression = 'PersonId'

-- reset to 1 based index
SET @startRowIndex = @startRowIndex + 1

-- build sql
DECLARE @sql nvarchar(4000)
SET @sql = 'SELECT PersonId,FirstName,LastName,BirthDate,City,Country
FROM
  (SELECT p.PersonId,p.FirstName,p.LastName,p.BirthDate,l.City,l.Country,
    ROW_NUMBER() over(ORDER BY ' + @sortExpression + ') AS RowNum
    FROM chpt03_Person AS p
    JOIN chpt03_Location AS l on l.LocationId = p.LocationId
  ) AS People
WHERE RowNum between ' + CONVERT(nvarchar(10), @startRowIndex) + 
        ' and (' + CONVERT(nvarchar(10), @startRowIndex) + ' + ' 
        + CONVERT(nvarchar(10), @maximumRows) + ') - 1'

-- Execute the SQL query
EXEC sp_executesql @sql

GO

GRANT EXEC ON chpt03_GetPeopleSubSetSorted TO PUBLIC
GO
