IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt04_GetLastNames')
	BEGIN
		DROP  Procedure  chpt04_GetLastNames
	END

GO

CREATE Procedure dbo.chpt04_GetLastNames
AS

SELECT DISTINCT LastName
FROM chpt04_Person
ORDER BY LastName

GO

GRANT EXEC ON chpt04_GetLastNames TO PUBLIC
GO
