
IF EXISTS (SELECT * FROM dbo.sysobjects 
WHERE id = object_id(N'[dbo].[FK_chpt02_Person_chpt02_Location]') 
and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[chpt02_Person] 
DROP CONSTRAINT FK_chpt02_Person_chpt02_Location
 