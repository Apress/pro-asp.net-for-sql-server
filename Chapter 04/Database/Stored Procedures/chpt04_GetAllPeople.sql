IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt04_GetAllPeople')
	BEGIN
		DROP  Procedure  chpt04_GetAllPeople
	END

GO

CREATE Procedure dbo.chpt04_GetAllPeople
AS

SELECT p.PersonId,p.FirstName,p.LastName,p.BirthDate,l.City,l.Country 
FROM chpt04_Person AS p
JOIN chpt04_Location AS l on l.LocationId = p.LocationId

GO

GRANT EXEC ON chpt04_GetAllPeople TO PUBLIC
GO
