
ALTER TABLE [dbo].[chpt04_Person]  WITH CHECK ADD  CONSTRAINT [FK_chpt04_Person_chpt04_Location] FOREIGN KEY([LocationId])
REFERENCES [dbo].[chpt04_Location] ([LocationId])
 