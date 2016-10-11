IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt04_GetPeopleByLastName')
	BEGIN
		DROP  Procedure  chpt04_GetPeopleByLastName
	END

GO

CREATE Procedure dbo.chpt04_GetPeopleByLastName
(
	@LastName varchar(50)
)
AS

SELECT p.PersonId,p.FirstName,p.LastName,p.BirthDate,l.City,l.Country 
FROM chpt04_Person AS p
JOIN chpt04_Location AS l ON l.LocationId = p.LocationId
WHERE p.LastName = @LastName

GO

GRANT EXEC ON chpt04_GetPeopleByLastName TO PUBLIC
GO
