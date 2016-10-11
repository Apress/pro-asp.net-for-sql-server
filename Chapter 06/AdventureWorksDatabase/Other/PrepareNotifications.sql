-- Where "X" is the user or group account:

GRANT CREATE PROCEDURE to [dev]
GRANT CREATE QUEUE to [dev]
GRANT CREATE SERVICE to [dev]

GRANT REFERENCES on
CONTRACT::[http://schemas.microsoft.com/SQL/Notifications/PostQueryNotification] to [dev]
--(note that the schema is case sensitive)

GRANT VIEW DEFINITION to [dev]

-- To grant permissions to do query notification

EXEC sp_addrole 'sql_dependency_subscriber'

GRANT SUBSCRIBE QUERY NOTIFICATIONS TO [dev]

GRANT RECEIVE ON QueryNotificationErrorsQueue TO [dev]

GRANT REFERENCES on
CONTRACT::[http://schemas.microsoft.com/SQL/Notifications/PostQueryNotification] to [dev]

EXEC sp_addrolemember 'sql_dependency_subscriber', 'dev'

GRANT SELECT TO [dev]

-- look at the permissions
EXEC sp_helprotect NULL, [dev]

select name,is_receive_enabled from sys.service_queues
select * from sys.service_queues

ALTER DATABASE AdventureWorks SET ENABLE_BROKER
WITH ROLLBACK IMMEDIATE

SELECT name,is_broker_enabled FROM sys.databases
select databasepropertyex('AdventureWorks', 'IsBrokerEnabled')
