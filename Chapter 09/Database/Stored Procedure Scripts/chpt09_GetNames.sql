IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt09_GetNames')
	BEGIN
		DROP  Procedure  chpt09_GetNames
	END

GO

CREATE Procedure dbo.chpt09_GetNames
AS

SELECT * FROM chpt09_Names

GO

GRANT EXEC ON chpt09_GetNames TO PUBLIC
GO
