-- update 1 (add stooges to names table)

EXEC chpt09_SaveName 'Larry'
GO

EXEC chpt09_SaveName 'Moe'
GO

EXEC chpt09_SaveName 'Curly'
GO

-- be sure to update the names schema version
EXEC chpt09_SetSchemaVersion 'names', 2
GO
