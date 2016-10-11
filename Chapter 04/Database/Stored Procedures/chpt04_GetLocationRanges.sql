IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt04_GetLocationRanges')
	BEGIN
		DROP  Procedure  chpt04_GetLocationRanges
	END

GO

CREATE Procedure dbo.chpt04_GetLocationRanges
(
	@MinId int OUTPUT,
	@MaxId int OUTPUT
)
AS

SET @MinId = (SELECT min(LocationId) FROM chpt04_Location)
SET @MaxId = (SELECT max(LocationId) FROM chpt04_Location)

GO

GRANT EXEC ON chpt04_GetLocationRanges TO PUBLIC
GO
