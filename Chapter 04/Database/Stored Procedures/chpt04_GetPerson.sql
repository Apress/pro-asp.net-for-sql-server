IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt04_GetPerson')
	BEGIN
		DROP  Procedure  chpt04_GetPerson
	END

GO

CREATE Procedure dbo.chpt04_GetPerson
(
	@PersonId bigint
)
AS

SELECT p.PersonId,p.FirstName,p.LastName,p.BirthDate,l.City,l.Country 
FROM chpt04_Person AS p
JOIN chpt04_Location AS l on l.LocationId = p.LocationId
where p.PersonId = @PersonId

GO

GRANT EXEC ON chpt04_GetPerson TO PUBLIC
GO
