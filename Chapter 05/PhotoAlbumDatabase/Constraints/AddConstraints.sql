IF EXISTS (select * from dbo.sysobjects where id = 
  object_id(N'[dbo].[FK_pap_Photos_pap_Albums]') and 
  OBJECTPROPERTY(id, N'IsForeignKey') = 1)
ALTER TABLE [dbo].[pap_Photos] DROP CONSTRAINT FK_pap_Photos_pap_Albums
GO

ALTER TABLE [dbo].[pap_Photos]  WITH CHECK ADD  
  CONSTRAINT [FK_pap_Photos_pap_Albums] FOREIGN KEY([AlbumID])
REFERENCES [dbo].[pap_Albums] ([id])
GO
