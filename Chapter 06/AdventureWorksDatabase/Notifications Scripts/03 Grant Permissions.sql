-- user needs to be a members of the db_owner role!
-- the SqlDepdendency.Start method handles creating the services and queues to make the messaging work


-- Where "X" is the user or group account:

GRANT CREATE PROCEDURE to [apress]
GRANT CREATE QUEUE to [apress]
GRANT CREATE SERVICE to [apress]

GRANT REFERENCES on
CONTRACT::[http://schemas.microsoft.com/SQL/Notifications/PostQueryNotification] to [apress]
--(note that the schema is case sensitive)

CREATE SERVICE SqlQueryNotificationService ON QUEUE ServiceBrokerQueue

GRANT VIEW DEFINITION to [apress]

-- To grant permissions to do query notification

EXEC sp_addrole 'sql_dependency_subscriber'

GRANT SUBSCRIBE QUERY NOTIFICATIONS TO [apress]

GRANT REFERENCES on
CONTRACT::[http://schemas.microsoft.com/SQL/Notifications/PostQueryNotification] to [apress]

EXEC sp_addrolemember 'sql_dependency_subscriber', 'apress'

GRANT SELECT TO [apress]

GRANT SUBSCRIBE QUERY NOTIFICATIONS TO [apress]
GRANT SEND ON SERVICE::SqlQueryNotificationService TO [apress]
GRANT RECEIVE ON QueryNotificationErrorsQueue TO [apress]
