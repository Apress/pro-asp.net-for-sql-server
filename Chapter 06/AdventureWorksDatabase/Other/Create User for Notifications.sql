
GRANT CREATE PROCEDURE to [VIRTUAL2\brennan]
GRANT CREATE QUEUE to [VIRTUAL2\brennan]
GRANT CREATE SERVICE to [VIRTUAL2\brennan]
GRANT REFERENCES on CONTRACT::[http://schemas.microsoft.com/SQL/Notifications/PostQueryNotification] to [VIRTUAL2\brennan]  --note that the schema is case sensitive!
GRANT VIEW DEFINITION to [VIRTUAL2\brennan]

EXEC sp_addrole 'sql_dependency_subscriber'
GRANT SUBSCRIBE QUERY NOTIFICATIONS TO [VIRTUAL2\brennan]
GRANT RECEIVE ON QueryNotificationErrorsQueue TO [VIRTUAL2\brennan]
GRANT REFERENCES on CONTRACT::[http://schemas.microsoft.com/SQL/Notifications/PostQueryNotification] to [VIRTUAL2\brennan]
EXEC sp_addrolemember 'sql_dependency_subscriber', 'brennan'
GRANT SELECT TO [VIRTUAL2\brennan]

-- look at the permissions
EXEC sp_helprotect NULL, [brennan]

GRANT CREATE PROCEDURE to [brennan]
GRANT CREATE QUEUE to [brennan]
GRANT CREATE SERVICE to [brennan]
GRANT REFERENCES on CONTRACT::[http://schemas.microsoft.com/SQL/Notifications/PostQueryNotification] to [brennan]  --note that the schema is case sensitive!
GRANT VIEW DEFINITION to [brennan]

EXEC sp_addrole 'sql_dependency_subscriber'
GRANT SUBSCRIBE QUERY NOTIFICATIONS TO [brennan]
GRANT RECEIVE ON QueryNotificationErrorsQueue TO [brennan]
GRANT REFERENCES on CONTRACT::[http://schemas.microsoft.com/SQL/Notifications/PostQueryNotification] to [brennan]
CONTRACT::[http://schemas.microsoft.com/SQL/Notifications/PostQueryNotification] to [dev]
EXEC sp_addrolemember 'sql_dependency_subscriber', 'brennan'
GRANT SELECT TO [brennan]

-- look at the permissions
EXEC sp_helprotect NULL, [brennan]


GRANT CREATE PROCEDURE to [dev]
GRANT CREATE QUEUE to [dev]
GRANT CREATE SERVICE to [dev]
GRANT REFERENCES on CONTRACT::[http://schemas.microsoft.com/SQL/Notifications/PostQueryNotification] to [brennan]  --note that the schema is case sensitive!
GRANT VIEW DEFINITION to [dev]

EXEC sp_addrole 'sql_dependency_subscriber'
GRANT SUBSCRIBE QUERY NOTIFICATIONS TO [dev]
GRANT RECEIVE ON QueryNotificationErrorsQueue TO [dev]
GRANT REFERENCES on CONTRACT::[http://schemas.microsoft.com/SQL/Notifications/PostQueryNotification] to [dev]
EXEC sp_addrolemember 'sql_dependency_subscriber', 'dev'
GRANT SELECT TO [dev]
