IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt03_GetLocationRanges')
	BEGIN
		DROP  Procedure  chpt03_GetLocationRanges
	END

GO

CREATE Procedure dbo.chpt03_GetLocationRanges
(
	@MinId int OUTPUT,
	@MaxId int OUTPUT
)
AS

SET @MinId = (SELECT min(LocationId) FROM chpt03_Location)
SET @MaxId = (SELECT max(LocationId) FROM chpt03_Location)

GO

GRANT EXEC ON chpt03_GetLocationRanges TO PUBLIC
GO
