IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt04_GetAllCountries')
	BEGIN
		DROP  Procedure  chpt04_GetAllCountries
	END

GO

CREATE Procedure dbo.chpt04_GetAllCountries
AS

SELECT DISTINCT Country
FROM chpt04_Location
ORDER BY Country

GO

GRANT EXEC ON chpt04_GetAllCountries TO PUBLIC
GO
