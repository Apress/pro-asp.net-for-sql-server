IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt03_GetAllPeople')
	BEGIN
		DROP  Procedure  chpt03_GetAllPeople
	END

GO

CREATE Procedure dbo.chpt03_GetAllPeople
AS

SELECT p.PersonId,p.FirstName,p.LastName,p.BirthDate,l.City,l.Country 
FROM chpt03_Person AS p
JOIN chpt03_Location AS l on l.LocationId = p.LocationId

GO

GRANT EXEC ON chpt03_GetAllPeople TO PUBLIC
GO
