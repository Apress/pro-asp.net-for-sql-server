EXEC chpt04_ClearData

DECLARE @LocationId bigint
EXEC chpt04_SaveLocation 'Milwaukee', 'USA', @LocationId OUTPUT
EXEC chpt04_SaveLocation 'Toronto', 'Canada', @LocationId OUTPUT
EXEC chpt04_SaveLocation 'Los Angeles', 'USA', @LocationId OUTPUT
EXEC chpt04_SaveLocation 'New York', 'USA', @LocationId OUTPUT
EXEC chpt04_SaveLocation 'Paris', 'France', @LocationId OUTPUT
EXEC chpt04_SaveLocation 'Moscow', 'Russia', @LocationId OUTPUT

DECLARE @MinId bigint
DECLARE @MaxId bigint
EXEC chpt04_GetLocationRanges @MinId OUTPUT, @MaxId OUTPUT
PRINT 'MinId is ' + CONVERT(varchar(100), @MinId)
PRINT 'Max is ' + CONVERT(varchar(100), @MaxId)
