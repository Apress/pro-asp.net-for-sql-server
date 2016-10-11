
EXEC sp_configure 'show advanced options', '1'
go
RECONFIGURE
go
EXEC sp_configure 'clr enabled', 1
go
RECONFIGURE

GRANT SUBSCRIBE QUERY NOTIFICATIONS TO [VIRTUAL2\brennan]
GRANT SEND ON SERVICE::SqlQueryNotificationService TO [VIRTUAL2\brennan]
EXEC sp_helprotect NULL, [brennan]
EXEC sp_helprotect NULL, [VIRTUAL2\brennan]



GRANT SUBSCRIBE QUERY NOTIFICATIONS TO [brennan]
GRANT SEND ON SERVICE::SqlQueryNotificationService TO [brennan]
GRANT RECEIVE on SqlQueryNotificationService_DefaultQueue to [brennan]

GRANT SUBSCRIBE QUERY NOTIFICATIONS TO guest

GRANT SEND ON SERVICE::SqlQueryNotificationService TO [brennan]
GRANT SEND ON SERVICE::SqlQueryNotificationService TO guest

CREATE QUEUE SqlQueryNotificationService
DROP QUEUE SqlQueryNotificationService

CREATE QUEUE ServiceBrokerQueue
DROP QUEUE SqlQueryNotificationService

CREATE SERVICE SqlQueryNotificationService
ON QUEUE ServiceBrokerQueue

REVOKE SUBSCRIBE QUERY NOTIFICATIONS TO [brennan]
REVOKE SEND ON SERVICE::SqlQueryNotificationService TO [brennan]

--

SELECT name,is_broker_enabled FROM sys.databases
select databasepropertyex('AdventureWorks', 'IsBrokerEnabled')
select databasepropertyex('AdventureWorks', 'IsClrEnabled')

ALTER DATABASE AdventureWorks SET ENABLE_BROKER


--
EXEC sp_addrole 'sql_dependency_subscriber'

GRANT SELECT to [brennan]
GRANT SUBSCRIBE QUERY NOTIFICATIONS TO [brennan]
GRANT RECEIVE ON QueryNotificationErrorsQueue TO [brennan]
GRANT REFERENCES on CONTRACT:: [http://schemas.microsoft.com/SQL/Notifications/PostQueryNotification] to [brennan]
EXEC sp_addrolemember 'sql_dependency_subscriber', 'brennan' 

--


GRANT CREATE PROCEDURE TO [brennan];
GRANT CREATE SERVICE TO [brennan];
GRANT CREATE QUEUE TO [brennan];
GRANT REFERENCES ON CONTRACT::[http://schemas.microsoft.com/SQL/Notifications/PostQueryNotification] TO [brennan];
GRANT SUBSCRIBE QUERY NOTIFICATIONS TO [brennan];
GRANT CONTROL ON SCHEMA::[dbo] TO [brennan];

GRANT IMPERSONATE ON USER::DBO TO [VIRTUAL2\brennan];

GRANT IMPERSONATE ON USER::DBO TO [brennan];

EXEC sp_helprotect NULL, ASPNET
