IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt07_GetNullables')
	BEGIN
		DROP  Procedure  chpt07_GetNullables
	END

GO

CREATE Procedure dbo.chpt07_GetNullables
AS

SELECT * FROM chpt07_Nullable

--EXEC doesnotexist

GO

GRANT EXEC ON chpt07_GetNullables TO PUBLIC
GO
