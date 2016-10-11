IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt03_GetPeopleRowCount')
	BEGIN
		DROP  Procedure  chpt03_GetPeopleRowCount
	END

GO

CREATE Procedure dbo.chpt03_GetPeopleRowCount
(
	@Count [bigint] OUTPUT
)
AS

SET @Count = (SELECT COUNT(*) AS [Count] FROM chpt03_Person)

GO

GRANT EXEC ON chpt03_GetPeopleRowCount TO PUBLIC
GO
