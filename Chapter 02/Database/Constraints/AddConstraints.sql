
ALTER TABLE [dbo].[chpt02_Person]  WITH CHECK ADD  
CONSTRAINT [FK_chpt02_Person_chpt02_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[chpt02_Location] ([LocationId])
 