IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt03_GetPeopleByLocation')
	BEGIN
		DROP  Procedure  chpt03_GetPeopleByLocation
	END

GO

CREATE Procedure dbo.chpt03_GetPeopleByLocation
(
	@LocationId bigint
)
AS

SELECT p.PersonId,p.FirstName,p.LastName,p.BirthDate,l.City,l.Country 
FROM chpt03_Person AS p
JOIN chpt03_Location AS l on l.LocationId = p.LocationId
WHERE l.LocationId = @LocationId
ORDER BY p.LastName,p.FirstName

GO

GRANT EXEC ON chpt03_GetPeopleByLocation TO PUBLIC
GO
