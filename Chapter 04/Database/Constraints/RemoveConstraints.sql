
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = object_id(N'[dbo].[FK_chpt04_Person_chpt04_Location]') and OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[chpt04_Person] DROP CONSTRAINT FK_chpt04_Person_chpt04_Location
 