IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt02_GetLocationRanges')
	BEGIN
		DROP  Procedure  chpt02_GetLocationRanges
	END

GO

CREATE Procedure dbo.chpt02_GetLocationRanges
(
	@MinId int OUTPUT,
	@MaxId int OUTPUT
)
AS

SET @MinId = (SELECT min(LocationId) FROM chpt02_Location)
SET @MaxId = (SELECT max(LocationId) FROM chpt02_Location)

GO

GRANT EXEC ON chpt02_GetLocationRanges TO PUBLIC
GO
