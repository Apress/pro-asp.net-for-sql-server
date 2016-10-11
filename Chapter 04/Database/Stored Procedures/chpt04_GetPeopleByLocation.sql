IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt04_GetPeopleByLocation')
	BEGIN
		DROP  Procedure  chpt04_GetPeopleByLocation
	END

GO

CREATE Procedure dbo.chpt04_GetPeopleByLocation
(
	@LocationId bigint
)
AS

SELECT p.PersonId,p.FirstName,p.LastName,p.BirthDate,l.City,l.Country 
FROM chpt04_Person AS p
JOIN chpt04_Location AS l on l.LocationId = p.LocationId
WHERE l.LocationId = @LocationId
ORDER BY p.LastName,p.FirstName

GO

GRANT EXEC ON chpt04_GetPeopleByLocation TO PUBLIC
GO
