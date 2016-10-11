EXEC chpt03_ClearData

DECLARE @LocationId bigint
EXEC chpt03_SaveLocation 'Milwaukee', 'USA', @LocationId OUTPUT
EXEC chpt03_SaveLocation 'Toronto', 'Canada', @LocationId OUTPUT
EXEC chpt03_SaveLocation 'Los Angeles', 'USA', @LocationId OUTPUT
EXEC chpt03_SaveLocation 'New York', 'USA', @LocationId OUTPUT
EXEC chpt03_SaveLocation 'Paris', 'France', @LocationId OUTPUT
EXEC chpt03_SaveLocation 'Moscow', 'Russia', @LocationId OUTPUT

DECLARE @MinId bigint
DECLARE @MaxId bigint
EXEC chpt03_GetLocationRanges @MinId OUTPUT, @MaxId OUTPUT
PRINT 'MinId is ' + CONVERT(varchar(100), @MinId)
PRINT 'Max is ' + CONVERT(varchar(100), @MaxId)
