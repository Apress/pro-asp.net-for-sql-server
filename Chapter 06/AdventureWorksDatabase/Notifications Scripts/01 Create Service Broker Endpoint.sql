 
CREATE MASTER KEY ENCRYPTION BY password = 'abc123';
GO

use Master; 
GO

CREATE CERTIFICATE [VIRTUAL1] 
	with subject = N'VIRTUAL1'; 
GO 

CREATE ENDPOINT [ServiceBroker]
	state = started as tcp (listener_port = 4022) for service_broker 
	(authentication = certificate [VIRTUAL1]); 
GO
