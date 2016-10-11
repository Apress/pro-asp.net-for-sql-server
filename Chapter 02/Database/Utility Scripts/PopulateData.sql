EXEC chpt02_ClearData

DECLARE @LocationId bigint
EXEC chpt02_SaveLocation 'Milwaukee', 'USA', @LocationId OUTPUT
EXEC chpt02_SaveLocation 'Toronto', 'Canada', @LocationId OUTPUT
EXEC chpt02_SaveLocation 'Los Angeles', 'USA', @LocationId OUTPUT
EXEC chpt02_SaveLocation 'New York', 'USA', @LocationId OUTPUT
EXEC chpt02_SaveLocation 'Paris', 'France', @LocationId OUTPUT
EXEC chpt02_SaveLocation 'Moscow', 'Russia', @LocationId OUTPUT

DECLARE @MinId bigint
DECLARE @MaxId bigint
EXEC chpt02_GetLocationRanges @MinId OUTPUT, @MaxId OUTPUT
PRINT 'MinId is ' + CONVERT(varchar(100), @MinId)
PRINT 'Max is ' + CONVERT(varchar(100), @MaxId)
