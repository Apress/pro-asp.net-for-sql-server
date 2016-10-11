IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' 
  AND name = 'chpt02_GetAllPeople')
  BEGIN
    DROP  Procedure  chpt02_GetAllPeople
  END

GO

CREATE Procedure dbo.chpt02_GetAllPeople
AS

SELECT p.PersonId,p.FirstName,p.LastName,p.BirthDate,l.City,l.Country 
FROM chpt02_Person AS p
JOIN chpt02_Location AS l on l.LocationId = p.LocationId

GO

GRANT EXEC ON chpt02_GetAllPeople TO PUBLIC
GO
