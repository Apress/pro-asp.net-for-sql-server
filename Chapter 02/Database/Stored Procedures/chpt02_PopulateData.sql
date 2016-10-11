IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'chpt02_PopulateData')
	BEGIN
		DROP  Procedure  chpt02_PopulateData
	END

GO

CREATE Procedure dbo.chpt02_PopulateData
AS

	--EXEC chpt02_ClearData

	DECLARE @LocationId bigint
	EXEC chpt02_SaveLocation 'Milwaukee', 'USA', @LocationId OUTPUT
	EXEC chpt02_SaveLocation 'Toronto', 'Canada', @LocationId OUTPUT
	EXEC chpt02_SaveLocation 'Los Angeles', 'USA', @LocationId OUTPUT
	EXEC chpt02_SaveLocation 'New York', 'USA', @LocationId OUTPUT
	EXEC chpt02_SaveLocation 'Paris', 'France', @LocationId OUTPUT
	EXEC chpt02_SaveLocation 'Moscow', 'Russia', @LocationId OUTPUT
	EXEC chpt02_SaveLocation 'Berlin', 'Germany', @LocationId OUTPUT
	EXEC chpt02_SaveLocation 'London', 'England', @LocationId OUTPUT
	EXEC chpt02_SaveLocation 'Stockholm', 'Sweden', @LocationId OUTPUT
	EXEC chpt02_SaveLocation 'Madrid', 'Spain', @LocationId OUTPUT

	DECLARE @MinId bigint
	DECLARE @MaxId bigint
	EXEC chpt02_GetLocationRanges @MinId OUTPUT, @MaxId OUTPUT
	PRINT 'MinId is ' + CONVERT(varchar(100), @MinId)
	PRINT 'Max is ' + CONVERT(varchar(100), @MaxId)


GO

GRANT EXEC ON chpt02_PopulateData TO PUBLIC
GO
