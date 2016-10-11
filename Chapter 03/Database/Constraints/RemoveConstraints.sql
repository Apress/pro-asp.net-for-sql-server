
IF EXISTS (SELECT * FROM dbo.sysobjects 
WHERE id = object_id(N'[dbo].[FK_chpt03_Person_chpt03_Location]') 
and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[chpt03_Person] 
DROP CONSTRAINT FK_chpt03_Person_chpt03_Location
 