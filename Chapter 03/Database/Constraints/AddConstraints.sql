
ALTER TABLE [dbo].[chpt03_Person]  WITH CHECK ADD  
CONSTRAINT [FK_chpt03_Person_chpt03_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[chpt03_Location] ([LocationId])
 