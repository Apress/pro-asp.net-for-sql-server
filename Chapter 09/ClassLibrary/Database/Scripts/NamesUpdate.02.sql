-- update 2 (add Shemp to names table)

EXEC chpt09_SaveName 'Shemp'

GO

-- be sure to update the names schema version
EXEC chpt09_SetSchemaVersion 'names', 3

GO
