IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt04_GetCitiesByCountry')
	BEGIN
		DROP  Procedure  chpt04_GetCitiesByCountry
	END

GO

CREATE Procedure dbo.chpt04_GetCitiesByCountry
(
	@Country varchar(50)
)
AS

SELECT DISTINCT City
FROM chpt04_Location
WHERE Country = @Country
ORDER BY City

GO

GRANT EXEC ON chpt04_GetCitiesByCountry TO PUBLIC
GO
