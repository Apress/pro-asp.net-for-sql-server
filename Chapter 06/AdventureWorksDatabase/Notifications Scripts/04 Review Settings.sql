
 -- look at the permissions
EXEC sp_helprotect NULL, [apress]

select name,is_receive_enabled from sys.service_queues

SELECT name,is_broker_enabled FROM sys.databases

