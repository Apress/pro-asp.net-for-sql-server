IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt04_GetAllPeopleRowCount')
	BEGIN
		DROP  Procedure  chpt04_GetAllPeopleRowCount
	END

GO

CREATE Procedure dbo.chpt04_GetAllPeopleRowCount
(
	@Count int OUTPUT
)
AS

SET @Count = (SELECT COUNT(*) AS [Count] FROM chpt04_Person)

GO

GRANT EXEC ON chpt04_GetAllPeopleRowCount TO PUBLIC
GO
