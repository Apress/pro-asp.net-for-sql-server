IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt03_PopulateData')
	BEGIN
		DROP  Procedure  chpt03_PopulateData
	END

GO

CREATE Procedure dbo.chpt03_PopulateData
AS

	--EXEC chpt03_ClearData

	DECLARE @LocationId bigint
	EXEC chpt03_SaveLocation 'Milwaukee', 'USA', @LocationId OUTPUT
	EXEC chpt03_SaveLocation 'Toronto', 'Canada', @LocationId OUTPUT
	EXEC chpt03_SaveLocation 'Los Angeles', 'USA', @LocationId OUTPUT
	EXEC chpt03_SaveLocation 'New York', 'USA', @LocationId OUTPUT
	EXEC chpt03_SaveLocation 'Paris', 'France', @LocationId OUTPUT
	EXEC chpt03_SaveLocation 'Moscow', 'Russia', @LocationId OUTPUT
	EXEC chpt03_SaveLocation 'Berlin', 'Germany', @LocationId OUTPUT
	EXEC chpt03_SaveLocation 'London', 'England', @LocationId OUTPUT
	EXEC chpt03_SaveLocation 'Stockholm', 'Sweden', @LocationId OUTPUT
	EXEC chpt03_SaveLocation 'Madrid', 'Spain', @LocationId OUTPUT

	DECLARE @MinId bigint
	DECLARE @MaxId bigint
	EXEC chpt03_GetLocationRanges @MinId OUTPUT, @MaxId OUTPUT
	PRINT 'MinId is ' + CONVERT(varchar(100), @MinId)
	PRINT 'Max is ' + CONVERT(varchar(100), @MaxId)


GO

GRANT EXEC ON chpt03_PopulateData TO PUBLIC
GO
