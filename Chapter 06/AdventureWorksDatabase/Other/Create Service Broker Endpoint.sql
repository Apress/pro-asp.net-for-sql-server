
create master key encryption by password = 'abc123';

use Master; 
go 

create certificate [WINDOWS2003] 
	with subject = N'WINDOWS2003'; 
go 

create endpoint [ServiceBroker]
	state = started as tcp (listener_port = 4022) for service_broker 
	(authentication = certificate [WINDOWS2003]); 
go

ALTER DATABASE AdventureWorks SET ENABLE_BROKER
